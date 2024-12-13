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
    public partial class Form1 : Form
    {
        private TextBox searchBox;
        private Button searchButton;
        private FlowLayoutPanel flowPanel;
        public Form1()
        {
            InitializeComponent();
            InitializeUI();
            LoadData();
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
        private void Form1_Load(object sender, EventArgs e)
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
            if (this.Tag.ToString() == "1")
            {
                LoadData();
            }
            else if(this.Tag.ToString()=="2")
            {
                loadexpiresoonmember();
            }
            else if(this.Tag.ToString() =="3")
            {
                loadexpiremember();
            }
            else if (this.Tag.ToString()== "4")
            {
                loadnewmember();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
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
            Form form = new Form6();


            form.Show();
            this.Close();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
        private void InitializeUI()
        {
            //اول حاجه عملت البوكس اللي هياخد انبوت البحث
            searchBox = new TextBox
            {
                Width = 200,
                Font = new System.Drawing.Font("Arial", 12),
                Anchor = AnchorStyles.Top
            };

            //تاني حاجه عملت الزر اللي هيعمل بحث
            searchButton = new Button
            {
                Text = "بحث",
                Width = 80,
                Height = searchBox.Height,
                Font = new System.Drawing.Font("Arial", 10),
                Anchor = AnchorStyles.Top
            };

            //لما اضغط ع زر البحث الفانكشن بتاعت البحث تشتغل
            searchButton.Click += SearchButton_Click;

            //البانل ده زي فريم صغير يتحط فيه حاجه البحث 
            Panel searchPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                Padding = new Padding(10),
                BackColor = System.Drawing.Color.LightGray
            };

            //اضافه زر البحث والبوكس للبانل
            searchPanel.Controls.Add(searchBox);
            searchPanel.Controls.Add(searchButton);

            //مكان الزر هيبقي بعد البوكس بمسافه 10 بكسل
            searchButton.Left = searchBox.Right + 10;

            //اضافه البانل ده للفورم الاساسيه
            this.Controls.Add(searchPanel);

            //دي البانل التانيه اللي فيها البطاقات
            flowPanel = new FlowLayoutPanel
            {
                Name = "flowPanel",
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(300, 80, 20, 20),
                BackColor = System.Drawing.Color.WhiteSmoke
            };

            //اضافه البانل دي للفورم الاساسيه
            this.Controls.Add(flowPanel);
        }



        //اضافه البانل دي للفورم الاساسيه

        private Panel CreateCard(int id, string fullname, string contactno, string address, string occupation,
                         string post_code, string email, int age, string gender, string country,
                         string membership_type_forign, string membership_photo,int numberofmonth, DateTime start_date, DateTime end_date)
        {
            Panel card = new Panel
            {
                BorderStyle = BorderStyle.FixedSingle,
                Width = 200,
                Height = 300, // Adjusted for additional buttons
                Margin = new Padding(10),
                BackColor = System.Drawing.Color.AliceBlue,
                Tag = id // Store the member ID for reference
            };

            // Title of the card
            Label cardTitle = new Label
            {
                Text = fullname,
                Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold),
                Dock = DockStyle.Top,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Height = 40
            };

            // Membership duration (ensuring start_date and end_date are on separate lines)
            Label membershipDates = new Label
            {
                Text = $"From: {start_date.ToShortDateString()}\nTo: {end_date.ToShortDateString()}",
                Font = new System.Drawing.Font("Arial", 10),
                Dock = DockStyle.Top,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Height = 40
            };

            // Display photo (default if not available)
            PictureBox memberPhoto = new PictureBox
            {
                Width = 100,
                Height = 100,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Dock = DockStyle.Top,
                Image = LoadMemberPhoto(id) // Use the method to load the photo by member ID
            };

            // View details button
            Button detailsButton = new Button
            {
                Text = "View Details",
                Dock = DockStyle.Bottom,
                BackColor = System.Drawing.Color.LightSkyBlue,
                Height = 30
            };
            detailsButton.Click += (sender, e) =>
            {
                MessageBox.Show($"ID: {id}\nFull Name: {fullname}\nContact Number: {contactno}\n" +
                                $"Address: {address}\nOccupation: {occupation}\nPost Code: {post_code}\n" +
                                $"Email: {email}\nAge: {age}\nGender: {gender}\nCountry: {country}\n" +
                                $"Membership Type: {membership_type_forign}\n" +
                                $"Number of months: {numberofmonth}\n" +
                                $"Start Date: {start_date.ToShortDateString()}\nEnd Date: {end_date.ToShortDateString()}");
            };

            // Update button
            Button updateButton = new Button
            {
                Text = "Update",
                Dock = DockStyle.Bottom,
                BackColor = System.Drawing.Color.LightGreen,
                Height = 30
            };
            updateButton.Click += (sender, e) =>
            {
                // Open the Add form to edit the member
                Add addForm = new Add();
                addForm.LoadMemberData(id); // Pass member ID to load data for editing
                addForm.Show();
            };

            // Delete button
            Button deleteButton = new Button
            {
                Text = "Delete",
                Dock = DockStyle.Bottom,
                BackColor = System.Drawing.Color.Red,
                Height = 30
            };
            deleteButton.Click += (sender, e) =>
            {
                if (MessageBox.Show($"Are you sure you want to delete member {fullname}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    DeleteMember(id);
                }
            };

            // Arrange the controls inside the card
            card.Controls.Add(deleteButton);
            card.Controls.Add(updateButton);
            card.Controls.Add(detailsButton);
            card.Controls.Add(membershipDates);
            card.Controls.Add(memberPhoto); // Add the member photo to the card
            card.Controls.Add(cardTitle);

            return card;
        }

        // Method to load the member photo or use a default if not available
        private Image LoadMemberPhoto(int memberId)
        {
            // Retrieve the member record from the database using the correct table (e.g., new_member_table)
            var member = db.new_member_table.FirstOrDefault(m => m.id == memberId);

            if (member != null)
            {
                string photoPath = member.membership_photo;

                // Check if the photo file exists in the specified folder
                string filePath = Path.Combine(Application.StartupPath, "Photos", photoPath);

                if (File.Exists(filePath))
                {
                    return Image.FromFile(filePath); // Return the image from the file
                }
            }

            // Return a default photo if the member does not have a photo or the file is not found
            return Properties.Resources.user;
        }








        private Gym_SystemEntities6 db = new Gym_SystemEntities6();

        // تحميل البيانات وعرض البطاقات
        private void LoadData()
        {
            try
            {
                // Fetch data from the database using the correct table (new_member_table)
                var members = db.new_member_table.ToList();

                flowPanel.Controls.Clear();

                foreach (var member in members)
                {
                    Panel card = CreateCard(member.id, member.full_name, member.contact_number, member.address,
                                            member.occupation, member.post_code, member.email, member.age,
                                            member.gender, member.country, member.membership_type_forign,
                                            member.membership_photo,member.number_of_month, member.startdate, member.enddate);
                    flowPanel.Controls.Add(card);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تحميل البيانات: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadexpiresoonmember()
        {
            try
            {
                // Fetch data from the database using the correct table (new_member_table)
                var members = db.new_member_table.ToList();

                flowPanel.Controls.Clear();

                TimeSpan time = TimeSpan.FromDays(4);

                foreach (var member in members)
                {
                    // Compare only the date part, ignoring the time component
                    if ((member.enddate - DateTime.Today) <= time && (member.enddate >DateTime.Today))
                    {
                        Panel card = CreateCard(member.id, member.full_name, member.contact_number, member.address,
                                                member.occupation, member.post_code, member.email, member.age,
                                                member.gender, member.country, member.membership_type_forign,
                                                member.membership_photo,member.number_of_month, member.startdate, member.enddate);
                        flowPanel.Controls.Add(card);   
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تحميل البيانات: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadexpiremember()
        {
            try
            {
                // Fetch data from the database using the correct table (new_member_table)
                var members = db.new_member_table.ToList();

                flowPanel.Controls.Clear();

                TimeSpan time = TimeSpan.Zero;

                foreach (var member in members)
                {
                    if (member.enddate - DateTime.Today <= time)
                    {
                        Panel card = CreateCard(member.id, member.full_name, member.contact_number, member.address,
                                                member.occupation, member.post_code, member.email, member.age,
                                                member.gender, member.country, member.membership_type_forign,
                                                member.membership_photo,member.number_of_month, member.startdate, member.enddate);
                        flowPanel.Controls.Add(card);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تحميل البيانات: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadnewmember()
        {
            try
            {
                // Fetch data from the database using the correct table (new_member_table)
                var members = db.new_member_table.ToList();

                flowPanel.Controls.Clear();

                TimeSpan time = TimeSpan.FromDays(3);

                foreach (var member in members)
                {
                    if (DateTime.Now-member.startdate <= time)
                    {
                        Panel card = CreateCard(member.id, member.full_name, member.contact_number, member.address,
                                                member.occupation, member.post_code, member.email, member.age,
                                                member.gender, member.country, member.membership_type_forign,
                                                member.membership_photo,member.number_of_month, member.startdate, member.enddate);
                        flowPanel.Controls.Add(card);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تحميل البيانات: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteMember(int memberId)
        {
            try
            {
                var member = db.new_member_table.Find(memberId);
                if (member != null)
                {
                    db.new_member_table.Remove(member);
                    db.SaveChanges();
                    MessageBox.Show("Member deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(); // Reload the data to update the UI
                }
                else
                {
                    MessageBox.Show("Member not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SearchButton_Click(object sender, EventArgs e)
        {
            // Get the search text and trim any extra spaces
            string searchText = searchBox.Text.Trim().ToLower();

            // Loop through all the cards inside the flowPanel
            foreach (Control control in flowPanel.Controls)
            {
                if (control is Panel card) // Ensure the element is a Panel
                {
                    // Retrieve ID from the Tag of the card
                    int cardId = card.Tag is int id ? id : -1;

                    // Search for the Label that contains the name
                    Label nameLabel = card.Controls.OfType<Label>().FirstOrDefault();

                    // Assume no match initially
                    bool isMatch = false;

                    if (nameLabel != null)
                    {
                        // Read the text from the name and convert it to lowercase
                        string cardName = nameLabel.Text.ToLower();

                        // Check if the search text is a number (ID search)
                        if (int.TryParse(searchText, out int searchId))
                        {
                            // Match the ID if it's a valid number
                            isMatch = (cardId == searchId);
                        }
                        else
                        {
                            // Otherwise, perform a text search on the full name
                            isMatch = cardName.Contains(searchText); // Check if the name contains the search text
                        }
                    }

                    // Control the visibility of the card based on whether a match was found
                    card.Visible = isMatch;
                }
            }

            // If no matches are found, show a message
            if (!flowPanel.Controls.OfType<Panel>().Any(c => c.Visible))
            {
                MessageBox.Show("No matching results found.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }





        //private void viewmember_Load(object sender, EventArgs e) { }
    }

}
