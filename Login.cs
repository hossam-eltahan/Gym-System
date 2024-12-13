using System;
using System.Drawing;
using System.Linq;
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
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.DoubleBuffered = true;
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            // التحقق من البريد الإلكتروني وكلمة المرور بشكل غير متزامن
            using (var context = new Gym_SystemEntities6())
            {
                // استخدام async لتحميل البيانات بشكل غير متزامن
                var entity = await Task.Run(() => context.password_table.FirstOrDefault(x => x.Email == email_textbox.Text));

                if (entity != null && password_textbox.Text == entity.current_password)
                {
                    // تسجيل الدخول بنجاح: فتح لوحة التحكم
                    Form dashboard = new Dashboard();
                    this.Tag = "3";
                    this.Hide();
                    dashboard.Show();
                }
                else
                {
                    // إظهار رسالة إذا فشل تسجيل الدخول
                    MessageBox.Show("Email or password is incorrect.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void Login_Load(object sender, EventArgs e)
        {
            // تحميل الصورة بشكل غير متزامن لتسريع العملية
            var img = await Task.Run(() => Resources.gym);
            var resizedImg = new Bitmap(img, new Size(1820, 1068));
            this.BackgroundImage = resizedImg;
            this.BackgroundImageLayout = ImageLayout.Stretch;
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
    }
}
