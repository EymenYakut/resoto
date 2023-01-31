namespace resoto
{
    partial class frmMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            this.btnMasaSiparis = new System.Windows.Forms.Button();
            this.btnRezervasyon = new System.Windows.Forms.Button();
            this.btnPaket = new System.Windows.Forms.Button();
            this.btnMutfak = new System.Windows.Forms.Button();
            this.btnKasa = new System.Windows.Forms.Button();
            this.btnMusteri = new System.Windows.Forms.Button();
            this.btnCikis = new System.Windows.Forms.Button();
            this.btnAyarlar = new System.Windows.Forms.Button();
            this.sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            this.btnHesapKapat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMasaSiparis
            // 
            this.btnMasaSiparis.BackColor = System.Drawing.Color.Transparent;
            this.btnMasaSiparis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMasaSiparis.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnMasaSiparis.ForeColor = System.Drawing.Color.Black;
            this.btnMasaSiparis.Image = global::resoto.Properties.Resources.chair__1_;
            this.btnMasaSiparis.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMasaSiparis.Location = new System.Drawing.Point(568, 288);
            this.btnMasaSiparis.Name = "btnMasaSiparis";
            this.btnMasaSiparis.Size = new System.Drawing.Size(246, 166);
            this.btnMasaSiparis.TabIndex = 0;
            this.btnMasaSiparis.Text = "MASA";
            this.btnMasaSiparis.UseVisualStyleBackColor = false;
            this.btnMasaSiparis.Click += new System.EventHandler(this.btnMasaSiparis_Click);
            // 
            // btnRezervasyon
            // 
            this.btnRezervasyon.BackColor = System.Drawing.Color.Transparent;
            this.btnRezervasyon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRezervasyon.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRezervasyon.ForeColor = System.Drawing.Color.Black;
            this.btnRezervasyon.Image = ((System.Drawing.Image)(resources.GetObject("btnRezervasyon.Image")));
            this.btnRezervasyon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRezervasyon.Location = new System.Drawing.Point(830, 288);
            this.btnRezervasyon.Name = "btnRezervasyon";
            this.btnRezervasyon.Size = new System.Drawing.Size(246, 166);
            this.btnRezervasyon.TabIndex = 1;
            this.btnRezervasyon.Text = "REZERVE";
            this.btnRezervasyon.UseVisualStyleBackColor = false;
            this.btnRezervasyon.Click += new System.EventHandler(this.btnRezervasyon_Click);
            // 
            // btnPaket
            // 
            this.btnPaket.BackColor = System.Drawing.Color.Transparent;
            this.btnPaket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaket.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPaket.ForeColor = System.Drawing.Color.Black;
            this.btnPaket.Image = global::resoto.Properties.Resources.delivery_man__1_;
            this.btnPaket.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPaket.Location = new System.Drawing.Point(1099, 288);
            this.btnPaket.Name = "btnPaket";
            this.btnPaket.Size = new System.Drawing.Size(246, 166);
            this.btnPaket.TabIndex = 2;
            this.btnPaket.Text = "PAKET";
            this.btnPaket.UseVisualStyleBackColor = false;
            this.btnPaket.Click += new System.EventHandler(this.btnPaket_Click);
            // 
            // btnMutfak
            // 
            this.btnMutfak.BackColor = System.Drawing.Color.Transparent;
            this.btnMutfak.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMutfak.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnMutfak.ForeColor = System.Drawing.Color.Black;
            this.btnMutfak.Image = global::resoto.Properties.Resources.restaurant_menu;
            this.btnMutfak.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMutfak.Location = new System.Drawing.Point(1099, 471);
            this.btnMutfak.Name = "btnMutfak";
            this.btnMutfak.Size = new System.Drawing.Size(246, 166);
            this.btnMutfak.TabIndex = 5;
            this.btnMutfak.Text = "MUTFAK";
            this.btnMutfak.UseVisualStyleBackColor = false;
            this.btnMutfak.Click += new System.EventHandler(this.btnMutfak_Click);
            // 
            // btnKasa
            // 
            this.btnKasa.BackColor = System.Drawing.Color.Transparent;
            this.btnKasa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKasa.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnKasa.ForeColor = System.Drawing.Color.Black;
            this.btnKasa.Image = global::resoto.Properties.Resources.keys;
            this.btnKasa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKasa.Location = new System.Drawing.Point(830, 471);
            this.btnKasa.Name = "btnKasa";
            this.btnKasa.Size = new System.Drawing.Size(246, 166);
            this.btnKasa.TabIndex = 4;
            this.btnKasa.Text = "KASA";
            this.btnKasa.UseVisualStyleBackColor = false;
            this.btnKasa.Click += new System.EventHandler(this.btnKasa_Click);
            // 
            // btnMusteri
            // 
            this.btnMusteri.BackColor = System.Drawing.Color.Transparent;
            this.btnMusteri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMusteri.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnMusteri.ForeColor = System.Drawing.Color.Black;
            this.btnMusteri.Image = global::resoto.Properties.Resources.user;
            this.btnMusteri.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMusteri.Location = new System.Drawing.Point(568, 471);
            this.btnMusteri.Name = "btnMusteri";
            this.btnMusteri.Size = new System.Drawing.Size(246, 166);
            this.btnMusteri.TabIndex = 3;
            this.btnMusteri.Text = "MÜŞTERİ";
            this.btnMusteri.UseVisualStyleBackColor = false;
            this.btnMusteri.Click += new System.EventHandler(this.btnMusteri_Click);
            // 
            // btnCikis
            // 
            this.btnCikis.BackColor = System.Drawing.Color.Transparent;
            this.btnCikis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCikis.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCikis.ForeColor = System.Drawing.Color.Black;
            this.btnCikis.Image = ((System.Drawing.Image)(resources.GetObject("btnCikis.Image")));
            this.btnCikis.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCikis.Location = new System.Drawing.Point(830, 657);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(246, 166);
            this.btnCikis.TabIndex = 8;
            this.btnCikis.Text = "KAPAT";
            this.btnCikis.UseVisualStyleBackColor = false;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // btnAyarlar
            // 
            this.btnAyarlar.BackColor = System.Drawing.Color.Transparent;
            this.btnAyarlar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAyarlar.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAyarlar.ForeColor = System.Drawing.Color.Black;
            this.btnAyarlar.Image = ((System.Drawing.Image)(resources.GetObject("btnAyarlar.Image")));
            this.btnAyarlar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAyarlar.Location = new System.Drawing.Point(568, 657);
            this.btnAyarlar.Name = "btnAyarlar";
            this.btnAyarlar.Size = new System.Drawing.Size(246, 166);
            this.btnAyarlar.TabIndex = 7;
            this.btnAyarlar.Text = "AYARLAR";
            this.btnAyarlar.UseVisualStyleBackColor = false;
            this.btnAyarlar.Click += new System.EventHandler(this.btnAyarlar_Click);
            // 
            // sqlCommand1
            // 
            this.sqlCommand1.CommandTimeout = 30;
            this.sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // btnHesapKapat
            // 
            this.btnHesapKapat.BackColor = System.Drawing.Color.Transparent;
            this.btnHesapKapat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHesapKapat.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnHesapKapat.ForeColor = System.Drawing.Color.Black;
            this.btnHesapKapat.Image = ((System.Drawing.Image)(resources.GetObject("btnHesapKapat.Image")));
            this.btnHesapKapat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHesapKapat.Location = new System.Drawing.Point(1099, 657);
            this.btnHesapKapat.Name = "btnHesapKapat";
            this.btnHesapKapat.Size = new System.Drawing.Size(246, 166);
            this.btnHesapKapat.TabIndex = 9;
            this.btnHesapKapat.Text = "ÇIKIŞ";
            this.btnHesapKapat.UseVisualStyleBackColor = false;
            this.btnHesapKapat.Click += new System.EventHandler(this.btnHesapKapat_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImage = global::resoto.Properties.Resources.arkaplan3;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.btnHesapKapat);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.btnAyarlar);
            this.Controls.Add(this.btnMutfak);
            this.Controls.Add(this.btnKasa);
            this.Controls.Add(this.btnMusteri);
            this.Controls.Add(this.btnPaket);
            this.Controls.Add(this.btnRezervasyon);
            this.Controls.Add(this.btnMasaSiparis);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnMasaSiparis;
        private Button btnRezervasyon;
        private Button btnPaket;
        private Button btnMutfak;
        private Button btnKasa;
        private Button btnMusteri;
        private Button btnCikis;
        private Button btnAyarlar;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private Button btnHesapKapat;
    }
}