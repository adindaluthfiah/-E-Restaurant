using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using Npgsql;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Remoting.Contexts;
using Microsoft.VisualBasic.Devices;

namespace eRestaurant
{
    public partial class Admin : Form
    {
        private NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=e-Restaurant");
        public DataTable dt;
        public static NpgsqlCommand cmd;
        private string sql = null;
        private DataGridViewRow r;

        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            LoadData();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 main = new Form1();
            this.Hide();
            main.Show();
            
        }

        private void tbSearch_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                // Let's try :)
                /*if (string.IsNullOrEmpty(tbSearch.Text.Trim()))
                {
                    LoadData();
                }
                else
                {
                    LoadData(tbSearch.Text.Trim());
                    conn.Open();
                    NpgsqlCommand comm = new NpgsqlCommand();
                    comm.Connection = conn;
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = "select * from menu";
                    NpgsqlDataReader dr = comm.ExecuteReader();
                    if (dr.HasRows)
                    {
                        DataTable dt = new DataTable();
                        dt.Load(dr);
                        DataGridView.DataSource = dt;
                    }
                    comm.Dispose();
                    conn.Close();
                }

                resetMe();*/
            }
                
        }
       

        private void LoadData()
        {
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select * from Menu";
            NpgsqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                DataGridView.DataSource = dt;
            }
            comm.Dispose();
            conn.Close();

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Mohon pilih baris data yang akan diupdate", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Apakah benar anda ingin menghapus data " + r.Cells["_no_pesanan"].Value.ToString() + " ?", "Hapus data terkonfirmasi",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                try
                {
                    conn.Open();
                    sql = @"select * from st_delete(:_No_Pesanan)";
                    cmd = new NpgsqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("_No_Pesanan", r.Cells["_No_Pesanan"].Value.ToString());
                    if ((int)cmd.ExecuteScalar() == 1)
                    {
                        MessageBox.Show("Data Users berhasil dihapus", "Well Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        conn.Close();
                        LoadData();
                        r = null;
                        
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex.Message, "DELETE FAIL!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

        }
    }
}
