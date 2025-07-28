using StudentManagementSystem.BusinessLogic.Features.Operations;
using StudentManagementSystem.BusinessLogic.Humans;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagementSystem.WinForm.Humans
{
    public partial class frmStudentDetails : Form
    {
        protected void RefreshData()
        {
            humansTable1.LoadData(clsStudentDetails.GetAllStudentDetails());
        }
        public frmStudentDetails()
        {
            InitializeComponent();
            humansTable1.values = new[]
            {
                ("StudentID", 0, true, true),
                ("FirstName", 1, true, false),
                ("LastName", 2, true, false),
                ("DateOfBirth", 3, true, false),
                ("Gender", 4, true, false),
                ("Email", 5, true, false),
                ("Phone", 6, true, false),
                ("Address", 7, true, false),
                ("EnrollmentNumber", 8, true, false),
                ("EnrollmentDate", 9, true, false),
                ("CurrentGradeLevel", 10, true, false),
                ("ClassName", 11, true, false),
                ("AcademicYear", 12, true, false)
            };
            humansTable1.LoadData(clsStudentDetails.GetAllStudentDetails());
        }

        private int StudentID = -1;

        private void frmStudentDetails_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void DeleteClick(object sender, int StudentID)
        {
            clsStudent StudentToDelete = clsStudent.Find(StudentID);

            if (StudentToDelete == null)
            {
                MessageBox.Show("Student not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsPerson Person = clsPerson.Find(StudentToDelete.PersonID);

            DialogResult result = MessageBox.Show($"Are you sure you want to delete the student {Person.FirstName} {Person.LastName}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                if (clsStudent.Delete(StudentToDelete.ID))
                {
                    MessageBox.Show("Student deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshData();
                }
                else
                {
                    MessageBox.Show("Failed to delete student.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void EditClick(object sender, int StudentID)
        {
            if (clsStudent.Find(StudentID) != null)
            {
                DialogResult Result = new frmManagementStudent(StudentID).ShowDialog(this);

                if (Result == DialogResult.OK)
                {
                    MessageBox.Show("Student details updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshData();
                }
            }
        }
    }
}
