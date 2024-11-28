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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void memberchipToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            panel1.Visible = !panel1.Visible;

            if (panel1.Visible == true)
            {
                button4.BackColor = Color.DimGray;
                button4.Text = "Membership Types  \u2193";
                panel2.Location= new Point(panel2.Location.X, panel1.Location.Y+panel1.Height);
            }
            else
            {
                button4.BackColor = Color.FromArgb(64, 64, 64);
                button4.Text = "Membership Types  \u2192";
                panel2.Location = new Point(panel2.Location.X, button4.Location.Y + button4.Height);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void button11_Click(object sender, EventArgs e)
        {
            //Form form = new Login();
            //form.Show();

            this.Close();
        }



        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {

            Form form = new Login();

            form.Tag = "1";
            form.Show();


        }
        private void Form3_Load(object sender, EventArgs e)
        {
            // Attach the FormClosing event to the handler
            this.FormClosing += new FormClosingEventHandler(Form3_FormClosing);
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }




        private void addmembershipbtn_Click(object sender, EventArgs e)
        {
            Form frm = new addmembershipfrm();
            frm.Show();
            this.Close();
        }



        private void addMemberbtn_Click(object sender, EventArgs e)
        {
            Form addfrm = new Add();
            addfrm.Show();

            //this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form frm= new Form3();
            frm.Show();
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form frm = new Form2();
            frm.Show();
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
