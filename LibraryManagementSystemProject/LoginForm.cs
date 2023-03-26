
using LibraryManagementSystemProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementLibraryProject
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        

        private void label2_Click(object sender, EventArgs e)
        {
            tbUser.Text = "";
            tbPass.Text = "";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (var context = new LibraryManagementSystemContext())
            {
                var count = context.Librarians
                    .Where(l => l.LibName == tbUser.Text && l.LibPassword == tbPass.Text)
                    .Count();

                if (count == 1)
                {
                    MessageBox.Show("Login successful!");
                   this.Hide();
                   MainForm main = new MainForm();
                    main.Show();
                }
                else
                {
                    MessageBox.Show("Incorrect username or password.");
                }
            }
        }
    }
}
