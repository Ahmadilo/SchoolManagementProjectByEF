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
    public partial class ucClassCard : UserControl
    {
        private int _classid = -1;

        private void FillClassData()
        {
            clsSchoolClass Class = clsSchoolClass.Find(_classid);

            if (Class == null)
                return;

            lblClassName.Text = Class.ClassName;
            lblGrad.Text = Class.GradeLevel.ToString();
            lblYear.Text = Class.AcademicYear.ToString();
            lblTeacherName.Text = clsTeacher.Find(Class.TeacherID.Value)?.FullName ?? "No Teacher Assigned";
        }

        private void ClearClassData()
        {
            string Clear = "[????]";
            lblClassName.Text = Clear;
            lblGrad.Text = Clear;
            lblYear.Text = Clear;
            lblTeacherName.Text = Clear;
        }

        public ucClassCard()
        {
            InitializeComponent();
        }

        public int? ClassID 
        { 
            get
            {
                return _classid;
            }
            set
            {
                if (!value.HasValue || value.Value < 1)
                    ClearClassData();
                else
                {
                    _classid = value.Value;
                    FillClassData();
                }    
            }
        } 
    }
}
