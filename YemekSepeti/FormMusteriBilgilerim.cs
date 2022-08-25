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
    public partial class FormMusteriBilgilerim : Form
    {
        int MusteriId; //ana formdan gelen parametre
        int Id=-1;//update işleminde kullanmak için Id isimli bir değişken tanımlıyoruz.
        private readonly static string connectionString = "Data Source=localhost;Database=YemekSepeti;Integrated Security=True;";
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        public FormMusteriBilgilerim(int _MusteriId)
        {
            MusteriId = _MusteriId;
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            //bağlantı tanımı
            sqlConnection = new SqlConnection(connectionString); 
            sqlCommand = new SqlCommand(); 
            sqlCommand.Connection = sqlConnection;

            //stored procedure çalıştırılacağından gereken komut ve parametre tanımlamaları yapılıyor.
            sqlCommand.CommandText = "exec usp_MusteriKaydetGuncelle @Id,@MusteriId,@Adres,@Telefon,@Eposta";

            sqlCommand.Parameters.AddWithValue("@Id", Id);
            sqlCommand.Parameters.AddWithValue("@MusteriId", MusteriId);
            sqlCommand.Parameters.AddWithValue("@Telefon", txtTelefon.Text);
            sqlCommand.Parameters.AddWithValue("@Eposta", txtEposta.Text);
            sqlCommand.Parameters.AddWithValue("@Adres", txtAdres.Text);

            //bağlantı durumu kontrol ediliyor. aktif bir bağlantı yok ise bağlantı açılıyor.
            if (sqlConnection.State == ConnectionState.Closed || sqlConnection.State == ConnectionState.Broken)
            {
                sqlConnection.Open();
            }

            //sorgu çalıştırılıyor ve işlem sonucunda etkilenen satır sayısı ile işlemin başarısı kontrol ediliyor.
            int etkilenen = sqlCommand.ExecuteNonQuery();

            //balantı kapatılıyor.
            sqlConnection.Close();

            if (etkilenen > 0)
            {
                MessageBox.Show("Kayıt edildi.");
            }

        }

        private void FormMusteriBilgilerim_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = "Select * From Musteri Where MusteriId=@Id";
            sqlCommand.Parameters.AddWithValue("Id", MusteriId);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            if (dataSet.Tables[0].Rows.Count > 0)
            {
                Id = (int)dataSet.Tables[0].Rows[0]["Id"];
                txtTelefon.Text = dataSet.Tables[0].Rows[0]["Telefon"].ToString();
                txtEposta.Text = dataSet.Tables[0].Rows[0]["Eposta"].ToString();
                txtAdres.Text = dataSet.Tables[0].Rows[0]["Adres"].ToString();
            }
        }
    }
}
