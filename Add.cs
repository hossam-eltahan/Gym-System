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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;


namespace WindowsFormsApp1
{
    public partial class Add : Form
    {
        private Gym_SystemEntities6 db  =new Gym_SystemEntities6();

        public Add()
        {
            InitializeComponent();
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.DoubleBuffered = true;
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
                    label15.Text = "Chosen";

                    // Load the image without locking the file
                    using (var stream = new MemoryStream(File.ReadAllBytes(selectedPhotoPath)))
                    {
                        pictureBox18.Image = Image.FromStream(stream);
                    }

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
        private Image pathz(string photoPath)
        {
            string filePath = Path.Combine(Application.StartupPath, "Photos", photoPath);

            if (File.Exists(filePath))
            {
                return Image.FromFile(filePath); // Return the image from the file
            }
            return Properties.Resources.Book;
        }
        private async void Add_Load(object sender, EventArgs e)
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
            await LoadMembershipTypesAsync();
            numericUpDown2.Enabled = false;
            numericUpDown2.Minimum = 0;
            numericUpDown2.Value = 0;
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

                    //membershipTypeComboBox.Items[i] =membershipaid[i].ToString();
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
        private int? editingMemberId = null; // Nullable int to store the ID of the member being edited

        public void LoadMemberData(int memberId)
        {
            var member = db.new_member_table.Find(memberId);
            if (member != null)
            {
                // Populate the form fields with existing member data
                fullNameTextBox.Text = member.full_name;
                numericUpDown1.Value = member.age;
                listBox2.Text = member.gender;
                contactNumberTextBox.Text = member.contact_number;
                emailTextBox.Text = member.email;
                addressTextBox.Text = member.address;
                countrytxtbx.Text = member.country;
                postCodeTextBox.Text = member.post_code;
                occupationTextBox.Text = member.occupation;
                membershipTypeComboBox.Text = member.membership_type_forign;
              
                

                // Prevent changes to start_date and end_date
               // numericUpDown2.Value = member.number_of_month;

               // numericUpDown2.Enabled = false;

                // Load photo
                string photoPath = Path.Combine(Application.StartupPath, "Photos", member.membership_photo);
                if (File.Exists(photoPath))
                {
                    pictureBox18.Image = Image.FromFile(photoPath);
                }

                // Store the editingMemberId for use during updates
                editingMemberId = memberId;
            }
        }




        private void button12_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Input validation
                if (string.IsNullOrWhiteSpace(fullNameTextBox.Text))
                {
                    MessageBox.Show("Full Name cannot be empty.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (numericUpDown1.Value < 10)
                {
                    MessageBox.Show("Age is invalid.", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (membershipTypeComboBox.SelectedIndex == -1)
                {
                    MessageBox.Show("Select a Membership Type.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
               

                // Check if editing an existing member
                if (editingMemberId != null)
                {
                    // Fetch the existing member
                    var member = db.new_member_table.Find(editingMemberId);
                    if (member != null)
                    {
                        // Update member properties except start_date and end_date
                        member.full_name = fullNameTextBox.Text;
                        member.age = Convert.ToInt32(numericUpDown1.Value);
                        member.gender = listBox2.Text;
                        member.contact_number = contactNumberTextBox.Text;
                        member.email = emailTextBox.Text;
                        member.address = addressTextBox.Text;
                        member.country = countrytxtbx.Text;
                        member.post_code = postCodeTextBox.Text;
                        member.occupation = occupationTextBox.Text;
                        member.membership_type_forign = membershipTypeComboBox.Text;

                        member.enddate = member.startdate.AddMonths(Convert.ToInt32(numericUpDown2.Value));

                        // Preserve original start_date and end_date
                        // Handle photo upload
                        if (selectedPhotoPath != "default.jpg")
                        {
                            string destinationFolder = Path.Combine(Application.StartupPath, "Photos");
                            if (!Directory.Exists(destinationFolder))
                            {
                                Directory.CreateDirectory(destinationFolder);
                            }
                            string destinationPath = Path.Combine(destinationFolder, Path.GetFileName(selectedPhotoPath));
                            File.Copy(selectedPhotoPath, destinationPath, true);
                            member.membership_photo = Path.GetFileName(selectedPhotoPath);
                        }

                        db.SaveChanges();
                        MessageBox.Show("Member updated successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Member not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Add a new member logic
                    new_member_table m = new new_member_table
                    {
                        full_name = fullNameTextBox.Text,
                        age = Convert.ToInt32(numericUpDown1.Value),
                        gender = listBox2.Text,
                        contact_number = contactNumberTextBox.Text,
                        email = emailTextBox.Text,
                        address = addressTextBox.Text,
                        country = countrytxtbx.Text,
                        post_code = postCodeTextBox.Text,
                        occupation = occupationTextBox.Text,
                        membership_type_forign = membershipTypeComboBox.Text,
                        startdate = DateTime.Today,
                        enddate = DateTime.Today.AddMonths(Convert.ToInt32(numericUpDown2.Value)),
                        membership_photo = selectedPhotoPath != "default.jpg"
                                            ? SavePhoto(selectedPhotoPath)
                                            : "default.jpg"
                    };

                 

                    db.new_member_table.Add(m);
                    db.SaveChanges();
                    MessageBox.Show("Member added successfully!");
                }

                // Clear the form inputs
                ClearFormInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}\n\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        // Helper function to save photo
        private string SavePhoto(string photoPath)
        {
            string destinationFolder = Path.Combine(Application.StartupPath, "Photos");

            if (!Directory.Exists(destinationFolder))
            {
                Directory.CreateDirectory(destinationFolder);
            }

            string destinationPath = Path.Combine(destinationFolder, Path.GetFileName(photoPath));

            try
            {
                // Ensure the source file is not locked or in use
                using (FileStream sourceStream = new FileStream(photoPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    // Copy the file to the destination folder
                    using (FileStream destinationStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        sourceStream.CopyTo(destinationStream);
                    }
                }
                return Path.GetFileName(photoPath);
            }
            catch (IOException ex)
            {
                MessageBox.Show($"An error occurred while copying the file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "default.jpg"; // return the default image if an error occurs
            }
        }

        private void button13_Click_2(object sender, EventArgs e)
        {
            pictureBox18.Image = null;
            button13.Visible = false;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            

        }
    }
}
