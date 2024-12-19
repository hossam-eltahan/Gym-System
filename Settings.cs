using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Settings : Form
    {
        private string log = "yes";
        private string selectedPhotoPath = "default.jpg";
        private Gym_SystemEntities8 db = new Gym_SystemEntities8();

        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (log == "yes")
            {
                Form form = new Login
                {
                    Tag = "1"
                };
                form.Show();
            }
        }

        private void updateSettingsButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate inputs
                if (string.IsNullOrWhiteSpace(systemNameTextBox.Text) ||
                    string.IsNullOrWhiteSpace(currencyTextBox.Text) ||
                    string.IsNullOrWhiteSpace(gymAddressTextBox.Text) ||
                    string.IsNullOrWhiteSpace(gymContactTextBox.Text) ||
                    string.IsNullOrWhiteSpace(gymEmailTextBox.Text) ||
                    !IsValidEmail(gymEmailTextBox.Text) ||
                    string.IsNullOrWhiteSpace(gymManagerTextBox.Text))
                {
                    MessageBox.Show("Please fill in all fields correctly.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Create a new setting object
                setting_table settings = new setting_table
                {
                    system_name = systemNameTextBox.Text,
                    currency = currencyTextBox.Text,
                    Gym_address = gymAddressTextBox.Text,
                    Gym_email = gymEmailTextBox.Text,
                    Gym_manager = gymManagerTextBox.Text,
                    Gym_contact = gymContactTextBox.Text,
                    logo = selectedPhotoPath != "default.jpg" ? SavePhoto(selectedPhotoPath) : "default.jpg"
                };

                // Remove existing settings and add new ones
                var existingSetting = db.setting_table.FirstOrDefault();
                if (existingSetting != null)
                {
                    db.setting_table.Remove(existingSetting);
                    db.SaveChanges();
                }

                db.setting_table.Add(settings);
                db.SaveChanges();

                MessageBox.Show("System Settings Updated successfully!");
                ClearFormInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private string SavePhoto(string photoPath)
        {
            string destinationFolder = Path.Combine(Application.StartupPath, "Photos");

            // Ensure directory exists
            if (!Directory.Exists(destinationFolder))
            {
                Directory.CreateDirectory(destinationFolder);
            }

            string destinationPath = Path.Combine(destinationFolder, Path.GetFileName(photoPath));

            try
            {
                File.Copy(photoPath, destinationPath, true);
                return Path.GetFileName(photoPath);
            }
            catch (IOException ex)
            {
                MessageBox.Show($"An error occurred while copying the file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "default.jpg";
            }
        }
        
        private void ClearFormInputs()
        {
            systemNameTextBox.Text = "";
            gymContactTextBox.Text = "";
            gymEmailTextBox.Text = "";
            currencyTextBox.Text = "";
            gymManagerTextBox.Text = "";
            gymAddressTextBox.Text = "";
            selectedPhotoPath = "default.jpg";
            pictureBox18.Image = null;
        }

        private void uploadbtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (.jpg;.jpeg;.png)|.jpg;.jpeg;.png";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedPhotoPath = openFileDialog.FileName;
                    MessageBox.Show("Photo selected: " + selectedPhotoPath);

                    // Load image into PictureBox
                    pictureBox18.Image =Image.FromFile(selectedPhotoPath);
                    pictureBox18.SizeMode = PictureBoxSizeMode.StretchImage;
                    button12.Visible = true;
                    label12.Text = "Choosen";
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            pictureBox18.Image = null;
            button12.Visible = false;
        }

        private void changePassButton_Click(object sender, EventArgs e)
        {
            var entity = db.password_table.FirstOrDefault();
            if (entity != null)
            {
                if (currentPassTextBox.Text != entity.current_password)
                {
                    MessageBox.Show("Current password incorrect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (newPassTextBox.Text != confirmPassTextBox.Text)
                {
                    MessageBox.Show("New password and confirm password don't match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    entity.current_password = newPassTextBox.Text;
                    db.SaveChanges();
                    MessageBox.Show("Password Updated successfully!");
                    ClearPasswordFields();
                }
            }
        }

        private void ClearPasswordFields()
        {
            currentPassTextBox.Clear();
            newPassTextBox.Clear();
            confirmPassTextBox.Clear();
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
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.DoubleBuffered = true;
        }
        private void Settings_Load(object sender, EventArgs e)
        {
            using (var context = new Gym_SystemEntities8())
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

        private void button13_Click(object sender, EventArgs e)
        {
            log = "no";
            Form addfrm = new Dashboard();
            addfrm.Show();
            this.Close();
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
            Form addfrm = new Add();
            addfrm.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            log = "no";
            Form addfrm = new Form1();
            addfrm.Show();
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {

            log = "no";
            Form addfrm = new Renewal();
            addfrm.Show();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {

            log = "no";
            Form addfrm = new Form2();
            addfrm.Show();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            log = "no";
            Form addfrm = new Form3();
            addfrm.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            log = "no";
            Form addfrm = new Form4();
            addfrm.Show();
            this.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            log = "yes";
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            log = "no";
            Form addfrm = new addmembershipfrm();
            addfrm.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            log = "no";
            Form addfrm = new Form6();
            addfrm.Show();
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
                systemNameTextBox.ForeColor = Color.Silver;
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
                currencyTextBox.ForeColor = Color.Silver;
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
                gymAddressTextBox.ForeColor = Color.Silver;
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
                gymContactTextBox.ForeColor = Color.Silver;
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
                gymEmailTextBox.ForeColor = Color.Silver;
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
                gymManagerTextBox.ForeColor = Color.Silver;
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
                currentPassTextBox.ForeColor = Color.Silver;
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
                newPassTextBox.ForeColor = Color.Silver;
            }
        }

        private void confirmPassTextBox_Enter(object sender, EventArgs e)
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
                confirmPassTextBox.ForeColor = Color.Silver;
            }
        }

        private void uploadbtn_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedPhotoPath = openFileDialog.FileName; // Store the selected file path
                    MessageBox.Show("Photo selected: " + selectedPhotoPath);
                    label15.Text = "Chosen";

                    // Load the image without locking the file
                    using (var stream = new MemoryStream(File.ReadAllBytes(selectedPhotoPath)))
                    {
                        pictureBox18.Image = Image.FromStream(stream);
                    }

                    pictureBox18.SizeMode = PictureBoxSizeMode.StretchImage;
                    button12.Visible = true;
                }
            }
        }
    }
}
