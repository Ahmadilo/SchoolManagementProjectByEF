using StudentManagementSystem.BusinessLogic.Assets;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SchoolManagementSystem.WinForm.Reports
{
    public partial class frmClassesReport : Form
    {
        private List<clsSchoolClass> classes = clsSchoolClass.GetAllClasses();
        
        private void RefreshClasses()
        {
            ucShowTable1.LoadData(classes);
            ucShowTable1.EditSetting.Name = "Select";
            ucShowTable1.EditSetting.Value = "Select";

            ucShowTable1.DeleteSetting.Visiblet = false;
        }

        public frmClassesReport()
        {
            InitializeComponent();
            clsSchoolClass Class = new clsSchoolClass();
            ucShowTable1.values = new[]
            {
                (nameof(Class.ID), 0, true, true),
                (nameof(Class.ClassName), 1, true, false),
                (nameof(Class.GradeLevel), 2, true, false),
                (nameof(Class.AcademicYear), 3, true, false),
            };
            RefreshClasses();
        }

        private void frmClassesReport_Load(object sender, EventArgs e)
        {
            RefreshClasses();
        }

        private void ucShowTable1_EditClicked(object sender, int ClassID)
        {
            frmClassCard frm = new frmClassCard
            {
                ClassID = ClassID
            };

            frm.ShowDialog(this);
        }
    }
}
