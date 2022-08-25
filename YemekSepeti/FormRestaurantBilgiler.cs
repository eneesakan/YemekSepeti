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
    public partial class FormRestaurantBilgiler : Form
    {
        int RestaurantId;
        private readonly static string connectionString = "Data Source=localhost;Database=YemekSepeti;Integrated Security=True;";
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        public FormRestaurantBilgiler(int _RestaurantId)
        {
            RestaurantId = _RestaurantId;
            InitializeComponent();
        }

        private void FormRestaurantBilgiler_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = "Select * From Restaurant Where RestaurantId=@Id";
            sqlCommand.Parameters.AddWithValue("Id", RestaurantId);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            if (dataSet.Tables[0].Rows.Count > 0)
            {
                txtRestaurantAdi.Text = dataSet.Tables[0].Rows[0]["RestaurantAd"].ToString();
                txtYetkiliAdSoyad.Text = dataSet.Tables[0].Rows[0]["YetkiliAdSoyad"].ToString();
                txtTelefon.Text = dataSet.Tables[0].Rows[0]["Telefon"].ToString();
                txtEposta.Text = dataSet.Tables[0].Rows[0]["Eposta"].ToString();
                txtAdres.Text = dataSet.Tables[0].Rows[0]["Adres"].ToString();
                chkAktif.Checked = (bool)dataSet.Tables[0].Rows[0]["Aktif"];
            }
            
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = "Update r set r.RestaurantAd=@RestaurantAd,r.YetkiliAdSoyad=@YetkiliAdSoyad,r.Telefon=@Telefon,r.Eposta=@Eposta,r.Adres=@Adres,r.Aktif=@Aktif from Restaurant r Where r.RestaurantId=@Id";

            sqlCommand.Parameters.AddWithValue("@Id", RestaurantId);
            sqlCommand.Parameters.AddWithValue("@RestaurantAd", txtRestaurantAdi.Text);
            sqlCommand.Parameters.AddWithValue("@YetkiliAdSoyad", txtYetkiliAdSoyad.Text);
            sqlCommand.Parameters.AddWithValue("@Telefon", txtTelefon.Text);
            sqlCommand.Parameters.AddWithValue("@Eposta", txtEposta.Text);
            sqlCommand.Parameters.AddWithValue("@Adres", txtAdres.Text);
            sqlCommand.Parameters.AddWithValue("@Aktif", chkAktif.Checked);

            if (sqlConnection.State == ConnectionState.Closed || sqlConnection.State == ConnectionState.Broken)
            {
                sqlConnection.Open();
            }

            int etkilenen = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            if (etkilenen>0)
            {
                MessageBox.Show("Kayıt edildi.");
            }

        }
    }
}
