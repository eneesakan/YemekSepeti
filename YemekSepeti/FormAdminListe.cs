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
    public partial class FormAdminListe : Form
    {
        string Liste;
        private readonly static string connectionString = "Data Source=localhost;Database=YemekSepeti;Integrated Security=True;";
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        public FormAdminListe(string _Liste)
        {
            Liste = _Liste;
            InitializeComponent();
        }

        private void FormAdminListe_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            SqlDataAdapter sqlDataAdapter;
            DataSet dataSet = new DataSet() ;

            switch (Liste)
            {
                case "Müşteriler":
                    sqlCommand.CommandText = @"select
                        m.MusteriId,
	                    k.KullaniciAdi,
	                    k.Sifre,
	                    k.Ad,
	                    k.Soyad,
	                    m.Adres,
	                    m.Telefon,
	                    m.Eposta
                    From Musteri m
                    inner join Kullanici k on m.MusteriId = k.Id";

                    
                    
                    break;
                case "Restaurantlar":
                    sqlCommand.CommandText = @"select
	                    k.KullaniciAdi,
	                    k.Sifre,
	                    r.RestaurantAd,
	                    r.YetkiliAdSoyad,
	                    r.Telefon,
	                    r.Eposta,
	                    r.Adres,
	                    r.Aktif
                    From Restaurant r
                    inner join Kullanici k on r.RestaurantId=k.Id";
                    break;
                case "Siparişler":
                    sqlCommand.CommandText = @"Select
                        s.Id as SiparisId,
	                    musteri.Ad+' '+musteri.Soyad Musteri,
	                    m.YemekAdi,
	                    restaurant.RestaurantAd,
                        restaurant.Telefon,
	                    s.Durumu,
	                    s.SiparisTarihi
                    From Siparis s
                    inner join Menu m on s.MenuId = m.Id
                    outer apply(select* from Kullanici k where k.Id= s.MusteriId) musteri
                    outer apply(select * from Restaurant k where k.RestaurantId = m.RestaurantId) restaurant";
                    break;
                case "Menü Tür":
                    sqlCommand.CommandText = @"Select * from MenuTur";
                    break;
                case "Sipariş Tanımları":
                    sqlCommand.CommandText = @"Select * from SiparisDurum";
                    break;
                default:
                    break;
            }

            sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            if (dataSet.Tables[0].Rows.Count > 0)
            {
                dataGridView1.DataSource = dataSet.Tables[0];
            }
        }
    }
}
