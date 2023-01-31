using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace resoto
{
    public partial class frmMasalar : Form
    {
        public frmMasalar()
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

        private void btnMasa1_Click(object sender, EventArgs e)
        {
            frmSiparis frmSiparis = new frmSiparis();
            int uzunluk = btnMasa1.Text.Length;

            cGenel._ButtonDeğer = btnMasa1.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonAd = btnMasa1.Name;
            cGenel._MasaId = btnMasa1.TabIndex;
            cGenel._sayfaNo = 2;
            this.Close();
            frmSiparis.Show();
        }

        private void btnMasa2_Click(object sender, EventArgs e)
        {
            frmSiparis frmSiparis = new frmSiparis();
            int uzunluk = btnMasa2.Text.Length;

            cGenel._ButtonDeğer = btnMasa2.Text.Substring(uzunluk - 6, 6);//substringle uzunluk kaç karakterse 6 çıkar ve 6.karakterden başlamak üzere al dedik
            cGenel._ButtonAd = btnMasa2.Name;
            cGenel._MasaId = btnMasa2.TabIndex;
            cGenel._sayfaNo = 2;
            this.Close();
            frmSiparis.Show();
        }

        private void btnMasa3_Click(object sender, EventArgs e)
        {
            frmSiparis frmSiparis = new frmSiparis();
            int uzunluk = btnMasa3.Text.Length;

            cGenel._ButtonDeğer = btnMasa3.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonAd = btnMasa3.Name;
            cGenel._MasaId = btnMasa3.TabIndex;
            cGenel._sayfaNo = 2;
            this.Close();
            frmSiparis.Show();
        }

        private void btnMasa4_Click(object sender, EventArgs e)
        {
            frmSiparis frmSiparis = new frmSiparis();
            int uzunluk = btnMasa4.Text.Length;

            cGenel._ButtonDeğer = btnMasa4.Text.Substring(uzunluk - 6, 6);//substringle uzunluk kaç karakterse 6 çıkar ve 6.karakterden başlamak üzere al dedik
            cGenel._ButtonAd = btnMasa4.Name;
            cGenel._MasaId = btnMasa4.TabIndex;
            cGenel._sayfaNo = 2;

            this.Close();
            frmSiparis.Show();
        }

        private void btnMasa5_Click(object sender, EventArgs e)
        {
            frmSiparis frmSiparis = new frmSiparis();
            int uzunluk = btnMasa5.Text.Length;

            cGenel._ButtonDeğer = btnMasa5.Text.Substring(uzunluk - 6, 6);//substringle uzunluk kaç karakterse 6 çıkar ve 6.karakterden başlamak üzere al dedik
            cGenel._ButtonAd = btnMasa5.Name;
            cGenel._MasaId = btnMasa5.TabIndex;
            cGenel._sayfaNo = 2;
            this.Close();
            frmSiparis.Show();
        }

        private void btnMasa6_Click(object sender, EventArgs e)
        {
            frmSiparis frmSiparis = new frmSiparis();
            int uzunluk = btnMasa6.Text.Length;

            cGenel._ButtonDeğer = btnMasa6.Text.Substring(uzunluk - 6, 6);//substringle uzunluk kaç karakterse 6 çıkar ve 6.karakterden başlamak üzere al dedik
            cGenel._ButtonAd = btnMasa6.Name;
            cGenel._MasaId = btnMasa6.TabIndex;
            cGenel._sayfaNo = 2;
            this.Close();
            frmSiparis.Show();
        }

        private void btnMasa7_Click(object sender, EventArgs e)
        {
            frmSiparis frmSiparis = new frmSiparis();
            int uzunluk = btnMasa7.Text.Length;

            cGenel._ButtonDeğer = btnMasa7.Text.Substring(uzunluk - 6, 6);//substringle uzunluk kaç karakterse 6 çıkar ve 6.karakterden başlamak üzere al dedik
            cGenel._ButtonAd = btnMasa7.Name;
            cGenel._MasaId = btnMasa7.TabIndex;
            cGenel._sayfaNo = 2;
            this.Close();
            frmSiparis.Show();
        }

        private void btnMasa8_Click(object sender, EventArgs e)
        {
            frmSiparis frmSiparis = new frmSiparis();
            int uzunluk = btnMasa8.Text.Length;

            cGenel._ButtonDeğer = btnMasa8.Text.Substring(uzunluk - 6, 6);//substringle uzunluk kaç karakterse 6 çıkar ve 6.karakterden başlamak üzere al dedik
            cGenel._ButtonAd = btnMasa8.Name;
            cGenel._MasaId = btnMasa8.TabIndex;
            cGenel._sayfaNo = 2;
            this.Close();
            frmSiparis.Show();
        }

        private void btnMasa9_Click(object sender, EventArgs e)
        {
            frmSiparis frmSiparis = new frmSiparis();
            int uzunluk = btnMasa9.Text.Length;

            cGenel._ButtonDeğer = btnMasa9.Text.Substring(uzunluk - 6, 6);//substringle uzunluk kaç karakterse 6 çıkar ve 6.karakterden başlamak üzere al dedik
            cGenel._ButtonAd = btnMasa9.Name;
            cGenel._MasaId = btnMasa9.TabIndex;
            cGenel._sayfaNo = 2;
            this.Close();
            frmSiparis.Show();
        }

        private void btnMasa10_Click(object sender, EventArgs e)
        {
            frmSiparis frmSiparis = new frmSiparis();
            int uzunluk = btnMasa10.Text.Length;

            cGenel._ButtonDeğer = btnMasa10.Text.Substring(uzunluk - 7, 7);
            cGenel._ButtonAd = btnMasa10.Name;
            cGenel._MasaId = btnMasa10.TabIndex;
            cGenel._sayfaNo = 2;
            this.Close();
            frmSiparis.Show();
        }

        cGenel gnl = new cGenel();
        private void frmMasalar_Load(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select DURUM,ID From masalar",con);
            SqlDataReader dr = null;

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                foreach (Control item in this.Controls)
                {
                    if (item is Button)
                    {
                        if (item.Name == "btnMasa" + dr["ID"].ToString() && dr["DURUM"].ToString() == "1")//masa numarası ve durumu 1 ise dedik
                        {
                            item.ForeColor = Color.Green;
                        }
                        else if (item.Name == "btnMasa" + dr["ID"].ToString() && dr["DURUM"].ToString() == "2")
                        {

                            cMasalar ms = new cMasalar();

                            DateTime dt = Convert.ToDateTime(ms.SessionSum(2,dr["ID"].ToString()));//datetime ile gelen değeri aldık
                            DateTime dt2 = DateTime.Now;//Şu an ki zamanı aldık

                            string st = Convert.ToDateTime(ms.SessionSum(2, dr["ID"].ToString())).ToShortTimeString();//gelen değerin kısa saatini aldık
                            string st2 = DateTime.Now.ToShortTimeString();//şu anın kısa saatini aldık

                            DateTime t = dt.AddMinutes(DateTime.Parse(st).TimeOfDay.TotalMinutes);//günü parse edip toplam dakikayı bulduk
                            DateTime t2 = dt2.AddMinutes(DateTime.Parse(st2).TimeOfDay.TotalMinutes);

                            var fark = t2 - t;

                            item.Text = String.Format("{0}{1}{2}",
                                fark.Days > 0 ? string.Format("{0} gün", fark.Days):"", //Burada ki ?, if yerine kullanılmıştır eğer gün değeri 0'ın üstündeyse formata yazdır 
                                fark.Hours > 0 ? string.Format("{0} saat", fark.Hours):"",
                                fark.Minutes > 0 ? string.Format("{0} dakika", fark.Minutes) : "").Trim() + "\n\n\nMasa" + dr["ID"].ToString();

                            item.ForeColor = Color.Red;
                        }
                        else if (item.Name == "btnMasa" + dr["ID"].ToString() && dr["DURUM"].ToString() == "3")
                        {
                            item.ForeColor = Color.Yellow;
                        }
                    }
                }
            }
        }
    }
}
