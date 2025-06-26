using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentManagementSystem.BusinessLogic.Assets;
using StudentManagementSystem.BusinessLogic.Features.Administrative.Auth;

namespace SchoolManagementSystem.WinForm.UserControls
{
    public partial class ucTeacherClasses : UserControl
    {
        private void RefreshData()
        {
            humansTable1.LoadData(clsSchoolClass.GetClassesByTeacher(clsLogin.UserLogin.Teacher.ID));
        }
        public ucTeacherClasses()
        {
            clsSchoolClass Class = new clsSchoolClass();
            InitializeComponent();
            humansTable1.values = new[]
            {
                (nameof(Class.ID), 0, true, true),
                (nameof(Class.ClassName), 1, true, false),
                (nameof(Class.GradeLevel), 2, true, false),
                (nameof(Class.AcademicYear), 3, true, false)
            };
            humansTable1.LoadData(clsSchoolClass.GetClassesByTeacher(clsLogin.UserLogin.Teacher.ID));
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void ucTeacherClasses_Load(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
