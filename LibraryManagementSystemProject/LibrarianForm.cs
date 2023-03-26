
using LibraryManagementSystemProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementLibraryProject
{
    public partial class LibrarianForm : Form
    {
        public LibrarianForm()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LibrarianForm_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            //ADD
            string message = "";
            if (string.IsNullOrWhiteSpace(tbId.Text) || string.IsNullOrWhiteSpace(tbName.Text) ||
                string.IsNullOrWhiteSpace(tbPassword.Text) || string.IsNullOrWhiteSpace(tbPhone.Text))
            {
                message = "Missing Information";
            }
            else if (!int.TryParse(tbId.Text, out var lid))
            {
                message = "Invalid ID format. Please enter a valid integer value.";
            }
            else if (lid <= 0)
            {
                message = "Invalid ID value. Please enter a positive integer value.";
            }
            else if (!long.TryParse(tbPhone.Text, out var phone))
            {
                message = "Phone number should only contain digits.";
            }
            else if (tbPhone.Text.Length != 11)
            {
                message = "Phone number should be 11 digits.";
            }
            else
            {
                //Check if the ID already exists in the database
                using (var context = new LibraryManagementSystemContext())
                {
                    if (context.Librarians.Any(l => l.LibId == lid))
                    {
                        message = "ID already exists. Please enter a different ID.";
                    }
                    else
                    {
                        // Create and add new librarian to the database
                        var librarian = new Librarian(lid, tbName.Text, tbPassword.Text, tbPhone.Text);
                        context.Add(librarian);
                        context.SaveChanges();
                        message = "Librarian added successfully.";
                    }
                }
            }
            MessageBox.Show(message);
            populate();
        }
        public void populate()
        {
            using (var context = new LibraryManagementSystemContext())
            {
                dgvLibrarian.DataSource = context.Librarians.Select(x => new
                {
                    x.LibId,
                    x.LibName,
                    x.LibPassword,
                    x.LibPhone
                }).ToList();
            }

        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dgvLibrarian.SelectedCells.Count > 0)
            {
                int selectedRowIndex = dgvLibrarian.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvLibrarian.Rows[selectedRowIndex];
                string cellValue = Convert.ToString(selectedRow.Cells["LibId"].Value);
                if (!string.IsNullOrEmpty(cellValue))
                {
                    using (var context = new LibraryManagementSystemContext())
                    {
                        try
                        {
                            int ID = Convert.ToInt32(cellValue);
                            Librarian librarian = context.Librarians.FirstOrDefault(x => x.LibId == ID);
                            if (librarian != null)
                            {
                                tbId.Text = librarian.LibId.ToString();
                                tbName.Text = librarian.LibName;
                                tbPassword.Text = librarian.LibPassword;
                                tbPhone.Text = librarian.LibPhone;
                            }
                            else
                            {
                                MessageBox.Show("Selected librarian record does not exist in the database.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error retrieving librarian record from the database: {ex.Message}");
                        }
                    }
                }
            }
        }


        private void guna2Button2_Click(object sender, EventArgs e)
        {
            //Edit
            string message = "";
            if (string.IsNullOrWhiteSpace(tbName.Text) || string.IsNullOrWhiteSpace(tbPassword.Text) ||
            string.IsNullOrWhiteSpace(tbPhone.Text))
            {
                message = "Missing Information";
            }
            else if (!int.TryParse(tbId.Text, out var lid))
            {
                message = "Invalid ID format. Please enter a valid integer value.";
            }
            else if (lid <= 0)
            {
                message = "Invalid ID value. Please enter a positive integer value.";
            }
            else if (!long.TryParse(tbPhone.Text, out var phone))
            {
                message = "Phone number should only contain digits.";
            }
            else if (tbPhone.Text.Length != 11)
            {
                message = "Phone number should be 11 digits.";
            }
            else
            {
                using (var context = new LibraryManagementSystemContext())
                {

                    // Get the existing librarian from the database using the ID
                    var librarian = context.Librarians.FirstOrDefault(l => l.LibId == lid);
                    if (librarian == null)
                    {
                        message = ($"Librarian with ID {lid} not found.");
                    }
                    else
                    {
                        var existingLibrarianWithPhone = context.Librarians.FirstOrDefault(l => l.LibPhone == tbPhone.Text && l.LibId != librarian.LibId);
                        if (existingLibrarianWithPhone != null)
                        {
                            message = $"Phone number {tbPhone.Text} is already in use by librarian with ID {existingLibrarianWithPhone.LibId}.";
                        }
                        else
                        {
                            // Update the other fields of the librarian with the values entered in the other TextBoxes
                            librarian.LibName = tbName.Text;
                            librarian.LibPassword = tbPassword.Text;
                            librarian.LibPhone = tbPhone.Text;
                            context.SaveChanges();
                            message = "Librarian edit successfully.";
                        }

                    }
                }
            }
            MessageBox.Show(message);
            populate();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            //Refresh
            tbId.Text = "";
            tbName.Text = "";
            tbPassword.Text = "";
            tbPhone.Text = "";
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            //Remove          
            //Check if the ID already exists in the database
            int lid = Convert.ToInt32(tbId.Text);
            using (var context = new LibraryManagementSystemContext())
            {
                var librarian = context.Librarians.FirstOrDefault(l => l.LibId == lid);
                if (librarian == null)
                {
                    MessageBox.Show($"Librarian with ID {lid} not found.");
                    return;
                }

                context.Remove(librarian);
                context.SaveChanges();

                MessageBox.Show("Librarian removed successfully.");
                populate();
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
