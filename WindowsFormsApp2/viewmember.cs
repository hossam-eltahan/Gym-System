using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2;
using WindowsFormsApp2.Properties;


namespace WindowsFormsApp
{
    public partial class viewmember : Form
    {
        private TextBox searchBox;
        private Button searchButton;
        private FlowLayoutPanel flowPanel;


        public viewmember()
        {
            InitializeComponent();
            InitializeUI();
            LoadData();

        }

        private void InitializeUI()
        {
            //اول حاجه عملت البوكس اللي هياخد انبوت البحث
            searchBox = new TextBox
            {
                Width = 200,
                Font = new System.Drawing.Font("Arial", 12),
                Anchor = AnchorStyles.Left | AnchorStyles.Top    
            };

            //تاني حاجه عملت الزر اللي هيعمل بحث
            searchButton = new Button
            {
                Text = "بحث",
                Width = 80,
                Height = searchBox.Height,
                Font = new System.Drawing.Font("Arial", 10),
                Anchor = AnchorStyles.Left | AnchorStyles.Top
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
                Padding = new Padding(10,80,20,20),
                BackColor = System.Drawing.Color.WhiteSmoke
            };

            //اضافه البانل دي للفورم الاساسيه
            this.Controls.Add(flowPanel);
        }

        private Panel CreateCard(int id, string fullname,decimal contactno, string address, string occupation ,string post_code,string email,
                                    string age,string gender,string country, string membership_type_forign, byte[] membership_photo)
        {
            Panel card = new Panel
            {
                BorderStyle = BorderStyle.FixedSingle,
                Width = 200,
                Height = 200,
                Margin = new Padding(10),
                BackColor = System.Drawing.Color.AliceBlue,
                Tag = id, // تخزين ID البطاقة
                //BackgroundImage = Resources.Image2,
                //BackgroundImageLayout = ImageLayout.Stretch // تكييف الصورة مع حجم البطاقة
            };

            Label cardTitle = new Label
            {
                Text = fullname,
                Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold),
                Dock = DockStyle.Fill,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Height = 40
            };


            Button detailsButton = new Button
            {
                Text = "عرض التفاصيل",
                Dock = DockStyle.Bottom,
                BackColor = System.Drawing.Color.LightSkyBlue,
                Height = 30,
                Width= 20
            };
            detailsButton.Click += (sender, e) => MessageBox.Show($"ID: {id}\nfull name: {fullname}\ncontact number: {contactno}\naddress: {address}\n" +
                $"job: {occupation}\npost code: {post_code}\nemail: {email}\nage: {age}\ngender: {gender}\ncountry: {country}\n" +
                $"membership type: {membership_type_forign}\n{membership_photo}");

            card.Controls.Add(detailsButton);
            card.Controls.Add(cardTitle);

            return card;
        }

        private Gym_SystemEntities db = new Gym_SystemEntities();

        // تحميل البيانات وعرض البطاقات
        private void LoadData()
        {
            try
            {
                var members = db.new_member_table.ToList();

                flowPanel.Controls.Clear(); // تنظيف البطاقات القديمة

                foreach (var member in members)
                {
                    Panel card = CreateCard(member.id,member.full_name,member.contact_number,member.address,member.occupation,member.post_code,member.email,
                        member.age,member.gender,member.country,member.membership_type_forign,member.membership_photo);
                    flowPanel.Controls.Add(card);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تحميل البيانات: " + ex.Message);
            }
        }

        // دالة البحث
        private void SearchButton_Click(object sender, EventArgs e)
        {
            string searchText = searchBox.Text.Trim().ToLower();

            foreach (Control control in flowPanel.Controls)
            {
                if (control is Panel card)
                {
                    // Retrieve the card ID and full name
                    int id = card.Tag != null ? (int)card.Tag : -1;
                    Label titleLabel = card.Controls.OfType<Label>().FirstOrDefault();

                    // Default visibility to false
                    bool isMatch = false;

                    if (titleLabel != null)
                    {
                        string fullname = titleLabel.Text.ToLower();

                        // Check if search text matches ID or full name
                        if (fullname.Contains(searchText) || id.ToString().Contains(searchText))
                        {
                            isMatch = true;
                        }
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

    }
}
