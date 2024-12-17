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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.DoubleBuffered = true;
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
                    
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
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

        private void button12_Click(object sender, EventArgs e)
        {
            log = "no";
            Form frm = new Dashboard();
            frm.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            log = "no";
            Form form = new Form6();


            form.Show();
            this.Close();
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            log = "no";
            Form form = new Dashboard();


            form.Show();
            this.Close();
        }

        private void fullNameTextBox_Enter(object sender, EventArgs e)
        {
            if (fullNameTextBox.Text == "Enter member name")
            {
                fullNameTextBox.Text = "";
                fullNameTextBox.ForeColor = Color.Black;
            }
        }

        private void fullNameTextBox_Leave(object sender, EventArgs e)
        {
            if (fullNameTextBox.Text == "")
            {
                fullNameTextBox.Text = "Enter member name";
                fullNameTextBox.ForeColor = Color.Silver;
            }
        }

        private void contactNumberTextBox_Enter(object sender, EventArgs e)
        {
            if (contactNumberBTextBox.Text == "Enter contact number")
            {
                contactNumberBTextBox.Text = "";
                contactNumberBTextBox.ForeColor = Color.Black;
            }
        }

        private void contactNumberTextBox_Leave(object sender, EventArgs e)
        {
            if (contactNumberBTextBox.Text == "")
            {
                contactNumberBTextBox.Text = "Enter contact number";
                contactNumberBTextBox.ForeColor = Color.Silver;
            }
        }

        private void billAmountTextBox_Enter(object sender, EventArgs e)
        {
            if (billAmountTextBox.Text == "Enter Bill Amount")
            {
                billAmountTextBox.Text = "";
                billAmountTextBox.ForeColor = Color.Black;
            }
        }

        private void billAmountTextBox_Leave(object sender, EventArgs e)
        {
            if (billAmountTextBox.Text == "")
            {
                billAmountTextBox.Text = "Enter Bill Amount";
                billAmountTextBox.ForeColor = Color.Silver;
            }
        }

        private void membershipTypeComboBox_Enter(object sender, EventArgs e)
        {
            if (membershipTypeComboBox.Text == " -Select-")
            {
                membershipTypeComboBox.Text = "";
                membershipTypeComboBox.ForeColor = Color.Black;
            }
        }

        private void membershipTypeComboBox_Leave(object sender, EventArgs e)
        {
            if (membershipTypeComboBox.Text == "")
            {
                membershipTypeComboBox.Text = " -Select-";
                membershipTypeComboBox.ForeColor = Color.Silver;
            }
        }

        private void emailTextBox_Enter(object sender, EventArgs e)
        {
            if (emailTextBox.Text == "Enter e-mail")
            {
                emailTextBox.Text = "";
                emailTextBox.ForeColor = Color.Black;
            }
        }

        private void emailTextBox_Leave(object sender, EventArgs e)
        {
            if (emailTextBox.Text == "")
            {
                emailTextBox.Text = "Enter e-mail";
                emailTextBox.ForeColor = Color.Silver;
            }
        }

        private void postcodeTextBox_Enter(object sender, EventArgs e)
        {
            if (postcodeTextBox.Text == "Enter post code")
            {
                postcodeTextBox.Text = "";
                postcodeTextBox.ForeColor = Color.Black;
            }
        }

        private void postcodeTextBox_Leave(object sender, EventArgs e)
        {
            if (postcodeTextBox.Text == "")
            {
                postcodeTextBox.Text = "Enter post code";
                postcodeTextBox.ForeColor = Color.Silver;
            }
        }
    }
}
