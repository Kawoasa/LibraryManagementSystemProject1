
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
using static Guna.UI2.Native.WinApi;

namespace ManagementLibraryProject
{
    public partial class BookTbl : Form
    {
        public BookTbl()
        {
            InitializeComponent();
        }
        public void populate()
        {
            using (var context = new LibraryManagementSystemContext())
            {

                dgvBookList.DataSource = context.Books.Select(x => new
                {
                    x.BookId,
                    x.BookName,
                    x.Publisher,
                    x.Author,
                    x.Price,
                    x.Quantity

                }).ToList();
            }

        }
        private void guna2Button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BookTbl_Load_1(object sender, EventArgs e)
        {
            populate();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbBookId.Text) || string.IsNullOrEmpty(tbTitle.Text) || string.IsNullOrEmpty(tbPublisher.Text) || string.IsNullOrEmpty(tbAuthor.Text) || string.IsNullOrEmpty(tbPrice.Text) || string.IsNullOrEmpty(tbQuantity.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }
            if (!int.TryParse(tbQuantity.Text, out int quantity) && !int.TryParse(tbPrice.Text, out int price))
            {
                MessageBox.Show("Please enter a valid number.");
                return;
            }
            if (!int.TryParse(tbBookId.Text, out var bid))
            {
                MessageBox.Show("Invalid ID format. Please enter a valid integer value.");
                return;
            }
            else if (bid <= 0)
            {
                MessageBox.Show("Invalid ID value. Please enter a positive integer value.");
                return;
            }

            string bname = tbTitle.Text;
            string bPublisher = tbPublisher.Text;
            int bPrice = Convert.ToInt32(tbPrice.Text);
            string bAuthor = tbAuthor.Text;
            int bQuantity = Convert.ToInt32(tbQuantity.Text);
            Book book = new Book()
            {
                BookId = bid,
                BookName = bname,
                Publisher = bPublisher,
                Author = bAuthor,
                Quantity = bQuantity,
                Price = bPrice,
            };

            using (var context = new LibraryManagementSystemContext())
            {
                if (context.Books.Any(x => x.BookId == bid))
                {
                    MessageBox.Show("Book ID already exists.");
                    return;
                }
                dgvBookList.DataSource = context.Books.Select(x => new
                {
                    x.BookId,
                    x.BookName,
                    x.Publisher,
                    x.Author,
                    x.Price,
                    x.Quantity
                }).ToList();
                context.Add(book);
                context.SaveChanges();
                MessageBox.Show("Book added successfully.");
                populate();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string message = "";
            if (string.IsNullOrEmpty(tbBookId.Text) || string.IsNullOrEmpty(tbTitle.Text) || string.IsNullOrEmpty(tbPublisher.Text) || string.IsNullOrEmpty(tbAuthor.Text) || string.IsNullOrEmpty(tbPrice.Text) || string.IsNullOrEmpty(tbQuantity.Text))
            {
                message = "Missing Information";
            }
            else if (!int.TryParse(tbBookId.Text, out var bid))
            {
                message = "Invalid ID format. Please enter a valid integer value.";
            }
            else if (bid <= 0)
            {
                message = "Invalid ID value. Please enter a positive integer value.";
            }
            else if (!long.TryParse(tbPrice.Text, out var price))
            {
                message = "Price should only contain digits.";
            }
            else if (price < 0)
            {
                message = "Invalid price value. Please enter a positive integer value.";
            }
            else if (!long.TryParse(tbQuantity.Text, out var quantity))
            {
                message = "Quantity should only contain digits.";
            }
            else if (quantity < 0)
            {
                message = "Invalid quantity value. Please enter a positive integer value.";
            }
            else
            {
                using (var context = new LibraryManagementSystemContext())
                {
                    // Get the existing book from the database using the ID
                    var book = context.Books.FirstOrDefault(b => b.BookId == bid);
                    if (book == null)
                    {
                        message = ($"Book with ID {bid} not found.");
                    }
                    else
                    {
                        // Update the other fields of the book with the values entered in the other TextBoxes
                        book.BookName = tbTitle.Text;
                        book.Author = tbAuthor.Text;
                        book.Publisher = tbPublisher.Text;
                        book.Price = Convert.ToInt32(tbPrice.Text);
                        book.Quantity = Convert.ToInt32(tbQuantity.Text);
                        context.Update(book);
                        context.SaveChanges();
                        message = "Student edited successfully.";

                    }
                }
            }
            MessageBox.Show(message);
            populate();
        }




        private void btnRefresh_Click(object sender, EventArgs e)
        {
            tbBookId.Text = "";
            tbTitle.Text = "";
            tbAuthor.Text = "";
            tbPublisher.Text = "";
            tbQuantity.Text = "";
            tbPrice.Text = "";
        }

        private void dgvBookList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dgvBookList.SelectedCells.Count > 0)
            {
                int selectedRowIndex = dgvBookList.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvBookList.Rows[selectedRowIndex];
                string cellValue = Convert.ToString(selectedRow.Cells["BookId"].Value);
                if (!string.IsNullOrEmpty(cellValue))
                {
                    using (var context = new LibraryManagementSystemContext())
                    {
                        try
                        {
                            int ID = Convert.ToInt32(cellValue);
                            Book book = context.Books.FirstOrDefault(b => b.BookId == ID);

                            if (book != null)
                            {
                                tbBookId.Text = book.BookId.ToString();
                                tbTitle.Text = book.BookName;
                                tbAuthor.Text = book.Author;
                                tbPublisher.Text = book.Publisher;
                                tbQuantity.Text = book.Quantity.ToString();
                                tbPrice.Text = book.Price.ToString();
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

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }
    }
}
