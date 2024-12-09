using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Add : Form
    {
        public Add()
        {
            InitializeComponent();
        }


        private string log = "yes";
        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void uploadbtn_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";
            openFileDialog.Title = "Select an Image File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                label1.Text = filePath;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            fullNameTextBox.Focus();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Add_Load(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Add("male");
            listBox2.Items.Add("female");
        }

        private void button13_Click(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            membershipTypeComboBox.Items.Add("Basic - $300");
            membershipTypeComboBox.Items.Add("Gold - $1000");
            membershipTypeComboBox.Items.Add("Silver - $750");
            membershipTypeComboBox.Items.Add("Bronze - $500");
            membershipTypeComboBox.Items.Add("Premium - $1200");
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

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
            Form frm = new Add();
            frm.Show();
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

        private void button10_Click(object sender, EventArgs e)
        {
            log = "no";
            Form frm = new Settings();
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

        private void Add_FormClosing(object sender, FormClosingEventArgs e)
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

        private void Dachboard_Click(object sender, EventArgs e)
        {
            log = "no";
            Form frm = new Dashboard();
            frm.Show();
            this.Close();
        }

        private void fullNameTextBox_Enter(object sender, EventArgs e)
        {
            if (fullNameTextBox.Text == "Enter your full name")
            {
                fullNameTextBox.Text = "";
                fullNameTextBox.ForeColor = Color.Black;
            }
        }

        private void fullNameTextBox_Leave(object sender, EventArgs e)
        {
            if (fullNameTextBox.Text == "")
            {
                fullNameTextBox.Text = "Enter your full name";
                fullNameTextBox.ForeColor = Color.DarkGray;
            }
        }

        private void contactNumberTextBox_Enter(object sender, EventArgs e)
        {
            if (contactNumberTextBox.Text == "Enter your contact number")
            {
                contactNumberTextBox.Text = "";
                contactNumberTextBox.ForeColor = Color.Black;
            }
        }

        private void contactNumberTextBox_Leave(object sender, EventArgs e)
        {
            if (contactNumberTextBox.Text == "")
            {
                contactNumberTextBox.Text = "Enter your contact number";
                contactNumberTextBox.ForeColor = Color.DarkGray;
            }
        }

        private void addressTextBox_Enter(object sender, EventArgs e)
        {
            if (addressTextBox.Text == "Enter your address")
            {
                addressTextBox.Text = "";
                addressTextBox.ForeColor = Color.Black;
            }
        }

        private void addressTextBox_Leave(object sender, EventArgs e)
        {
            if (addressTextBox.Text == "")
            {
                addressTextBox.Text = "Enter your address";
                addressTextBox.ForeColor = Color.DarkGray;
            }
            }

            private void postCodeTextBox_Enter(object sender, EventArgs e)
        {
            if (postCodeTextBox.Text == "Enter your post code")
            {
                postCodeTextBox.Text = "";
                postCodeTextBox.ForeColor = Color.Black;
            }
        }

        private void postCodeTextBox_Leave(object sender, EventArgs e)
        {
            if (postCodeTextBox.Text == "")
            {
                postCodeTextBox.Text = "Enter your post code";
                postCodeTextBox.ForeColor = Color.DarkGray;
            }
        }

        private void membershipTypeComboBox_Enter(object sender, EventArgs e)
        {
            if (membershipTypeComboBox.Text == "Choose membership type")
            {
                membershipTypeComboBox.Text = "";
                membershipTypeComboBox.ForeColor = Color.Black;
            }
        }

        private void membershipTypeComboBox_Leave(object sender, EventArgs e)
        {
            if (membershipTypeComboBox.Text == "")
            {
                membershipTypeComboBox.Text = "Choose membership type";
                membershipTypeComboBox.ForeColor = Color.Black;
            }
        }

        private void emailTextBox_Enter(object sender, EventArgs e)
        {
            if (emailTextBox.Text == "Enter your email")
            {
                emailTextBox.Text = "";
                emailTextBox.ForeColor = Color.Black;
            }
        }

        private void emailTextBox_Leave(object sender, EventArgs e)
        {
            if (emailTextBox.Text == "")
            {
                emailTextBox.Text = "Enter your email";
                emailTextBox.ForeColor = Color.DarkGray;
            }
        }
        private void countrytxtbx_Enter(object sender, EventArgs e)
        {
            if (countrytxtbx.Text == "Enter your country")
            {
                countrytxtbx.Text = "";
                countrytxtbx.ForeColor = Color.Black;
            }
        }

        private void countrytxtbx_Leave(object sender, EventArgs e)
        {
            if (countrytxtbx.Text == "")
            {
                countrytxtbx.Text = "Enter your country";
                countrytxtbx.ForeColor = Color.DarkGray;
            }
        }

        private void occupationTextBox_Enter(object sender, EventArgs e)
        {
            if (occupationTextBox.Text == "Enter occupation")
            {
                occupationTextBox.Text = "";
                occupationTextBox.ForeColor = Color.Black;
            }
        }

        private void occupationTextBox_Leave(object sender, EventArgs e)
        {
            if (occupationTextBox.Text == "")
            {
                occupationTextBox.Text = "Enter occupation";
                occupationTextBox.ForeColor = Color.DarkGray;
            }
        }
    }
}
