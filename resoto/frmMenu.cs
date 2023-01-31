using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessagingToolkit.QRCode.Codec;

namespace resoto
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void btnMasaSiparis_Click(object sender, EventArgs e)
        {
            frmMasalar frmMasa = new frmMasalar();
            this.Close();
            frmMasa.Show();
        }

        private void btnRezervasyon_Click(object sender, EventArgs e)
        {
            frmRezervasyon frmRezerv = new frmRezervasyon();
            this.Close();
            frmRezerv.Show();
        }

        private void btnPaket_Click(object sender, EventArgs e)
        {
            frmPaketSiparis frmPaket = new frmPaketSiparis();
            this.Close();
            frmPaket.Show();
        }

        private void btnMusteri_Click(object sender, EventArgs e)
        {
            frmMusteriAra frmMusteri = new frmMusteriAra();
            this.Close();
            frmMusteri.Show();
        }

        private void btnKasa_Click(object sender, EventArgs e)
        {
            frmKasa frmKasa = new frmKasa();
            this.Close();
            frmKasa.Show();
        }

        private void btnMutfak_Click(object sender, EventArgs e)
        {
            frmMutfak frmMutfak = new frmMutfak();
            this.Close();
            frmMutfak.Show();
        }


        private void btnAyarlar_Click(object sender, EventArgs e)
        {
            frmAyarlar frmAyarlar = new frmAyarlar();
            this.Close();
            frmAyarlar.Show();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("çıkmak istermisiniz?", "uyarı!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnHesapKapat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("hesabı kapatmak istermisiniz?", "uyarı!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                frmGiris fg = new frmGiris();
                this.Close();
                fg.Show();
            }
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            cGenel._SayfaNo2 = 0;
        }
    }
}
