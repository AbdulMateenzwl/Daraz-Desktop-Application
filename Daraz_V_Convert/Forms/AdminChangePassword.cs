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
namespace Daraz_V_Convert.Forms
{
    public partial class AdminChangePassword : Form
    {
        public AdminChangePassword()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void AdminChangePassword_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int chk = AdminDL.change_password(textBox1.Text, textBox2.Text, textBox3.Text);
            if (chk == 1)
            {
                MessageBox.Show("Wrong Password.");
                textBox1.Clear();
            }
            else if (chk == 2)
            {
                MessageBox.Show("New Password can not be the Old Password.");
            }
            else if (chk == 3)
            {
                MessageBox.Show("Password has been changed.");
                this.Hide();
                AdminMenu a = new AdminMenu();
                a.Show();
            }
            else if (chk == 4)
            {
                MessageBox.Show("New Passwords does not match.");
            }
            textBox2.Clear();
            textBox3.Clear();
            textBox1.Focus();
        }
    }
}