using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Daraz_V_Convert.BL;
namespace Daraz_V_Convert.Forms
{
    public partial class EditProduct : Form
    {
        Product pre = new Product();
        public EditProduct(Product p)
        {
            InitializeComponent();
            pre = p;
        }

        private void EditProduct_Load(object sender, EventArgs e)
        {
            textBox1.Text= pre.Name;
            numericUpDown1.Value = pre.Prices;
            numericUpDown2.Value = pre.Quantity;
            textBox1.Focus();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Product nw = new Product(textBox1.Text, (int)numericUpDown1.Value, (int)numericUpDown2.Value);
            Sign_In.seller.replace_product(pre, nw);
            //save all to file
            //save
            this.Hide();
            SellerGV d = new SellerGV();
            d.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();
            SellerGV d = new SellerGV();
            d.Show();
        }
    }
}
