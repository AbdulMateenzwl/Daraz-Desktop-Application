using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Daraz_V_Convert.Forms;
namespace Daraz_V_Convert
{
    public partial class Main_Menu : Form
    {
        public Main_Menu()
        {
            InitializeComponent();
        }

        private void Main_Menu_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        

        private void button1_Click_2(object sender, EventArgs e)
        {
            Sign_In open = new Sign_In();
            this.Hide();
            open.Show();
        }
    }
}
