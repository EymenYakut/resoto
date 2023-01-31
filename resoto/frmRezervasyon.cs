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
    public partial class frmRezervasyon : Form
    {
        public frmRezervasyon()
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

        private void frmRezervasyon_Load(object sender, EventArgs e)
        {
            cMusteriler cm = new cMusteriler();
            cm.MusteriGetir(lvMusteriler);

            cRezervasyon cr = new cRezervasyon();
            cr.BosMasaGoster(cbMasaSec);
        }

        private void txtAd_TextChanged(object sender, EventArgs e)
        {
            cMusteriler cm = new cMusteriler();
            cm.musteriGetirAd(lvMusteriler, txtAd.Text);
        }

        private void txtSoyad_TextChanged(object sender, EventArgs e)
        {
            cMusteriler cm = new cMusteriler();
            cm.musteriGetirSoyad(lvMusteriler, txtSoyad.Text);
        }

        private void txtTelefon_TextChanged(object sender, EventArgs e)
        {
            cMusteriler cm = new cMusteriler();
            cm.musteriGetirTelefon(lvMusteriler, txtTelefon.Text);
        }

        private void txtAdres_TextChanged(object sender, EventArgs e)
        {
            cMusteriler cm = new cMusteriler();
            cm.musteriGetirAdres(lvMusteriler, txtAdres.Text);
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            MusteriEkleme me = new MusteriEkleme();

            me.btnGuncelle.Visible = false;

            cGenel._musteriEkleme = 1;
            //this.Close();
            me.Show();
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            cMusteriler cm = new cMusteriler();
            cm.MusteriGetir(lvMusteriler);
        }


        private void btnRezervAc_Click(object sender, EventArgs e)
        {
            try
            {
                cRezervasyon cr = new cRezervasyon();

                if (dtpTarih.Text != "" && txtMasaId.Text != "" && txtKisiSayisi.Text != "" && txtAciklama.Text != "" && lvMusteriler.SelectedItems.Count > 0)
                {


                    if (txtKisiSayisi.Text != "0")
                    {
                        if (lblKapasite.Text != "")
                        {

                            if (Convert.ToInt32(txtKisiSayisi.Text) > Convert.ToInt32(lblKapasite.Text))
                            {
                                MessageBox.Show("lütfen masa kapsitesinde fazla kişi sayısı girmeyiniz");
                            }
                            else
                            {
                                cr.Tarih = Convert.ToDateTime(dtpTarih.Text);
                                cr.MasaId = Convert.ToInt32(txtMasaId.Text);
                                cr.KisiSayisi = Convert.ToInt32(txtKisiSayisi.Text);
                                cr.Aciklama = txtAciklama.Text;
                                cr.MusteriId = Convert.ToInt32(lvMusteriler.SelectedItems[0].SubItems[0].Text);
                                cMasalar cm = new cMasalar();
                                int sonuc = cr.RezervasyonAc(cr);



                                MessageBox.Show("işlem başarılı");

                            }
                        }
                        else
                        {
                            MessageBox.Show("lütfen bir masa seçiniz");
                        }
                    }
                    else
                    {
                        MessageBox.Show("lütfen kişi sayısını sıfırdan farklı bir sayı giriniz");
                    }
                }
                else
                {
                    MessageBox.Show("lütfen gerekli yerleri doldurunuz veya bir müşteri seçiniz");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("işlem başarısız");
            }
           
        }

        private void cbMasaSec_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblKapasite.Text = String.Empty;
            cMasalar cm = new cMasalar();

            txtMasaId.Text = Convert.ToString(cbMasaSec.Text);
            cm.masaKapasite(Convert.ToInt32(txtMasaId.Text),lblKapasite);
        }

        private void btnRezerv_Click(object sender, EventArgs e)
        {
            frmAcikRezervasyonlar fa = new frmAcikRezervasyonlar();
            this.Close();
            fa.Show();
        }

    }
}
