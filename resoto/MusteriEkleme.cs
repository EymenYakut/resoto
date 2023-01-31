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
    public partial class MusteriEkleme : Form
    {
        public MusteriEkleme()
        {
            InitializeComponent();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            frmMusteriAra fm = new frmMusteriAra();
            this.Close();
            //fm.Show();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("çıkmak istermisiniz?", "uyarı!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtTelefon.Text.Length>6)
            {
                if (txtAd.Text == "" || txtSoyad.Text == "")
                {
                    MessageBox.Show("lütfen müşteri ad ve soyad bilgilerini giriniz.");
                }
                else
                {
                    cMusteriler cm = new cMusteriler();
                    bool sonuc = cm.MusteriVarMi(txtTelefon.Text);
                    if (sonuc == false)
                    {
                        cm.MusteriAd = txtAd.Text;
                        cm.MusteriSoyad = txtSoyad.Text;
                        cm.Telefon = txtTelefon.Text;
                        cm.Email = txtMail.Text;
                        cm.Adres = txtAdres.Text;
                        txtID.Text = cm.MusteriEkle(cm).ToString();
                        if (txtID.Text != "")
                        {
                            MessageBox.Show("Müşteri eklendi");
                        }
                        else
                        {
                            MessageBox.Show("Müşteri eklenemedi");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bu telefona ait kayıt bulunmaktadır");
                    }
                }
            }
            else
            {
                MessageBox.Show("lütfen en az 7 haneli telefon numarası giriniz.");
            }
        }

        /*private void btnMusteriSec_Click(object sender, EventArgs e)
        {
            //0 ise rezervasyona 1 ise paket siparişe gidecek
            if (cGenel._musteriEkleme == 0)
            {
                frmRezervasyon fr = new frmRezervasyon();
                cGenel._musteriEkleme = 1;
                this.Close();
                fr.Show();

            }
            else if(cGenel._musteriEkleme == 1)
            {
                frmPaketSiparis fp = new frmPaketSiparis();
                cGenel._musteriEkleme = 0;
                this.Close();
                fp.Show();
            }
        }*/

        private void btnGuncelle_Click(object sender, EventArgs e)
        {


            if (txtTelefon.Text.Length > 6)
            {
                if (txtAd.Text == "" || txtSoyad.Text == "")
                {
                    MessageBox.Show("lütfen müşteri ad ve soyad bilgilerini giriniz.");
                }
                else
                {
                    cMusteriler cm = new cMusteriler();

                    cm.MusteriAd = txtAd.Text;
                    cm.MusteriSoyad = txtSoyad.Text;
                    cm.Telefon = txtTelefon.Text;
                    cm.Email = txtMail.Text;
                    cm.Adres = txtAdres.Text;
                    cm.MusteriId = Convert.ToInt32(txtID.Text);
                    bool sonuc = cm.MusteriGuncelle(cm);


                    if (sonuc == false)
                    {
                        
                        if (txtID.Text != "")
                        {
                            MessageBox.Show("Müşteri güncellendi");

                            //frmMusteriAra ma = new frmMusteriAra();
                            //ma.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Müşteri güncellenemedi");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Müşteri güncellendi");

                        //frmMusteriAra ma = new frmMusteriAra();
                        //ma.Show();
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("lütfen en az 7 haneli telefon numarası giriniz.");
            }
        }

        private void MusteriEkleme_Load(object sender, EventArgs e)
        {
            
            if (cGenel._musteriId>0)
            {
                cMusteriler c = new cMusteriler();
                txtID.Text = cGenel._musteriId.ToString();
                c.musterileriGetirID(Convert.ToInt32(txtID.Text), txtAd, txtSoyad, txtTelefon, txtAdres, txtMail);
            }

        }
    }
}
