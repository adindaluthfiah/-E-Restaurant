﻿using Npgsql;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace eRestaurant
{

    public partial class Form1 : Form
    {
        public static int subTotal;
        public static double totalSemua;

        Data connectData = new Data();
        public DataTable dt;
        public static NpgsqlCommand cmd;
        
        //DataSetTableAdapters.tabelMenuTableAdapter order = new DataSetTableAdapters.tabelMenuTableAdapter();

        public Form1()
        {
            InitializeComponent();
        }
        
        private void Main_Load(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            NoOtomatis();
        }
        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            tbNama.Text = "Masukkan Nama";
            tbPesan1.Text = tbPesan2.Text = tbPesan3.Text = tbPesan4.Text = "0";
            tbNama.ForeColor = tbPesan1.ForeColor = tbPesan2.ForeColor = tbPesan3.ForeColor = tbPesan4.ForeColor = Color.DarkGray;
            NoOtomatis();
            tbTotal.Clear();
            tbSubTotal.Clear();
        }

        private void btnOrder_Click_1(object sender, EventArgs e)
        {

            if (tbNama.Text.Trim() == "Masukkan Nama" || tbNama.Text == "" || tbPesan1.Text == "" || tbPesan2.Text == "" || tbPesan3.Text == "" || tbPesan4.Text == "")
            {
                MessageBox.Show("Pastikan nama terisi dengan benar dan tidak ada data yang kosong");
            }
            else if (tbPesan1.Text == "0" && tbPesan2.Text == "0" && tbPesan3.Text == "0" && tbPesan4.Text == "0")
            {
                MessageBox.Show("Mohon pastikan jumlah pesanan dengan benar");
            }
            else
            {

                Total_pesan.total(Convert.ToInt32(tbPesan1.Text), Convert.ToInt32(tbPesan2.Text), Convert.ToInt32(tbPesan3.Text), Convert.ToInt32(tbPesan4.Text));
                tbSubTotal.Text = "Rp " + Convert.ToString(subTotal);
                tbTotal.Text = "Rp " + Convert.ToString(totalSemua);

                DialogResult dialogResult = MessageBox.Show("Apakah pesanan sudah sesuai?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        DataInsert req = new DataInsert(
                            tbNoPesanan.Text,
                            tbNama.Text,
                            tbPesan1.Text,
                            tbPesan2.Text,
                            tbPesan3.Text,
                            tbPesan4.Text,
                            tbTotal.Text
                            );
                        Data insertData = new Data();
                        int status = insertData.Insert(req);

                    }
                    catch (Exception X)
                    {
                        MessageBox.Show(X.ToString());
                    }
                }

            }

        }
        public void NoOtomatis()
        {
            NoPesanan urut = new NoPesanan();
            tbNoPesanan.Text = urut.Number();
        }

        private void tbNama_KeyDown(object sender, KeyEventArgs e)
        {
            if (tbNama.Text == "Masukkan Nama")
            {
                tbNama.Clear();
                tbNama.ForeColor = Color.Black;
            }

        }

        private void tbPesan1_KeyDown(object sender, KeyEventArgs e)
        {
            if (tbPesan1.Text == "0")
            {
                tbPesan1.Clear();
                tbPesan1.ForeColor = Color.Black;
            }
        }
        private void tbPesan2_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (tbPesan2.Text == "0")
            {
                tbPesan2.Clear();
                tbPesan2.ForeColor = Color.Black;
            }
        }

        private void tbPesan3_KeyDown(object sender, KeyEventArgs e)
        {
            if (tbPesan3.Text == "0")
            {
                tbPesan3.Clear();
                tbPesan3.ForeColor = Color.Black;
            }
        }

        private void tbPesan4_KeyDown(object sender, KeyEventArgs e)
        {
            if (tbPesan4.Text == "0")
            {
                tbPesan4.Clear();
                tbPesan4.ForeColor = Color.Black;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnAdmin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm main = new LoginForm();
            main.Show();
        }
    }
}
