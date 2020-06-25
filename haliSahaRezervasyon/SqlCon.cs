using haliSahaRezervasyon.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace haliSahaRezervasyon
{
    
    public class SqlCon
    {
        SqlConnection con = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand com = new SqlCommand();
        DataSet ds = new DataSet();
        /*public void gridoldur()
        {
            DataTable dt = new DataTable();
            con = new SqlConnection("Data Source=DESKTOP-R60O1VQ\\SQLEXPRESS03;Initial Catalog=ProjeHaliSaha;Integrated Security=True");
            da = new SqlDataAdapter("Select * from Sahalars", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Sahalars");
            dt = ds.Tables["Sahalars"];
            dataGridView1.DataSource = ds.Tables["Sahalars"];
            con.Close();
        }*/
       public void SahaDurumGuncelle(int SahaId,bool SahaDurum)
        {
            con = new SqlConnection("Data Source=DESKTOP-R60O1VQ\\SQLEXPRESS03;Initial Catalog=ProjeHaliSaha;Integrated Security=True");
            string sql = "UPDATE Sahalars SET SahaDurum=@SahaDurum WHERE SahaId=@SahaId";
            com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@SahaDurum", SahaDurum);
            com.Parameters.AddWithValue("@SahaId", SahaId);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        
        public DataTable RezervasyonFiyatGetir()
        {
            con = new SqlConnection("Data Source=DESKTOP-R60O1VQ\\SQLEXPRESS03;Initial Catalog=ProjeHaliSaha;Integrated Security=True");
            con.Open();
            SqlDataAdapter adap = new SqlDataAdapter("Select Fiyat from Sahalars", con);
            DataTable tbl = new DataTable();
            adap.Fill(tbl);
            con.Close();
            return tbl;
        }
        public DataTable TabloyuGetir(bool SahaDurum)
        {
            con = new SqlConnection("Data Source=DESKTOP-R60O1VQ\\SQLEXPRESS03;Initial Catalog=ProjeHaliSaha;Integrated Security=True");
            con.Open();
            SqlDataAdapter adap = new SqlDataAdapter("Select * from Sahalars where SahaDurum='"+SahaDurum+"'", con);
            DataTable tbl = new DataTable();
            adap.Fill(tbl);
            con.Close();
            return tbl;
        }
        public DataTable RezervasyonTablo()
        {
            con = new SqlConnection("Data Source=DESKTOP-R60O1VQ\\SQLEXPRESS03;Initial Catalog=ProjeHaliSaha;Integrated Security=True");
            con.Open();
            SqlDataAdapter adap = new SqlDataAdapter("Select Sahalars.SahaId,Sahalars.SahaIsim,Rezervasyons.Tarih,Rezervasyons.RezervasyonSaat,Sahalars.SahaKisi,Sahalars.Fiyat,Sahalars.Adres,Rezervasyons.PayCheck AS FiyatDurumu from Rezervasyons inner join Sahalars ON Rezervasyons.SahaId=Sahalars.SahaId", con);
            DataTable tbl = new DataTable();
            adap.Fill(tbl);
            con.Close();
            return tbl;
        }
        public DataTable TabloyuGetir1()
        {
            con = new SqlConnection("Data Source=DESKTOP-R60O1VQ\\SQLEXPRESS03;Initial Catalog=ProjeHaliSaha;Integrated Security=True");
            con.Open();
            SqlDataAdapter adap = new SqlDataAdapter("Select * from Sahalars", con);
            DataTable tbl = new DataTable();
            adap.Fill(tbl);
            con.Close();
            return tbl;
        }
        public Boolean SaatTarihKontrol(int SahaId,string Tarih,string saat)
        {

          

            Boolean success = false;
            con = new SqlConnection("Data Source=DESKTOP-R60O1VQ\\SQLEXPRESS03;Initial Catalog=ProjeHaliSaha;Integrated Security=True");
            con.Open();
            com = new SqlCommand("Select * from Rezervasyons where RezervasyonSaat=@saat and Tarih=@Tarih and SahaId=@SahaId", con);
            com.Parameters.AddWithValue("@saat", saat);
            com.Parameters.AddWithValue("@SahaId", SahaId);
            com.Parameters.AddWithValue("@Tarih", Convert.ToDateTime(Tarih));
            using (SqlDataReader reader = com.ExecuteReader())
            {
                if(reader.Read())
                {
                    success = true;
                }
            }
                con.Close();

            return success;

        }
        public Boolean PayCheckUpdate(string Tarih, string saat, int RSahaId, bool PayCheck)
        {
            Boolean success = false;
            con = new SqlConnection("Data Source=DESKTOP-R60O1VQ\\SQLEXPRESS03;Initial Catalog=ProjeHaliSaha;Integrated Security=True");
            string sql = "UPDATE Rezervasyons SET PayCheck=@PayCheck WHERE RezervasyonSaat=@saat and Tarih=@Tarih and SahaId=@RSahaId";
            com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@PayCheck", PayCheck);
            com.Parameters.AddWithValue("@RSahaId", RSahaId);
            com.Parameters.AddWithValue("@saat", saat);
            com.Parameters.AddWithValue("@Tarih", Convert.ToDateTime(Tarih));
            con.Open();
            using (SqlDataReader reader = com.ExecuteReader())
            {
                if (reader.Read())
                {
                    success = true;
                }
            }
            con.Close();
            return success;
            
        }
    }
}
