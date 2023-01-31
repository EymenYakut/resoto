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
    public partial class frmKasa : Form
    {
        public frmKasa()
        {
            InitializeComponent();
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

        private void btnAylikRapor_Click(object sender, EventArgs e)
        {
            double toplam = 0.0;
            btnZraporAl.Visible = false;
            dtpBaslangic.Value = DateTime.Now.AddMonths(-1);
            dtpBitis.Value = DateTime.Now;
            cUrunler cu = new cUrunler();
            cu.urunleriListeleIstatislik(lvListe, dtpBaslangic.Value, dtpBitis.Value);
            for (int i = 0; i < lvListe.Items.Count; i++)
            {
                toplam += Convert.ToDouble(lvListe.Items[i].SubItems[2].Text);
            }
            lblToplamTutar.Text = toplam.ToString();
        }

        private void frmKasa_Load(object sender, EventArgs e)
        {
            pnlZrapor.Visible = false;
            pnlUrun.Visible = false;

            cbKategoriler.Items.Insert(0, "Tüm Kategoriler");

            double toplam = 0.0;

            cUrunler cu = new cUrunler();
            cu.urunleriListeleIstatislik(lvListe, dtpBaslangic.Value, dtpBitis.Value);

            UrunCesidi uc = new UrunCesidi();
            uc.KategorileriListele(cbKategoriler);

            cu.zRaporTabloGoster(lvZrapor);

            for (int i = 0; i < lvListe.Items.Count; i++)
            {
                toplam += Convert.ToDouble(lvListe.Items[i].SubItems[2].Text);
            }
            lblToplamTutar.Text = toplam.ToString();
        }

        private void btnZrapor_Click(object sender, EventArgs e)
        {
            double toplam = 0.0;
            dtpBitis.Value = DateTime.Now;
            dtpBaslangic.Value = DateTime.Now;
            cUrunler cu = new cUrunler();
            cu.zRaporuListele(lvListe, dtpBitis.Value);

            for (int i = 0; i < lvListe.Items.Count; i++)
            {
                toplam += Convert.ToDouble(lvListe.Items[i].SubItems[2].Text);
            }
            lblToplamTutar.Text = toplam.ToString();
            btnZraporAl.Visible = true;


        }

        private void btnZraporAl_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Z raporu almak istediğinize emin misiniz ?", "Uyarı", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (lvListe.Items.Count > 0)
                {
                    cUrunler cu = new cUrunler();
                    dtpBitis.Value = DateTime.Now;

                   int sonuc = cu.zRaporEkle(dtpBitis.Value, Convert.ToInt32(lblToplamTutar.Text));
                    if (sonuc != 0)
                    {
                        MessageBox.Show("Z raporu alınmıştır");
                    }
                    else
                    {
                        MessageBox.Show("Z raporu alma işlemi başarısız olmuştur"); ;
                    }
                }
                else
                {
                    MessageBox.Show("Bugün herhangi bir satışınız bulunmamaktadır.");
                }
            }
            else
            {
                MessageBox.Show("z raporu alınmamıştır.");
            }


        }

        private void cbKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            double toplam = 0.0;

            cUrunler cu = new cUrunler();

            if (cbKategoriler.SelectedIndex == 0)
            {
                cu.urunleriListeleIstatislik(lvListe, dtpBaslangic.Value, dtpBitis.Value);
            }
            else
            {
                cu.urunleriListeleIstatislikKatId(lvListe, dtpBaslangic.Value, dtpBitis.Value, cbKategoriler.SelectedIndex);
            }

            for (int i = 0; i < lvListe.Items.Count; i++)
            {
                toplam += Convert.ToDouble(lvListe.Items[i].SubItems[2].Text);
            }
            lblToplamTutar.Text = toplam.ToString();

        }

        private void btnYillik_Click(object sender, EventArgs e)
        {
            double toplam = 0.0;
            btnZraporAl.Visible = false;
            dtpBaslangic.Value = DateTime.Now.AddYears(-1);
            dtpBitis.Value = DateTime.Now;
            cUrunler cu = new cUrunler();
            cu.urunleriListeleIstatislik(lvListe, dtpBaslangic.Value, dtpBitis.Value);
            for (int i = 0; i < lvListe.Items.Count; i++)
            {
                toplam += Convert.ToDouble(lvListe.Items[i].SubItems[2].Text);
            }
            lblToplamTutar.Text = toplam.ToString();
        }

        private void rbZrapor_CheckedChanged(object sender, EventArgs e)
        {
            cUrunler cu = new cUrunler();
            cu.zRaporTabloGoster(lvZrapor);
            pnlZrapor.Visible = true;
            pnlUrun.Visible = false;
            pnlZrapor.Location = new Point(700, 118);
        }

        private void rbUrunSatis_CheckedChanged(object sender, EventArgs e)
        {
            cUrunler cu = new cUrunler();
            cu.urunleriListeleIstatislik(lvListe, dtpBaslangic.Value, dtpBitis.Value);

            UrunCesidi uc = new UrunCesidi();
            uc.KategorileriListele(cbKategoriler);

            cbKategoriler.Items.Insert(0, "Tüm Kategoriler");
            pnlZrapor.Visible = false;
            pnlUrun.Visible = true;
            pnlUrun.Location = new Point(600, 118);
        }

        private void btnIkiTarih_Click(object sender, EventArgs e)
        {
            cUrunler cu = new cUrunler();
            cu.urunleriListeleIstatislik(lvListe, dtpBaslangic.Value, dtpBitis.Value);
        }
    }
}
