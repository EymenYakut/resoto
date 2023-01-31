namespace resoto
{
    partial class frmSiparisKontrol
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSiparisKontrol));
            this.lvMusteriDetaylari = new System.Windows.Forms.ListView();
            this.mID = new System.Windows.Forms.ColumnHeader();
            this.MusteriAd = new System.Windows.Forms.ColumnHeader();
            this.MusteriSoyad = new System.Windows.Forms.ColumnHeader();
            this.Tarih = new System.Windows.Forms.ColumnHeader();
            this.AdisyonId = new System.Windows.Forms.ColumnHeader();
            this.lvSatisDetaylari = new System.Windows.Forms.ListView();
            this.SatisId = new System.Windows.Forms.ColumnHeader();
            this.UrunAdi = new System.Windows.Forms.ColumnHeader();
            this.Adedi = new System.Windows.Forms.ColumnHeader();
            this.Fiyati = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtToplamTutar = new System.Windows.Forms.TextBox();
            this.lblToplamSiparis = new System.Windows.Forms.Label();
            this.lblGenelToplam = new System.Windows.Forms.Label();
            this.lblSonSiparisTarihi = new System.Windows.Forms.Label();
            this.lvMusteriler = new System.Windows.Forms.ListView();
            this.MusteriId = new System.Windows.Forms.ColumnHeader();
            this.Musteri = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.btnCikis = new System.Windows.Forms.Button();
            this.btnGeri = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvMusteriDetaylari
            // 
            this.lvMusteriDetaylari.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.mID,
            this.MusteriAd,
            this.MusteriSoyad,
            this.Tarih,
            this.AdisyonId});
            this.lvMusteriDetaylari.FullRowSelect = true;
            this.lvMusteriDetaylari.GridLines = true;
            this.lvMusteriDetaylari.Location = new System.Drawing.Point(445, 254);
            this.lvMusteriDetaylari.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lvMusteriDetaylari.Name = "lvMusteriDetaylari";
            this.lvMusteriDetaylari.Size = new System.Drawing.Size(350, 222);
            this.lvMusteriDetaylari.TabIndex = 0;
            this.lvMusteriDetaylari.UseCompatibleStateImageBehavior = false;
            this.lvMusteriDetaylari.View = System.Windows.Forms.View.Details;
            this.lvMusteriDetaylari.SelectedIndexChanged += new System.EventHandler(this.lvMusteriDetaylari_SelectedIndexChanged);
            // 
            // mID
            // 
            this.mID.DisplayIndex = 3;
            this.mID.Text = "mID";
            this.mID.Width = 0;
            // 
            // MusteriAd
            // 
            this.MusteriAd.DisplayIndex = 0;
            this.MusteriAd.Text = "AD";
            this.MusteriAd.Width = 120;
            // 
            // MusteriSoyad
            // 
            this.MusteriSoyad.DisplayIndex = 1;
            this.MusteriSoyad.Text = "SOYAD";
            this.MusteriSoyad.Width = 120;
            // 
            // Tarih
            // 
            this.Tarih.DisplayIndex = 2;
            this.Tarih.Text = "TARIH";
            this.Tarih.Width = 100;
            // 
            // AdisyonId
            // 
            this.AdisyonId.Text = "Aid";
            this.AdisyonId.Width = 0;
            // 
            // lvSatisDetaylari
            // 
            this.lvSatisDetaylari.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SatisId,
            this.UrunAdi,
            this.Adedi,
            this.Fiyati});
            this.lvSatisDetaylari.FullRowSelect = true;
            this.lvSatisDetaylari.GridLines = true;
            this.lvSatisDetaylari.Location = new System.Drawing.Point(840, 254);
            this.lvSatisDetaylari.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lvSatisDetaylari.Name = "lvSatisDetaylari";
            this.lvSatisDetaylari.Size = new System.Drawing.Size(351, 222);
            this.lvSatisDetaylari.TabIndex = 1;
            this.lvSatisDetaylari.UseCompatibleStateImageBehavior = false;
            this.lvSatisDetaylari.View = System.Windows.Forms.View.Details;
            // 
            // SatisId
            // 
            this.SatisId.DisplayIndex = 3;
            this.SatisId.Text = "SatisId";
            this.SatisId.Width = 0;
            // 
            // UrunAdi
            // 
            this.UrunAdi.DisplayIndex = 0;
            this.UrunAdi.Text = "URUN ADI";
            this.UrunAdi.Width = 120;
            // 
            // Adedi
            // 
            this.Adedi.DisplayIndex = 1;
            this.Adedi.Text = "ADET";
            this.Adedi.Width = 120;
            // 
            // Fiyati
            // 
            this.Fiyati.DisplayIndex = 2;
            this.Fiyati.Text = "FIYAT";
            this.Fiyati.Width = 100;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(567, 508);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "Toplam Tutar : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(567, 597);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 30);
            this.label2.TabIndex = 3;
            this.label2.Text = "Toplam : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(567, 645);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 30);
            this.label3.TabIndex = 4;
            this.label3.Text = "Genel Toplam : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(567, 688);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(175, 30);
            this.label4.TabIndex = 5;
            this.label4.Text = "En Son Sipariş : ";
            // 
            // txtToplamTutar
            // 
            this.txtToplamTutar.Location = new System.Drawing.Point(803, 517);
            this.txtToplamTutar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtToplamTutar.Name = "txtToplamTutar";
            this.txtToplamTutar.ReadOnly = true;
            this.txtToplamTutar.Size = new System.Drawing.Size(202, 23);
            this.txtToplamTutar.TabIndex = 6;
            // 
            // lblToplamSiparis
            // 
            this.lblToplamSiparis.AutoSize = true;
            this.lblToplamSiparis.BackColor = System.Drawing.Color.Transparent;
            this.lblToplamSiparis.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblToplamSiparis.ForeColor = System.Drawing.Color.White;
            this.lblToplamSiparis.Location = new System.Drawing.Point(860, 597);
            this.lblToplamSiparis.Name = "lblToplamSiparis";
            this.lblToplamSiparis.Size = new System.Drawing.Size(43, 30);
            this.lblToplamSiparis.TabIndex = 3;
            this.lblToplamSiparis.Text = ".....";
            // 
            // lblGenelToplam
            // 
            this.lblGenelToplam.AutoSize = true;
            this.lblGenelToplam.BackColor = System.Drawing.Color.Transparent;
            this.lblGenelToplam.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblGenelToplam.ForeColor = System.Drawing.Color.Red;
            this.lblGenelToplam.Location = new System.Drawing.Point(860, 645);
            this.lblGenelToplam.Name = "lblGenelToplam";
            this.lblGenelToplam.Size = new System.Drawing.Size(43, 30);
            this.lblGenelToplam.TabIndex = 4;
            this.lblGenelToplam.Text = ".....";
            // 
            // lblSonSiparisTarihi
            // 
            this.lblSonSiparisTarihi.AutoSize = true;
            this.lblSonSiparisTarihi.BackColor = System.Drawing.Color.Transparent;
            this.lblSonSiparisTarihi.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSonSiparisTarihi.ForeColor = System.Drawing.Color.White;
            this.lblSonSiparisTarihi.Location = new System.Drawing.Point(860, 688);
            this.lblSonSiparisTarihi.Name = "lblSonSiparisTarihi";
            this.lblSonSiparisTarihi.Size = new System.Drawing.Size(43, 30);
            this.lblSonSiparisTarihi.TabIndex = 5;
            this.lblSonSiparisTarihi.Text = ".....";
            // 
            // lvMusteriler
            // 
            this.lvMusteriler.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MusteriId,
            this.Musteri,
            this.columnHeader12});
            this.lvMusteriler.FullRowSelect = true;
            this.lvMusteriler.GridLines = true;
            this.lvMusteriler.Location = new System.Drawing.Point(1089, 530);
            this.lvMusteriler.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lvMusteriler.Name = "lvMusteriler";
            this.lvMusteriler.Size = new System.Drawing.Size(260, 145);
            this.lvMusteriler.TabIndex = 7;
            this.lvMusteriler.UseCompatibleStateImageBehavior = false;
            this.lvMusteriler.View = System.Windows.Forms.View.Details;
            this.lvMusteriler.Visible = false;
            // 
            // MusteriId
            // 
            this.MusteriId.Text = "MusteriId";
            this.MusteriId.Width = 90;
            // 
            // Musteri
            // 
            this.Musteri.Text = "Musteri";
            this.Musteri.Width = 120;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "adisyonId";
            this.columnHeader12.Width = 80;
            // 
            // btnCikis
            // 
            this.btnCikis.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCikis.BackgroundImage")));
            this.btnCikis.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCikis.FlatAppearance.BorderSize = 0;
            this.btnCikis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCikis.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.btnCikis.Location = new System.Drawing.Point(84, 1008);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(53, 60);
            this.btnCikis.TabIndex = 9;
            this.btnCikis.Text = "Kapat";
            this.btnCikis.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCikis.UseVisualStyleBackColor = true;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // btnGeri
            // 
            this.btnGeri.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGeri.BackgroundImage")));
            this.btnGeri.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGeri.FlatAppearance.BorderSize = 0;
            this.btnGeri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeri.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGeri.Location = new System.Drawing.Point(12, 1008);
            this.btnGeri.Name = "btnGeri";
            this.btnGeri.Size = new System.Drawing.Size(53, 60);
            this.btnGeri.TabIndex = 8;
            this.btnGeri.UseVisualStyleBackColor = true;
            this.btnGeri.Click += new System.EventHandler(this.btnGeri_Click);
            // 
            // frmSiparisKontrol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::resoto.Properties.Resources.arkaplan3;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.btnGeri);
            this.Controls.Add(this.lvMusteriler);
            this.Controls.Add(this.txtToplamTutar);
            this.Controls.Add(this.lblSonSiparisTarihi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblGenelToplam);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblToplamSiparis);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvSatisDetaylari);
            this.Controls.Add(this.lvMusteriDetaylari);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmSiparisKontrol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSiparisKontrol";
            this.Load += new System.EventHandler(this.frmSiparisKontrol_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListView lvMusteriDetaylari;
        private ColumnHeader mID;
        private ColumnHeader MusteriAd;
        private ColumnHeader MusteriSoyad;
        private ColumnHeader Tarih;
        private ColumnHeader AdisyonId;
        private ListView lvSatisDetaylari;
        private ColumnHeader SatisId;
        private ColumnHeader UrunAdi;
        private ColumnHeader Adedi;
        private ColumnHeader Fiyati;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtToplamTutar;
        private Label lblToplamSiparis;
        private Label lblGenelToplam;
        private Label lblSonSiparisTarihi;
        private ListView lvMusteriler;
        private ColumnHeader MusteriId;
        private ColumnHeader Musteri;
        private ColumnHeader columnHeader12;
        private Button btnCikis;
        private Button btnGeri;
    }
}