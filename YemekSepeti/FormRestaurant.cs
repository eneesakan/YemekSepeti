using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YemekSepeti
{
    public partial class FormRestaurant : Form
    {
        int RestaurantId;
        public FormRestaurant(int _RestaurantId)
        {
            RestaurantId = _RestaurantId;
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

        private void btnRestaurantBilgileri_Click(object sender, EventArgs e)
        {
            DigerFormlariKapat(this);
            FormRestaurantBilgiler formRestaurantBilgiler = new FormRestaurantBilgiler((int)RestaurantId);
            formRestaurantBilgiler.MdiParent = this;
            formRestaurantBilgiler.Show();
        }

        private void btnRestaurantMenu_Click(object sender, EventArgs e)
        {
            DigerFormlariKapat(this);
            FormRestaurantMenu formRestaurantMenu = new FormRestaurantMenu((int)RestaurantId);
            formRestaurantMenu.MdiParent = this;
            formRestaurantMenu.Show();
        }

        private void btnRestaurantSiparisler_Click(object sender, EventArgs e)
        {
            DigerFormlariKapat(this);
            FormRestaurantSiparisler formRestaurantSiparisler = new FormRestaurantSiparisler((int)RestaurantId);
            formRestaurantSiparisler.MdiParent = this;
            formRestaurantSiparisler.Show();
        }
    }
}
