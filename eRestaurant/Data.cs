using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eRestaurant
{
    internal class Data : CRUD
    {
        public NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;Port=5432;Username=postgres;Password=Postgres123;Database=e-Rest");
        public string sql = null;
        public static NpgsqlCommand cmd;
        private DataGridViewRow r;
        public int Insert(DataInsert req)
        {
            try
            {
                conn.Open();
                sql = @"select * from st_insert(:_No_Pesanan,:_Nama,:_Scramble_Toast,:_Bacon_DoubleCT,:_Avo_Toast,:_Shrimp_Toast,:_Total)";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("_No_Pesanan", req.NoPesanan);
                cmd.Parameters.AddWithValue("_Nama", req.Nama);
                cmd.Parameters.AddWithValue("_Scramble_Toast", req.Pesan1);
                cmd.Parameters.AddWithValue("_Bacon_DoubleCT", req.Pesan2);
                cmd.Parameters.AddWithValue("_Avo_Toast", req.Pesan3);
                cmd.Parameters.AddWithValue("_Shrimp_Toast", req.Pesan4);
                cmd.Parameters.AddWithValue("_Total", req.Total);
                
                MessageBox.Show("Pesanan anda telah ditambahkan ke antrian, Silahkan lanjutkan pembayaran anda ke kasir");
                int status = (int)cmd.ExecuteScalar();
                conn.Close();
                return status;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Data gagal dikirimkan.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
                return 0;
            }
        }

        public int Delete(string reqNoPesanan)
        {
            conn.Open();
            sql = @"select * from st_delete(:_No_Pesanan)";
            cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("_No_Pesanan", reqNoPesanan);
            int status = (int)cmd.ExecuteScalar();
            MessageBox.Show("Data Users berhasil dihapus", "Well Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn.Close();
            r = null;
            return status;
        }
    }
}
