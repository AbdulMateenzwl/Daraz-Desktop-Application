using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Daraz_V_Convert.DL;
using Daraz_V_Convert.BL;
namespace Daraz_V_Convert.Forms
{
    public partial class EditSeller : Form
    {
        Seller pre = new Seller();

        public Product Product { get; }

        public EditSeller(Seller s)
        {
            InitializeComponent();
            pre = s;
        }

        public EditSeller(Product product)
        {
            Product = product;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Seller nw = new Seller(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
            SellerDL.replace(pre, nw);
            AdminDL.Admin.add_history("You edited " + textBox1.Text + " .");
            //save all to file
            //save
            this.Hide();
            AdminGV a = new AdminGV();
            a.Show();
        }

        private void EditSeller_Load(object sender, EventArgs e)
        {
            textBox1.Text = pre.Name;
            textBox2.Text = pre.PhoneNum;
            textBox3.Text = pre.Buisness;
            textBox4.Text = pre.Password;
            textBox1.Focus();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminGV a = new AdminGV();
            a.Show();
        }
    }
}
