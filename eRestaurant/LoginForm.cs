using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eRestaurant
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(tbUserName.Text == "adminRest" && tbPassword.Text == "123")
            {
                Admin admin = new Admin();
                this.Hide();
                admin.Show();

            }
            else if(tbPassword.Text != "123" || tbPassword.Text == "")
            {
                MessageBox.Show("Password yang anda masukkan salah");
            }
            else if (tbUserName.Text != "adminRest" || tbUserName.Text == "")
            {
                MessageBox.Show("Username yang anda masukkan salah");
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 main = new Form1();
            main.Show();
        }

        private void tbUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if(tbUserName.Text == "Username")
            {
                tbUserName.Clear();
                tbUserName.ForeColor = Color.Black;
            }
        }

        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(tbPassword.Text == "123456")
            {
                tbPassword.Clear();
                tbPassword.ForeColor = Color.Black;
            }
        }
    }
}
