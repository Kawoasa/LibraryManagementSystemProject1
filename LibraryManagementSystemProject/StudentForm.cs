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
using System.Xml.Linq;

namespace ManagementLibraryProject
{
    public partial class StudentForm : Form
    {
        public StudentForm()
        {
            InitializeComponent();
        }
        public void populate()
        {
            using (var context = new LibraryManagementSystemContext())
            {
                cbStDep.ValueMember = "StdDepartmentId";
                cbStDep.DisplayMember = "StdDepartmentName";
                cbStDep.DataSource = context.StudentDepartments.ToList();

                cbStdSem.ValueMember = "StdSemesterId";
                cbStdSem.DisplayMember = "StdSemesterName";
                cbStdSem.DataSource = context.StudetnSemesters.ToList();

                dgvStd.DataSource = context.Students.Select(x => new
                {
                    x.StdId,
                    x.StdName,
                    x.StdDeparment,
                    x.StdSemester,
                    x.StdPhone
                }).ToList();
            }

        }


        private void StudentForm_Load(object sender, EventArgs e)
        {
            populate();
        }



        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dgvStd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dgvStd.SelectedCells.Count > 0)
            {
                int selectedRowIndex = dgvStd.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvStd.Rows[selectedRowIndex];
                string cellValue = Convert.ToString(selectedRow.Cells["StdId"].Value);
                if (!string.IsNullOrEmpty(cellValue))
                {
                    using (var context = new LibraryManagementSystemContext())
                    {
                        try
                        {
                            int ID = Convert.ToInt32(cellValue);
                            Student student = context.Students
                                .Include(e => e.StdDeparmentNavigation)
                                .Include(e => e.StdSemesterNavigation)
                                .FirstOrDefault(e => e.StdId == ID);

                            if (student != null)
                            {
                                tbStdId.Text = student.StdId.ToString();
                                tbStdName.Text = student.StdName;
                                tbStdPhone.Text = student.StdPhone;
                                cbStDep.SelectedValue = student.StdDeparmentNavigation.StdDepartmentId;
                                cbStdSem.SelectedValue = student.StdSemesterNavigation.StdSemesterId;
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            tbStdId.Text = "";
            tbStdName.Text = "";
            tbStdPhone.Text = "";
            cbStdSem.SelectedIndex = 0;
            cbStDep.SelectedIndex = 0;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string message = "";
            if (string.IsNullOrWhiteSpace(tbStdId.Text) || string.IsNullOrWhiteSpace(tbStdName.Text) ||
            string.IsNullOrWhiteSpace(tbStdPhone.Text))
            {
                message = "Missing Information";
            }
            else if (!int.TryParse(tbStdId.Text, out var sid))
            {
                message = "Invalid ID format. Please enter a valid integer value.";
            }
            else if (sid <= 0)
            {
                message = "Invalid ID value. Please enter a positive integer value.";
            }
            else if (!long.TryParse(tbStdPhone.Text, out var phone))
            {
                message = "Phone number should only contain digits.";
            }
            else if (tbStdPhone.Text.Length != 11)
            {
                message = "Phone number should be 11 digits.";
            }
            else
            {
                using (var context = new LibraryManagementSystemContext())
                {
                    // Get the existing student from the database using the ID
                    var student = context.Students.Include(s => s.StdDeparmentNavigation).Include(s => s.StdSemesterNavigation).FirstOrDefault(s => s.StdId == sid);
                    if (student == null)
                    {
                        message = ($"Student with ID {sid} not found.");
                    }
                    else
                    {

                        // Update the other fields of the student with the values entered in the other TextBoxes
                        student.StdName = tbStdName.Text;
                        student.StdPhone = tbStdPhone.Text;
                        student.StdDeparmentNavigation = context.StudentDepartments.FirstOrDefault(sd => sd.StdDepartmentId == Convert.ToInt32(cbStDep.SelectedValue));
                        student.StdSemesterNavigation = context.StudetnSemesters.FirstOrDefault(ss => ss.StdSemesterId == Convert.ToInt32(cbStdSem.SelectedValue));
                        context.Update(student);
                        context.SaveChanges();
                        message = "Student edited successfully.";
                    }


                }
            }
            MessageBox.Show(message);
            populate();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            string message = "";
            if (string.IsNullOrWhiteSpace(tbStdId.Text) || string.IsNullOrWhiteSpace(tbStdName.Text) ||
            string.IsNullOrWhiteSpace(tbStdPhone.Text))
            {
                message = "Missing Information";
            }
            else if (!int.TryParse(tbStdId.Text, out var sid))
            {
                message = "Invalid ID format. Please enter a valid integer value.";
            }
            else if (sid <= 0)
            {
                message = "Invalid ID value. Please enter a positive integer value.";
            }
            else if (!long.TryParse(tbStdPhone.Text, out var phone))
            {
                message = "Phone number should only contain digits.";
            }
            else if (tbStdPhone.Text.Length != 11)
            {
                message = "Phone number should be 11 digits.";
            }
            else
            {
                string sname = tbStdName.Text;
                string sphone = tbStdPhone.Text;
                StudentDepartment sDepartment = (StudentDepartment)cbStDep.SelectedItem;
                StudetnSemester sSemester = (StudetnSemester)cbStdSem.SelectedItem;
                Student student = new Student()
                {
                    StdId = sid,
                    StdName = sname,
                    StdPhone = sphone,
                    StdDeparment = sDepartment.StdDepartmentId,
                    StdSemester = sSemester.StdSemesterId
                };

                using (var context = new LibraryManagementSystemContext())
                {
                    if (context.Students.Any(x => x.StdId == sid))
                    {
                        message = "Student ID already exists.";

                    }
                    else
                    {
                        dgvStd.DataSource = context.Students.Select(x => new
                        {
                            x.StdId,
                            x.StdName,
                            x.StdPhone,
                            StdDeparment = x.StdDeparmentNavigation.StdDepartmentId,
                            StdSemester = x.StdSemesterNavigation.StdSemesterId
                        }).ToList();
                        context.Add(student);
                        context.SaveChanges();
                        message = "Student added successfully.";
                    }

                }
            }
            MessageBox.Show(message);
            populate();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string message = "";
            if (string.IsNullOrWhiteSpace(tbStdId.Text))
            {
                message = "Please enter the ID of the student you want to remove.";
            }
            else if (!int.TryParse(tbStdId.Text, out var sid))
            {
                message = "Invalid ID format. Please enter a valid integer value.";
            }
            else if (sid <= 0)
            {
                message = "Invalid ID value. Please enter a positive integer value.";
            }
            else
            {
                using (var context = new LibraryManagementSystemContext())
                {
                    // Get the existing student from the database using the ID
                    var student = context.Students.FirstOrDefault(s => s.StdId == sid);
                    if (student == null)
                    {
                        message = ($"Student with ID {sid} not found.");
                    }
                    else
                    {
                        context.Students.Remove(student);
                        context.SaveChanges();
                        message = "Student removed successfully.";
                    }
                }
            }
            MessageBox.Show(message);
            populate();
            tbStdId.Text = "";
            tbStdName.Text = "";
            tbStdPhone.Text = "";
            cbStdSem.SelectedIndex = 0;
            cbStDep.SelectedIndex = 0;
        }
    }
}
