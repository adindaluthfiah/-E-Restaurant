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
using System.Xml.Linq;
using Microsoft.VisualBasic.Devices;
using Microsoft.ReportingServices.Diagnostics.Internal;

namespace eRestaurant
{
    public partial class Admin : Form
    {
        Data connect = new Data();
        private DataGridViewRow r;
        private DataTable dt;
        public static NpgsqlCommand cmd;
        public Admin()
        {
            InitializeComponent();
            Data connection2 = new Data();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Mohon pilih baris data yang akan diupdate", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Apakah benar anda ingin menghapus data " + r.Cells["noPesananDataGridViewTextBoxColumn"].Value.ToString() + " ?", "Hapus data terkonfirmasi",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                try
                {
                    Data deleteData = new Data();
                    int status = deleteData.Delete(r.Cells["noPesananDataGridViewTextBoxColumn"].Value.ToString());
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex.Message, "DELETE FAIL!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                r = dgvData.Rows[e.RowIndex];

            }
        }

        private void LoadData()
        {
            connect.conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = connect.conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select * from menu";
            NpgsqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                dgvData.DataSource = dt;
            }
            comm.Dispose();
            connect.conn.Close();
        }
        private void searchBar(object sender, EventArgs e)
        {
            if (tbSearch.Text.Length >= 1)
            {
                try
                {
                    connect.conn.Open();
                    NpgsqlCommand comm = new NpgsqlCommand();
                    comm.Connection = connect.conn;
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = "select * from menu";

                    NpgsqlDataReader dr = comm.ExecuteReader();
                    if (dr.HasRows)
                    {
                        DataTable dt = new DataTable();
                        dt.Load(dr);
                        DataView dv = dt.DefaultView;
                        dv.RowFilter = string.Format("Nama like '%{0}%'", tbSearch.Text);
                        dgvData.DataSource = dv;
                    }
                    comm.Dispose();
                    connect.conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error: " + ex.Message);
                    connect.conn.Close();
                }
            }
            else
            {
                LoadData();
            }
        }
    }
}
