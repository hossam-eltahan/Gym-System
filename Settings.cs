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
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void systemNameTextBox_TextChanged(object sender, EventArgs e)
        { 
        
        }

        private string log = "yes";
        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = !panel1.Visible;

            if (panel1.Visible == true)
            {
                button4.BackColor = Color.DimGray;
                button4.Text = "Membership Types  \u2193";
                panel2.Location = new Point(panel2.Location.X, panel1.Location.Y + panel1.Height);
            }
            else
            {
                button4.BackColor = Color.FromArgb(64, 64, 64);
                button4.Text = "Membership Types  \u2192";
                panel2.Location = new Point(panel2.Location.X, button4.Location.Y + button4.Height);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            log = "no";
            Form addfrm = new Add();
            addfrm.Show();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            log = "no";
            Form frm = new Form2();
            frm.Show();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            log = "no";
            Form frm = new Form3();
            frm.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            log = "no";
            Form frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            log = "no";
            Form frm = new Renewal();
            frm.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            log = "no";
            Form frm = new Form4();
            frm.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            log = "no";
            Form form = new Form6();


            form.Show();
            this.Close();
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (log == "yes")
            {
                Form form = new Login();

                form.Tag = "1";
                form.Show();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            log = "yes";
            this.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            log = "no";
            Form frm = new Dashboard();
            frm.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            log = "no";
            Form form = new addmembershipfrm();


            form.Show();
            this.Close();
        }


       

        private void systemNameTextBox_Enter(object sender, EventArgs e)
        {
            if (systemNameTextBox.Text == "Enter System Name")
            {
                systemNameTextBox.Text = "";
                systemNameTextBox.ForeColor = Color.Black;
            }
         } 
        private void systemNameTextBox_Leave(object sender, EventArgs e)
        {
            if (systemNameTextBox.Text == "")
            {
                systemNameTextBox.Text = "Enter System Name";
                systemNameTextBox.ForeColor = Color.DarkGray;
            }
        }

        private void currencyTextBox_Enter(object sender, EventArgs e)
        {

            if (currencyTextBox.Text == "Enter your currency")
            {
                currencyTextBox.Text = "";
                currencyTextBox.ForeColor = Color.Black;
            }
        }

        private void currencyTextBox_Leave(object sender, EventArgs e)
        {
            if (currencyTextBox.Text == "")
            {
                currencyTextBox.Text = "Enter your currency";
                currencyTextBox.ForeColor = Color.DarkGray;
            }
        }
        private void gymAddressTextBox_Enter(object sender, EventArgs e)
        {

            if (gymAddressTextBox.Text == "Enter GYM address")
            {
                gymAddressTextBox.Text = "";
                gymAddressTextBox.ForeColor = Color.Black;
            }
        }

        private void gymAddressTextBox_Leave(object sender, EventArgs e)
        {
            if (gymAddressTextBox.Text == "")
            {
                gymAddressTextBox.Text = "Enter GYM address";
                gymAddressTextBox.ForeColor = Color.DarkGray;
            }
        }

        private void gymContactTextBox_Enter(object sender, EventArgs e)
        {

            if (gymContactTextBox.Text == "Enter GYM contact")
            {
                gymContactTextBox.Text = "";
                gymContactTextBox.ForeColor = Color.Black;
            }
        }

        private void gymContactTextBox_Leave(object sender, EventArgs e)
        {
            if (gymContactTextBox.Text == "")
            {
                gymContactTextBox.Text = "Enter GYM contact";
                gymContactTextBox.ForeColor = Color.DarkGray;
            }
        }
        private void gymEmailTextBox_Enter(object sender, EventArgs e)
        {

            if (gymEmailTextBox.Text == "Enter GYM Email")
            {
                gymEmailTextBox.Text = "";
                gymEmailTextBox.ForeColor = Color.Black;
            }
        }

        private void gymEmailTextBox_Leave(object sender, EventArgs e)
        {
            if (gymEmailTextBox.Text == "")
            {
                gymEmailTextBox.Text = "Enter GYM Email";
                gymEmailTextBox.ForeColor = Color.DarkGray;
            }
        }
        private void gymManagerTextBox_Enter(object sender, EventArgs e)
        {

            if (gymManagerTextBox.Text == "Enter GYM manager name")
            {
                gymManagerTextBox.Text = "";
                gymManagerTextBox.ForeColor = Color.Black;
            }
        }

        private void gymManagerTextBox_Leave(object sender, EventArgs e)
        {
            if (gymManagerTextBox.Text == "")
            {
                gymManagerTextBox.Text = "Enter GYM manager name";
                gymManagerTextBox.ForeColor = Color.DarkGray;
            }
        }

        private void currentPassTextBox_Enter(object sender, EventArgs e)
        {

            if (currentPassTextBox.Text == "Enter current password")
            {
                currentPassTextBox.Text = "";
                currentPassTextBox.ForeColor = Color.Black;
            }
        }

        private void currentPassTextBox_Leave(object sender, EventArgs e)
        {
            if (currentPassTextBox.Text == "")
            {
                currentPassTextBox.Text = "Enter current password";
                currentPassTextBox.ForeColor = Color.DarkGray;
            }
        }

        private void newPassTextBox_Enter(object sender, EventArgs e)
        {

            if (newPassTextBox.Text == "Enter new password")
            {
                newPassTextBox.Text = "";
                newPassTextBox.ForeColor = Color.Black;
            }
        }

        private void newPassTextBox_Leave(object sender, EventArgs e)
        {
            if (newPassTextBox.Text == "")
            {
                newPassTextBox.Text = "Enter new password";
                newPassTextBox.ForeColor = Color.DarkGray;
            }
        }private void confirmPassTextBox_Enter(object sender, EventArgs e)
        {

            if (confirmPassTextBox.Text == "Confirm new password")
            {
                confirmPassTextBox.Text = "";
                confirmPassTextBox.ForeColor = Color.Black;
            }
        }

        private void confirmPassTextBox_Leave(object sender, EventArgs e)
        {
            if (confirmPassTextBox.Text == "")
            {
                confirmPassTextBox.Text = "Confirm new password";
                confirmPassTextBox.ForeColor = Color.DarkGray;
            }
        }
    }
}
