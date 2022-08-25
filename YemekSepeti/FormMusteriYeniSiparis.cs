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
    public partial class FormMusteriYeniSiparis : Form
    {
        int MusteriId;
        private readonly static string connectionString = "Data Source=localhost;Database=YemekSepeti;Integrated Security=True;";
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        public FormMusteriYeniSiparis(int _MusteriId)
        {
            MusteriId = _MusteriId;
            InitializeComponent();
        }

        private void FormMusteriYeniSiparis_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = @"select r.RestaurantAd,m.* From Menu m outer apply (Select * from Restaurant r where m.RestaurantId=r.RestaurantId) r";

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
            {
                //burada flowLayoutPanel içerisine eklenmek üzere yemekler için dinamik bir kontrol oluşturuyoruz.
                MenuElemani menu = new MenuElemani();
                menu.MusteriId = MusteriId;
                menu.MenuId = (int)dataSet.Tables[0].Rows[i]["Id"];
                menu.Restaurant = dataSet.Tables[0].Rows[i]["RestaurantAd"].ToString();
                menu.YemekAdi = dataSet.Tables[0].Rows[i]["YemekAdi"].ToString();
                menu.Fiyat = dataSet.Tables[0].Rows[i]["Fiyat"].ToString()+" TL";
                menu.Gorsel = dataSet.Tables[0].Rows[i]["Gorsel"].ToString();

                //oluşturulan kontrolü panelin içine ekliyoruz.
                flowLayoutPanel1.Controls.Add(menu);
            }
        }
    }
}
