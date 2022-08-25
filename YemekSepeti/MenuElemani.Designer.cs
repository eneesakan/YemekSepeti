
namespace YemekSepeti
{
    partial class MenuElemani
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.imgGorsel = new System.Windows.Forms.PictureBox();
            this.lblYemekAdi = new System.Windows.Forms.Label();
            this.lblFiyat = new System.Windows.Forms.Label();
            this.lblRestaurant = new System.Windows.Forms.Label();
            this.btnSiparisVer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imgGorsel)).BeginInit();
            this.SuspendLayout();
            // 
            // imgGorsel
            // 
            this.imgGorsel.Dock = System.Windows.Forms.DockStyle.Top;
            this.imgGorsel.Location = new System.Drawing.Point(0, 0);
            this.imgGorsel.Margin = new System.Windows.Forms.Padding(4);
            this.imgGorsel.Name = "imgGorsel";
            this.imgGorsel.Size = new System.Drawing.Size(264, 161);
            this.imgGorsel.TabIndex = 0;
            this.imgGorsel.TabStop = false;
            // 
            // lblYemekAdi
            // 
            this.lblYemekAdi.AutoSize = true;
            this.lblYemekAdi.Location = new System.Drawing.Point(4, 165);
            this.lblYemekAdi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblYemekAdi.Name = "lblYemekAdi";
            this.lblYemekAdi.Size = new System.Drawing.Size(89, 16);
            this.lblYemekAdi.TabIndex = 1;
            this.lblYemekAdi.Text = "LblYemekAdi";
            // 
            // lblFiyat
            // 
            this.lblFiyat.AutoSize = true;
            this.lblFiyat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblFiyat.Location = new System.Drawing.Point(199, 141);
            this.lblFiyat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFiyat.Name = "lblFiyat";
            this.lblFiyat.Size = new System.Drawing.Size(63, 16);
            this.lblFiyat.TabIndex = 2;
            this.lblFiyat.Text = "LblFiyat";
            this.lblFiyat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRestaurant
            // 
            this.lblRestaurant.AutoSize = true;
            this.lblRestaurant.Location = new System.Drawing.Point(6, 201);
            this.lblRestaurant.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRestaurant.Name = "lblRestaurant";
            this.lblRestaurant.Size = new System.Drawing.Size(87, 16);
            this.lblRestaurant.TabIndex = 4;
            this.lblRestaurant.Text = "lblRestaurant";
            // 
            // btnSiparisVer
            // 
            this.btnSiparisVer.Location = new System.Drawing.Point(202, 172);
            this.btnSiparisVer.Name = "btnSiparisVer";
            this.btnSiparisVer.Size = new System.Drawing.Size(60, 41);
            this.btnSiparisVer.TabIndex = 5;
            this.btnSiparisVer.Text = "Sipariş Ver";
            this.btnSiparisVer.UseVisualStyleBackColor = true;
            this.btnSiparisVer.Click += new System.EventHandler(this.btnSiparisVer_Click);
            // 
            // MenuElemani
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnSiparisVer);
            this.Controls.Add(this.lblRestaurant);
            this.Controls.Add(this.lblFiyat);
            this.Controls.Add(this.lblYemekAdi);
            this.Controls.Add(this.imgGorsel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MenuElemani";
            this.Size = new System.Drawing.Size(264, 222);
            ((System.ComponentModel.ISupportInitialize)(this.imgGorsel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgGorsel;
        private System.Windows.Forms.Label lblYemekAdi;
        private System.Windows.Forms.Label lblFiyat;
        private System.Windows.Forms.Label lblRestaurant;
        private System.Windows.Forms.Button btnSiparisVer;
    }
}
