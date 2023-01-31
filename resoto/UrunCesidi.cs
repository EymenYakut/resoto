using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace resoto
{
    internal class UrunCesidi
    {

        cGenel gnl = new cGenel();

        private int _UrunTurNo;
        private string _KategoriAd;
        private string _Aciklama;

        public int UrunTurNo { get => _UrunTurNo; set => _UrunTurNo = value; }
        public string KategoriAd { get => _KategoriAd; set => _KategoriAd = value; }
        public string Aciklama { get => _Aciklama; set => _Aciklama = value; }

        public void UrunCesidiGetir(ListView Cesitler, Button btn)
        {
            Cesitler.Items.Clear(); //listview'i her çağırdığımızda temizlememiz lazım
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("UrunCesidiGetir", con);

            string aa = btn.Name;
            int uzunluk = aa.Length;

            cmd.Parameters.Add("@KATEGORIID", SqlDbType.Int).Value = aa.Substring(uzunluk - 1, 1); //bastığımız buttonun name'inden yola çıkarak kategori id'sini alıyoruz
            cmd.CommandType = CommandType.StoredProcedure;

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                Cesitler.Items.Add(dr["URUNADI"].ToString());
                Cesitler.Items[i].SubItems.Add(dr["FIYAT"].ToString());
                Cesitler.Items[i].SubItems.Add(dr["ID"].ToString());
                i++;
            }
            dr.Close();
            con.Dispose();
            con.Close();
        }

        public void ArananUrunuGetir(ListView Cesitler, int txt)
        {
            Cesitler.Items.Clear(); //listview'i her çağırdığımızda temizlememiz lazım
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("ArananUrunuGetir", con);



            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = txt;
            cmd.CommandType = CommandType.StoredProcedure;

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                Cesitler.Items.Add(dr["URUNADI"].ToString());
                Cesitler.Items[i].SubItems.Add(dr["FIYAT"].ToString());
                Cesitler.Items[i].SubItems.Add(dr["ID"].ToString());
                i++;
            }
            dr.Close();
            con.Dispose();
            con.Close();
        }

        //ürün çeşitleri getir combobox
        public void KategorileriListele(ComboBox cb)
        {

            cb.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("KategorileriListele", con);
            SqlDataReader dr = null;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                int sayac = 0;
                while (dr.Read())
                {
                    UrunCesidi uc = new UrunCesidi();
                    uc._UrunTurNo = Convert.ToInt32(dr["ID"]);
                    uc._KategoriAd = Convert.ToString(dr["KATEGORIADI"]);
                    uc._Aciklama = Convert.ToString(dr["ACIKLAMA"]);

                    cb.Items.Add(uc);
                    sayac++;
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            dr.Close();
            con.Dispose();
            con.Close();
        }

        //ürün çeşitleri getir ListView
        public void KategorileriListele(ListView lv)
        {

            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("KategorileriListeleLv", con);
            SqlDataReader dr = null;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                int sayac = 0;
                while (dr.Read())
                {
                    lv.Items.Add(Convert.ToInt32(dr["ID"]).ToString());
                    lv.Items[sayac].SubItems.Add(dr["KATEGORIADI"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ACIKLAMA"].ToString());
                    sayac++;
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            dr.Close();
            con.Dispose();
            con.Close();
        }

        //ürün çeşitleri getir ListView arama
        public void KategorileriListele(ListView lv, string arama)
        {

            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("KategorileriListeleArama", con);
            SqlDataReader dr = null;

            cmd.Parameters.Add("arama", SqlDbType.VarChar).Value = arama;
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                int sayac = 0;
                while (dr.Read())
                {
                    lv.Items.Add(Convert.ToInt32(dr["ID"]).ToString());
                    lv.Items[sayac].SubItems.Add(dr["KATEGORIADI"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ACIKLAMA"].ToString());
                    sayac++;
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            dr.Close();
            con.Dispose();
            con.Close();
        }

        //urun çeşitleri ekle
        public int kategoriEkle(UrunCesidi uc)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("KategoriEkle", con);


            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@kategoriAdi", SqlDbType.VarChar).Value = uc._KategoriAd;
                cmd.Parameters.Add("@aciklama", SqlDbType.VarChar).Value = uc._Aciklama;
                cmd.CommandType = CommandType.StoredProcedure;
                sonuc = Convert.ToInt32(cmd.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {

                string hata = ex.Message;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }

            return sonuc;
        }

        //ürün çeşitleri güncelle
        public int kategoriGuncelle(UrunCesidi uc)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("KategoriGuncelle", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@kategoriAdi", SqlDbType.VarChar).Value = uc._KategoriAd;
                cmd.Parameters.Add("@aciklama", SqlDbType.VarChar).Value = uc._Aciklama;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = uc._UrunTurNo;
                cmd.CommandType = CommandType.StoredProcedure;
                sonuc = Convert.ToInt32(cmd.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {

                string hata = ex.Message;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }

            return sonuc;
        }

        //ürün çeşitleri sil
        public int kategoriSil(UrunCesidi uc)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("KategoriSil", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = uc._UrunTurNo;
                cmd.CommandType = CommandType.StoredProcedure;
                sonuc = Convert.ToInt32(cmd.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {

                string hata = ex.Message;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }

            return sonuc;
        }

        public override string ToString()
        {
            return KategoriAd;
        }

    }
}