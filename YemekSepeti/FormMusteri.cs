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
    public partial class FormMusteri : Form
    {
        int MusteriId;
        public FormMusteri(int _MusteriId)
        {
            MusteriId = _MusteriId;
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
        private void btnSiparisVer_Click(object sender, EventArgs e)
        {
            //Diğer açık child formları kapatmak için fonksiyon çağırıyoruz.
            DigerFormlariKapat(this);
            FormMusteriYeniSiparis form = new FormMusteriYeniSiparis((int)MusteriId);
            form.MdiParent = this;
            form.Show();
        }

        private void btnSiparislerim_Click(object sender, EventArgs e)
        {
            DigerFormlariKapat(this);
            FormMusteriSiparislerim form = new FormMusteriSiparislerim((int)MusteriId);
            form.MdiParent = this;
            form.Show();
        }

        private void btnBilgilerim_Click(object sender, EventArgs e)
        {
            DigerFormlariKapat(this);
            FormMusteriBilgilerim form = new FormMusteriBilgilerim((int)MusteriId);
            form.MdiParent = this;
            form.Show();
        }
    }
}
