using LibraryManagementSystemProject;
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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }



        private void guna2Button1_Click(object sender, EventArgs e)
        {
            StudentForm students = new StudentForm();
            students.Show();
            this.Hide();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            BookTbl books = new BookTbl();
            books.Show();
            this.Hide();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            LibrarianForm librarian = new LibrarianForm();
            librarian.Show();
            this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            IssueBookForm issueBook = new IssueBookForm();
            issueBook.Show();
            this.Hide();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            ReturnBookForm returnBook = new ReturnBookForm();
            returnBook.Show();
            this.Hide();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            AboutUsForm aboutUs = new AboutUsForm();
            aboutUs.Show();
            this.Hide();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            DashboardForm dashboardForm = new DashboardForm();
            dashboardForm.Show();
            this.Hide();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            TipForm tipForm = new TipForm();
            tipForm.Show();
            this.Hide();
        }
    }
}
