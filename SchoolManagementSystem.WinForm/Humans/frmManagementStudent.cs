using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentManagementSystem.BusinessLogic.Humans;

namespace SchoolManagementSystem.WinForm.Humans
{
    public partial class frmManagementStudent : Form
    {
        private void RefreshStudentTable()
        {
            humansTable1.LoadData(clsStudent.GetAllStudent());
            humansTable1.RoleValues("ParentID", -1, 0);
        }
        private void AddInputFields()
        {
            ucSaveBar1.InputControls.Clear();
            ucSaveBar1.InputControls.Add(txtEnrollmentNumber);
            ucSaveBar1.InputControls.Add(txtCurrentGradeLevel);
        }

        private int StudentID = -1;
        private int PersonID
        {
            get
            {
                return Convert.ToInt32(lblPersonID.Tag);
            }

            set
            {
                lblPersonID.Tag = value;
                lblPersonID.Text = $"PersonID {value}";
            }
        }
        private int ParentID
        {
            get
            {
                return Convert.ToInt32(lblParentID.Tag);
            }

            set
            {
                lblParentID.Tag = value;
                lblParentID.Text = $"ParentID {value}";
            }
        }

        private void SetComponent()
        {
            this.humansTable1.EditClicked += EditClick;
            this.humansTable1.DeleteClicked += DeleteClick;
            this.ucSaveBar1.SaveChange += SaveClick;
            this.ucSaveBar1.ClearInputsChange += ClearClick;
            this.btnSelectPerson.Click += SelectPersonClick;
            this.btnSelectsParent.Click += SelectParentClick;
        }

        public frmManagementStudent()
        {
            InitializeComponent();
            humansTable1.values = new[]
            {
                ("ID", 0, true, true),
                ("EnrollmentNumber", 1, true, false),
                ("EnrollmentDate", 2, true, false),
                ("CurrentGradeLevel", 3, true, false),
                ("PersonID", 4, true, false),
                ("ParentID", 5, true, false)
            };
            humansTable1.LoadData(clsStudent.GetAllStudent());
            AddInputFields();
            SetComponent();
            this.PersonID = 1;
            this.ParentID = 1;
        }

        private void frmManagementStudent_Load(object sender, EventArgs e)
        {
            RefreshStudentTable();
        }

        private void SaveClick(object sender, EventArgs e)
        {
            clsStudent Student;
            if(StudentID == -1)
            {
                Student = new clsStudent();
                Student.PersonID = PersonID;
                Student.ParentID = ParentID;
                Student.EnrollmentDate = DateTime.Now;
                ucSaveBar1.Save(Student);
                RefreshStudentTable();
                return;
            }

            Student = clsStudent.Find(StudentID);
            if (Student == null)
            {
                MessageBox.Show("Student not found.");
                return;
            }

            Student.PersonID = PersonID;
            Student.ParentID = ParentID;
            ucSaveBar1.Save(Student);
            RefreshStudentTable();
        }

        private void ClearClick(object sender, EventArgs e)
        {
            StudentID = -1;
            PersonID = 1;
            ParentID = 1;
        }

        private void EditClick(object sender, int StudentID)
        {
            clsStudent Student = clsStudent.Find(StudentID);

            if(Student == null)
            {
                MessageBox.Show("Student not found.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.StudentID = StudentID;

            txtEnrollmentNumber.Text = Student.EnrollmentNumber;
            txtCurrentGradeLevel.Text = Student.CurrentGradeLevel.ToString();
        }

        private void DeleteClick(object sender, int StudentID)
        {
            clsStudent studentToDelete = clsStudent.Find(StudentID);

            if (studentToDelete == null)
            {
                MessageBox.Show("The Student To Delete is not Find!", "Error Mssage", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete this student?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.No)
                return;

            if (clsStudent.Delete(studentToDelete.ID))
            {
                MessageBox.Show("Student deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshStudentTable();
            }
            else
            {
                MessageBox.Show("Failed to delete student.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetPersonID(object sender, int PersonID)
        {
            this.PersonID = PersonID;
        }

        private void GetParentID(object sender, int ParentID)
        {
            this.ParentID = ParentID;
        }

        private void SelectParentClick(object sender, EventArgs e)
        {
            frmSelectStaff frm = new frmSelectStaff(new[]
            {
                ("ID", 0, true, true),
                ("FirstName", 1, true, false),
                ("LastName", 2, true, false),
                ("DateOfBirth", 3, true, false),
                ("Email", 4, true, false)
            }, clsPerson.GetAllPeople());

            frm.SelectHuman += GetParentID;

            frm.ShowDialog();
        }

        private void SelectPersonClick(object sender, EventArgs e)
        {
            frmSelectStaff frm = new frmSelectStaff(new[]
            {
                ("ID", 0, true, true),
                ("FirstName", 1, true, false),
                ("LastName", 2, true, false),
                ("DateOfBirth", 3, true, false),
                ("Email", 4, true, false)
            }, clsPerson.GetAllPeople());

            frm.SelectHuman += GetPersonID;

            frm.ShowDialog();
        }
    }
}
