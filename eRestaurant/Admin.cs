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

namespace eRestaurant
{
    public partial class Admin : Form
    {
        
        public Admin()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable("tabelMenu");
        private void Admin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet.tabelMenu' table. You can move, or remove it, as needed.
            this.tabelMenuTableAdapter.Fill(this.dataSet.tabelMenu);
            try
            {
                /*using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (cn.State == ConnectionState.Closed)
                        cn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter("select *from tabelMenu", cn))
                    {
                        da.Fill(dt);
                        DataGridView.DataSource = dt;
                    }
                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("Nama like '%{0}%'", tbSearch.Text);
                DataGridView.DataSource = dv.ToTable();
            }
                
        }
    }
}
