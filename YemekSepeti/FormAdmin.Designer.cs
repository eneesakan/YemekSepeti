
namespace YemekSepeti
{
    partial class FormAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSiparisTanimlari = new System.Windows.Forms.Button();
            this.btnRestaurantlar = new System.Windows.Forms.Button();
            this.btnMenuTur = new System.Windows.Forms.Button();
            this.btnMusteriler = new System.Windows.Forms.Button();
            this.btnSiparisler = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSiparisler);
            this.panel1.Controls.Add(this.btnSiparisTanimlari);
            this.panel1.Controls.Add(this.btnRestaurantlar);
            this.panel1.Controls.Add(this.btnMenuTur);
            this.panel1.Controls.Add(this.btnMusteriler);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 37);
            this.panel1.TabIndex = 3;
            // 
            // btnSiparisTanimlari
            // 
            this.btnSiparisTanimlari.Location = new System.Drawing.Point(627, 3);
            this.btnSiparisTanimlari.Name = "btnSiparisTanimlari";
            this.btnSiparisTanimlari.Size = new System.Drawing.Size(150, 30);
            this.btnSiparisTanimlari.TabIndex = 3;
            this.btnSiparisTanimlari.Text = "Sipariş Tanımları";
            this.btnSiparisTanimlari.UseVisualStyleBackColor = true;
            this.btnSiparisTanimlari.Click += new System.EventHandler(this.btnSiparisTanimlari_Click);
            // 
            // btnRestaurantlar
            // 
            this.btnRestaurantlar.Location = new System.Drawing.Point(159, 3);
            this.btnRestaurantlar.Name = "btnRestaurantlar";
            this.btnRestaurantlar.Size = new System.Drawing.Size(150, 30);
            this.btnRestaurantlar.TabIndex = 2;
            this.btnRestaurantlar.Text = "Restaurantlar";
            this.btnRestaurantlar.UseVisualStyleBackColor = true;
            this.btnRestaurantlar.Click += new System.EventHandler(this.btnRestaurantlar_Click);
            // 
            // btnMenuTur
            // 
            this.btnMenuTur.Location = new System.Drawing.Point(471, 3);
            this.btnMenuTur.Name = "btnMenuTur";
            this.btnMenuTur.Size = new System.Drawing.Size(150, 30);
            this.btnMenuTur.TabIndex = 1;
            this.btnMenuTur.Text = "Menü Türleri";
            this.btnMenuTur.UseVisualStyleBackColor = true;
            this.btnMenuTur.Click += new System.EventHandler(this.btnMenuTur_Click);
            // 
            // btnMusteriler
            // 
            this.btnMusteriler.Location = new System.Drawing.Point(3, 3);
            this.btnMusteriler.Name = "btnMusteriler";
            this.btnMusteriler.Size = new System.Drawing.Size(150, 30);
            this.btnMusteriler.TabIndex = 0;
            this.btnMusteriler.Text = "Kullanıcılar";
            this.btnMusteriler.UseVisualStyleBackColor = true;
            this.btnMusteriler.Click += new System.EventHandler(this.btnMusteriler_Click);
            // 
            // btnSiparisler
            // 
            this.btnSiparisler.Location = new System.Drawing.Point(315, 3);
            this.btnSiparisler.Name = "btnSiparisler";
            this.btnSiparisler.Size = new System.Drawing.Size(150, 30);
            this.btnSiparisler.TabIndex = 4;
            this.btnSiparisler.Text = "Siparişler";
            this.btnSiparisler.UseVisualStyleBackColor = true;
            this.btnSiparisler.Click += new System.EventHandler(this.btnSiparisler_Click);
            // 
            // FormAdmin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.IsMdiContainer = true;
            this.Name = "FormAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormAdmin";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSiparisTanimlari;
        private System.Windows.Forms.Button btnRestaurantlar;
        private System.Windows.Forms.Button btnMenuTur;
        private System.Windows.Forms.Button btnMusteriler;
        private System.Windows.Forms.Button btnSiparisler;
    }
}