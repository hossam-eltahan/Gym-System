using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            button1.Focus();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {
            // Check email and password
            if ((textBox2.Text == "ahmed") && (textBox1.Text == "1234"))
            {
                // Login successful: open Dashboard
                Form dashboard = new Dashboard();
                this.Tag = "3";
                this.Hide();
                dashboard.Show();
            }
            else
            {
                // Show alert if login fails
                MessageBox.Show("Email or password is incorrect.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Tag.ToString() == "1")
            {
                if (MessageBox.Show(
                     "Are you sure you want to exit?",
                    "Confirm Exit",
                       MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Tag = "2";
                    Application.Exit();

                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                Application.Exit();
            }


        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
