
namespace YemekSepeti
{
    partial class FormRestaurant
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
            this.btnRestaurantSiparisler = new System.Windows.Forms.Button();
            this.btnRestaurantMenu = new System.Windows.Forms.Button();
            this.btnRestaurantBilgileri = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRestaurantSiparisler);
            this.panel1.Controls.Add(this.btnRestaurantMenu);
            this.panel1.Controls.Add(this.btnRestaurantBilgileri);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1042, 37);
            this.panel1.TabIndex = 1;
            // 
            // btnRestaurantSiparisler
            // 
            this.btnRestaurantSiparisler.Location = new System.Drawing.Point(315, 3);
            this.btnRestaurantSiparisler.Name = "btnRestaurantSiparisler";
            this.btnRestaurantSiparisler.Size = new System.Drawing.Size(150, 30);
            this.btnRestaurantSiparisler.TabIndex = 2;
            this.btnRestaurantSiparisler.Text = "Siparişler";
            this.btnRestaurantSiparisler.UseVisualStyleBackColor = true;
            this.btnRestaurantSiparisler.Click += new System.EventHandler(this.btnRestaurantSiparisler_Click);
            // 
            // btnRestaurantMenu
            // 
            this.btnRestaurantMenu.Location = new System.Drawing.Point(159, 3);
            this.btnRestaurantMenu.Name = "btnRestaurantMenu";
            this.btnRestaurantMenu.Size = new System.Drawing.Size(150, 30);
            this.btnRestaurantMenu.TabIndex = 1;
            this.btnRestaurantMenu.Text = "Menü";
            this.btnRestaurantMenu.UseVisualStyleBackColor = true;
            this.btnRestaurantMenu.Click += new System.EventHandler(this.btnRestaurantMenu_Click);
            // 
            // btnRestaurantBilgileri
            // 
            this.btnRestaurantBilgileri.Location = new System.Drawing.Point(3, 3);
            this.btnRestaurantBilgileri.Name = "btnRestaurantBilgileri";
            this.btnRestaurantBilgileri.Size = new System.Drawing.Size(150, 30);
            this.btnRestaurantBilgileri.TabIndex = 0;
            this.btnRestaurantBilgileri.Text = "Restaurant Bilgileri";
            this.btnRestaurantBilgileri.UseVisualStyleBackColor = true;
            this.btnRestaurantBilgileri.Click += new System.EventHandler(this.btnRestaurantBilgileri_Click);
            // 
            // FormRestaurant
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1042, 589);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.IsMdiContainer = true;
            this.Name = "FormRestaurant";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Restaurant Kullanıcısı";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRestaurantBilgileri;
        private System.Windows.Forms.Button btnRestaurantSiparisler;
        private System.Windows.Forms.Button btnRestaurantMenu;
    }
}