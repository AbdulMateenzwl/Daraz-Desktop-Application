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
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '*';
                textBox3.PasswordChar = '*';
            }
            else if (!checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0';
                textBox3.PasswordChar = '\0';
            }
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
                AdminDL.Admin.add_history("You changed password .");
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

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminMenu m = new AdminMenu();
            m.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '*';
                textBox3.PasswordChar = '*';
            }
            else if (!checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0';
                textBox3.PasswordChar = '\0';
            }
        }
    }
}
