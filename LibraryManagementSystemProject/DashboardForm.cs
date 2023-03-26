using LibraryManagementSystemProject.Models;
using ManagementLibraryProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystemProject
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            using (var context = new LibraryManagementSystemContext())
            {
                int bcount = context.Books.Count();
                lbBook.Text = bcount.ToString();
                int scount = context.Students.Count();
                lbStd.Text = scount.ToString();
                int lcount = context.Librarians.Count();
                lbLibrarian.Text = lcount.ToString();
                int icount = context.BooksIssues.Count();
                lbIssue.Text = icount.ToString();
                int rcount = context.ReturnBooks.Count();
                lbReturn.Text = rcount.ToString();
            }
        }


    }
}
