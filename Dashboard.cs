using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.DoubleBuffered = true;
        }

        private Gym_SystemEntities6 db = new Gym_SystemEntities6();
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void memberchipToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private async Task LoadTotalMemberAsync()
        {
            try
            {
                // حساب عدد الصفوف مباشرة
                var memberCount = await db.new_member_table.CountAsync();

                // تحديث واجهة المستخدم
                label4.Invoke((MethodInvoker)(() => label4.Text = memberCount.ToString()));
            }
            catch (Exception ex)
            {
                // للتعامل مع الأخطاء إذا حدثت
                MessageBox.Show($"حدث خطأ: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string log = "yes";
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
            log = "no";
            Form frm = new Form1();
            frm.Show();
            this.Close();
            
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void button11_Click(object sender, EventArgs e)
        {
            log = "yes";
            //Form form = new Login();
            //form.Show();

            this.Close();
            
        }



        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (log == "yes")
            {
                Form form = new Login();

                form.Tag = "1";
                form.Show();
            }



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
            log = "no";
            Form frm = new addmembershipfrm();
            frm.Show();
            this.Close();
        }



        private void addMemberbtn_Click(object sender, EventArgs e)
        {
            log = "no";
            Form addfrm = new Add();
            addfrm.Show();
            this.Close();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            log = "no";
            Form frm= new Form3();
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

        private void button11_Click_1(object sender, EventArgs e)
        {
            log = "yes";
            this.Close();
        }

        


        private void button2_Click_1(object sender, EventArgs e)
        {
            Form frm = new Form6();
            frm.Show();
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

        private void button2_Click_(object sender, EventArgs e)
        {
            log = "no";
            Form form = new Form6();
            form.Show();
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void Dachboard_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            log = "no";
            Form frm = new Form6();
            frm.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            log = "no";
            Form frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            log = "no";
            Form frm = new Form6();
            frm.Show();
            this.Close();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            log = "no";
            Form frm = new Form1();
            frm.Tag = "4";
            frm.Show();
            this.Close();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            log = "no";
            Form frm = new Form4();
            frm.Show();
            this.Close();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            log = "no";
            Form frm = new Form1();
            frm.Tag = "2";
            frm.Show();
            this.Close();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            log = "no";
            Form frm = new Form1();
            frm.Tag = "3";
            frm.Show();
            this.Close();
        }

        //int countmember=Select Count (* from 


       

        private void label4_Click(object sender, EventArgs e)
        {

        }




        private void DisplayTotalMembers()
        {
            try
            {
                // Connection string to the database
                string connectionString = "Server=AHMEDHAMADA;Database=Gym_System;Integrated Security=True;";

                // Queries to fetch different metrics
                string query1 = "SELECT COUNT(*) FROM new_member_table";
                string query2 = "SELECT COUNT(*) FROM membership_type_table";
                string query3 = "SELECT COUNT(*) FROM new_member_table WHERE enddate BETWEEN GETDATE() AND DATEADD(DAY, 4, GETDATE())";
                string query4 = "SELECT COUNT(*) FROM new_member_table WHERE enddate < GETDATE()";
                string query5 = "SELECT COUNT(*) FROM new_member_table WHERE startdate >= DATEADD(DAY, -3, GETDATE())";
                string query6 = "SELECT SUM(total_amount) FROM renew";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Commands for each query
                    SqlCommand cmd1 = new SqlCommand(query1, conn);
                    SqlCommand cmd2 = new SqlCommand(query2, conn);
                    SqlCommand cmd3 = new SqlCommand(query3, conn);
                    SqlCommand cmd4 = new SqlCommand(query4, conn);
                    SqlCommand cmd5 = new SqlCommand(query5, conn);
                    SqlCommand cmd6 = new SqlCommand(query6, conn);

                    // Execute each query and store results
                    int totalMembers = (int)cmd1.ExecuteScalar();
                    int totalMembershipType = (int)cmd2.ExecuteScalar();
                    int expiringSoonMembers = (int)cmd3.ExecuteScalar();
                    int expiredMembers = (int)cmd4.ExecuteScalar();
                    int newMembers = (int)cmd5.ExecuteScalar();
                    decimal totalRevenue = cmd6.ExecuteScalar() != DBNull.Value ? (decimal)cmd6.ExecuteScalar() : 0m;

                    // Update labels
                    label4.Text = totalMembers.ToString();
                    label5.Text = totalMembershipType.ToString();
                    label6.Text = expiringSoonMembers.ToString();
                    label10.Text = expiredMembers.ToString();
                    label8.Text = newMembers.ToString();
                    label7.Text = totalRevenue.ToString("C2"); // Currency format
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        private void Dashboard_Load_2(object sender, EventArgs e)
        {
            using (var context = new Gym_SystemEntities6())
            {
                var entity = context.setting_table.FirstOrDefault();

                if (entity == null) {
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
                DisplayTotalMembers();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
