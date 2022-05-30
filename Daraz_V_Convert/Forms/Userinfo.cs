using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Daraz_V_Convert.Forms
{
    public partial class Userinfo : Form
    {
        public Userinfo()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="" || textBox2.Text=="" || textBox2.Text.Length<11)
            {
                MessageBox.Show("Please Enter the correct information...");
            }
            else
            {
                Sign_In.user.Email = textBox1.Text;
                Sign_In.user.Phone = textBox2.Text;
                //Sign_In.user.clear_buyproducts();
                this.Hide();
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
