using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static resoto.Enum.MasaDurumlari;

namespace resoto
{
    public partial class frmOdeme : Form
    {
        public frmOdeme()
        {
            InitializeComponent();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            if (lblGeldigiSayfa.Text == 1.ToString())
            {
                frmSiparis frmSiparis = new frmSiparis();
                frmSiparis.Show();
                this.Close();

            }
            else
            {
                frmSiparisKontrol fsk = new frmSiparisKontrol();
                fsk.Show();
                this.Close();
            }


        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("çıkmak istermisiniz?", "uyarı!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }


        cSiparis cs = new cSiparis();
        int odemeTuru = 0;
        private void frmOdeme_Load(object sender, EventArgs e)
        {
            lblGeldigiSayfa.Text = "0";
            lblGeldigiSayfa.Text = cGenel._SayfaNo2.ToString();
            label10.Visible = false;
            txtKisiSayisi.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            lblKisiPara.Visible = false;

            if (cGenel._ServisTurNo == 1)
            {
                lblAdisyonID.Text = cGenel._AdisyonId;
                txtIndirim.TextChanged += new EventHandler(txtIndirim_TextChanged);
                cs.SiparisGetir(lvUrunler, Convert.ToInt32(lblAdisyonID.Text));

                if (lvUrunler.Items.Count>0)
                {
                    decimal toplam = 0;
                    for (int i = 0; i < lvUrunler.Items.Count; i++)
                    {
                        toplam += Convert.ToDecimal(lvUrunler.Items[i].SubItems[3].Text);
                    }

                    lbToplamTutar.Text = String.Format("{0:0.0}", toplam); //toplam fiyat yazıldıktan sonra bu kod sayesinde sonun otomatikman 00 çıkacak
                    lbOdenecek.Text = String.Format("{0:0.0}", toplam);
                    decimal kdv = Convert.ToDecimal(lbOdenecek.Text) * 18 / 100;
                    lbKdv.Text = String.Format("{0:0.0}", kdv);
                }

                label14.Visible = false;
                txtIndirim.Visible = false;
                txtIndirim.Clear();

            }

            else if (cGenel._ServisTurNo == 2)
            {
                lblAdisyonID.Text = cGenel._AdisyonId;
                cPaketler cp = new cPaketler();
                odemeTuru = cp.OdemeTurIdGetir(Convert.ToInt32(lblAdisyonID.Text));
                txtIndirim.TextChanged += new EventHandler(txtIndirim_TextChanged);
                cs.SiparisGetir(lvUrunler, Convert.ToInt32(lblAdisyonID.Text));

                if (odemeTuru == 1)
                {
                    rbNakit.Checked = true;
                }
                else if (odemeTuru == 2)
                {
                    rbKredi.Checked = true;
                }
                else if (odemeTuru == 3)
                {
                    rbTicket.Checked = true;
                }
                else if (odemeTuru == 4)
                {
                    rbMultinet.Checked = true;
                }
                else if (odemeTuru == 2)
                {
                    rbSodexo.Checked = true;
                }
                else
                {
                    rbSet.Checked = true;
                }



                if (lvUrunler.Items.Count > 0)
                {
                    decimal toplam = 0;
                    for (int i = 0; i < lvUrunler.Items.Count; i++)
                    {
                        toplam += Convert.ToDecimal(lvUrunler.Items[i].SubItems[3].Text);
                    }

                    lbToplamTutar.Text = String.Format("{0:0.0}", toplam); //toplam fiyat yazıldıktan sonra bu kod sayesinde sonun otomatikman 00 çıkacak
                    lbOdenecek.Text = String.Format("{0:0.0}", toplam);
                    decimal kdv = Convert.ToDecimal(lbOdenecek.Text) * 18 / 100;
                    lbKdv.Text = String.Format("{0:0.0}", kdv);

                }

                label14.Visible = false;
                txtIndirim.Visible = false;
                txtIndirim.Clear();

                
            }
        }

        private void txtIndirim_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (Convert.ToDecimal(txtIndirim.Text) < Convert.ToDecimal(lbToplamTutar.Text))
                {

                    try
                    {
                        lblIndirim.Text = String.Format("{0:0.0}", Convert.ToDecimal(txtIndirim.Text));
                    }
                    catch (Exception)
                    {

                        lblIndirim.Text = String.Format("{0:0.0}", 0);
                    }

                }
                else
                {
                    MessageBox.Show("indirim tutarı, toplam tutardan fazla olamaz.");
                }

            }
            catch (Exception)
            {

                lblIndirim.Text = String.Format("{0:0.0}", 0);
            }
        }

