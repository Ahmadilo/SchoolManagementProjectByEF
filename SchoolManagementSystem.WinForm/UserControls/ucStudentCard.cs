using StudentManagementSystem.BusinessLogic.Activates;
using StudentManagementSystem.BusinessLogic.Assets;
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

namespace SchoolManagementSystem.WinForm.UserControls
{
    public partial class ucStudentCard : UserControl
    {
        private int _studentId = -1;

        private void FillStudentReport(int studentId)
        {
            clsStudent student = clsStudent.Find(_studentId);

            if (student == null)
            {
                //MessageBox.Show("Student not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime birthDate = clsPerson.Find(student.PersonID).DateOfBirth;
            int age = DateTime.Now.Year - birthDate.Year;

            lblStudentName.Text = student.FullName;
            lblEnrolmentDate.Text = student.EnrollmentDate.ToString("dd/MM/yyyy");
            lblAge.Text = ((DateTime.Now.Month < birthDate.Month ||
               (DateTime.Now.Month == birthDate.Month && DateTime.Now.Day < birthDate.Day))
               ? age - 1 : age).ToString();
            lblGradLevel.Text = student.CurrentGradeLevel.ToString();
            if (clsStudentClass.GetAllStudentClasses().Any(sc => sc.StudentID == student.ID))
            {
                lblClassName.Text = clsStudentClass.GetAllStudentClasses()
                                    .Where(sc => sc.StudentID == student.ID)
                                    .Select(sc => clsSchoolClass.Find(clsStudentClass.Find(sc.ID).ClassID).ClassName)
                                    .FirstOrDefault()
                                    .ToString();
            }
            else
            {
                lblClassName.Text = "N/A";
            }
            lblGender.Text = clsPerson.Find(student.PersonID).Gender.Trim();

            if (student.ParentID != -1)
            {
                clsPerson parent = clsPerson.Find(student.ParentID.Value);
                lblParentName.Text = parent.FullName;
                lblPhone.Text = parent.PhoneNumber;
            }
            else
            {
                lblParentName.Text = "N/A";
                lblPhone.Text = "N/A";
            }
        }

        private void ClearStudentReport()
        {
            string ClearString = "[????]";
            lblStudentName.Text = ClearString;
            lblEnrolmentDate.Text = ClearString;
            lblAge.Text = ClearString;
            lblGradLevel.Text = ClearString;
            lblClassName.Text = ClearString;
            lblGender.Text = ClearString;
            lblParentName.Text = ClearString;
            lblPhone.Text = ClearString;
        }

        public ucStudentCard()
        {
            InitializeComponent();
        }

        public int StudentID
        {
            get { return _studentId; }
            set
            {
                _studentId = value;
                if (_studentId != -1)
                    FillStudentReport(_studentId);
                else
                    ClearStudentReport();
            }
        }
    }
}
