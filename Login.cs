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
            if ((email_textbox.Text == "admin") && (password_textbox.Text == "1234"))
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

        //private void textBox2_TextChanged(object sender, EventArgs e)
        //{

        //}

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



        

        private void email_textbox_Enter_1(object sender, EventArgs e)
        {

            if (email_textbox.Text == "Someone@example.com")
            {
                email_textbox.Text = "";
                email_textbox.ForeColor = Color.White;
            }

        }

        private void email_textbox_Leave(object sender, EventArgs e)
        {
            if (email_textbox.Text == "")
            {
                email_textbox.Text = "Someone@example.com";
                email_textbox.ForeColor = Color.Silver;
            }
        }

        private void password_textbox_Enter_1(object sender, EventArgs e)
        {
            if (password_textbox.Text == "Password")
            {
                password_textbox.Text = "";
                password_textbox.ForeColor = Color.White;
            }
        }

        private void password_textbox_Leave_1(object sender, EventArgs e)
        {
            if (password_textbox.Text == "")
            {
                password_textbox.Text = "Password";
                password_textbox.ForeColor = Color.Silver;
            }
        }


    }

        
    
}
