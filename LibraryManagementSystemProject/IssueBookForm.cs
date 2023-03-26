using LibraryManagementSystemProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementLibraryProject
{
    public partial class IssueBookForm : Form
    {
        public IssueBookForm()
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
                        newQty = Qty - 1;
                        book.Quantity = newQty;
                        context.SaveChanges();
                    }
                }
            }
        }
        private void UpdateBookQuantityCancel()
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
        private void getStudentByID()
        {
            using (var context = new LibraryManagementSystemContext())
            {
                Student student = context.Students.Include(s => s.StdDeparmentNavigation).FirstOrDefault(s => s.StdId == Convert.ToInt32(cbStdId.SelectedValue.ToString()));
                if (student != null)
                {
                    tbStdName.Text = student.StdName;
                    tbPhone.Text = student.StdPhone;
                    tbDep.Text = student.StdDeparmentNavigation.StdDepartmentName;
                }
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
        private void IssueBookForm_Load(object sender, EventArgs e)
        {
            FillStudentId();
            getBook();
            populate();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void cbStdId_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            //Refresh
            tbNum.Text = "";
            cbStdId.SelectedIndex = 0;
            tbStdName.Text = "";
            tbDep.Text = "";
            tbPhone.Text = "";
            cbBook.SelectedIndex = 0;
            dtpDate.Value = DateTime.Now;
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
                                tbNum.Text = booksIssue.IssuNumber.ToString();
                                cbStdId.SelectedValue = booksIssue.Std.StdId;
                                tbStdName.Text = booksIssue.StdName;
                                tbDep.Text = booksIssue.Std.StdDeparmentNavigation.StdDepartmentName;
                                tbPhone.Text = booksIssue.StdPhone;
                                cbBook.SelectedValue = booksIssue.BookIssuedNavigation.BookId;
                                dtpDate.Value = (DateTime)booksIssue.IssueDate;

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

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cbStdId_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void cbStdId_SelectionChangeCommitted(object sender, EventArgs e)
        {
            getStudentByID();

        }

        private void cbBook_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            // Check if all required information is available
            if (string.IsNullOrEmpty(tbNum.Text) || string.IsNullOrEmpty(tbStdName.Text) || string.IsNullOrEmpty(tbPhone.Text) || string.IsNullOrEmpty(tbDep.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            // Parse issue number
            if (!int.TryParse(tbNum.Text, out int issueNumber))
            {
                MessageBox.Show("Invalid issue number.");
                return;
            }

            Book book = (Book)cbBook.SelectedItem;
            Student student = (Student)cbStdId.SelectedItem;
            // Get issue date
            DateTime issueDate = dtpDate.Value;

            // Create new BooksIssue 
            var newIssue = new BooksIssue
            {
                IssuNumber = issueNumber,
                StdId = student.StdId,
                StdName = tbStdName.Text,
                StdDeparment = tbDep.Text,
                StdPhone = tbPhone.Text,
                BookIssued = book.BookId,
                IssueDate = issueDate
            };

            try
            {
                // Add new BooksIssue to database context
                using (var context = new LibraryManagementSystemContext())
                {
                    if (context.BooksIssues.Any(x => x.IssuNumber == issueNumber))
                    {
                        MessageBox.Show("Issue number already exists.");
                        return;
                    }

                    context.BooksIssues.Add(newIssue);
                    context.SaveChanges();
                    MessageBox.Show("Book issued successfully.");
                    UpdateBookQuantity();
                    populate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while issuing the book: " + ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int issueNumber = Convert.ToInt32(tbNum.Text);
            Book book = (Book)cbBook.SelectedItem;
            Student student = (Student)cbStdId.SelectedItem;
            // Get issue date
            DateTime issueDate = dtpDate.Value;
            if (tbNum.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Book issued not found!");
            } else
            {
                using (var context = new LibraryManagementSystemContext())
                {

                    // Create new BooksIssue 
                    var issue = new BooksIssue
                    {
                        IssuNumber = issueNumber,
                        StdId = student.StdId,
                        StdName = tbStdName.Text,
                        StdDeparment = tbDep.Text,
                        StdPhone = tbPhone.Text,
                        BookIssued = book.BookId,
                        IssueDate = issueDate
                    };

                    context.BooksIssues.Update(issue);
                    context.SaveChanges();
                    MessageBox.Show("Edit book issued successfully.");
                    populate();
                    //Refresh
                    tbNum.Text = "";
                    cbStdId.SelectedIndex = 0;
                    tbStdName.Text = "";
                    tbDep.Text = "";
                    tbPhone.Text = "";
                    cbBook.SelectedIndex = 0;
                    dtpDate.Value = DateTime.Now;
                }
            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int issueNumber = Convert.ToInt32(tbNum.Text);
            Book book = (Book)cbBook.SelectedItem;
            Student student = (Student)cbStdId.SelectedItem;
            // Get issue date
            DateTime issueDate = dtpDate.Value;
            if (tbNum.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Book issued not found!");
            }
            else
            {
                using (var context = new LibraryManagementSystemContext())
                {

                    // Create new BooksIssue 
                    var issue = new BooksIssue
                    {
                        IssuNumber = issueNumber,
                        StdId = student.StdId,
                        StdName = tbStdName.Text,
                        StdDeparment = tbDep.Text,
                        StdPhone = tbPhone.Text,
                        BookIssued = book.BookId,
                        IssueDate = issueDate
                    };

                    context.BooksIssues.Remove(issue);
                    context.SaveChanges();
                    MessageBox.Show("Issue successfully canceled.");
                    populate();
                    UpdateBookQuantityCancel();
                    //Refresh
                    tbNum.Text = "";
                    cbStdId.SelectedIndex = 0;
                    tbStdName.Text = "";
                    tbDep.Text = "";
                    tbPhone.Text = "";
                    cbBook.SelectedIndex = 0;
                    dtpDate.Value = DateTime.Now;
                }
            }
        }
    }
}
