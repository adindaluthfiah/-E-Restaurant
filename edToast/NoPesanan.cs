using System;
using System.Data.SqlClient;

namespace edToast
{
    class NoPesanan : Data
    {

        public string Number()
        {

            long hitung;
            string urutan = (Properties.Settings.Default.MenuConnectionString);
            SqlConnection con = new SqlConnection(urutan);
            con.Open();
            string query = "Select Max (No_Pesanan) from tabelMenu";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string val = dr[0].ToString();
                if (val == "")
                {
                    NoPesanan = "000001";
                }
                else
                {
                    hitung = Convert.ToInt64(dr[0].ToString().Substring(dr[0].ToString().Length - 6, 6)) + 1;
                    string kodeurutan = "000000" + hitung;
                    NoPesanan= kodeurutan.Substring(kodeurutan.Length - 6, 6);
                }
                con.Close();
                
            }
            return NoPesanan;
            
        }
    }
}
