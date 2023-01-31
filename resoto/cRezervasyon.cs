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
    internal class cRezervasyon
    {

        cGenel gnl = new cGenel();

        private int _ID;
        private int _MasaId;
        private int _MusteriId;
        private DateTime _Tarih;
        private int _KisiSayisi;
        private string _Aciklama;
        private int _durum;

        public int ID { get => _ID; set => _ID = value; }
        public int MasaId { get => _MasaId; set => _MasaId = value; }
        public int MusteriId { get => _MusteriId; set => _MusteriId = value; }
        public DateTime Tarih { get => _Tarih; set => _Tarih = value; }
        public int KisiSayisi { get => _KisiSayisi; set => _KisiSayisi = value; }
        public string Aciklama { get => _Aciklama; set => _Aciklama = value; }
        public int Durum { get => _durum; set => _durum = value; }


        //müşteriID ve masa numarasına göre
        public int musteriIdRezervasyonGetir(int masaId)
        {

            int kullaniciId = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("musteriIdRezervasyonGetir", con);

            try
            {

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@masaid", SqlDbType.Int).Value = masaId;
                cmd.CommandType = CommandType.StoredProcedure;

                kullaniciId = Convert.ToInt32(cmd.ExecuteScalar());

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

            return kullaniciId;

        }

        public int RezervasyonAc(cRezervasyon cr)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("RezervasyonEkle", con);


            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                cmd.Parameters.Add("@musteriId", SqlDbType.Int).Value = cr._MusteriId;
                cmd.Parameters.Add("@masaId", SqlDbType.Int).Value = cr._MasaId;
                cmd.Parameters.Add("@kisiSayisi", SqlDbType.Int).Value = cr._KisiSayisi;
                cmd.Parameters.Add("@tarih", SqlDbType.DateTime).Value = cr._Tarih;
                cmd.Parameters.Add("@aciklama", SqlDbType.VarChar).Value = cr._Aciklama;
                cmd.Parameters.Add("@durum", SqlDbType.Int).Value = cr._durum;
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

        public void RezIdEkle(int masaId)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("RezIdEkle", con); //masalarda ki durumu değiş


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }


            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = _ID;
            cmd.Parameters.Add("@masaId", SqlDbType.Int).Value = masaId;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.ExecuteNonQuery();
            con.Dispose();
            con.Close();

        }

        public void BosMasaGoster(ComboBox cb)
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
                    cb.Items.Add(dr["ID"].ToString());

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

        public int RezervasyonSil(int rezervId)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("RezervasyonSil", con);


            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }



                cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = rezervId;
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

        public void AcikRezerv(ListView lv)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("AcikRezerv", con);

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
                    lv.Items.Add(dr["ID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["MUSTERIID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["AD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["MASAID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["KISISAYISI"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["TARIH"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ACIKLAMA"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["DURUM"].ToString());

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

        public int RezervasyonSilSiparis(int masaId)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("RezervasyonSilSiparis", con);


            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }



                cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = masaId;
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

    }
}
