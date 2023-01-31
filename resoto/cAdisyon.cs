using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace resoto
{
    internal class cAdisyon
    {
        cGenel gnl = new cGenel();

        private int _ID;
        private int _SERVISTURNO;
        private decimal _TUTAR;
        private DateTime _TARIH;
        private int _PERSONELID;
        private int _DURUM;
        private int _MASAID;

        public int ID { get => _ID; set => _ID = value; }
        public int SERVISTURNO { get => _SERVISTURNO; set => _SERVISTURNO = value; }
        public decimal TUTAR { get => _TUTAR; set => _TUTAR = value; }
        public DateTime TARIH { get => _TARIH; set => _TARIH = value; }
        public int PERSONELID { get => _PERSONELID; set => _PERSONELID = value; }
        public int DURUM { get => _DURUM; set => _DURUM = value; }
        public int MASAID { get => _MASAID; set => _MASAID = value; }

        public int AdisyonGetir(int MasaId)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("AdisyonGetir", con); // top 1 sadece 1 kayıt getir demek
            
            cmd.Parameters.Add("@MasaId", SqlDbType.Int).Value = MasaId;
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                MasaId = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch (SqlException ex)
            {

                string hata = ex.Message;
            }
            finally
            {
                
                con.Close();
            }

            return MasaId;
        }

        public bool AdisyonAc(cAdisyon Bilgiler)
        {
            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("AdisyonAc", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@ServisTurNo",SqlDbType.Int).Value=Bilgiler.SERVISTURNO;
                cmd.Parameters.Add("@Tarıh", SqlDbType.DateTime).Value = Bilgiler.TARIH;
                cmd.Parameters.Add("@PersonelID", SqlDbType.Int).Value = Bilgiler.PERSONELID;
                cmd.Parameters.Add("@MasaID", SqlDbType.Int).Value = Bilgiler.MASAID;
                cmd.Parameters.Add("@Durum", SqlDbType.Bit).Value = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());

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

        public void AdisyonKapat(int adisyonId,int durum)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("AdisyonKapat", con);

            try
            {

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@adisyonId", SqlDbType.Int).Value = adisyonId;
                cmd.Parameters.Add("@durum", SqlDbType.Int).Value = durum;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }
        }

        public int paketAdisyonIdBul()
        {
            int miktar = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("paketAdisyonIdBul", con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                miktar = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                
            }
            return miktar;
        }

        public void acikPaketAdisyonlar(ListView lv)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("acikPaketAdisyonlar", con);
            SqlDataReader dr = null;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                dr = cmd.ExecuteReader();
                int sayac= 0;
                while (dr.Read())
                {
                    lv.Items.Add(dr["MUSTERIID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["Musteri"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["adisyonId"].ToString());
                    cmd.CommandType = CommandType.StoredProcedure;
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

        public string musteriSonAdisyon(int musteriId)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("musteriSonAdisyon", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@musteriId", SqlDbType.Int).Value = musteriId;
                cmd.CommandType = CommandType.StoredProcedure;
                sonuc = Convert.ToInt32(cmd.ExecuteScalar());

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

            return sonuc.ToString();
        }

        public void musteriDetaylar(ListView lv, int musteriId) 
        {
            lv.Items.Clear ();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("musteriDetaylar", con);
            cmd.Parameters.Add("@musteriId",SqlDbType.Int).Value=musteriId;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = null;
            

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            try
            {
                int sayac = 0;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lv.Items.Add(dr["MUSTERIID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["AD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["SOYAD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["tarih"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ADISYONID"].ToString());
                    sayac++;
                }
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

        }
    }
}
