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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace WindowsFormsApp1
{
    public partial class Add : Form
    {
        private Gym_SystemEntities db = new Gym_SystemEntities();

        public Add()
        {
            InitializeComponent();
        }


        private string log = "yes";
        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private string selectedPhotoPath = "default.jpg"; // Default photo

        private void uploadbtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedPhotoPath = openFileDialog.FileName; // Store the selected file path
                    MessageBox.Show("Photo selected: " + selectedPhotoPath);
                    label15.Text = "Choosen";

                    pictureBox18.Image = Image.FromFile(selectedPhotoPath);
                    pictureBox18.SizeMode = PictureBoxSizeMode.StretchImage;
                    button13.Visible = true;
                }
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            fullNameTextBox.Focus();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void Add_Load(object sender, EventArgs e)
        {
            await LoadMembershipTypesAsync();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }



        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private async Task LoadMembershipTypesAsync()
        {
            try
            {
                // Clear existing items in the ComboBox
                membershipTypeComboBox.Items.Clear();

                // Fetch membership types asynchronously
                var membershipTypes = await Task.Run(() => db.membership_type_table.Select(mt => mt.membershiptype).ToList());
                var membershipamount = await Task.Run(() => db.membership_type_table.Select(mt => mt.amount).ToList());



                for (int i = 0; i < membershipTypes.Count; i++)
                {
                    membershipTypeComboBox.Items.Add(membershipTypes[i] + "  $" + membershipamount[i]);
                }

                // Populate the ComboBox


                // Optionally, set the first item as selected
                if (membershipTypeComboBox.Items.Count > 0)
                {
                    membershipTypeComboBox.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading membership types: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void button12_Click(object sender, EventArgs e)
        {
            
        }

        // Helper function to validate email format
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        // Clear form inputs method
        private void ClearFormInputs()
        {
            fullNameTextBox.Text = "";
            numericUpDown1.Value = 1;
            listBox2.SelectedIndex = -1;
            contactNumberTextBox.Text = "";
            emailTextBox.Text = "";
            addressTextBox.Text = "";
            countrytxtbx.Text = "";
            postCodeTextBox.Text = "";
            occupationTextBox.Text = "";
            membershipTypeComboBox.SelectedIndex = -1;
            selectedPhotoPath = "default.jpg";
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            selectedPhotoPath = "default.jpg";
            pictureBox18.Image = null;
            label15.Text = "no file choosen";
            button13.Visible = false;

        }

        private void home_Click(object sender, EventArgs e)
        {

            log = "no";
            Form frm = new Dashboard();
            frm.Show();
            this.Close();

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            log = "no";
            Form frm = new addmembershipfrm();
            frm.Show();
            this.Close();
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Create a new member object
                new_member_table m = new new_member_table();

                // Input validation
                DateTime minimumDate = new DateTime(1900, 1, 1); // Minimum allowable DOB
                if (string.IsNullOrWhiteSpace(fullNameTextBox.Text))
                {
                    MessageBox.Show("Full Name cannot be empty.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (numericUpDown1.Value < 10)
                {
                    MessageBox.Show("age is invalid.", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(listBox2.Text))
                {
                    MessageBox.Show("Gender must be selected.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(contactNumberTextBox.Text))
                {
                    MessageBox.Show("Contact Number cannot be empty.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(emailTextBox.Text) || !IsValidEmail(emailTextBox.Text))
                {
                    MessageBox.Show("Enter a valid Email.", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(addressTextBox.Text))
                {
                    MessageBox.Show("Address cannot be empty.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(countrytxtbx.Text))
                {
                    MessageBox.Show("Country cannot be empty.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (membershipTypeComboBox.SelectedIndex == -1)
                {
                    MessageBox.Show("Select a Membership Type.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (numericUpDown2.Value <= 0)
                {
                    MessageBox.Show("Enter a valid number.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Assign values from the form inputs
                m.full_name = fullNameTextBox.Text;
                m.age = Convert.ToInt32(numericUpDown1.Value);
                m.gender = listBox2.Text;
                m.contact_number = contactNumberTextBox.Text;
                m.email = emailTextBox.Text;
                m.address = addressTextBox.Text;
                m.country = countrytxtbx.Text;
                m.post_code = postCodeTextBox.Text;
                m.occupation = occupationTextBox.Text;
                m.number_of_month = Convert.ToInt32(numericUpDown2.Value);

                // Assign the selected membership type
                m.membership_type_forign = membershipTypeComboBox.Text; // Assuming ComboBox index matches membership type ID

                // Generate a random membership number
                // Random rand = new Random();
                //m.membership_number = "CA-" + rand.Next(100000, 999999).ToString();


                // Assign the current date as the creation date
                m.start_date = DateTime.Today;
                m.end_date = m.start_date.AddMonths(((int)numericUpDown2.Value));

                // Handle photo upload
                // Handle photo upload
                if (selectedPhotoPath != "default.jpg")
                {
                    // Define the destination folder for photos
                    string destinationFolder = Path.Combine(Application.StartupPath, "Photos");

                    // Ensure the destination folder exists
                    if (!Directory.Exists(destinationFolder))
                    {
                        Directory.CreateDirectory(destinationFolder);
                    }

                    // Define the destination path
                    string destinationPath = Path.Combine(destinationFolder, Path.GetFileName(selectedPhotoPath));

                    // Copy the selected photo to the destination folder
                    File.Copy(selectedPhotoPath, destinationPath, true);

                     //Save only the file name to the database
                     m.membership_photo = Path.GetFileName(selectedPhotoPath);
                }
                else
                {
                    // Use the default photo if none was selected
                    m.membership_photo = "default.jpg";
                }


                // Calculate the expiry date (e.g., 1 year from today)
                // m.expiry_date = DateTime.Today.AddYears(1);

                //m.bills = null; // Add billing logic if applicable
                //m.renews = null; // Add renewal logic if applicable

                // Add the new member to the database
                db.new_member_table.Add(m);
                db.SaveChanges();

                // Show success message
                MessageBox.Show("Member added successfully!");

                // Clear the form inputs
                ClearFormInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}\n\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}