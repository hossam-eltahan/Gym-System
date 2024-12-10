using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();

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
                           string membership_type_forign, string membership_photo, DateTime start_date, DateTime end_date)
        {
            Panel card = new Panel
            {
                BorderStyle = BorderStyle.FixedSingle,
                Width = 200,
                Height = 250, // زود الارتفاع لتناسب الحقول الجديدة
                Margin = new Padding(10),
                BackColor = System.Drawing.Color.AliceBlue,
                Tag = id // تخزين ID البطاقة
            };

            // عنوان البطاقة
            Label cardTitle = new Label
            {
                Text = fullname,
                Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold),
                Dock = DockStyle.Top,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Height = 40
            };

            // إضافة تفاصيل العضوية
            Label membershipDates = new Label
            {
                Text = $"المدة: {start_date.ToShortDateString()} - {end_date.ToShortDateString()}",
                Font = new System.Drawing.Font("Arial", 10),
                Dock = DockStyle.Top,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            };

            // زر عرض التفاصيل
            Button detailsButton = new Button
            {
                Text = "عرض التفاصيل",
                Dock = DockStyle.Bottom,
                BackColor = System.Drawing.Color.LightSkyBlue,
                Height = 30
            };
            detailsButton.Click += (sender, e) =>
            {
                MessageBox.Show($"ID: {id}\nالاسم الكامل: {fullname}\nرقم الاتصال: {contactno}\n" +
                                $"العنوان: {address}\nالوظيفة: {occupation}\nالرمز البريدي: {post_code}\n" +
                                $"الإيميل: {email}\nالعمر: {age}\nالنوع: {gender}\nالدولة: {country}\n" +
                                $"نوع العضوية: {membership_type_forign}\nالصورة: {membership_photo}\n" +
                                $"تاريخ البداية: {start_date.ToShortDateString()}\nتاريخ النهاية: {end_date.ToShortDateString()}");
            };

            // ترتيب العناصر داخل البطاقة
            card.Controls.Add(detailsButton);
            card.Controls.Add(membershipDates);
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

                flowPanel.Controls.Clear();

                foreach (var member in members)
                {
                    Panel card = CreateCard(member.id, member.full_name, member.contact_number, member.address,
                                            member.occupation, member.post_code, member.email, member.age,
                                            member.gender, member.country, member.membership_type_forign,
                                            member.membership_photo, member.start_date, member.end_date);
                    flowPanel.Controls.Add(card);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تحميل البيانات: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SearchButton_Click(object sender, EventArgs e)
        {
            // قراءة النص المدخل وتحويله إلى أحرف صغيرة
            string searchText = searchBox.Text.Trim().ToLower();

            // التكرار على جميع البطاقات داخل flowPanel
            foreach (Control control in flowPanel.Controls)
            {
                if (control is Panel card) // التأكد أن العنصر هو Panel
                {
                    // استرجاع ID من Tag الخاص بالبطاقة
                    int cardId = card.Tag is int id ? id : -1;

                    // البحث عن الـ Label الذي يحتوي على الاسم
                    Label nameLabel = card.Controls.OfType<Label>().FirstOrDefault();

                    // افتراض عدم وجود تطابق
                    bool isMatch = false;

                    if (nameLabel != null)
                    {
                        // قراءة النص من الاسم وتحويله إلى أحرف صغيرة
                        string cardName = nameLabel.Text.ToLower();

                        // التحقق مما إذا كان النص المدخل رقميًا
                        if (int.TryParse(searchText, out int searchId))
                        {
                            // إذا كان البحث رقميًا، نطابقه مع ID
                            isMatch = (cardId == searchId);
                        }
                        else
                        {
                            // إذا كان البحث نصيًا، نبحث في الاسم
                            isMatch = cardName.Contains(searchText);
                        }
                    }

                    // التحكم في ظهور البطاقة بناءً على وجود تطابق
                    card.Visible = isMatch;
                }
            }

            // عرض رسالة إذا لم يتم العثور على أي نتائج
            if (!flowPanel.Controls.OfType<Panel>().Any(c => c.Visible))
            {
                MessageBox.Show("لا توجد نتائج مطابقة للبحث.", "نتائج البحث", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //private void viewmember_Load(object sender, EventArgs e) { }
    }
}