        private void chkIndirim_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIndirim.Checked)
            {
                label14.Visible = true;
                txtIndirim.Visible = true;
                txtIndirim.Clear();
            }
            else
            {
                label14.Visible = false;
                txtIndirim.Visible = false;
                txtIndirim.Clear();
            }
        }

        private void lblIndirim_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(lblIndirim.Text)>0)
            {

                decimal odenecek = 0;
                lbOdenecek.Text = lbToplamTutar.Text;
                odenecek = Convert.ToDecimal(lbOdenecek.Text) - Convert.ToDecimal(lblIndirim.Text);

                lbOdenecek.Text = String.Format("{0:0.0}", odenecek);
            }

            decimal kdv = Convert.ToDecimal(lbOdenecek.Text) * 18 / 100;
            lbKdv.Text = String.Format("{0:0.0}", kdv);
        }

        cMasalar masalar = new cMasalar();
        cRezervasyon rezerve = new cRezervasyon();
        private void btnHesapKapat_Click(object sender, EventArgs e)
        {
            if (rbNakit.Checked == false && rbKredi.Checked == false && rbMultinet.Checked == false && rbSet.Checked == false && rbSodexo.Checked == false && rbTicket.Checked == false)
            {
                MessageBox.Show("lütfen bir ödeme yöntemi seçiniz.");
            }
            else 
            {

                if (cGenel._ServisTurNo == 1)
                {

                    int masaId = masalar.tablodanSayiGetir(Convert.ToString(cGenel._MasaId));
                    int musteriId = 0;

                    if (masalar.MasaDurumu(masaId, (int)Durumlar.Boş) == true)
                    {
                        musteriId = rezerve.musteriIdRezervasyonGetir(masaId);
                    }
                    else
                    {
                        musteriId = 1;
                    }

                    int odemeTurId = 0;

                    if (rbNakit.Checked)
                    {
                        odemeTurId = 1;
                    }
                    else if (rbKredi.Checked)
                    {
                        odemeTurId = 2;
                    }
                    else if (rbTicket.Checked)
                    {
                        odemeTurId = 3;
                    }
                    else if (rbMultinet.Checked)
                    {
                        odemeTurId = 4;
                    }
                    else if (rbSodexo.Checked)
                    {
                        odemeTurId = 5;
                    }
                    else if (rbSet.Checked)
                    {
                        odemeTurId = 6;
                    }

                    cOdeme odeme = new cOdeme();

                    //ADISYONID, ODEMETURID, MUSTERIID, ARATOPLAM, KDVTUTARI, INDIRIM, TOPLAMTUTAR


                    odeme.AdisyonID = Convert.ToInt32(lblAdisyonID.Text);
                    odeme.OdemeTurID = odemeTurId;
                    odeme.MusteriID = musteriId;
                    odeme.AraToplam = Convert.ToDecimal(lbOdenecek.Text);
                    odeme.KdvTutari = Convert.ToDecimal(lbKdv.Text);
                    odeme.Indirim = Convert.ToDecimal(lblIndirim.Text);
                    odeme.GenelToplam = Convert.ToDecimal(lbToplamTutar.Text);

                    bool sonuc = odeme.HesapKapat(odeme);

                    if (sonuc)
                    {
                        MessageBox.Show("Hesap Kapatılmıştır.");
                        masalar.MasaDurumunuDegis(masaId, 1);

                        //cRezervasyon cr = new cRezervasyon();
                        //cr.RezervasyonKapat(Convert.ToInt32(lblAdisyonID.Text));

                        cAdisyon ca = new cAdisyon();
                        ca.AdisyonKapat(Convert.ToInt32(lblAdisyonID.Text), 0);

                        this.Close();
                        frmMasalar frm = new frmMasalar();
                        frm.Show();

                    }
                    else
                    {
                        MessageBox.Show("hesap kapatılırken bir hata oluştu lütfen yetkililere bildiriniz.");
                    }
                }

                //paket sipariş
                else if (cGenel._ServisTurNo == 2)
                {
                    cOdeme odeme = new cOdeme();

                    //ADISYONID, ODEMETURID, MUSTERIID, ARATOPLAM, KDVTUTARI, INDIRIM, TOPLAMTUTAR


                    odeme.AdisyonID = Convert.ToInt32(lblAdisyonID.Text);
                    odeme.OdemeTurID = odemeTuru;
                    odeme.MusteriID = 1;
                    odeme.AraToplam = Convert.ToDecimal(lbOdenecek.Text);
                    odeme.KdvTutari = Convert.ToDecimal(lbKdv.Text);
                    odeme.Indirim = Convert.ToDecimal(lblIndirim.Text);
                    odeme.GenelToplam = Convert.ToDecimal(lbToplamTutar.Text);


                    bool sonuc = odeme.HesapKapat(odeme);

                    if (sonuc)
                    {

                        cAdisyon ca = new cAdisyon();
                        ca.AdisyonKapat(Convert.ToInt32(lblAdisyonID.Text), 1);



                        cPaketler cp = new cPaketler();
                        cp.PaketServisKapa(Convert.ToInt32(lblAdisyonID.Text));

                        MessageBox.Show("Hesap Kapatılmıştır.");

                        this.Close();
                        frmSiparisKontrol frm = new frmSiparisKontrol();
                        frm.Show();

                    }
                    else
                    {
                        MessageBox.Show("hesap kapatılırken bir hata oluştu lütfen yetkililere bildiriniz.");
                    }
                }

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                label10.Visible = true;
                txtKisiSayisi.Visible = true;
                label11.Visible = true;
                label12.Visible = true;
                lblKisiPara.Visible = true;
            }
            else
            {
                label10.Visible = false;
                txtKisiSayisi.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                lblKisiPara.Visible = false;
            }
        }

        private void txtKisiSayisi_TextChanged(object sender, EventArgs e)
        {
            try
            {
                    decimal kisi = Convert.ToDecimal(txtKisiSayisi.Text);
                    decimal hesap = Convert.ToDecimal(lbOdenecek.Text);
                    decimal islem = hesap / kisi;
                    lblKisiPara.Text = Convert.ToString(islem);
            }
            catch (Exception)
            {
                lblKisiPara.Text = String.Format("{0:0.0}", 0);
            }


        }
    }
}
