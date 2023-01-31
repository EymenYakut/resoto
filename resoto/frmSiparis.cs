using resoto.Enum;
using System;
using System.Collections;
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
    public partial class frmSiparis : Form
    {
        public frmSiparis()
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
            if (lblGeldigiSayfa.Text == "1")
            {
                frmPaketSiparis fp = new frmPaketSiparis();
                this.Close();
                fp.Show();
            }
            else
            {
                frmMasalar fm = new frmMasalar();
                this.Close();
                fm.Show();
            }

        }

        //hesap işlemi

        void islem(Object sender, EventArgs e)
        {
            Button btn = sender as Button;

            switch (btn.Name)
            {
                case "btn1":
                    txtAdet.Text += (1).ToString();
                    break;
                case "btn2":
                    txtAdet.Text += (2).ToString();
                    break;
                case "btn3":
                    txtAdet.Text += (3).ToString();
                    break;
                case "btn4":
                    txtAdet.Text += (4).ToString();
                    break;
                case "btn5":
                    txtAdet.Text += (5).ToString();
                    break;
                case "btn6":
                    txtAdet.Text += (6).ToString();
                    break;
                case "btn7":
                    txtAdet.Text += (7).ToString();
                    break;
                case "btn8":
                    txtAdet.Text += (8).ToString();
                    break;
                case "btn9":
                    txtAdet.Text += (9).ToString();
                    break;
                case "btn0":
                    txtAdet.Text += (0).ToString();
                    break;
                default:
                    MessageBox.Show("sayı giriniz.");
                    break;

            }
        }

        int masaId; int adisyonId;
       
        private void frmPaket_Load(object sender, EventArgs e)
        {
            lblGeldigiSayfa.Text = cGenel._sayfaNo.ToString();

            pnlAdet.Visible = true;
            lblMasaNo.Text = cGenel._ButtonDeğer;

            cSiparis cs = new cSiparis();
            cs.BosMasaGoster(lvMusaitMasalar);

            cMasalar ms = new cMasalar();
            masaId = cGenel._MasaId;

            if (ms.MasaDurumu(masaId,(int)Durumlar.Dolu) == true)
            {
                cAdisyon Ad = new cAdisyon();
                adisyonId = Ad.AdisyonGetir(masaId);
                cSiparis siparis = new cSiparis();
                siparis.SiparisGetir(lvSiparis, adisyonId);
            }

            btn1.Click += new EventHandler(islem);
            btn2.Click += new EventHandler(islem);
            btn3.Click += new EventHandler(islem);
            btn4.Click += new EventHandler(islem);
            btn5.Click += new EventHandler(islem);
            btn6.Click += new EventHandler(islem);
            btn7.Click += new EventHandler(islem);
            btn8.Click += new EventHandler(islem);
            btn9.Click += new EventHandler(islem);
            btn0.Click += new EventHandler(islem);

        }
        UrunCesidi uc = new UrunCesidi();
        private void btnAnaYemek1_Click(object sender, EventArgs e)
        {
            uc.UrunCesidiGetir(lvMenu, btnAnaYemek1);
        }
        private void btnIzgara2_Click(object sender, EventArgs e)
        {
            uc.UrunCesidiGetir(lvMenu, btnIzgara2);
        }
        private void btnTatlı3_Click(object sender, EventArgs e)
        {
            uc.UrunCesidiGetir(lvMenu, btnTatlı3);
        }
        private void btnIcecek4_Click(object sender, EventArgs e)
        {
            uc.UrunCesidiGetir(lvMenu, btnIcecek4);
        }
        private void btnSalata5_Click(object sender, EventArgs e)
        {
            uc.UrunCesidiGetir(lvMenu, btnSalata5);
        }
        private void btnCorba6_Click(object sender, EventArgs e)
        {
            uc.UrunCesidiGetir(lvMenu, btnCorba6);
        }


        int sayac = 0; int sayac2 = 0;
        private void lvMenu_DoubleClick(object sender, EventArgs e)
        {

            if (txtAdet.Text=="")
            {
                txtAdet.Text = "1"; //adeti otomatik olarak 1 yapıyor ürünü seçince
            }

            if (lvMenu.Items.Count>0)//item lvmenu'de var mı?
            {

                sayac = lvSiparis.Items.Count;
                lvSiparis.Items.Add(lvMenu.SelectedItems[0].Text);
                lvSiparis.Items[sayac].SubItems.Add(txtAdet.Text);//adeti alırız txtadetten
                lvSiparis.Items[sayac].SubItems.Add(lvMenu.SelectedItems[0].SubItems[2].Text);//fiyat bilgisini aktardık
                lvSiparis.Items[sayac].SubItems.Add((Convert.ToDecimal(lvMenu.SelectedItems[0].SubItems[1].Text) * Convert.ToDecimal(txtAdet.Text)).ToString());//fiyatı adetle çarpıp fiyat kısmına yazıyoruz
                lvSiparis.Items[sayac].SubItems.Add("0");
                sayac2 = lvYeniEklenenler.Items.Count;
                lvSiparis.Items[sayac].SubItems.Add(sayac2.ToString());


                lvYeniEklenenler.Items.Add((adisyonId).ToString());
                lvYeniEklenenler.Items[sayac2].SubItems.Add(lvMenu.SelectedItems[0].SubItems[2].Text);
                lvYeniEklenenler.Items[sayac2].SubItems.Add(txtAdet.Text);
                lvYeniEklenenler.Items[sayac2].SubItems.Add(masaId.ToString());
                lvYeniEklenenler.Items[sayac2].SubItems.Add(sayac2.ToString());

                sayac2++;

                txtAdet.Text = "";
            }

        }

        ArrayList silinenler = new ArrayList();

        private void btnSiparis_Click(object sender, EventArgs e)
        {
            if (masaId != 0)
            {

                cMasalar masa = new cMasalar();
                cAdisyon yeniAdisyon = new cAdisyon();
                cSiparis SiparisKaydet = new cSiparis();
                frmMasalar frmMasalar = new frmMasalar();
                cRezervasyon cr = new cRezervasyon();
                bool sonuc = false;

                if (masa.MasaDurumu(masaId, (int)Durumlar.Boş) == true) // masa durumu 1 ise yani boş ise
                {
                
                 yeniAdisyon.SERVISTURNO = 1;
                 yeniAdisyon.PERSONELID = 1;
                  yeniAdisyon.MASAID = masaId;
                 yeniAdisyon.TARIH = DateTime.Now;
                 sonuc = yeniAdisyon.AdisyonAc(yeniAdisyon);
                 masa.MasaDurumunuDegis(masaId, 2);

                  if (lvSiparis.Items.Count > 0) //kayıt 0 dan büyükse bilgileri veri tabanına geçir
                 {

                     for (int i = 0; i < lvSiparis.Items.Count; i++)
                     {
                         SiparisKaydet.MasaId = masaId;
                         SiparisKaydet.UrunId = Convert.ToInt32(lvSiparis.Items[i].SubItems[2].Text);
                         SiparisKaydet.AdisyonId = yeniAdisyon.AdisyonGetir(masaId);
                         SiparisKaydet.Adet = Convert.ToInt32(lvSiparis.Items[i].SubItems[1].Text);
                         SiparisKaydet.SiparisKaydet(SiparisKaydet);
                     }
                     this.Close();
                     frmMasalar.Show();
                 }
             }
             else if (masa.MasaDurumu(masaId, (int)Durumlar.Dolu) == true)
             {
                
                  if (lvYeniEklenenler.Items.Count > 0) //kayıt 0 dan büyükse bilgileri veri tabanına geçir
                  {

                       for (int i = 0; i < lvYeniEklenenler.Items.Count; i++)
                       {
                           SiparisKaydet.MasaId = masaId;
                            SiparisKaydet.UrunId = Convert.ToInt32(lvYeniEklenenler.Items[i].SubItems[1].Text);
                            SiparisKaydet.AdisyonId = yeniAdisyon.AdisyonGetir(masaId);
                            SiparisKaydet.Adet = Convert.ToInt32(lvYeniEklenenler.Items[i].SubItems[2].Text);
                            SiparisKaydet.SiparisKaydet(SiparisKaydet);
                        }
                    

                    }
                    if (silinenler.Count > 0) //burayı bir ürünü ekledikten sonra sipariş ekranı kapanmadan silersek ürünü onu silmek için yapılı
                    {
                        foreach (string item in silinenler)
                        {
                            SiparisKaydet.SiparisSil(Convert.ToInt32(item));
                        }
                    }

                    this.Close();
                    frmMasalar.Show();

                }

               else if (masa.MasaDurumu(masaId, (int)Durumlar.Rezerve) == true)
               {
                    yeniAdisyon.SERVISTURNO = 1;
                    yeniAdisyon.PERSONELID = 1;
                 yeniAdisyon.MASAID = masaId;
                    yeniAdisyon.TARIH = DateTime.Now;
                    sonuc = yeniAdisyon.AdisyonAc(yeniAdisyon);
                    cr.RezervasyonSilSiparis(masaId);
                    masa.MasaDurumunuDegis(masaId, 2);

                    //cRezervasyon cr = new cRezervasyon();
                    //cr.RezervasyonSil();
                    if (lvSiparis.Items.Count > 0) //kayıt 0 dan büyükse bilgileri veri tabanına geçir
                 {

                    for (int i = 0; i < lvSiparis.Items.Count; i++)
                    {
                        SiparisKaydet.MasaId = masaId;
                        SiparisKaydet.UrunId = Convert.ToInt32(lvSiparis.Items[i].SubItems[2].Text);
                        SiparisKaydet.AdisyonId = yeniAdisyon.AdisyonGetir(masaId);
                        SiparisKaydet.Adet = Convert.ToInt32(lvSiparis.Items[i].SubItems[1].Text);
                        SiparisKaydet.SiparisKaydet(SiparisKaydet);
                    }
                    this.Close();
                    frmMasalar.Show();
                 }
               }
            
            }
            else
            {
                cAdisyon yeniAdisyon = new cAdisyon();
                cPaketler cp = new cPaketler();
                cSiparis SiparisKaydet = new cSiparis();

                yeniAdisyon.SERVISTURNO = 2;
                yeniAdisyon.PERSONELID = 1;
                yeniAdisyon.MASAID = masaId;
                yeniAdisyon.TARIH = DateTime.Now;
                yeniAdisyon.DURUM = 0;
                cp.MUSTERIID = cGenel._musteriId;
                cp.ODEMETURID = 1;
                cp.ACIKLAMA = "NULL";
                cp.DURUM = 0;
                int sonuc = cp.PaketServisAc(cp, yeniAdisyon);
                
                if (sonuc != 0)
                {

                
                for (int i = 0; i < lvSiparis.Items.Count; i++)
                {
                    SiparisKaydet.MasaId = masaId;
                    SiparisKaydet.UrunId = Convert.ToInt32(lvSiparis.Items[i].SubItems[2].Text);
                        SiparisKaydet.AdisyonId = sonuc;
                    SiparisKaydet.Adet = Convert.ToInt32(lvSiparis.Items[i].SubItems[1].Text);
                    SiparisKaydet.SiparisKaydet(SiparisKaydet);
                }
                this.Close();
                frmPaketSiparis fps = new frmPaketSiparis();
                fps.Show();
                }
                else
                {
                    MessageBox.Show("işlem başarısız");
                }
            }
        }

        private void lvSiparis_DoubleClick(object sender, EventArgs e)
        {
            if (lvSiparis.Items.Count > 0) //lvsiparis de ürün var mı?
            {
                if (lvSiparis.SelectedItems[0].SubItems[4].Text != "0") //satış ıd'si 0 değilse..
                {
                    cSiparis siparisKaydet = new cSiparis();
                    siparisKaydet.SiparisSil(Convert.ToInt32(lvSiparis.SelectedItems[0].SubItems[4].Text));
                }
                else
                {
                    for (int i = 0; i < lvYeniEklenenler.Items.Count; i++) //silinenId'si 0 ise yeni eklenenlerden sil
                    {
                        if (lvSiparis.Items[0].SubItems[4].Text == lvSiparis.Items[0].SubItems[5].Text)
                        {
                            lvYeniEklenenler.Items.RemoveAt(i);
                        }
                    }
                }

                lvSiparis.Items.RemoveAt(lvSiparis.SelectedItems[0].Index);
            }
        }

        private void txtUrunNo_TextChanged(object sender, EventArgs e)
        {
            if (txtUrunNo.Text =="")
            {
                txtUrunNo.Text = "";
            }
            else
            {
                UrunCesidi uc = new UrunCesidi();
                uc.ArananUrunuGetir(lvMenu, Convert.ToInt32(txtUrunNo.Text));
            }
            
        }

        private void btnOdeme_Click(object sender, EventArgs e)
        {
            cGenel._ServisTurNo = 1;
            cGenel._AdisyonId = adisyonId.ToString();
            cGenel._SayfaNo2 = 1;
            frmOdeme frmOdeme = new frmOdeme();
            frmOdeme.Show();
            this.Close();

        }

        private void btnIptal_Click(object sender, EventArgs e)
        {

            if (lvSiparis.Items.Count > 0) //lvsiparis de ürün var mı?
            {
                if (lvSiparis.SelectedItems.Count > 0)
                {


                    if (lvSiparis.SelectedItems[0].SubItems[4].Text != "0") //satış ıd'si 0 değilse..
                    {
                        cSiparis siparisKaydet = new cSiparis();
                        siparisKaydet.SiparisSil(Convert.ToInt32(lvSiparis.SelectedItems[0].SubItems[4].Text));
                    }
                    else
                    {
                        for (int i = 0; i < lvYeniEklenenler.Items.Count; i++) //silinenId'si 0 ise yeni eklenenlerden sil
                        {
                            if (lvSiparis.Items[0].SubItems[4].Text == lvSiparis.Items[0].SubItems[5].Text)
                            {
                                lvYeniEklenenler.Items.RemoveAt(i);
                            }
                        }
                    }

                    lvSiparis.Items.RemoveAt(lvSiparis.SelectedItems[0].Index);
                }
                else
                {
                    MessageBox.Show("Lütfen çıkartmak için bir ürün seçiniz.");
                }
               
            }
            

        }

        private void btnC_Click(object sender, EventArgs e)
        {
            txtAdet.Clear();
        }

        private void btnMasaAktar_Click(object sender, EventArgs e)
        {
            pnlAdet.Visible = false;

            pnlMasaAktar.Location = new Point(1372, 189); 
            pnlMasaAktar.Visible = true;
        }

        private void btnOnay_Click(object sender, EventArgs e)
        {
            cMasalar cm = new cMasalar();

            if (txtMusait.Text!=" ")
            {
                if (MessageBox.Show(txtMusait.Text + " no'lu masaya aktarım yapılsın mı?", "UYARI", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int sonuc = cm.MasaDegisAdisyonlar(Convert.ToInt32(txtMusait.Text), adisyonId);
                    int sonuc2 = cm.MasaDegisSatislar(Convert.ToInt32(txtMusait.Text), adisyonId);
                    if (sonuc != 0 && sonuc2 != 0)
                    {
                        cm.MasaDurumunuDegis(masaId, 1);
                        cm.MasaDurumunuDegis(Convert.ToInt32(txtMusait.Text), 2);
                        MessageBox.Show("Aktarım Yapıldı.");
                        frmMasalar fm = new frmMasalar();
                        this.Close();
                        fm.Show();
                    }
                    else
                    {
                        MessageBox.Show("masa dolu olduğu için aktarım yapılamadı.");
                    }
                }
                else
                {
                    MessageBox.Show("Aktarım yapılmadı.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen aktarım için masa no giriniz.");
            }
        }

        private void btnAktarIptal_Click(object sender, EventArgs e)
        {
            pnlAdet.Visible = true;
            pnlMasaAktar.Visible = false;
            txtMusait.Clear();
        }

        private void lvMusaitMasalar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtMusait.Text != "")
            {
                txtMusait.Clear();
                lvMusaitMasalar.Items.Clear();
                cSiparis cs = new cSiparis();
                cs.BosMasaGoster(lvMusaitMasalar);
            }
            else
            {
                txtMusait.Text = lvMusaitMasalar.SelectedItems[0].Text;
            }


        }

        private void txtUrunNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);//sadece rakam girişi yapmak için
        }
    }
}
