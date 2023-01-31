using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace resoto
{
    internal class cPaketler
    {
        cGenel gnl = new cGenel();

        private int _ID;
        private int _MUSTERIID;
        private int _ADISYONID;
        private int _ODEMETURID;
        private string _ACIKLAMA;
        private int _DURUM;

        public int ID { get => _ID; set => _ID = value; }
        public int MUSTERIID { get => _MUSTERIID; set => _MUSTERIID = value; }
        public int ADISYONID { get => _ADISYONID; set => _ADISYONID = value; }
        public int ODEMETURID { get => _ODEMETURID; set => _ODEMETURID = value; }
        public string ACIKLAMA { get => _ACIKLAMA; set => _ACIKLAMA = value; }
        public int DURUM { get => _DURUM; set => _DURUM = value; }

        //paket servis açma işlemi
        public int PaketServisAc(cPaketler paket,cAdisyon adisyon)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("PaketSiparisEkle", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@ServisTurNo", SqlDbType.Int).Value = adisyon.SERVISTURNO;
                cmd.Parameters.Add("@PersonelID", SqlDbType.Int).Value = adisyon.PERSONELID;
                cmd.Parameters.Add("@Tarıh", SqlDbType.DateTime).Value = adisyon.TARIH;
                cmd.Parameters.Add("@adisyonDurum", SqlDbType.Int).Value = adisyon.DURUM;

                cmd.Parameters.Add("@musteriId", SqlDbType.Int).Value = paket.MUSTERIID;
                cmd.Parameters.Add("@odemeTurId", SqlDbType.Int).Value = paket.ODEMETURID;
                cmd.Parameters.Add("@aciklama", SqlDbType.VarChar).Value = paket.ACIKLAMA;
                cmd.Parameters.Add("@paketDurum", SqlDbType.Int).Value = paket.DURUM;
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
            return sonuc;
        }

        //paket servis kapatma işlemi
        public void PaketServisKapa(int AdisyonId)
        {
            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("PaketServisKapa", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@AdisyonId", SqlDbType.Int).Value = AdisyonId;
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
        }


        //açılan adisyon ve siparişe ait önden girilen ödeme tür ıd
        public int OdemeTurIdGetir(int adisyonId)
        {
            int odemeTurId = 0;

            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("OdemeTurIdGetir", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@AdisyonId", SqlDbType.Int).Value = adisyonId;
                cmd.CommandType = CommandType.StoredProcedure;
                odemeTurId = Convert.ToInt32(cmd.ExecuteScalar());
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
            return odemeTurId;
        }


        //Sipariş kontrol için müşteriye ait son adisyonu getirme
        public int MusteriSonAdisyonIdGetir(int musteriId)
        {
            int no = 0;

                SqlConnection con = new SqlConnection(gnl.conString);
                SqlCommand cmd = new SqlCommand("MusteriSonAdisyonIdGetir", con);

                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    cmd.Parameters.Add("@musteriId", SqlDbType.Int).Value = musteriId;
                    cmd.CommandType = CommandType.StoredProcedure;
                    no = Convert.ToInt32(cmd.ExecuteNonQuery());
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

            return no;
        }

        //Müşteri Arama ekranında adisyonbul butonu kontrolü
        public bool AcıkAdisyonKontrol(int adisyonId)
        {
            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("AcıkAdisyonKontrol", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@adisyonId", SqlDbType.Int).Value = adisyonId;
                cmd.CommandType = CommandType.StoredProcedure;
                sonuc = Convert.ToBoolean(cmd.ExecuteScalar());
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




    }
}
