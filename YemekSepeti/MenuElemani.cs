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
    public partial class MenuElemani : UserControl
    {
        int _MusteriId;
        int _MenuId;
        private readonly static string connectionString = "Data Source=localhost;Database=YemekSepeti;Integrated Security=True;";
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        public MenuElemani()
        {
            InitializeComponent();
        }

        //bu user controlü sipariş verme sayfasında yemekleri oluşturmak için kullanacağız. Aşağıdakiler yemeğe ait özellikler.
        public int MenuId
        {
            get { return _MenuId; }
            set { _MenuId = value; }
        }
        public int MusteriId
        {
            get { return _MusteriId; }
            set { _MusteriId = value; }
        }
        public string Restaurant
        {
            get { return lblRestaurant.Text; }
            set { lblRestaurant.Text = value; }
        }
        public string YemekAdi
        {
            get { return lblYemekAdi.Text; }
            set { lblYemekAdi.Text = value; }
        }
        public string Fiyat
        {
            get { return lblFiyat.Text; }
            set { lblFiyat.Text = value; }
        }
        public string Gorsel
        {
            get { return imgGorsel.ImageLocation; }
            set { imgGorsel.ImageLocation = value; }
        }

        private void btnSiparisVer_Click(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = "Insert into Siparis (MusteriId,MenuId,Durumu) values (@MusteriId,@MenuId,@Durumu)";

            sqlCommand.Parameters.AddWithValue("@MusteriId", MusteriId);
            sqlCommand.Parameters.AddWithValue("@MenuId", MenuId);
            sqlCommand.Parameters.AddWithValue("@Durumu", "Sipariş Alındı");

            if (sqlConnection.State == ConnectionState.Closed || sqlConnection.State == ConnectionState.Broken)
            {
                sqlConnection.Open();
            }

            int etkilenen = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            if (etkilenen > 0)
            {
                MessageBox.Show("Siparişiniz alındı. Siparişlerim sayfasından durumunu takip edebilirsiniz.");
            }
        }
    }
}
