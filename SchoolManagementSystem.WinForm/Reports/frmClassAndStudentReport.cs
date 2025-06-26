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

namespace SchoolManagementSystem.WinForm.Reports
{
    public partial class frmClassAndStudentReport : Form
    {
        private List<clsSchoolClass> ClassData = clsSchoolClass.GetAllClasses();
        private List<clsStudent> StudentData = clsStudent.GetAllStudent();

        private (string Name, int Index, bool Visible, bool Key)[] Classvalues = new[]
        {
            ("ID", 0, true, true),
            ("ClassName", 1, true, false),
            ("GradeLevel", 2, true, false),
            ("AcademicYear", 3, true, false),
            ("TeacherID", 4, false, false)
        };
        private (string Name, int Index, bool Visible, bool Key)[] Studentvalues = new[]
        {
            ("ID", 0, true, true),
            ("FullName", 1, true, false),
            ("EnrollmentNumber", 2, true, false),
            ("CurrentGradeLevel", 3, true, false)
        };

        private void SetTable(HumansTable Table, (string Name, int Index, bool Visible, bool Key)[] values, object DataSource)
        {
            Table.values = values;
            Table.LoadData(DataSource);
        }
        
        private void RefreshTables()
        {
            clsSchoolClass Class = new clsSchoolClass();
            clsStudent Student = new clsStudent();
            SetTable(ClassTable, Classvalues, clsSchoolClass.GetAllClasses());
            SetTable(StudentTable, Studentvalues, clsStudent.GetAllStudent());
        }

        public frmClassAndStudentReport()
        {
            InitializeComponent();
            RefreshTables();
        }

        private void frmClassAndStudentReport_Load(object sender, EventArgs e)
        {
            RefreshTables();
        }

        private void FailterTable(HumansTable Table, (string Name, int Index, bool Visible, bool Key)[] values, object DataSourse)
        {
            Table.values = values;
            Table.LoadData(DataSourse);
        }

        private int StudentID = 0;
        private int ClassID = 0;

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.StudentID = 0;
            this.ClassID = 0;
            btnClear.Visible = false;
            txtClassName.Text = string.Empty;
            txtStudentName.Text = string.Empty;
            RefreshTables();
        }

        private void StudentEditClick(object sender, int StudentID)
        {
            if (StudentID <= 0)
                return;

            btnClear.Visible = true;
            txtStudentName.Text = StudentData.First(s => s.ID == StudentID).FullName;
            FailterTable(ClassTable, Classvalues, clsSchoolClass.GetClassesForStudent(StudentID));
        }

        private void ClassEditClick(object sender, int ClassID)
        {
            if (ClassID <= 0)
                return;
            btnClear.Visible = true;
            txtStudentName.Text = ClassData.First(c => c.ID == ClassID).ClassName;
            FailterTable(StudentTable, Studentvalues, clsStudent.GetAllStudentInClass(ClassID));
        }
    }
}
