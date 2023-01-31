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
    internal class cUrunler
    {
        cGenel gnl = new cGenel();

        private int _urunId;
        private int _urunTurNo;
        private string _urunAd;
        private decimal _fiyat;
        private string _aciklama;
        private DateTime _baslangic;
        private DateTime _bitis;
        private double _toplamTutar;

        public int UrunId { get => _urunId; set => _urunId = value; }
        public int UrunTurNo { get => _urunTurNo; set => _urunTurNo = value; }
        public string UrunAd { get => _urunAd; set => _urunAd = value; }
        public decimal Fiyat { get => _fiyat; set => _fiyat = value; }
        public string Aciklama { get => _aciklama; set => _aciklama = value; }
        public DateTime Baslangic { get => _baslangic; set => _baslangic = value; }
        public DateTime Bitis { get => _bitis; set => _bitis = value; }
        public double ToplamTutar { get => _toplamTutar; set => _toplamTutar = value; }


        //ürün adına göre listeleme
        public void urunleriListeleUrunAdi(ListView lv, string urunAdi)
        {

            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("urunleriListeleUrunAdi", con);
            SqlDataReader dr = null;

            cmd.Parameters.Add("urunAd", SqlDbType.VarChar).Value = urunAdi;
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
                    lv.Items[sayac].SubItems.Add(dr["KATEGORIID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["KATEGORIADI"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["URUNADI"].ToString());
                    lv.Items[sayac].SubItems.Add(String.Format("{0:0#00.0}",dr["FIYAT"].ToString()));
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

        public int urunEkle(cUrunler cu)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("urunEkle", con);


            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@kategoriId", SqlDbType.Int).Value = cu._urunTurNo;
                cmd.Parameters.Add("@urunAdi", SqlDbType.VarChar).Value = cu._urunAd;
                cmd.Parameters.Add("@aciklama", SqlDbType.VarChar).Value = cu._aciklama;
                cmd.Parameters.Add("@fiyat", SqlDbType.Money).Value = cu._fiyat;
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

        //ürünleri ve kategorileri listele
        public void urunListele(ListView lv)
        {

            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("urunListele", con);
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
                    lv.Items[sayac].SubItems.Add(dr["KATEGORIID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["KATEGORIADI"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["URUNADI"].ToString());
                    lv.Items[sayac].SubItems.Add(String.Format("{0:0#00.0}", dr["FIYAT"].ToString()));
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

        //ürünleri güncelle
        public int urunGuncelle(cUrunler cu)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("urunGuncelle", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@kategoriId", SqlDbType.Int).Value = cu._urunTurNo;
                cmd.Parameters.Add("@urunAdi", SqlDbType.VarChar).Value = cu._urunAd;
                cmd.Parameters.Add("@aciklama", SqlDbType.VarChar).Value = cu._aciklama;
                cmd.Parameters.Add("@fiyat", SqlDbType.Money).Value = cu._fiyat;
                cmd.Parameters.Add("@urunId", SqlDbType.Int).Value = cu._urunId;
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

        //ürünleri sil
        public int urunSil(cUrunler cu)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("urunSil", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@urunId", SqlDbType.Int).Value = cu._urunId;
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

        //ürün Id'ye göre listeleme
        public void urunleriListeleId(ListView lv, int katId)
        {

            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("urunleriListeleId", con);
            SqlDataReader dr = null;

            cmd.Parameters.Add("katId", SqlDbType.Int).Value = katId;
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
                    lv.Items[sayac].SubItems.Add(dr["KATEGORIID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["KATEGORIADI"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["URUNADI"].ToString());
                    lv.Items[sayac].SubItems.Add(String.Format("{0:0#00.0}", dr["FIYAT"].ToString()));
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

        //bütün ürünleri getiriyor ve satış adedini yazıyor
        public void urunleriListeleIstatislik(ListView lv, DateTime baslangic, DateTime bitis)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("urunleriListeleIstatislik", con);
            SqlDataReader dr = null;

            cmd.Parameters.Add("@Baslangic", SqlDbType.VarChar).Value = baslangic.Date;
            cmd.Parameters.Add("@Bitis", SqlDbType.VarChar).Value = bitis.Date;
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
                    lv.Items.Add(dr["URUNADI"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["Satis Adeti"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["Toplam Fiyat"].ToString());
                    sayac++;
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }

            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();
            }    
            
        }

        //belirli kategoriye ait ürünleri getiriyor ve satış adedini yazıyor
        public void urunleriListeleIstatislikKatId(ListView lv, DateTime baslangic, DateTime bitis, int kategoriId)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("urunleriListeleIstatislikKatId", con);
            SqlDataReader dr = null;

            cmd.Parameters.Add("@Baslangic", SqlDbType.VarChar).Value = baslangic.Date;
            cmd.Parameters.Add("@Bitis", SqlDbType.VarChar).Value = bitis.Date;
            cmd.Parameters.Add("@kategoriId", SqlDbType.Int).Value = kategoriId;
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
                    lv.Items.Add(dr["URUNADI"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["Satis Adeti"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["Toplam Fiyat"].ToString());
                    sayac++;
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }

            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();
            }

        }


        public void zRaporuListele(ListView lv, DateTime Bitis)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("zRaporuListele", con);
            SqlDataReader dr = null;

            cmd.Parameters.Add("@Bitis", SqlDbType.VarChar).Value = Bitis;
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
                    lv.Items.Add(dr["URUNADI"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["Satis Adeti"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["Toplam Fiyat"].ToString());
                    sayac++;
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }

            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();
            }
        }

        public int zRaporEkle(DateTime bitis,double toplam)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("zRaporEkle", con);


            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@bitis", SqlDbType.DateTime).Value = bitis;
                cmd.Parameters.Add("@tutar", SqlDbType.Money).Value = toplam;
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

        public void zRaporTabloGoster(ListView lv)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("zRaporTabloGoster", con);
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
                    lv.Items.Add(dr["BASLANGIC"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["BITIS"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["TUTAR"].ToString());
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


    }
}
