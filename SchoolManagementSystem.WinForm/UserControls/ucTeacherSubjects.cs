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
using StudentManagementSystem.BusinessLogic.Features.Operations;

namespace SchoolManagementSystem.WinForm.UserControls
{
    public partial class ucTeacherSubjects : UserControl
    {
        private void RefreshData()
        {
            humansTable1.LoadData(clsTeacherSubjects.GetTeacherSubjectsByTeacherID(clsLogin.UserLogin.Teacher.ID));
        }
        public ucTeacherSubjects()
        {
            InitializeComponent();
            humansTable1.values = new[]
            {
                ("TeacherID", 0, true, true),
                ("SubjectName", 1, true, false),
                ("SubjectID", 2, true, false),
                ("Description", 3, true,false)
            };
            humansTable1.LoadData(clsTeacherSubjects.GetTeacherSubjectsByTeacherID(clsLogin.UserLogin.Teacher.ID));
        }

        private void ucTeacherSubjects_Load(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
