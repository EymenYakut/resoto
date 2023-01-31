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
    public partial class frmMusteriAra : Form
    {
        public frmMusteriAra()
        {
            InitializeComponent();
        }

        private void frmMusteriler_Load(object sender, EventArgs e)
        {
            cMusteriler cm = new cMusteriler();
            cm.MusteriGetir(lvMusteriler);
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            frmMenu frmMenu = new frmMenu();
            this.Close();
            frmMenu.Show();
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
            MusteriEkleme me = new MusteriEkleme();

            me.btnGuncelle.Visible = false;

            cGenel._musteriEkleme = 1;
            //this.Close();
            me.Show();
            
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {

            MusteriEkleme me = new MusteriEkleme();

            me.btnEkle.Visible = false;

            if (lvMusteriler.SelectedItems.Count>0)
            {

                cGenel._musteriEkleme = 1;
                cGenel._musteriId = Convert.ToInt32(lvMusteriler.SelectedItems[0].SubItems[0].Text);

                me.Show();
            }
            else
            {
                MessageBox.Show("Lütfen bir kayıt seçiniz.");
            }

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

        private void btnAdisyonBul_Click(object sender, EventArgs e)
        {
            if (txtAdisyon.Text !="")
            {
                cGenel._AdisyonId = txtAdisyon.Text;
                cPaketler c = new cPaketler();

                bool sonuc = c.AcıkAdisyonKontrol(Convert.ToInt32(txtAdisyon.Text));

                if (sonuc)
                {
                    frmOdeme fo = new frmOdeme();
                    cGenel._ServisTurNo = 2;
                    fo.Show();
                }
                else
                {
                    MessageBox.Show("Bu numarada bir adisyon bulunamadı.");
                }
            }
            else
            {
                MessageBox.Show("Aramak istediğiniz adisyon no'yu giriniz.");
            }
        }

        private void btnSiparisler_Click(object sender, EventArgs e)
        {
            frmSiparisKontrol sk = new frmSiparisKontrol();
            this.Close();
            sk.Show();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Müşteri silinsin mi?","uyarı",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                cMusteriler cm = new cMusteriler();
                int sonuc = cm.MusteriSil(Convert.ToInt32(lvMusteriler.SelectedItems[0].SubItems[0].Text));
                if (sonuc != 0)
                {
                    MessageBox.Show("silme işlemi başarılı");
                    cm.MusteriGetir(lvMusteriler);
                }
                else
                {
                    MessageBox.Show("silme işlemi başarısız");
                }
            }
            else
            {
                MessageBox.Show("silme işleminden vazgeçildi");
            }

        }
    }
}
