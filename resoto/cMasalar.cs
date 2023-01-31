using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace resoto
{
    internal class cMasalar
    {

        private int _ID;
        private int _KAPASITE;
        private int _SERVISTURU;
        private int _DURUM;
        private int _ONAY;

        public int ID { get => _ID; set => _ID = value; }
        public int KAPASITE { get => _KAPASITE; set => _KAPASITE = value; }
        public int SERVISTURU { get => _SERVISTURU; set => _SERVISTURU = value; }
        public int DURUM { get => _DURUM; set => _DURUM = value; }
        public int ONAY { get => _ONAY; set => _ONAY = value; }


        cGenel gnl = new cGenel();

        public string SessionSum(int state, string masaId)
        {
            string dt = "";
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("SessionSum", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@durum", SqlDbType.Int).Value = state;//burada parametreyi oluşturduk
            cmd.Parameters.Add("@masaID", SqlDbType.Int).Value = Convert.ToInt32(masaId);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr=cmd.ExecuteReader();//verileri okuduk
                while (dr.Read())
                {
                    dt = Convert.ToDateTime(dr["TARIH"]).ToString();
                }
            }
            catch (SqlException ex)
            {

                string hata = ex.Message;

                throw;
            }
            finally 
            { 
                dr.Close();
                con.Dispose();
                con.Close(); 
                
            }
            return dt;
            
        }

        public int tablodanSayiGetir(string tableDeger)
        {
            string aa = tableDeger;
            int uzunluk = aa.Length;
            

            if (uzunluk == 2)  //btn10 olursa masa adı sondan 2 karakteri al
            {
                return Convert.ToInt32(aa.Substring(uzunluk - 2, 2));
            }
            else
            {
                return Convert.ToInt32(aa.Substring(uzunluk - 1, 1)); 
            }


            //return Convert.ToInt32(aa.Substring(uzunluk - 1, 1));
        }

        public bool MasaDurumu(int ButtonAdi, int Durum)
        {
            bool sonuc = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("MasaDurumu", con);

            cmd.Parameters.Add("@TableId",SqlDbType.Int).Value=ButtonAdi;
            cmd.Parameters.Add("@state",SqlDbType.Int).Value=Durum;
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
            }
            finally
            {
                con.Dispose();
                con.Close();
            }

            return sonuc;
        }

        public void MasaDurumunuDegis(int masaNo, int Durum)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("MasaDurumunuDegis", con); //masalarda ki durumu değiş


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.Parameters.Add("@Durum", SqlDbType.Int).Value = Durum;
            cmd.Parameters.Add("@MasaNo", SqlDbType.Int).Value = masaNo;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.ExecuteNonQuery();
            con.Dispose();
            con.Close ();

        }

        public int MasaDegisAdisyonlar(int masaId, int adisyonId)
        {
            int sonuc = 0;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("MasaDegisAdisyonlar", con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.Parameters.Add("@AdisyonId", SqlDbType.Int).Value = adisyonId;
            cmd.Parameters.Add("@MasaId", SqlDbType.Int).Value = masaId;
            cmd.CommandType = CommandType.StoredProcedure;
            sonuc = Convert.ToInt32(cmd.ExecuteNonQuery());

            return sonuc;

            cmd.ExecuteNonQuery();
            con.Dispose();
            con.Close();
        }

        public int MasaDegisSatislar(int masaId, int adisyonId)
        {
            int sonuc = 0;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("MasaDegisSatislar", con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.Parameters.Add("@AdisyonId", SqlDbType.Int).Value = adisyonId;
            cmd.Parameters.Add("@MasaId", SqlDbType.Int).Value = masaId;
            cmd.CommandType = CommandType.StoredProcedure;
            sonuc = Convert.ToInt32(cmd.ExecuteNonQuery());

            return sonuc;

            cmd.ExecuteNonQuery();
            con.Dispose();
            con.Close();
        }

        public void masaKapasite(int masaId,Label lbl)
        {

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("masaKapasite", con);
            SqlDataReader dr = null;

            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = masaId;
            cmd.CommandType = CommandType.StoredProcedure;

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                lbl.Text = dr["KAPASİTE"].ToString();
            }

            con.Dispose();
            con.Close();
        }

    }
}
