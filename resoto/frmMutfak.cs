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
    public partial class frmMutfak : Form
    {
        public frmMutfak()
        {
            InitializeComponent();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("çıkmak istermisiniz?", "uyarı!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            frmMenu frmMenu = new frmMenu();
            this.Close();
            frmMenu.Show();
        }

        private void frmMutfak_Load(object sender, EventArgs e)
        {
            pnlUrunler.Visible = false;
            pnlKategori.Visible = false;

            UrunCesidi uc = new UrunCesidi();
            uc.KategorileriListele(cbKategoriler);
            uc.KategorileriListele(lvKategoriler);

            cbKategoriler.Items.Insert(0, "Tüm Kategoriler");
            cbKategoriler.SelectedIndex = 0;
            label6.Visible = false;
            txtAra.Visible = false;

            cUrunler cu = new cUrunler();
            cu.urunListele(lvUrunler);

            btnOk.Visible = false;
            
        }

        private void temizle()
        {
            txtUrunAd.Clear();
            txtUrunFiyat.Text = String.Format("{0:##0.00}", 0);
            txtUrunId.Clear();
            txtKategoriId.Clear();
            cbKategoriler.SelectedIndex = 0;

            txtKatAciklama.Clear();
            txtKategoriAd.Clear();
            txtKatId.Clear();
        }

        private void yenile()
        {
            UrunCesidi uc = new UrunCesidi();
            uc.KategorileriListele(cbKategoriler);
            uc.KategorileriListele(lvKategoriler);

            cUrunler cu = new cUrunler();
            cu.urunListele(lvUrunler);
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (rbUrun.Checked == true)
            {
                if (txtUrunAd.Text.Trim() == "" || txtUrunFiyat.Text.Trim() == "" || cbKategoriler.SelectedItem.ToString() == "Tüm Kategoriler")
                {
                    MessageBox.Show("Lütfen ilgili alanları doldurunuz.");
                }
                else
                {
                    cUrunler cu = new cUrunler();

                    cu.UrunAd = txtUrunAd.Text;
                    cu.Fiyat = Convert.ToDecimal(txtUrunFiyat.Text);
                    cu.Aciklama = txtUrunAd.Text;
                    cu.UrunTurNo = Convert.ToInt32(txtKategoriId.Text);
                    int sonuc = cu.urunEkle(cu);
                    if (sonuc != 0)
                    {
                        MessageBox.Show("ürün başarıyla eklenmiştir.");
                        cbKategoriler_SelectedIndexChanged(sender, e);
                        temizle();
                        yenile();
                    }
                    else
                    {
                        MessageBox.Show("Ürün ekleme başarısız olmuştur.");
                    }
                }
            }
            else if (rbKategori.Checked == true)
            {
                if (txtKategoriAd.Text.Trim() == "")
                {
                    MessageBox.Show("Lütfen kategori adı giriniz.");
                }
                else
                {
                    UrunCesidi uc = new UrunCesidi();
                    uc.KategoriAd = txtKategoriAd.Text;
                    uc.Aciklama = txtKatAciklama.Text;
                    int sonuc = uc.kategoriEkle(uc);
                    if (sonuc != 0)
                    {
                        MessageBox.Show("Ürün başarılı şekilde eklenmiştir.");
                        uc.KategorileriListele(lvKategoriler);
                        temizle();
                        yenile();
                    }
                    else
                    {
                        MessageBox.Show("Ürün eklenmede başarısız olmuştur.");
                    }
                }
            }
            else
            {
                MessageBox.Show("güncellemek istediğiniz bölümü seçiniz.");
            }
        }

        int urunTurNo = 0;
        private void cbKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            cUrunler cu = new cUrunler();
            if (cbKategoriler.SelectedItem.ToString() == "Tüm Kategoriler")
            {
                cu.urunListele(lvUrunler);
            }
            else
            {
                UrunCesidi uc = (UrunCesidi)cbKategoriler.SelectedItem;
                urunTurNo = uc.UrunTurNo;
                txtKategoriId.Text = uc.UrunTurNo.ToString();
                cu.urunleriListeleId(lvUrunler, urunTurNo);
            }
        }

        private void btnDegistir_Click(object sender, EventArgs e)
        {
            if (rbUrun.Checked == true)
            {
                if (txtUrunAd.Text.Trim() == "" || txtUrunFiyat.Text.Trim() == "" || txtUrunId.Text.Trim() == "")
                {
                    MessageBox.Show("Lütfen ilgili alanları doldurunuz.");
                }
                else
                {
                    cUrunler cu = new cUrunler();

                    cu.UrunAd = txtUrunAd.Text;
                    cu.Fiyat = Convert.ToDecimal(txtUrunFiyat.Text);
                    cu.Aciklama = txtUrunAd.Text;
                    cu.UrunId = Convert.ToInt32(txtUrunId.Text);
                    cu.UrunTurNo = Convert.ToInt32(txtKategoriId.Text);
                    int sonuc = cu.urunGuncelle(cu);
                    if (sonuc != 0)
                    {
                        MessageBox.Show("ürün başarıyla güncellenmiştir.");
                        cbKategoriler_SelectedIndexChanged(sender, e);
                        temizle();
                        yenile();
                    }
                    else
                    {
                        MessageBox.Show("Ürün güncelleme başarısız olmuştur.");
                    }
                }
            }
            else if (rbKategori.Checked == true)
            {
                if (txtKatId.Text.Trim() == "")
                {
                    MessageBox.Show("Lütfen kategori seçiniz.");
                }
                else
                {
                    UrunCesidi uc = new UrunCesidi();
                    uc.KategoriAd = txtKategoriAd.Text;
                    uc.Aciklama = txtKatAciklama.Text;
                    uc.UrunTurNo = Convert.ToInt32(txtKatId.Text);
                    int sonuc = uc.kategoriGuncelle(uc);
                    if (sonuc != 0)
                    {
                        MessageBox.Show("Kategori başarılı şekilde güncellenmiştir.");
                        uc.KategorileriListele(lvKategoriler);
                        temizle();
                        yenile();
                    }
                    else
                    {
                        MessageBox.Show("Kategori güncelleme başarısız olmuştur.");
                    }
                }
            }
            else
            {
                MessageBox.Show("hangi işlemi yapacağınızı seçin.");
            }
        }

        private void lvUrunler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvUrunler.SelectedItems.Count > 0)
            {
                txtUrunAd.Text = lvUrunler.SelectedItems[0].SubItems[3].Text;
                txtUrunFiyat.Text = lvUrunler.SelectedItems[0].SubItems[4].Text;
                txtKategoriId.Text = lvUrunler.SelectedItems[0].SubItems[1].Text;
                txtUrunId.Text = lvUrunler.SelectedItems[0].SubItems[0].Text;
                //cbKategoriler.SelectedIndex = Convert.ToInt32(txtUrunKatId.Text);
            }
        }

        private void lvKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvKategoriler.SelectedItems.Count > 0)
            {
                txtKategoriAd.Text = lvKategoriler.SelectedItems[0].SubItems[1].Text;
                txtKatAciklama.Text = lvKategoriler.SelectedItems[0].SubItems[2].Text;
                txtKatId.Text = lvKategoriler.SelectedItems[0].SubItems[0].Text;
                //cbKategoriler.SelectedIndex = Convert.ToInt32(txtUrunKatId.Text);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (rbUrun.Checked == true)
            {
                if (lvUrunler.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Lütfen silmek istediğiniz ürünü seçiniz.");
                }
                else
                {
                    cUrunler cu = new cUrunler();
                    cu.UrunId = Convert.ToInt32(txtUrunId.Text);
                    int sonuc = cu.urunSil(cu);

                    if (sonuc != 0 && MessageBox.Show(txtUrunAd.Text + " isimli ürün silinsin mi ?","Bilgiler Silinecek!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        MessageBox.Show("ürün başarıyla silinmiştir.");
                        cbKategoriler_SelectedIndexChanged(sender, e);
                        temizle();
                        yenile();
                    }
                    else
                    {
                        MessageBox.Show("Ürün silme başarısız olmuştur.");
                    }
                }
            }
            else if (rbKategori.Checked == true)
            {
                if (lvKategoriler.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Lütfen silmek için bir kategori seçiniz.");
                }
                else
                {
                    UrunCesidi uc = new UrunCesidi();
                    uc.UrunTurNo = Convert.ToInt32(txtKatId.Text);
                    int sonuc = uc.kategoriSil(uc);
                    if (sonuc != 0 && MessageBox.Show(txtKategoriAd.Text + " isimli kategori silinsin mi ?", "Bilgiler Silinecek!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        MessageBox.Show("Kategori başarılı şekilde silinmiştir.");
                        temizle();
                        yenile();
                    }
                    else
                    {
                        MessageBox.Show("Kategori silme başarısız olmuştur.");
                    }
                }
            }
            else
            {
                MessageBox.Show("hangi işlemi yapacağınızı seçin.");
            }
        }

        private void btnBul_Click(object sender, EventArgs e)
        {
            label6.Visible = true;
            txtAra.Visible = true;
            btnOk.Visible = true;
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            if (rbUrun.Checked == true)
            {
                cUrunler cu = new cUrunler();
                cu.urunleriListeleUrunAdi(lvUrunler, txtAra.Text.Trim());
            }
            else if (rbKategori.Checked == true)
            {
                UrunCesidi uc = new UrunCesidi();
                uc.KategorileriListele(lvKategoriler, txtAra.Text.Trim());
            }
            else
            {
                MessageBox.Show("İşlem yapmak istediğiniz kategoriyi en üstten seçiniz");
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            txtAra.Text = "";
            txtAra.Visible = false;
            btnOk.Visible = false;
            label6.Visible = false;
        }

        private void rbUrun_CheckedChanged(object sender, EventArgs e)
        {
            pnlKategori.Visible = false;
            pnlUrunler.Visible = true;
            pnlUrunler.Location = new System.Drawing.Point(750, 229);
        }

        private void rbKategori_CheckedChanged(object sender, EventArgs e)
        {
            pnlKategori.Visible = true;
            pnlUrunler.Visible = false;
            pnlKategori.Location = new System.Drawing.Point(750, 229);
        }
    }
}
