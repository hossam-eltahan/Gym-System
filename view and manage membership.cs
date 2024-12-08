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
    public partial class Form6 : Form
    {

        public Form6()
        {
            InitializeComponent();
        }

        Gym_SystemEntities db=new Gym_SystemEntities();
        private void LoadData()
        {
            // Get the data from the database and bind it to the DataGridView
            var members = db.new_member_table.ToList();

            // Bind data to DataGridView
            dataGridView1.DataSource = members;

            // Customize the DataGridView to make it more readable
            CustomizeDataGridView();
        }

        private void CustomizeDataGridView()
        {
            // Customize the column headers to make them more readable
            dataGridView1.Columns["full name"].HeaderText = "Full Name";
            dataGridView1.Columns["contact number"].HeaderText = "Contact Number";
            dataGridView1.Columns["address"].HeaderText = "Address";
            dataGridView1.Columns["post code"].HeaderText = "Post Code";
            dataGridView1.Columns["age"].HeaderText = "Age";
            dataGridView1.Columns["gender"].HeaderText = "Gender";
            dataGridView1.Columns["email"].HeaderText = "Email";
            dataGridView1.Columns["country"].HeaderText = "Country";
            dataGridView1.Columns["occupation"].HeaderText = "Occupation";
            dataGridView1.Columns["membership photo"].HeaderText = "Membership Photo";
            dataGridView1.Columns["membership type foreign"].HeaderText = "Membership Type";

            // Optionally, you can set column widths for better readability
            dataGridView1.Columns["full name"].Width = 150;
            dataGridView1.Columns["contact number"].Width = 120;
            dataGridView1.Columns["address"].Width = 200;
            dataGridView1.Columns["post code"].Width = 100;
            dataGridView1.Columns["age"].Width = 50;
            dataGridView1.Columns["gender"].Width = 80;
            dataGridView1.Columns["email"].Width = 150;
            dataGridView1.Columns["country"].Width = 100;
            dataGridView1.Columns["occupation"].Width = 150;

            // Optionally, format the 'membership photo' column (if the data is an image, you can show a thumbnail)
            dataGridView1.Columns["membership photo"].DefaultCellStyle.NullValue = "No Image"; // or show a placeholder text

            // You can also adjust other properties like text alignment, font, etc.
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            // Call LoadData method when the form loads
            LoadData();
        }


        private void label7_Click(object sender, EventArgs e)
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

        private void button10_Click(object sender, EventArgs e)
        {
            log = "no";
            Form frm = new Settings();
            frm.Show();
            this.Close();
        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
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
            Form form = new addmembershipfrm();


            form.Show();
            this.Close();
        }
    }
}
