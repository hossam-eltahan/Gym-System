using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class addmembershipfrm : Form
    {
        private string editingMembershipType = null; // Track the membership type being edited


        private Gym_SystemEntities6 db = new Gym_SystemEntities6();

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.DoubleBuffered = true;
        }
        public addmembershipfrm()
        {
        
            
            InitializeComponent();
          }
        private Image pathz(string photoPath)
        {
            string filePath = Path.Combine(Application.StartupPath, "Photos", photoPath);

            if (File.Exists(filePath))
            {
                return Image.FromFile(filePath); // Return the image from the file
            }
            return Properties.Resources.Book;
        }
        private string log = "yes";
        private void Form5_Load(object sender, EventArgs e)
        {
            using (var context = new Gym_SystemEntities6())
            {

                    var entity = context.setting_table.FirstOrDefault();

                if (entity == null)
                {
                    label1.Text = "Gym System";
                    label2.Text = "Gym Manager";
                    //pictureBox2.Image = 
                }
                else
                {
                    label1.Text = entity.system_name;
                    label2.Text = entity.Gym_manager;
                    pictureBox2.Image = pathz(entity.logo);
                }
            }
        }
        public void LoadMembershipData(string membershipType)
        {
            var membership = db.membership_type_table.FirstOrDefault(m => m.membershiptype == membershipType);
            if (membership != null)
            {
                editingMembershipType = membershipType; // Track the current membership type
                textBox1.Text = membership.membershiptype;
                numericUpDown1.Value = membership.amount;
            }
        }

        private void ClearFormInputs()
        {
            textBox1.Text = "";
            numericUpDown1.Value = 1;

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

        private void addmembershipfrm_FormClosing(object sender, FormClosingEventArgs e)
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

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Enter Membership Type")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Enter Membership Type";
                textBox1.ForeColor = Color.Silver;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Membership type cannot be empty.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (numericUpDown1.Value <= 0)
                {
                    MessageBox.Show("Amount must be greater than zero.", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (editingMembershipType != null) // Update existing membership
                {
                    var membership = db.membership_type_table.FirstOrDefault(m => m.membershiptype == editingMembershipType);
                    if (membership != null)
                    {
                        membership.membershiptype = textBox1.Text;
                        membership.amount = numericUpDown1.Value;
                        db.SaveChanges();
                        MessageBox.Show("Membership type updated successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Membership type not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else // Add new membership
                {
                    membership_type_table m = new membership_type_table
                    {
                        membershiptype = textBox1.Text,
                        amount = numericUpDown1.Value
                    };

                    db.membership_type_table.Add(m);
                    db.SaveChanges();
                    MessageBox.Show("Membership type added successfully!");
                }

                ClearFormInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
