namespace resoto
{
    public partial class frmGiris : Form
    {
        public frmGiris()
        {
            InitializeComponent();
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTarih.Text = DateTime.Now.ToLongDateString();
            lblSaat.Text = DateTime.Now.ToLongTimeString();

            int saat = DateTime.Now.Hour;

            if (saat<12)
            {
                lblSelam.Text = "Günaydın";
            }
            else if (saat>12 && saat<17)
            {
                lblSelam.Text = "iyi günler";
            }
            else
            {
                lblSelam.Text = "iyi akşamlar";
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            cPersoneller p = new cPersoneller();
            p.personelBilgileri(cbKullanici);

            if (chbSifreGoster.Checked)
            {
                txtSifre.UseSystemPasswordChar = false;
            }
            else
            {
                txtSifre.UseSystemPasswordChar = true;
            }
        }
        
        private void btnGiris_Click(object sender, EventArgs e)
        {
            cGenel gnl = new cGenel();
            cPersoneller prsnl = new cPersoneller();
            bool sonuc = prsnl.personelGirisKontrol(txtSifre.Text, cGenel.personelId);

            if (sonuc == true)
            {
                cPersonelHareketleri ch = new cPersonelHareketleri();
                ch.PersonelId=cGenel.personelId;
                ch.Islem = "Giriş Yaptı";
                ch.Tarih = DateTime.Now;
                ch.PersonelHareketKaydı(ch);

                this.Hide();
                frmMenu menu = new frmMenu();
                menu.Show();
            }
            else
            {
                MessageBox.Show("Şifreniz Yanlış");
            }
        }

        private void cbKullanici_SelectedIndexChanged(object sender, EventArgs e)
        {
            cPersoneller prsnl = (cPersoneller)cbKullanici.SelectedItem;
            cGenel.personelId = prsnl.PersonelId;
            cGenel.gorevId = prsnl.PersonelGorevId;
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak istermisiniz?","uyarı!!",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void chbSifreGoster_CheckedChanged(object sender, EventArgs e)
        {
            if (chbSifreGoster.Checked)
            {
                txtSifre.UseSystemPasswordChar = false;
            }
            else
            {
                txtSifre.UseSystemPasswordChar = true;
            }
        }
    }
}