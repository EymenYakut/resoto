using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace resoto
{
    public partial class frmAyarlar : Form
    {
        public frmAyarlar()
        {
            InitializeComponent();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            frmMenu fm = new frmMenu();
            this.Close();
            fm.Show();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("çıkmak istermisiniz?", "uyarı!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void frmAyarlar_Load(object sender, EventArgs e)
        {
            cPersoneller cp = new cPersoneller();
            cPersonelGorev cpg = new cPersonelGorev();
            string gorev = cpg.PersonelGorevTanim(cGenel.gorevId);
            if (gorev=="Müdür")
            {
                cp.personelBilgileri(cbPersonel);
                cpg.PersonelGorevGetir(cbGorev);
                cp.personelBilgileriniGetir(lvPersoneller);
                btnYeni.Enabled = true;
                btnSil.Enabled = false;
                btnBilgiDegistir.Enabled = false;
                btnEkle.Enabled = false;
                /*groupBox1.Visible = true;
                groupBox2.Visible = true;
                groupBox3.Visible = true;
                groupBox4.Visible = true;*/
                txtSifre.ReadOnly = true;
                txtSifreTekrar.ReadOnly = true;
                lblGirisYapan.Text = "Mevki : " + cpg.PersonelGorevTanim(cGenel.gorevId) + " / Yetki : sınırsız / Kullanıcı : " + cp.personelBilgiGetir(cGenel.personelId);

            }
            else
            {
                groupBox1.Visible = false;
                groupBox2.Visible = false;
                groupBox3.Visible = true;
                groupBox4.Visible = false;
                lblGirisYapan.Text = "Mevki :" + cpg.PersonelGorevTanim(cGenel.gorevId) +"/ yetki sınırlı / Kullanıcı : " + cp.personelBilgiGetir(cGenel.personelId);
                groupBox3.Location = new System.Drawing.Point(700, 350);
            }
        }

        private void btnDegistir_Click(object sender, EventArgs e)
        {
            if (txtYeniSifre.Text.Trim() != "" || txtYeniSifreTekrar.Text.Trim() != "")
            {

                if (txtYeniSifre.Text == txtYeniSifreTekrar.Text)
                {
                    if (txtPersonelId.Text != "")
                    {
                        cPersoneller c = new cPersoneller();
                        bool sonuc = c.personelSifreDegistir(Convert.ToInt32(txtPersonelId.Text), txtYeniSifre.Text);
                        if (sonuc)
                        {
                            MessageBox.Show("şifre değiştirme işlemi başarılı.");
                            txtYeniSifre.Clear();
                            txtYeniSifreTekrar.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("personel seçiniz.");
                    }
                }
                else
                {
                    MessageBox.Show("Şifreler aynı değil.");
                }

            }
            else
            {
                MessageBox.Show("Şifre alanını boş bırakmayınız.");
            }
        }

        private void cbGorev_SelectedIndexChanged(object sender, EventArgs e)
        {
            cPersonelGorev c = (cPersonelGorev)cbGorev.SelectedItem;
            txtGorevId.Text = Convert.ToString(c.PersonelGorevId);
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            btnYeni.Enabled = true;
            btnEkle.Enabled = true;
            btnBilgiDegistir.Enabled = false;
            btnSil.Enabled = false;
            txtSifre.ReadOnly = false;
            txtSifreTekrar.ReadOnly = false;

        }

        private void cbPersonel_SelectedIndexChanged(object sender, EventArgs e)
        {
            cPersoneller cp = (cPersoneller)cbPersonel.SelectedItem;
            txtPersonelId.Text = Convert.ToString(cp.PersonelId);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("silmek istediğinize emin misiniz ?","uyarı",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning)==DialogResult.OK)
            {
                if (lvPersoneller.SelectedItems.Count>0)
                {
                    cPersoneller cp = new cPersoneller();
                    bool sonuc = cp.personelSil(Convert.ToInt32(lvPersoneller.SelectedItems[0].Text));
                    if (sonuc)
                    {
                        MessageBox.Show("kayıt silinmiştir.");
                        cp.personelBilgileriniGetir(lvPersoneller);
                    }
                    else
                    {
                        MessageBox.Show("kayıt silinirken bi hata oluştu.");
                    }
                }
                else
                {
                    MessageBox.Show("lütfen bir kayıt seçiniz.");
                }
            }
            
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtAd.Text != "" && txtSoyad.Text != "" && txtSifre.Text != "" && txtSifreTekrar.Text != "" && txtGorevId.Text != "")
            {
                if ((txtSifreTekrar.Text.Trim() == txtSifre.Text.Trim()) && (txtSifre.Text.Length>5 || txtSifreTekrar.Text.Length>5))
                {
                    cPersoneller c = new cPersoneller();
                    c.PersonelAd = txtAd.Text.Trim();
                    c.PersonelSoyad = txtSoyad.Text.Trim();
                    c.PersonelParola = txtSifreTekrar.Text.Trim();
                    c.PersonelGorevId = Convert.ToInt32(txtGorevId.Text);
                    bool sonuc = c.personelEkle(c);

                    if (sonuc)
                    {
                        MessageBox.Show("kayıt başarılı");
                        c.personelBilgileriniGetir(lvPersoneller);
                    }
                    else
                    {
                        MessageBox.Show("kayıt başarısız tekrar deneyiniz");
                    }
                }
                else
                {
                    MessageBox.Show("şifreler aynı değil veya şifre 5 karakterden daha kısa");
                }
            }
            else
            {
                MessageBox.Show("boş alan bırakmayınız");
            }
        }

        private void btnBilgiDegistir_Click(object sender, EventArgs e)
        {
            if (lvPersoneller.SelectedItems.Count > 0)
            {

                if (txtAd.Text != "" || txtSoyad.Text != "" || txtGorevId.Text != "")
                {
                    
                        cPersoneller c = new cPersoneller();
                        c.PersonelAd = txtAd.Text.Trim();
                        c.PersonelSoyad = txtSoyad.Text.Trim();
                        c.PersonelParola = txtSifreTekrar.Text.Trim();
                        c.PersonelGorevId = Convert.ToInt32(txtGorevId.Text);
                        bool sonuc = c.personelGuncelle(c,Convert.ToInt32(txtPersonelId2.Text));

                        if (sonuc)
                        {
                            MessageBox.Show("güncelleme başarılı");
                            c.personelBilgileriniGetir(lvPersoneller);
                        }
                        else
                        {
                            MessageBox.Show("güncelleme başarısız tekrar deneyiniz");
                        }
                   
                }
                else
                {
                    MessageBox.Show("boş alan bırakmayınız");
                }

            }
            else
            {
                MessageBox.Show("lütfen bir kayıt seçiniz.");
            }
        }

        private void btnDegistir3_Click(object sender, EventArgs e)
        {
            if (txtYeniSifre2.Text.Trim() != "" || txtYeniSifreTekrar2.Text.Trim() != "")
            {

                if (txtYeniSifre2.Text == txtYeniSifreTekrar2.Text)
                {
                    if (Convert.ToString(cGenel.personelId) != "")
                    {
                        cPersoneller c = new cPersoneller();
                        bool sonuc = c.personelSifreDegistir(Convert.ToInt32(cGenel.personelId), txtYeniSifre2.Text);
                        if (sonuc)
                        {
                            MessageBox.Show("şifre değiştirme işlemi başarılı.");
                            txtYeniSifre2.Clear();
                            txtYeniSifreTekrar2.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("personel seçiniz.");
                    }
                }
                else
                {
                    MessageBox.Show("Şifreler aynı değil.");
                }

            }
            else
            {
                MessageBox.Show("Şifre alanını boş bırakmayınız.");
            }
        }

        private void lvPersoneller_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvPersoneller.SelectedItems.Count>0)
            {
                btnYeni.Enabled = false;
                btnSil.Enabled = true;
                btnBilgiDegistir.Enabled = true;
                btnEkle.Enabled = false;
                btnBırak.Visible = true;
                txtPersonelId2.Text = lvPersoneller.SelectedItems[0].SubItems[0].Text;
            cbGorev.SelectedIndex = Convert.ToInt32(lvPersoneller.SelectedItems[0].SubItems[1].Text) - 1;
            txtAd.Text = lvPersoneller.SelectedItems[0].SubItems[3].Text;
            txtSoyad.Text = lvPersoneller.SelectedItems[0].SubItems[4].Text;
            }
            else
            {
                btnYeni.Enabled = true;
                btnSil.Enabled = false;
                btnBilgiDegistir.Enabled = false;
                btnEkle.Enabled = false;
                btnBırak.Visible = false;
            }
        }

        private void btnBırak_Click(object sender, EventArgs e)
        {
            if (lvPersoneller.SelectedItems.Count > 0)
            {
                lvPersoneller.SelectedItems.Clear();
                txtAd.Clear();
                txtSoyad.Clear();
                cbGorev.Text = "";
            }
        }
    }
}
