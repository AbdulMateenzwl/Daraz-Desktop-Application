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
    public partial class UserGV : Form
    {
        List<string> list = new List<string>();
        public UserGV()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Product> p = SellerDL.get_products(comboBox1.Text);
            if(p != null)
            {
                dataBind(p);
            }
            else
            {
                dataGrid.DataSource = null;
                dataGrid.Refresh();
            }
        }
        public void dataBind(List<Product> p)
        {
            dataGrid.DataSource = null;
            dataGrid.DataSource = p;
            dataGrid.Refresh();
        }

        private void UserGV_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < SellerDL.Seller.Count; i++)
            {
                list.Add(SellerDL.Seller[i].Name);
            }
            comboBox1.DataSource=list;
        }
    }
}
