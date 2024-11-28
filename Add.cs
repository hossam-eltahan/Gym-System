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
    public partial class Add : Form
    {
        public Add()
        {
            InitializeComponent();
        }


        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void uploadbtn_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";
            openFileDialog.Title = "Select an Image File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                label1.Text = filePath;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            fullNameTextBox.Focus();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Add_Load(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Add("male");
            listBox2.Items.Add("female");
        }

        private void button13_Click(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            membershipTypeComboBox.Items.Add("Basic - $300");
            membershipTypeComboBox.Items.Add("Gold - $1000");
            membershipTypeComboBox.Items.Add("Silver - $750");
            membershipTypeComboBox.Items.Add("Bronze - $500");
            membershipTypeComboBox.Items.Add("Premium - $1200");
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
