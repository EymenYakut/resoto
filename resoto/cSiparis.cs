using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace resoto
{
    internal class cSiparis
    {
        cGenel gnl = new cGenel();

        private int _Id;
        private int _adisyonId;
        private int _urunId;
        private int _adet;
        private int _masaId;

        public int Id { get => _Id; set => _Id = value; }
        public int AdisyonId { get => _adisyonId; set => _adisyonId = value; }
        public int UrunId { get => _urunId; set => _urunId = value; }
        public int Adet { get => _adet; set => _adet = value; }
        public int MasaId { get => _masaId; set => _masaId = value; }

        public void SiparisGetir(ListView lv, int AdisyonId)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("SiparisGetir", con);
            SqlDataReader dr = null;

            cmd.Parameters.Add("@AdisyonId", SqlDbType.Int).Value = AdisyonId;
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
                    lv.Items[sayac].SubItems.Add(dr["ADET"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["URUNID"].ToString());
                    lv.Items[sayac].SubItems.Add(Convert.ToString(Convert.ToDecimal(dr["FIYAT"]) * Convert.ToDecimal(dr["ADET"])));
                    lv.Items[sayac].SubItems.Add(dr["ID"].ToString());

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

        public bool SiparisKaydet(cSiparis Bilgiler)
        {
            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("SiparisKaydet", con);


            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                
                cmd.Parameters.Add("@AdisyonNo", SqlDbType.Int).Value = Bilgiler._adisyonId;
                cmd.Parameters.Add("@UrunId", SqlDbType.Int).Value = Bilgiler._urunId;
                cmd.Parameters.Add("@Adet", SqlDbType.Int).Value = Bilgiler._adet;
                cmd.Parameters.Add("@MasaId", SqlDbType.Int).Value = Bilgiler._masaId;
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

        public void SiparisSil(int satisID)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("SiparisSil", con);

            cmd.Parameters.Add("@SatisID", SqlDbType.Int).Value = satisID;
            cmd.CommandType = CommandType.StoredProcedure;

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.ExecuteNonQuery();
            con.Dispose();
            con.Close();
        }

        public decimal GenelToplamBul(int musteriId)
        {
            decimal genelToplam = 0;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("GenelToplamBul", con);
            cmd.Parameters.Add("musteriId", SqlDbType.Int).Value = musteriId;
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }



                genelToplam = Convert.ToDecimal(cmd.ExecuteScalar());

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
            return genelToplam;
        }

        public void adisyonPaketDetaylari(ListView lv, int adisyonID)
        {
            lv.Items.Clear();
            decimal genelToplam = 0;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("adisyonPaketDetaylari", con);

            cmd.Parameters.Add("adisyonID", SqlDbType.Int).Value = adisyonID;
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader dr = null;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                int i = 0;
                dr=cmd.ExecuteReader();
                while (dr.Read())
                {
                    lv.Items.Add(dr["satisID"].ToString());
                    lv.Items[i].SubItems.Add(dr["URUNADI"].ToString());
                    lv.Items[i].SubItems.Add(dr["ADET"].ToString());
                    lv.Items[i].SubItems.Add(dr["FIYAT"].ToString());
                    i++;
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

        public void BosMasaGoster(ListView lb)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("BosMasaGoster", con);
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
                    lb.Items.Add(dr["ID"].ToString());

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

    }
}
