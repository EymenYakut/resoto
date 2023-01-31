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
    public partial class frmAcikRezervasyonlar : Form
    {
        public frmAcikRezervasyonlar()
        {
            InitializeComponent();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            frmRezervasyon fm = new frmRezervasyon();
            fm.Show();
            this.Close();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("çıkmak istermisiniz?", "uyarı!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void frmAcikRezervasyonlar_Load(object sender, EventArgs e)
        {
            cRezervasyon cr = new cRezervasyon();
            cr.AcikRezerv(lvRezerv);
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("rezervasyon iptal edilsin mi ? ","Uyarı",MessageBoxButtons.OKCancel)==DialogResult.OK)
            {
                cRezervasyon cr = new cRezervasyon();
                cMasalar cm = new cMasalar();

                cm.MasaDurumunuDegis(Convert.ToInt32(lvRezerv.SelectedItems[0].SubItems[3].Text),1);
                int sonuc = cr.RezervasyonSil(Convert.ToInt32(lvRezerv.SelectedItems[0].SubItems[0].Text));

                if (sonuc != 0)
                {
                    MessageBox.Show("iptal edilmiştir");
                    cr.AcikRezerv(lvRezerv);
                }
                else
                {
                    MessageBox.Show("iptal edilme başarısız olmuştur");
                }
            }
            else
            {
                MessageBox.Show("iptal edilme başarısız olmuştur");
            }

        }
    }
}
