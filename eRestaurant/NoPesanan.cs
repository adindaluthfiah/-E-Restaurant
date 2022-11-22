using System;
using Npgsql;

namespace eRestaurant
{
    class NoPesanan : Data2
    {

        public string Number()
        {

            long hitung;
            string urutan = "Host=e-restaurant.postgres.database.azure.com;Port=5432;Username=postgresql@e-restaurant;Password=Postgres123;Database=postgres;sslmode=require";
            NpgsqlConnection con = new NpgsqlConnection(urutan);
            con.Open();
            string query = "Select Max (No_Pesanan) from Menu";
            NpgsqlCommand cmd = new NpgsqlCommand(query, con);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string val = dr[0].ToString();
                if (val == "")
                {
                    NoPesanan = "202200001";
                }
                else
                {
                    hitung = Convert.ToInt64(dr[0].ToString().Substring(dr[0].ToString().Length - 9, 9)) + 1;
                    string kodeurutan = "20220000" + hitung;
                    NoPesanan = kodeurutan.Substring(kodeurutan.Length - 9, 9);
                }
                con.Close();

            }
            return NoPesanan;

        }
    }
}
