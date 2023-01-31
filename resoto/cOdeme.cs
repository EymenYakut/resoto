using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace resoto
{
    
    internal class cOdeme
    {
        cGenel gnl = new cGenel();

        private int _OdemeID;
        private int _AdisyonID;
        private int _OdemeTurID;
        private decimal _AraToplam;
        private decimal _Indirim;
        private decimal _KdvTutari;
        private decimal _GenelToplam;
        private DateTime _Tarih;
        private int _MusteriID;

        public int OdemeID { get => _OdemeID; set => _OdemeID = value; }
        public int AdisyonID { get => _AdisyonID; set => _AdisyonID = value; }
        public int OdemeTurID { get => _OdemeTurID; set => _OdemeTurID = value; }
        public decimal AraToplam { get => _AraToplam; set => _AraToplam = value; }
        public decimal Indirim { get => _Indirim; set => _Indirim = value; }
        public decimal KdvTutari { get => _KdvTutari; set => _KdvTutari = value; }
        public decimal GenelToplam { get => _GenelToplam; set => _GenelToplam = value; }
        public DateTime Tarih { get => _Tarih; set => _Tarih = value; }
        public int MusteriID { get => _MusteriID; set => _MusteriID = value; }




        //müşterinin masa hesabını kapatma
       public bool HesapKapat(cOdeme hesap)
        {
            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("HesapKapat", con);

            try
            {

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@ADISYONID", SqlDbType.Int).Value = hesap._AdisyonID;
                cmd.Parameters.Add("@ODEMETURID", SqlDbType.Int).Value = hesap._OdemeTurID;
                cmd.Parameters.Add("@MUSTERIID", SqlDbType.Int).Value = hesap._MusteriID;
                cmd.Parameters.Add("@ARATOPLAM", SqlDbType.Money).Value = hesap._AraToplam;
                cmd.Parameters.Add("@KDVTUTARI", SqlDbType.Money).Value = hesap._KdvTutari;
                cmd.Parameters.Add("@INDIRIM", SqlDbType.Money).Value = hesap._Indirim;
                cmd.Parameters.Add("@TOPLAMTUTAR", SqlDbType.Money).Value = hesap._GenelToplam;
                cmd.CommandType = CommandType.StoredProcedure;
                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());

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

            return sonuc;
        }




    }
}
