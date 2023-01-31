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
    internal class cMusteriler
    {
        cGenel gnl = new cGenel();

        private int _musteriId;
        private string _musteriAd;
        private string _musteriSoyad;
        private string _telefon;
        private string _adres;
        private string _email;

        public int MusteriId { get => _musteriId; set => _musteriId = value; }
        public string MusteriAd { get => _musteriAd; set => _musteriAd = value; }
        public string MusteriSoyad { get => _musteriSoyad; set => _musteriSoyad = value; }
        public string Telefon { get => _telefon; set => _telefon = value; }
        public string Adres { get => _adres; set => _adres = value; }
        public string Email { get => _email; set => _email = value; }


        //müşterinin olup olmadığını numarasına göre sorguluyoruz
        public bool MusteriVarMi(string tlf)
        {
            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "MusteriVarMi";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@telefon", SqlDbType.VarChar).Value = tlf;
            cmd.Parameters.Add("@sonuc", SqlDbType.Int);
            cmd.Parameters["@sonuc"].Direction = ParameterDirection.Output;

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            try
            {
                cmd.ExecuteNonQuery();
                sonuc = Convert.ToBoolean(cmd.Parameters["@sonuc"].Value);
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

        public int MusteriEkle(cMusteriler cm)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("MusteriEkle", con);


            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                cmd.Parameters.Add("@ad", SqlDbType.VarChar).Value = cm._musteriAd;
                cmd.Parameters.Add("@soyad", SqlDbType.VarChar).Value = cm._musteriSoyad;
                cmd.Parameters.Add("@adres", SqlDbType.VarChar).Value = cm._adres;
                cmd.Parameters.Add("@telefon", SqlDbType.VarChar).Value = cm._telefon;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = cm._email;
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

        public bool MusteriGuncelle(cMusteriler cm)
        {
            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("MusteriGuncelle", con);


            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                cmd.Parameters.Add("@ad", SqlDbType.VarChar).Value = cm._musteriAd;
                cmd.Parameters.Add("@soyad", SqlDbType.VarChar).Value = cm._musteriSoyad;
                cmd.Parameters.Add("@adres", SqlDbType.VarChar).Value = cm._adres;
                cmd.Parameters.Add("@telefon", SqlDbType.VarChar).Value = cm._telefon;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = cm._email;
                cmd.Parameters.Add("@musteriId", SqlDbType.VarChar).Value = cm._musteriId;
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

        public int MusteriSil(int mId)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("MusteriSil", con);


            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                
                cmd.Parameters.Add("@musteriId", SqlDbType.VarChar).Value = mId;
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


        public void MusteriGetir(ListView lv)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("MusteriGetir", con);

            SqlDataReader dr = null;

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
                    lv.Items.Add(dr["ID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["AD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["SOYAD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ADRES"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["TELEFON"].ToString().Trim().Replace(" ", String.Empty));
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

        //müşterileri ID ye göre getir
        public void musterileriGetirID(int musteriId, TextBox ad, TextBox soyad, TextBox tlf, TextBox adres, TextBox email)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("musterileriGetirID", con);

            SqlDataReader dr = null;
            cmd.Parameters.Add("musteriID", SqlDbType.Int).Value = musteriId;
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                dr = cmd.ExecuteReader();



                while (dr.Read())
                {
                    ad.Text = dr["AD"].ToString();
                    soyad.Text = dr["SOYAD"].ToString();
                    tlf.Text = dr["TELEFON"].ToString();
                    adres.Text = dr["ADRES"].ToString();
                    email.Text = dr["EMAIL"].ToString();
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

        //müşterileri AD a göre getir
        public void musteriGetirAd(ListView lv, string musteriAd)
        {
            
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("musteriGetirAd", con);

            SqlDataReader dr = null;
            cmd.Parameters.Add("musteriAd", SqlDbType.VarChar).Value = musteriAd;
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
                    lv.Items[sayac].SubItems.Add(dr["AD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["SOYAD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ADRES"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["TELEFON"].ToString());

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

        //müşterileri SOYAD a göre getir
        public void musteriGetirSoyad(ListView lv, string musteriSoyad)
        {

            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("musteriGetirSoyad", con);

            SqlDataReader dr = null;
            cmd.Parameters.Add("musteriSoyad", SqlDbType.VarChar).Value = musteriSoyad;
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
                    lv.Items[sayac].SubItems.Add(dr["AD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["SOYAD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ADRES"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["TELEFON"].ToString());

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

        //müşterileri TELEFON a göre getir
        public void musteriGetirTelefon(ListView lv, string musteriTelefon)
        {

            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("musteriGetirTelefon", con);

            SqlDataReader dr = null;
            cmd.Parameters.Add("musteriTelefon", SqlDbType.VarChar).Value = musteriTelefon;
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
                    lv.Items[sayac].SubItems.Add(dr["AD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["SOYAD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ADRES"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["TELEFON"].ToString().Trim().Replace(" ",String.Empty));

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

        //müşterileri ADRES e göre getir
        public void musteriGetirAdres(ListView lv, string musteriAdres)
        {

            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("musteriGetirAdres", con);

            SqlDataReader dr = null;
            cmd.Parameters.Add("musteriAdres", SqlDbType.VarChar).Value = musteriAdres;
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
                    lv.Items[sayac].SubItems.Add(dr["AD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["SOYAD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ADRES"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["TELEFON"].ToString());

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
