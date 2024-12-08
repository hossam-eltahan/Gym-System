using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Properties;

namespace WindowsFormsApp1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Check email and password
            if ((textBox2.Text == "admin") && (textBox1.Text == "1234"))
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private async void Login_Load(object sender, EventArgs e)
        {
            
            var img = Resources.gym;
            var resizedImg = new Bitmap(img, new Size(1820, 1068)); 
           

            BackgroundWorker bgWorker = new BackgroundWorker();
            bgWorker.DoWork += (s,args) =>
            {
                args.Result = resizedImg;
               
            };
            
            bgWorker.RunWorkerCompleted += (s, args) =>
            {
                
                this.BackgroundImage = (Image)args.Result;
                this.BackgroundImageLayout = ImageLayout.Stretch;
            };
            bgWorker.RunWorkerAsync();
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text== "Enter Your Email")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.White;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Enter Your Email";
                textBox2.ForeColor = Color.Silver;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Enter Password")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.White;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Enter Password";
                textBox1.ForeColor = Color.Silver;
                //textBox1.PasswordChar = '*';
            }
        }
    }

        
    
}
