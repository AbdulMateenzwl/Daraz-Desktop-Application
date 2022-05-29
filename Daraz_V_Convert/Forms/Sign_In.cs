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
        public static User user=new User();
        public static Seller seller = new Seller();
        public Sign_In()
        {
            InitializeComponent();
        }
        private void Sign_In_Load(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '*';
            }
            else if (!checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0';
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string pass = textBox2.Text;
            Admin chk = AdminDL.get_admin(name,pass);
            seller = SellerDL.get_seller(name, pass);
            user = UserDL.get_user(name, pass);
            if (chk != null)
            {
                AdminMenu a = new AdminMenu();
                this.Hide();
                a.Show();
            }
            else if (seller != null)
            {
                SellerMenu d = new SellerMenu();
                this.Hide();
                d.Show();
            }
            else if(user!=null)
            {
                UserMenu u = new UserMenu();
                this.Hide();
                u.Show();
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                textBox2.PasswordChar = '*';
            }
            else if(!checkBox1.Checked)
            {
                textBox2.PasswordChar ='\0';
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
