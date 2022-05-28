﻿using System;
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
    public partial class Sign_In : Form
    {
        public static User u=new User();
        public static Seller s = new Seller();
        public Sign_In()
        {
            InitializeComponent();
        }
        private void Sign_In_Load(object sender, EventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string pass = textBox2.Text;
            Admin chk = AdminDL.get_admin(name,pass);
            s = SellerDL.get_seller(name, pass);
            u = UserDL.get_user(name, pass);
            if (chk != null)
            {
                AdminMenu a = new AdminMenu();
                this.Hide();
                a.Show();
            }
            else if (s != null)
            {
                SellerMenu d = new SellerMenu();
                this.Hide();
                d.Show();
            }
            else if(u!=null)
            {

            }
            else
            {
                MessageBox.Show("There is no such User...");
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Focus();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}