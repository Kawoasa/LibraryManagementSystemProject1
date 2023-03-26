using LibraryManagementSystemProject.Models;
using ManagementLibraryProject;
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

namespace LibraryManagementSystemProject
{
    public partial class ReturnBookForm : Form
    {
        public ReturnBookForm()
        {
            InitializeComponent();
        }
        private void UpdateBookQuantity()
        {
            {
                int Qty, newQty;
                using (var context = new LibraryManagementSystemContext())
                {
                    var book = context.Books.SingleOrDefault(b => b.BookId == Convert.ToInt32(cbBook.SelectedValue));
                    if (book != null)
                    {
                        Qty = book.Quantity;
                        newQty = Qty + 1;
                        book.Quantity = newQty;
                        context.SaveChanges();
                    }
                }
            }
        }
        public void populate()
        {
            using (var context = new LibraryManagementSystemContext())
            {


                dgvBookIssue.DataSource = context.BooksIssues.Select(x => new
                {
                    x.IssuNumber,
                    x.StdId,
                    x.StdName,
                    x.StdDeparment,
                    x.StdPhone,
                    x.BookIssued,
                    x.IssueDate
                }).ToList();
            }
        }
        public void populateReturnBook()
        {
            using (var context = new LibraryManagementSystemContext())
            {


                dgvBookReturn.DataSource = context.ReturnBooks.Select(x => new
                {
                    x.ReturnNum,
                    x.StdId,
                    x.StdName,
                    x.StdDepartment,
                    x.StdPhone,
                    x.Bookreturned,
                    x.IssueDate,
                    x.ReturnDate
                }).ToList();
            }
        }
        private void ReturnBookForm_Load(object sender, EventArgs e)
        {
            FillStudentId();
            getBook();
            populate();
            populateReturnBook();
        }
        private void FillStudentId()
        {
            using (var context = new LibraryManagementSystemContext())
            {
                var student = context.Students.ToList();
                cbStdId.ValueMember = "StdId";
                cbStdId.ValueMember = "StdId";
                cbStdId.DataSource = student;
            }
        }
        private void getBook()
        {
            using (var context = new LibraryManagementSystemContext())
            {
                var books = context.Books.Where(b => b.Quantity > 0).ToList();
                cbBook.ValueMember = "BookId";
                cbBook.DisplayMember = "BookName";
                cbBook.DataSource = books;
            }
        }
        private void dgvBookIssue_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dgvBookIssue.SelectedCells.Count > 0)
            {
                int selectedRowIndex = dgvBookIssue.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvBookIssue.Rows[selectedRowIndex];
                string cellValue = Convert.ToString(selectedRow.Cells["IssuNumber"].Value);
                if (!string.IsNullOrEmpty(cellValue))
                {
                    using (var context = new LibraryManagementSystemContext())
                    {
                        try
                        {
                            int ID = Convert.ToInt32(cellValue);
                            BooksIssue booksIssue = context.BooksIssues
                                .Include(e => e.BookIssuedNavigation)
                                .Include(e => e.Std)
                                .Include(e => e.Std.StdDeparmentNavigation)
                                .FirstOrDefault(e => e.IssuNumber == ID);

                            if (booksIssue != null)
                            {
                                cbStdId.SelectedValue = booksIssue.Std.StdId;
                                tbStdName.Text = booksIssue.StdName;
                                tbDep.Text = booksIssue.Std.StdDeparmentNavigation.StdDepartmentName;
                                tbPhone.Text = booksIssue.StdPhone;
                                cbBook.SelectedValue = booksIssue.BookIssuedNavigation.BookId;
                                dtpIssue.Value = (DateTime)booksIssue.IssueDate;

                            }
                            else
                            {
                                MessageBox.Show("Selected student record does not exist in the database.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error retrieving student record from the database: {ex.Message}");
                        }
                    }
                }
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            // Check if all required information is available
            if (string.IsNullOrEmpty(tbNum.Text) || string.IsNullOrEmpty(tbStdName.Text) || string.IsNullOrEmpty(tbPhone.Text) || string.IsNullOrEmpty(tbDep.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            // Parse issue number
            if (!int.TryParse(tbNum.Text, out int returnIssueNumber))
            {
                MessageBox.Show("Invalid issue number.");
                return;
            }

            Book book = (Book)cbBook.SelectedItem;
            Student student = (Student)cbStdId.SelectedItem;
            // Get issue date
            DateTime issueDate = dtpIssue.Value;
            DateTime returnIssueDate = dtpReturn.Value;
            if (issueDate > returnIssueDate)
            {
                MessageBox.Show("Issue date cannot be greater than return date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Create new BooksIssue 
            var newReturnIssue = new ReturnBook
            {
                ReturnNum = returnIssueNumber,
                StdId = student.StdId,
                StdName = tbStdName.Text,
                StdDepartment = tbDep.Text,
                StdPhone = tbPhone.Text,
                Bookreturned = book.BookId,
                IssueDate = issueDate,
                ReturnDate = returnIssueDate
            };

            try
            {
                // Add new BooksIssue to database context
                using (var context = new LibraryManagementSystemContext())
                {
                    if (context.ReturnBooks.Any(x => x.ReturnNum == returnIssueNumber))
                    {
                        MessageBox.Show("Issue number already exists.");
                        return;
                    }

                    context.ReturnBooks.Add(newReturnIssue);
                    context.SaveChanges();
                    MessageBox.Show("Book returnrd successfully.");
                    UpdateBookQuantity();
                    populate();
                    populateReturnBook();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while returning the book: " + ex.Message);
            }
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }
    }
}
