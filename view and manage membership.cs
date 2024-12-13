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
    public partial class Form6 : Form
    {
        private FlowLayoutPanel flowPanel;
        private TextBox searchBox;
        private Button searchButton;

        public Form6()
        {
            InitializeComponent();
            InitializeUI();
            LoadData();
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.DoubleBuffered = true;
        }
        private void InitializeUI()
        {
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
            }; searchPanel.Controls.Add(searchBox);
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
        private Panel CreateCard(string membershipType, int amount)
        {
            Panel card = new Panel
            {
                BorderStyle = BorderStyle.FixedSingle,
                Width = 250,
                Height = 250,
                Margin = new Padding(10),
                BackColor = System.Drawing.Color.LightGray,
                Tag = membershipType // Use the membership type as a unique identifier
            };

            // Membership type title
            Label cardTitle = new Label
            {
                Text = membershipType.ToUpperInvariant(),
                Font = new System.Drawing.Font("Arial", 16, System.Drawing.FontStyle.Bold),
                Dock = DockStyle.Top,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Height = 40
            };

            // Amount
            Label amountLabel = new Label
            {
                Text = $"Amount: {amount} $",
                Font = new System.Drawing.Font("Arial", 12),
                Dock = DockStyle.Top,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Height = 30
            };

            // Edit button
            Button editButton = new Button
            {
                Text = "Edit",
                Dock = DockStyle.Bottom,
                BackColor = System.Drawing.Color.LightGreen,
                Height = 30
            };
            editButton.Click += (sender, e) =>
            {
                // Open the Add Membership form with existing data
                addmembershipfrm addForm = new addmembershipfrm();
                addForm.LoadMembershipData(membershipType);
                addForm.ShowDialog();

                // Refresh data after editing
                LoadData();
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
                if (MessageBox.Show($"Are you sure you want to delete the membership type '{membershipType}'?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    DeleteMembership(membershipType);
                }
            };

            // Add components to the card
            card.Controls.Add(deleteButton);
            card.Controls.Add(editButton);
            card.Controls.Add(amountLabel);
            card.Controls.Add(cardTitle);

            return card;
        }


        Gym_SystemEntities6 db = new Gym_SystemEntities6();
        private void LoadData()
        {
            try
            {

                var memberships = db.membership_type_table
                .Select(m => new { m.membershiptype, m.amount })
                .ToList();

                flowPanel.Controls.Clear(); // Clear old cards

                foreach (var membership in memberships)
                {
                    // Create a card for each membership type
                    Panel card = CreateCard(membership.membershiptype, (int)membership.amount);
                    flowPanel.Controls.Add(card); // Add the card to the flow panel
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تحميل البيانات: " + ex.Message);
            }
        }
        private void DeleteMembership(string membershipType)
        {
            try
            {
                var membership = db.membership_type_table.FirstOrDefault(m => m.membershiptype == membershipType);
                if (membership != null)
                {
                    db.membership_type_table.Remove(membership);
                    db.SaveChanges();
                    MessageBox.Show("Membership type deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(); // Refresh the membership list
                }
                else
                {
                    MessageBox.Show("Membership type not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            string searchText = searchBox.Text.Trim().ToLower();

            foreach (Control control in flowPanel.Controls)
            {
                if (control is Panel card)
                {
                    // Retrieve the membership type from the card's Tag
                    string membershipType = card.Tag != null ? card.Tag.ToString().ToLower() : string.Empty;

                    // Default visibility to false
                    bool isMatch = false;

                    // Check if search text matches membership type
                    if (membershipType.Contains(searchText))
                    {
                        isMatch = true;
                    }

                    // Toggle visibility based on match
                    card.Visible = isMatch;
                }
            }

            // Optional: Show a message if no matches are found
            bool anyVisible = flowPanel.Controls.OfType<Panel>().Any(c => c.Visible);
            if (!anyVisible)
            {
                MessageBox.Show("لا توجد نتائج مطابقة للبحث.", "نتائج البحث", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void Form6_Load(object sender, EventArgs e)
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
            // Call LoadData method when the form loads
            LoadData();
        }


        private void label7_Click(object sender, EventArgs e)
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

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
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
            Form form = new addmembershipfrm();


            form.Show();
            this.Close();
        }
    }
}
