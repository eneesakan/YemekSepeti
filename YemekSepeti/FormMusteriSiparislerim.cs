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
    public partial class FormMusteriSiparislerim : Form
    {
        int MusteriId;
        private readonly static string connectionString = "Data Source=localhost;Database=YemekSepeti;Integrated Security=True;";
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        public FormMusteriSiparislerim(int _MusteriId)
        {
            MusteriId = _MusteriId;
            InitializeComponent();
        }

        private void FormMusteriSiparislerim_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = @"Select
                s.Id as SiparisId,
	            m.YemekAdi,
	            restaurant.RestaurantAd,
                restaurant.Telefon,
	            s.Durumu,
	            s.SiparisTarihi
            From Siparis s
            inner join Menu m on s.MenuId = m.Id
            outer apply(select* from Kullanici k where k.Id= s.MusteriId) musteri
            outer apply(select * from Restaurant k where k.RestaurantId = m.RestaurantId) restaurant
            Where s.MusteriId = @MusteriId and s.Durumu != 'Teslim Edildi'";
            sqlCommand.Parameters.AddWithValue("MusteriId", MusteriId);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            if (dataSet.Tables[0].Rows.Count > 0)
            {
                dataGridView1.DataSource = dataSet.Tables[0]; //sorgu sonucu dataGrid'e aktarılıyor.
            }
        }
    }
}
