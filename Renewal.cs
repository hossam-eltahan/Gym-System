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
    public partial class Renewal : Form
    {
        private TextBox searchBox;
        private Button searchButton;
        private FlowLayoutPanel flowPanel;
        public Renewal()
        {
            InitializeComponent();
            InitializeUI();
            LoadData();
        }

        private string log = "yes";
        public static object Designer { get; internal set; }


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
        private Panel CreateCard(int id, string fullname, string contactno, string address, string occupation,
                         string post_code, string email, int age, string gender, string country,
                         string membership_type_forign, string membership_photo, DateTime start_date, DateTime end_date)
        {
            Panel card = new Panel
            {
                BorderStyle = BorderStyle.FixedSingle,
                Width = 300,
                Height = 450, // Adjusted for additional controls
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

            // Membership duration
            Label membershipDates = new Label
            {
                Text = $"From: {start_date.ToShortDateString()}\nTo: {end_date.ToShortDateString()}",
                Font = new System.Drawing.Font("Arial", 10),
                Dock = DockStyle.Top,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Height = 40
            };

            // Display photo
            PictureBox memberPhoto = new PictureBox
            {
                Width = 100,
                Height = 100,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Dock = DockStyle.Top,
                Image = LoadMemberPhoto(id) // Use the method to load the photo by member ID
            };

            // Number of months to renew
            Label monthsLabel = new Label
            {
                Text = "Months to Renew:",
                Dock = DockStyle.Top,
                Height = 30
            };
            NumericUpDown monthsNumericUpDown = new NumericUpDown
            {
                Dock = DockStyle.Top,
                Minimum = 0,
                Maximum = 24,
                Value = 0
            };

            // Membership type selection
            Label typeLabel = new Label
            {
                Text = "Membership Type:",
                Dock = DockStyle.Top,
                Height = 30
            };
            ComboBox membershipTypeComboBox = new ComboBox
            {
                Dock = DockStyle.Top,
                Height = 30
            };

            // Populate the ComboBox with membership types from the database
            PopulateMembershipTypes(membershipTypeComboBox);

            // Total amount label
            Label totalAmountLabel = new Label
            {
                Text = "Total Amount: $0",
                Dock = DockStyle.Top,
                Height = 30
            };

            // Calculate total amount dynamically when values change
            monthsNumericUpDown.ValueChanged += (sender, e) =>
            {
                UpdateTotalAmountLabel(membershipTypeComboBox, monthsNumericUpDown, totalAmountLabel);
            };
            membershipTypeComboBox.SelectedIndexChanged += (sender, e) =>
            {
                UpdateTotalAmountLabel(membershipTypeComboBox, monthsNumericUpDown, totalAmountLabel);
            };

            // Renew Button
            Button renewButton = new Button
            {
                Text = "Renew",
                Dock = DockStyle.Bottom,
                BackColor = System.Drawing.Color.LightSkyBlue,
                Height = 30
            };
            renewButton.Click += (sender, e) =>
            {
                if (membershipTypeComboBox.SelectedItem != null)
                {
                    string selectedType = membershipTypeComboBox.SelectedItem.ToString();
                    int months = (int)monthsNumericUpDown.Value;
                    decimal totalAmount = months * GetMembershipAmount(selectedType);

                    RenewMembership(id, selectedType, months, totalAmount);
                    MessageBox.Show($"Membership renewed for {fullname}.\nTotal Amount: ${totalAmount}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please select a membership type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            // Arrange the controls inside the card
            card.Controls.Add(renewButton);
            card.Controls.Add(totalAmountLabel);
            card.Controls.Add(membershipTypeComboBox);
            card.Controls.Add(typeLabel);
            card.Controls.Add(monthsNumericUpDown);
            card.Controls.Add(monthsLabel);
            card.Controls.Add(membershipDates);
            card.Controls.Add(memberPhoto);
            card.Controls.Add(cardTitle);

            return card;
        }

        private void PopulateMembershipTypes(ComboBox comboBox)
        {
            try
            {
                var membershipTypes = db.membership_type_table.Select(mt => new { mt.membershiptype, mt.amount }).ToList();

                comboBox.Items.Clear();
                foreach (var type in membershipTypes)
                {
                    comboBox.Items.Add($"{type.membershiptype} (${type.amount})");
                }

                if (comboBox.Items.Count > 0)
                {
                    comboBox.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading membership types: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void UpdateTotalAmountLabel(ComboBox comboBox, NumericUpDown numericUpDown, Label label)
        {
            if (comboBox.SelectedItem != null)
            {
                string selectedType = comboBox.SelectedItem.ToString();
                decimal amountPerMonth = GetMembershipAmount(selectedType);
                decimal totalAmount = (int)numericUpDown.Value * amountPerMonth;

                Console.WriteLine($"Selected Type: {selectedType}");
                Console.WriteLine($"Amount Per Month: {amountPerMonth}");
                Console.WriteLine($"Total Amount: {totalAmount}");

                label.Text = $"Total Amount: ${totalAmount:F2}";
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
        private decimal GetMembershipAmount(string selectedType)
        {
            // Extract amount from the format "Type ($Amount)"
            if (selectedType.Contains("($"))
            {
                string amountText = selectedType.Split('$')[1].Replace(")", "").Trim();
                if (decimal.TryParse(amountText, out decimal amount))
                {
                    return amount;
                }
            }
            return 0; // Return 0 if parsing fails
        }



        private void RenewMembership(int memberId, string membershipType, int months, decimal totalAmount)
        {
            try
            {
                var member = db.new_member_table.Find(memberId);
                if (member != null)
                {
                    member.membership_type_forign = membershipType;
                    member.enddate = member.enddate.AddMonths(months);
                    member.number_of_month += months;
                    // Add a record to the renew table
                    db.renews.Add(new renew
                    {
                        member_id = memberId,
                        total_amount = totalAmount,
                        renew_date = DateTime.Now
                    });

                   
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadData();
        }


        private decimal ExtractAmountFromText(string text)
        {
            string amountText = text.Split('$')[1].Replace(")", "").Trim();
            return decimal.Parse(amountText);
        }

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
                                            member.membership_photo, member.startdate, member.enddate);
                    flowPanel.Controls.Add(card);
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

        private void button1_Click(object sender, EventArgs e)
        {
            log = "no";
            Form frm = new addmembershipfrm();
            frm.Show();
            this.Close();
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

        private void Renewal_FormClosing(object sender, FormClosingEventArgs e)
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

        private void button9_Click(object sender, EventArgs e)
        {

        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.DoubleBuffered = true;
        }
        private void Renewal_Load(object sender, EventArgs e)
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
            LoadData();

        }
    }
}
