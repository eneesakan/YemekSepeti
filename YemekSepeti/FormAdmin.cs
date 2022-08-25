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
    public partial class FormAdmin : Form
    {
        int AdminId;
        
        public FormAdmin(int _AdminId)
        {
            AdminId = _AdminId;
            InitializeComponent();
        }
        private void DigerFormlariKapat(Form form)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm != form)
                {
                    frm.Dispose();
                    return;
                }
            }
        }

        private void btnMusteriler_Click(object sender, EventArgs e)
        {
            DigerFormlariKapat(this);
            FormAdminListe form = new FormAdminListe("Müşteriler");
            form.MdiParent = this;
            form.Text = "Müşteriler";
            form.Show();
        }

        private void btnRestaurantlar_Click(object sender, EventArgs e)
        {
            DigerFormlariKapat(this);
            FormAdminListe form = new FormAdminListe("Restaurantlar");
            form.MdiParent = this;
            form.Text = "Restaurantlar";
            form.Show();
        }

        private void btnSiparisler_Click(object sender, EventArgs e)
        {
            DigerFormlariKapat(this);
            FormAdminListe form = new FormAdminListe("Siparişler");
            form.MdiParent = this;
            form.Text = "Siparişler";
            form.Show();
        }

        private void btnMenuTur_Click(object sender, EventArgs e)
        {
            DigerFormlariKapat(this);
            FormAdminListe form = new FormAdminListe("Menü Tür");
            form.MdiParent = this;
            form.Text = "Menü Tür";
            form.Show();
        }

        private void btnSiparisTanimlari_Click(object sender, EventArgs e)
        {
            DigerFormlariKapat(this);
            FormAdminListe form = new FormAdminListe("Sipariş Tanımları");
            form.MdiParent = this;
            form.Text = "Sipariş Tanımları";
            form.Show();
        }
    }
}
