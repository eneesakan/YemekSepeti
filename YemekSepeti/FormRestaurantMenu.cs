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
    public partial class FormRestaurantMenu : Form
    {
        int RestaurantId;
        int MenuId = -1;
        private readonly static string connectionString = "Data Source=localhost;Database=YemekSepeti;Integrated Security=True;";
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        public FormRestaurantMenu(int _RestaurantId)
        {
            RestaurantId = _RestaurantId;
            InitializeComponent();
        }
        private void ListeYukle()
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = "Select * From Menu Where RestaurantId=@Id";
            sqlCommand.Parameters.AddWithValue("Id", RestaurantId);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            if (dataSet.Tables[0].Rows.Count > 0)
            {
                dataGridView1.DataSource = dataSet.Tables[0];
                //dataGridView1.Columns["Id"].Visible = false;
                //dataGridView1.Columns["RestaurantId"].Visible = false;
            }
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = "exec usp_MenuKaydetGuncelle @MenuId,@RestaurantId,@YemekAdi,@Aciklama,@Tur,@Gorsel,@Fiyat";

            sqlCommand.Parameters.AddWithValue("@MenuId", MenuId);
            sqlCommand.Parameters.AddWithValue("@RestaurantId", RestaurantId);
            sqlCommand.Parameters.AddWithValue("@YemekAdi", txtYemekAdi.Text);
            sqlCommand.Parameters.AddWithValue("@Aciklama", txtAciklama.Text);
            sqlCommand.Parameters.AddWithValue("@Tur", comboTur.SelectedItem);
            sqlCommand.Parameters.AddWithValue("@Gorsel", lblGorsel.Text);
            sqlCommand.Parameters.AddWithValue("@Fiyat", Math.Round(Convert.ToDecimal(txtFiyat.Text),2));

            if (sqlConnection.State == ConnectionState.Closed || sqlConnection.State == ConnectionState.Broken)
            {
                sqlConnection.Open();
            }

            int etkilenen = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            if (etkilenen > 0)
            {
                MessageBox.Show("Kayıt edildi.");
            }
            ListeYukle();
        }

        private void FormRestaurantMenu_Load(object sender, EventArgs e)
        {
            ListeYukle();

            sqlConnection = new SqlConnection(connectionString);
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = "Select * From MenuTur";

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            //MenuTur'lerini çekip döngü ile combobox'a ekliyoruz.
            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
            {
                comboTur.Items.Add(dataSet.Tables[0].Rows[i]["Ad"].ToString());
            }
        }

        private void btnGorselSec_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog()) //yemek görseli için openfiledialog ile resimin bulunduğu yerin path'ini alıyoruz.
            {
                dlg.Title = "Resim Seç";
                dlg.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    imgGorsel.Image = new Bitmap(dlg.FileName); //PictureBox'a görüntüyü basıyoruz.
                    lblGorsel.Text = dlg.FileName; //veri tabanına yazabilmek için de label'e path'i yazıyoruz.
                }
            }
            
        }

        private void btnYeniKayit_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            txtYemekAdi.Text = string.Empty;
            txtAciklama.Text = string.Empty;
            txtFiyat.Text = string.Empty;
            comboTur.SelectedItem = string.Empty;
            lblGorsel.Text = string.Empty;
            imgGorsel.Image = null;
            MenuId = -1;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //update için datagrid üzerinde seçilen satırın form'a aktarılmasını sağlıyoruz.
            MenuId = (int)dataGridView1.CurrentRow.Cells["Id"].Value;
            txtYemekAdi.Text = dataGridView1.CurrentRow.Cells["YemekAdi"].Value.ToString();
            txtAciklama.Text = dataGridView1.CurrentRow.Cells["Aciklama"].Value.ToString();
            txtFiyat.Text = dataGridView1.CurrentRow.Cells["Fiyat"].Value.ToString();
            comboTur.SelectedItem = dataGridView1.CurrentRow.Cells["Tur"].Value.ToString();
            lblGorsel.Text = dataGridView1.CurrentRow.Cells["Gorsel"].Value.ToString();
            imgGorsel.ImageLocation = dataGridView1.CurrentRow.Cells["Gorsel"].Value.ToString();
        }
    }
}
