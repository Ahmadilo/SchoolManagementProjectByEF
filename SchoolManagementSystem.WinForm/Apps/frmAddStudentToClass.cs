using StudentManagementSystem.BusinessLogic.Humans;
using StudentManagementSystem.BusinessLogic.Assets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentManagementSystem.BusinessLogic.Activates;

namespace SchoolManagementSystem.WinForm.Apps
{
    public partial class frmAddStudentToClass : Form
    {
        private void RefreshData()
        {
            humansTable1.LoadData(clsStudent.GetAllStudentsNotInClasses());
            humansTable2.LoadData(clsSchoolClass.GetAllClasses());
        }

        private void FailterData(List<clsStudent> students, List<clsSchoolClass> classes)
        {
            humansTable1.LoadData(students);
            humansTable2.LoadData(classes);
        }

        List<clsStudent> students = clsStudent.GetAllStudentsNotInClasses();
        List<clsSchoolClass> classes = clsSchoolClass.GetAllClasses();

        public frmAddStudentToClass()
        {
            InitializeComponent();
            clsStudent stu = new clsStudent();
            humansTable1.values = new[]
            {
                (nameof(stu.ID), 0, true, true),
                (nameof(stu.FullName), 1, true, false),
                (nameof(stu.CurrentGradeLevel), 2, true, false),
            };
            humansTable1.LoadData(clsStudent.GetAllStudentsNotInClasses());
            clsSchoolClass @class = new clsSchoolClass();
            humansTable2.values = new[]
            {
                (nameof(@class.ID), 0, true, true),
                (nameof(@class.ClassName), 1, true, false),
                (nameof(@class.GradeLevel), 2, true, false),
            };
            humansTable2.LoadData(clsSchoolClass.GetAllClasses());
        }

        private int StudentID = 0;
        private int ClassID = 0;

        private void frmAddStudentToClass_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void StudentEditClick(object sender, int StudentID)
        {
            if (StudentID <= 0)
                return;

            this.StudentID = StudentID;

            txtStudentName.Text = students.First(s => s.ID == StudentID).FullName;
        }

        private void ClassEditClick(object sender, int ClassID)
        {
            if (ClassID <= 0) return;

            this.ClassID = ClassID;
            txtClassName.Text = classes.First(c => c.ID == ClassID).ClassName;
        }

        private void ClearClick(object sender, EventArgs e)
        {
            this.StudentID = 0;
            this.ClassID = 0;
            txtStudentName.Text = string.Empty;
            txtClassName.Text = string.Empty;
            this.students = clsStudent.GetAllStudentsNotInClasses();
            this.classes = clsSchoolClass.GetAllClasses();
        }

        private void SaveClick(object sender, EventArgs e)
        {
            if (StudentID <= 0) return;

            if (ClassID <= 0) return;

            clsStudentClass StudentToClass = new clsStudentClass();
            StudentToClass.StudentID = StudentID;
            StudentToClass.ClassID = ClassID;
            StudentToClass.EnrollmentDate = DateTime.Now;



            if (StudentToClass.Save())
            {
                MessageBox.Show("Student added to class successfully.");
                RefreshData();
                ClearClick(sender, e);
            }
            else
            {
                MessageBox.Show("Failed to add student to class. Please try again." + string.Join(", ", StudentToClass.ErrorMessages));
            }
        }
    }
}
