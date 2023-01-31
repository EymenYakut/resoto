namespace resoto
{
    partial class frmKasa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKasa));
            this.btnCikis = new System.Windows.Forms.Button();
            this.btnGeri = new System.Windows.Forms.Button();
            this.btnAylikRapor = new System.Windows.Forms.Button();
            this.btnZrapor = new System.Windows.Forms.Button();
            this.lvListe = new System.Windows.Forms.ListView();
            this.URUNADI = new System.Windows.Forms.ColumnHeader();
            this.adeti = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.dtpBaslangic = new System.Windows.Forms.DateTimePicker();
            this.dtpBitis = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblToplamTutar = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnZraporAl = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cbKategoriler = new System.Windows.Forms.ComboBox();
            this.btnYillik = new System.Windows.Forms.Button();
            this.lvZrapor = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.label7 = new System.Windows.Forms.Label();
            this.rbUrunSatis = new System.Windows.Forms.RadioButton();
            this.rbZrapor = new System.Windows.Forms.RadioButton();
            this.pnlUrun = new System.Windows.Forms.Panel();
            this.pnlZrapor = new System.Windows.Forms.Panel();
            this.btnIkiTarih = new System.Windows.Forms.Button();
            this.pnlUrun.SuspendLayout();
            this.pnlZrapor.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCikis
            // 
            this.btnCikis.BackColor = System.Drawing.SystemColors.Control;
            this.btnCikis.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCikis.BackgroundImage")));
            this.btnCikis.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCikis.FlatAppearance.BorderSize = 0;
            this.btnCikis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCikis.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.btnCikis.Location = new System.Drawing.Point(84, 1008);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(53, 60);
            this.btnCikis.TabIndex = 8;
            this.btnCikis.Text = "Kapat";
            this.btnCikis.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCikis.UseVisualStyleBackColor = false;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // btnGeri
            // 
            this.btnGeri.BackColor = System.Drawing.SystemColors.Control;
            this.btnGeri.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGeri.BackgroundImage")));
            this.btnGeri.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGeri.FlatAppearance.BorderSize = 0;
            this.btnGeri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeri.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGeri.Location = new System.Drawing.Point(12, 1008);
            this.btnGeri.Name = "btnGeri";
            this.btnGeri.Size = new System.Drawing.Size(53, 60);
            this.btnGeri.TabIndex = 7;
            this.btnGeri.UseVisualStyleBackColor = false;
            this.btnGeri.Click += new System.EventHandler(this.btnGeri_Click);
            // 
            // btnAylikRapor
            // 
            this.btnAylikRapor.BackColor = System.Drawing.Color.Transparent;
            this.btnAylikRapor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAylikRapor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAylikRapor.Image = global::resoto.Properties.Resources.report;
            this.btnAylikRapor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAylikRapor.Location = new System.Drawing.Point(57, 379);
            this.btnAylikRapor.Name = "btnAylikRapor";
            this.btnAylikRapor.Size = new System.Drawing.Size(158, 65);
            this.btnAylikRapor.TabIndex = 9;
            this.btnAylikRapor.Text = "AYLIK RAPOR";
            this.btnAylikRapor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAylikRapor.UseVisualStyleBackColor = false;
            this.btnAylikRapor.Click += new System.EventHandler(this.btnAylikRapor_Click);
            // 
            // btnZrapor
            // 
            this.btnZrapor.BackColor = System.Drawing.Color.Transparent;
            this.btnZrapor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZrapor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnZrapor.Image = global::resoto.Properties.Resources.z;
            this.btnZrapor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnZrapor.Location = new System.Drawing.Point(57, 490);
            this.btnZrapor.Name = "btnZrapor";
            this.btnZrapor.Size = new System.Drawing.Size(158, 65);
            this.btnZrapor.TabIndex = 10;
            this.btnZrapor.Text = "Z RAPOR";
            this.btnZrapor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnZrapor.UseVisualStyleBackColor = false;
            this.btnZrapor.Click += new System.EventHandler(this.btnZrapor_Click);
            // 
            // lvListe
            // 
            this.lvListe.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.URUNADI,
            this.adeti,
            this.columnHeader1});
            this.lvListe.FullRowSelect = true;
            this.lvListe.GridLines = true;
            this.lvListe.Location = new System.Drawing.Point(313, 263);
            this.lvListe.Name = "lvListe";
            this.lvListe.Size = new System.Drawing.Size(386, 440);
            this.lvListe.TabIndex = 11;
            this.lvListe.UseCompatibleStateImageBehavior = false;
            this.lvListe.View = System.Windows.Forms.View.Details;
            // 
            // URUNADI
            // 
            this.URUNADI.Text = "URUN ADI";
            this.URUNADI.Width = 200;
            // 
            // adeti
            // 
            this.adeti.Text = "SATIŞ ADET";
            this.adeti.Width = 80;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "TOPLAM FİYAT";
            this.columnHeader1.Width = 100;
            // 
            // dtpBaslangic
            // 
            this.dtpBaslangic.Location = new System.Drawing.Point(446, 90);
            this.dtpBaslangic.Name = "dtpBaslangic";
            this.dtpBaslangic.Size = new System.Drawing.Size(200, 23);
            this.dtpBaslangic.TabIndex = 12;
            this.dtpBaslangic.Value = new System.DateTime(2022, 6, 2, 0, 0, 0, 0);
            // 
            // dtpBitis
            // 
            this.dtpBitis.Location = new System.Drawing.Point(446, 141);
            this.dtpBitis.Name = "dtpBitis";
            this.dtpBitis.Size = new System.Drawing.Size(200, 23);
            this.dtpBitis.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(313, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 21);
            this.label1.TabIndex = 14;
            this.label1.Text = "Başlangıç Tarihi : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(314, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 21);
            this.label2.TabIndex = 15;
            this.label2.Text = "Bitiş Tarihi : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(313, 235);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 25);
            this.label3.TabIndex = 16;
            this.label3.Text = "Ürün Satış Tablosu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(328, 749);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 25);
            this.label4.TabIndex = 17;
            this.label4.Text = "Toplam Tutar : ";
            // 
            // lblToplamTutar
            // 
            this.lblToplamTutar.AutoSize = true;
            this.lblToplamTutar.BackColor = System.Drawing.Color.Transparent;
            this.lblToplamTutar.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblToplamTutar.ForeColor = System.Drawing.Color.White;
            this.lblToplamTutar.Location = new System.Drawing.Point(490, 749);
            this.lblToplamTutar.Name = "lblToplamTutar";
            this.lblToplamTutar.Size = new System.Drawing.Size(0, 25);
            this.lblToplamTutar.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(569, 749);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 25);
            this.label5.TabIndex = 19;
            this.label5.Text = "TL";
            // 
            // btnZraporAl
            // 
            this.btnZraporAl.BackColor = System.Drawing.Color.Transparent;
            this.btnZraporAl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZraporAl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnZraporAl.ForeColor = System.Drawing.Color.Black;
            this.btnZraporAl.Image = global::resoto.Properties.Resources.keys;
            this.btnZraporAl.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnZraporAl.Location = new System.Drawing.Point(843, 622);
            this.btnZraporAl.Name = "btnZraporAl";
            this.btnZraporAl.Size = new System.Drawing.Size(145, 66);
            this.btnZraporAl.TabIndex = 20;
            this.btnZraporAl.Text = "Z RAPOR AL";
            this.btnZraporAl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnZraporAl.UseVisualStyleBackColor = false;
            this.btnZraporAl.Visible = false;
            this.btnZraporAl.Click += new System.EventHandler(this.btnZraporAl_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(314, 193);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 21);
            this.label6.TabIndex = 21;
            this.label6.Text = "Kategori Adı : ";
            // 
            // cbKategoriler
            // 
            this.cbKategoriler.FormattingEnabled = true;
            this.cbKategoriler.Location = new System.Drawing.Point(446, 191);
            this.cbKategoriler.Name = "cbKategoriler";
            this.cbKategoriler.Size = new System.Drawing.Size(200, 23);
            this.cbKategoriler.TabIndex = 22;
            this.cbKategoriler.SelectedIndexChanged += new System.EventHandler(this.cbKategoriler_SelectedIndexChanged);
            // 
            // btnYillik
            // 
            this.btnYillik.BackColor = System.Drawing.Color.Transparent;
            this.btnYillik.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYillik.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnYillik.Image = global::resoto.Properties.Resources.report;
            this.btnYillik.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnYillik.Location = new System.Drawing.Point(57, 278);
            this.btnYillik.Name = "btnYillik";
            this.btnYillik.Size = new System.Drawing.Size(158, 65);
            this.btnYillik.TabIndex = 23;
            this.btnYillik.Text = "YILLIK RAPOR";
            this.btnYillik.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnYillik.UseVisualStyleBackColor = false;
            this.btnYillik.Click += new System.EventHandler(this.btnYillik_Click);
            // 
            // lvZrapor
            // 
            this.lvZrapor.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvZrapor.FullRowSelect = true;
            this.lvZrapor.GridLines = true;
            this.lvZrapor.Location = new System.Drawing.Point(106, 66);
            this.lvZrapor.Name = "lvZrapor";
            this.lvZrapor.Size = new System.Drawing.Size(407, 440);
            this.lvZrapor.TabIndex = 24;
            this.lvZrapor.UseCompatibleStateImageBehavior = false;
            this.lvZrapor.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "BASLANGIC";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "BITIS";
            this.columnHeader3.Width = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "TUTAR";
            this.columnHeader4.Width = 100;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(106, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(148, 25);
            this.label7.TabIndex = 25;
            this.label7.Text = "Z Rapor Tablosu";
            // 
            // rbUrunSatis
            // 
            this.rbUrunSatis.AutoSize = true;
            this.rbUrunSatis.BackColor = System.Drawing.Color.Transparent;
            this.rbUrunSatis.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rbUrunSatis.ForeColor = System.Drawing.Color.White;
            this.rbUrunSatis.Location = new System.Drawing.Point(1075, 56);
            this.rbUrunSatis.Name = "rbUrunSatis";
            this.rbUrunSatis.Size = new System.Drawing.Size(156, 25);
            this.rbUrunSatis.TabIndex = 26;
            this.rbUrunSatis.TabStop = true;
            this.rbUrunSatis.Text = "Ürün Satış Tablosu";
            this.rbUrunSatis.UseVisualStyleBackColor = false;
            this.rbUrunSatis.CheckedChanged += new System.EventHandler(this.rbUrunSatis_CheckedChanged);
            // 
            // rbZrapor
            // 
            this.rbZrapor.AutoSize = true;
            this.rbZrapor.BackColor = System.Drawing.Color.Transparent;
            this.rbZrapor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rbZrapor.ForeColor = System.Drawing.Color.White;
            this.rbZrapor.Location = new System.Drawing.Point(801, 56);
            this.rbZrapor.Name = "rbZrapor";
            this.rbZrapor.Size = new System.Drawing.Size(139, 25);
            this.rbZrapor.TabIndex = 27;
            this.rbZrapor.TabStop = true;
            this.rbZrapor.Text = "Z Rapor Tablosu";
            this.rbZrapor.UseVisualStyleBackColor = false;
            this.rbZrapor.CheckedChanged += new System.EventHandler(this.rbZrapor_CheckedChanged);
            // 
            // pnlUrun
            // 
            this.pnlUrun.BackColor = System.Drawing.Color.Transparent;
            this.pnlUrun.Controls.Add(this.btnIkiTarih);
            this.pnlUrun.Controls.Add(this.btnYillik);
            this.pnlUrun.Controls.Add(this.btnAylikRapor);
            this.pnlUrun.Controls.Add(this.btnZraporAl);
            this.pnlUrun.Controls.Add(this.btnZrapor);
            this.pnlUrun.Controls.Add(this.lvListe);
            this.pnlUrun.Controls.Add(this.dtpBaslangic);
            this.pnlUrun.Controls.Add(this.cbKategoriler);
            this.pnlUrun.Controls.Add(this.dtpBitis);
            this.pnlUrun.Controls.Add(this.label6);
            this.pnlUrun.Controls.Add(this.label1);
            this.pnlUrun.Controls.Add(this.label2);
            this.pnlUrun.Controls.Add(this.label5);
            this.pnlUrun.Controls.Add(this.label3);
            this.pnlUrun.Controls.Add(this.lblToplamTutar);
            this.pnlUrun.Controls.Add(this.label4);
            this.pnlUrun.Location = new System.Drawing.Point(232, 118);
            this.pnlUrun.Name = "pnlUrun";
            this.pnlUrun.Size = new System.Drawing.Size(1016, 801);
            this.pnlUrun.TabIndex = 28;
            // 
            // pnlZrapor
            // 
            this.pnlZrapor.BackColor = System.Drawing.Color.Transparent;
            this.pnlZrapor.Controls.Add(this.label7);
            this.pnlZrapor.Controls.Add(this.lvZrapor);
            this.pnlZrapor.Location = new System.Drawing.Point(1300, 118);
            this.pnlZrapor.Name = "pnlZrapor";
            this.pnlZrapor.Size = new System.Drawing.Size(583, 801);
            this.pnlZrapor.TabIndex = 29;
            // 
            // btnIkiTarih
            // 
            this.btnIkiTarih.BackColor = System.Drawing.Color.Transparent;
            this.btnIkiTarih.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIkiTarih.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnIkiTarih.Image = global::resoto.Properties.Resources.calendar;
            this.btnIkiTarih.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIkiTarih.Location = new System.Drawing.Point(674, 90);
            this.btnIkiTarih.Name = "btnIkiTarih";
            this.btnIkiTarih.Size = new System.Drawing.Size(124, 65);
            this.btnIkiTarih.TabIndex = 24;
            this.btnIkiTarih.Text = "İKİ TARİH ARASI";
            this.btnIkiTarih.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIkiTarih.UseVisualStyleBackColor = false;
            this.btnIkiTarih.Click += new System.EventHandler(this.btnIkiTarih_Click);
            // 
            // frmKasa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::resoto.Properties.Resources.arkaplan3;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.pnlZrapor);
            this.Controls.Add(this.pnlUrun);
            this.Controls.Add(this.rbZrapor);
            this.Controls.Add(this.rbUrunSatis);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.btnGeri);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmKasa";
            this.Text = "frmKasa";
            this.Load += new System.EventHandler(this.frmKasa_Load);
            this.pnlUrun.ResumeLayout(false);
            this.pnlUrun.PerformLayout();
            this.pnlZrapor.ResumeLayout(false);
            this.pnlZrapor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnCikis;
        private Button btnGeri;
        private Button btnAylikRapor;
        private Button btnZrapor;
        private ListView lvListe;
        private ColumnHeader URUNADI;
        private ColumnHeader adeti;
        private DateTimePicker dtpBaslangic;
        private DateTimePicker dtpBitis;
        private Label label1;
        private Label label2;
        private ColumnHeader columnHeader1;
        private Label label3;
        private Label label4;
        private Label lblToplamTutar;
        private Label label5;
        private Button btnZraporAl;
        private Label label6;
        private ComboBox cbKategoriler;
        private Button btnYillik;
        private ListView lvZrapor;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private Label label7;
        private RadioButton rbUrunSatis;
        private RadioButton rbZrapor;
        private Panel pnlUrun;
        private Panel pnlZrapor;
        private Button btnIkiTarih;
    }
}