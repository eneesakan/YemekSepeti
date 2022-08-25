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
    public partial class FormGiris : Form
    {
        //connectionstring tanımı yapıyoruz.
        private readonly static string connectionString = "Data Source=localhost;Database=YemekSepeti;Integrated Security=True;";

        SqlConnection sqlConnection; //veri tabanı bağlantısı için kullanılacak olan SqlConnection nesnesi
        SqlCommand sqlCommand; //veri tabanı sorguları için kullanılacak olan SqlCommand nesnesi
        public FormGiris()
        {
            InitializeComponent();
        }

        private void comboRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboRol.SelectedItem.ToString())
            {
                case "Admin":
                    txtKullaniciAdi.Text = "admin";
                    txtSifre.Text = "admin";
                    break;
                case "Restaurant 1":
                    txtKullaniciAdi.Text = "restaurant1";
                    txtSifre.Text = "restaurant1";
                    break;
                case "Müşteri 1":
                    txtKullaniciAdi.Text = "musteri1";
                    txtSifre.Text = "musteri1";
                    break;
                default:
                    txtKullaniciAdi.Text = String.Empty;
                    txtSifre.Text = String.Empty;
                    break;

            }
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(connectionString); //yeni veri tabanı bağlantısı oluşturuluyor.
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;

            //veri tabanı sorgusu tanımlanıyor.
            sqlCommand.CommandText = "Select * From Kullanici Where KullaniciAdi=@KullaniciAdi and Sifre=@Sifre and Aktif=1";
            
            //sql sorgu parametreleri ekleniyor.
            sqlCommand.Parameters.AddWithValue("KullaniciAdi", txtKullaniciAdi.Text);
            sqlCommand.Parameters.AddWithValue("Sifre", txtSifre.Text);

            //SqlDataAdapter nesnesi ile sorgu çalıştırılıp sonucu DataSet nesnesine aktarılıyor.
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            if (dataSet.Tables[0].Rows.Count>0)
            {
                switch (dataSet.Tables[0].Rows[0]["Rol_Id"])
                {
                    //Kullanıcının RolId sine göre hangi forma gideceğini belirliyoruz ve bu forma kullanıcının id sini parametre olarak gönderiyoruz.
                    case 1: //admin
                        FormAdmin formAdmin = new FormAdmin((int)dataSet.Tables[0].Rows[0]["Id"]);
                        formAdmin.Show();
                        break;
                    case 2: //restaurant
                        FormRestaurant formRestaurant = new FormRestaurant((int)dataSet.Tables[0].Rows[0]["Id"]);
                        formRestaurant.Show();
                        break;
                    case 3: //müşteri
                        FormMusteri formMusteri = new FormMusteri((int)dataSet.Tables[0].Rows[0]["Id"]);
                        formMusteri.Show();
                        break;
                    default:
                        break;
                }
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı bulunamadı.");
            }
            

        }

        private void FormGiris_Load(object sender, EventArgs e)
        {

        }
    }
}
