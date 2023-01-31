using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace resoto
{
    internal class cPersoneller
    {
        cGenel gnl = new cGenel();

        private int _PersonelId;
        private int _PersonelGorevId;
        private string _PersonelAd;
        private string _PersonelSoyad;
        private string _PersonelParola;
        private string _PersonelKullaniciAdi;
        private bool _PersonelDurum;

        public int PersonelId { get => _PersonelId; set => _PersonelId = value; }
        public int PersonelGorevId { get => _PersonelGorevId; set => _PersonelGorevId = value; }
        public string PersonelAd { get => _PersonelAd; set => _PersonelAd = value; }
        public string PersonelSoyad { get => _PersonelSoyad; set => _PersonelSoyad = value; }
        public string PersonelParola { get => _PersonelParola; set => _PersonelParola = value; }
        public string PersonelKullaniciAdi { get => _PersonelKullaniciAdi; set => _PersonelKullaniciAdi = value; }
        public bool PersonelDurum { get => _PersonelDurum; set => _PersonelDurum = value; }

        



        public bool personelGirisKontrol(string Sifre,int kullanıcıID)
        {

            bool sonuc = false;
            
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("personelGirisKontrol", con);

            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = kullanıcıID;
            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = Sifre;
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                sonuc = Convert.ToBoolean(cmd.ExecuteScalar());
            }
            catch (SqlException ex)
            {

                string hata = ex.Message;
                throw;
            }
            
            return sonuc;
        }

        public void personelBilgileri(ComboBox cb)
        {
            cb.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("personelBilgileri", con);
            

            
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cPersoneller p = new cPersoneller();
                p._PersonelId = Convert.ToInt32(dr["ID"]);
                p._PersonelGorevId = Convert.ToInt32(dr["GOREVID"]);
                p._PersonelAd = Convert.ToString(dr["AD"]);
                p._PersonelSoyad = Convert.ToString(dr["SOYAD"]);
                p._PersonelParola = Convert.ToString(dr["PAROLA"]);
                p._PersonelKullaniciAdi = Convert.ToString(dr["KULLANICIADI"]);
                p._PersonelDurum = Convert.ToBoolean(dr["DURUM"]);
                cb.Items.Add(p);

            }
            dr.Close();
            con.Close();

        }

        public override string ToString()//comboBox'a isim bilgilerini almak için overload yaptık
        {
            return PersonelAd + " " + PersonelSoyad;
        }

        public void personelBilgileriniGetir(ListView lv)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("personelBilgileriniGetir", con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            cmd.CommandType = CommandType.StoredProcedure;

            int i = 0;
            while (dr.Read())
            {
                lv.Items.Add(dr["ID"].ToString());
                lv.Items[i].SubItems.Add(dr["GOREVID"].ToString());
                lv.Items[i].SubItems.Add(dr["GOREV"].ToString());
                lv.Items[i].SubItems.Add(dr["AD"].ToString());
                lv.Items[i].SubItems.Add(dr["SOYAD"].ToString());
                lv.Items[i].SubItems.Add(dr["KULLANICIADI"].ToString());
                i++;

            }
            dr.Close();
            con.Close();
        }

        public void personelBilgileriniGetirID(ListView lv, int perId)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("personelBilgileriniGetirID", con);

            cmd.Parameters.Add("perId",SqlDbType.Int).Value = perId;
            cmd.CommandType = CommandType.StoredProcedure;

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();

            int i = 0;
            while (dr.Read())
            {
                lv.Items.Add(dr["ID"].ToString());
                lv.Items[i].SubItems.Add(dr["GOREVID"].ToString());
                lv.Items[i].SubItems.Add(dr["GOREV"].ToString());
                lv.Items[i].SubItems.Add(dr["AD"].ToString());
                lv.Items[i].SubItems.Add(dr["SOYAD"].ToString());
                lv.Items[i].SubItems.Add(dr["KULLANICIADI"].ToString());
                i++;
            }
            dr.Close();
            con.Close();
        }

        public string personelBilgiGetir(int perId)
        {
            string sonuc = "";

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("personelBilgiGetir", con);

            cmd.Parameters.Add("perId", SqlDbType.Int).Value = perId;
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                sonuc = cmd.ExecuteScalar().ToString();
            }
            catch (Exception)
            {

                throw;
            }

            con.Close();
            return sonuc;
        }

        public bool personelSifreDegistir(int perId,string sifre)
        {

            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("personelSifreDegistir", con);

            cmd.Parameters.Add("perId", SqlDbType.Int).Value = perId;
            cmd.Parameters.Add("parola", SqlDbType.VarChar).Value = sifre;
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (Exception)
            {

                throw;
            }

            con.Close();
            return sonuc;

        }

        public bool personelEkle(cPersoneller cp)
        {

            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("personelEkle", con);
            
            cmd.Parameters.Add("AD", SqlDbType.VarChar).Value = _PersonelAd;
            cmd.Parameters.Add("SOYAD", SqlDbType.VarChar).Value = _PersonelSoyad;
            cmd.Parameters.Add("PAROLA", SqlDbType.VarChar).Value = _PersonelParola;
            cmd.Parameters.Add("GOREVID", SqlDbType.Int).Value = _PersonelGorevId;
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());

            }
            catch (Exception)
            {

                throw;
            }

            con.Close();
            return sonuc;

        }

        public bool personelGuncelle (cPersoneller cp, int perId)
        {

            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            // SqlCommand cmd = new SqlCommand("Update personeller set AD=@AD, SOYAD=@SOYAD, PAROLA=@PAROLA, GOREVID=@GOREVID where ID=@perId", con);
            SqlCommand cmd = new SqlCommand("personelGuncelle", con);

            cmd.Parameters.Add("perId", SqlDbType.VarChar).Value = perId;
            cmd.Parameters.Add("AD", SqlDbType.VarChar).Value = _PersonelAd;
            cmd.Parameters.Add("SOYAD", SqlDbType.VarChar).Value = _PersonelSoyad;
            //cmd.Parameters.Add("PAROLA", SqlDbType.VarChar).Value = _PersonelParola;
            cmd.Parameters.Add("GOREVID", SqlDbType.Int).Value = _PersonelGorevId;
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());


            }
            catch (Exception)
            {

                throw;
            }

            con.Close();
            return sonuc;

        }

        public bool personelSil(int perId)
        {

            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("personelSil", con);

            cmd.Parameters.Add("perId", SqlDbType.VarChar).Value = perId;
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (Exception)
            {

                throw;
            }

            con.Close();
            return sonuc;

        }
    }
}
