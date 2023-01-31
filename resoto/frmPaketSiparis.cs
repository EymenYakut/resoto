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
    public partial class frmPaketSiparis : Form
    {
        public frmPaketSiparis()
        {
            InitializeComponent();
        }

        private void frmPaketSiparis_Load(object sender, EventArgs e)
        {
             cMusteriler cm = new cMusteriler();
            cm.MusteriGetir(lvMusteriler);
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

        private void btnSiparisler_Click(object sender, EventArgs e)
        {
            frmSiparisKontrol sk = new frmSiparisKontrol();
            this.Close();
            sk.Show();
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

        private void btnMusteriEkle_Click(object sender, EventArgs e)
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

        private void btnSiparisAc_Click(object sender, EventArgs e)
        {
            frmSiparis fs = new frmSiparis();
            cGenel cg = new cGenel();
            if (lvMusteriler.SelectedItems.Count>0)
            {
                cGenel._musteriId = Convert.ToInt32(lvMusteriler.SelectedItems[0].SubItems[0].Text);
                cGenel._ButtonDeğer = Convert.ToString(lvMusteriler.SelectedItems[0].SubItems[1].Text + " " + lvMusteriler.SelectedItems[0].SubItems[2].Text);
                cGenel._MasaId = 0;

                cGenel._sayfaNo = 1;
                this.Close();
                fs.Show();
            }
            else
            {
                MessageBox.Show("Lütfen bir müşteri seçiniz.");
            }

        }
    }
}