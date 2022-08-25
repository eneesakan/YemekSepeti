using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YemekSepeti
{
    public partial class FormRestaurantSiparisler : Form
    {
        int RestaurantId;
        int SiparisId=-1;
        private readonly static string connectionString = "Data Source=localhost;Database=YemekSepeti;Integrated Security=True;";
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        public FormRestaurantSiparisler(int _RestaurantId)
        {
            RestaurantId = _RestaurantId;
            InitializeComponent();
        }
        private void ListeYukle()
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = @"Select
                s.Id as SiparisId,
	            m.YemekAdi,
	            restaurant.RestaurantAd,
	            s.Durumu,
	            s.SiparisTarihi
            From Siparis s
            inner join Menu m on s.MenuId = m.Id
            outer apply(select* from Kullanici k where k.Id= s.MusteriId) musteri
            outer apply(select * from Restaurant k where k.RestaurantId = m.RestaurantId) restaurant
            Where m.RestaurantId = @RestaurantId";
            sqlCommand.Parameters.AddWithValue("RestaurantId", RestaurantId);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            if (dataSet.Tables[0].Rows.Count > 0)
            {
                dataGridView1.DataSource = dataSet.Tables[0];
            }
        }

        private void FormRestaurantSiparisler_Load(object sender, EventArgs e)
        {
            ListeYukle();

            sqlConnection = new SqlConnection(connectionString);
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = "Select * From SiparisDurum";

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
            {
                comboDurum.Items.Add(dataSet.Tables[0].Rows[i]["Durum"].ToString());
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            SiparisId = (int)dataGridView1.CurrentRow.Cells["SiparisId"].Value;
            txtYemekAdi.Text = dataGridView1.CurrentRow.Cells["YemekAdi"].Value.ToString();
            comboDurum.SelectedItem = dataGridView1.CurrentRow.Cells["Durumu"].Value.ToString();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = "Update s set s.Durumu=@Durumu from Siparis s Where s.Id=@SiparisId";

            sqlCommand.Parameters.AddWithValue("@SiparisId", SiparisId);
            sqlCommand.Parameters.AddWithValue("@Durumu", comboDurum.SelectedItem);

            if (sqlConnection.State == ConnectionState.Closed || sqlConnection.State == ConnectionState.Broken)
            {
                sqlConnection.Open();
            }

            int etkilenen = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            if (etkilenen > 0)
            {
                MessageBox.Show("Sipariş güncellendi.");
            }
            ListeYukle();
        }
    }
}
