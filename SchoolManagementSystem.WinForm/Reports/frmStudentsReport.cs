using StudentManagementSystem.BusinessLogic.Features.Operations.Reports;
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
    public partial class frmStudentsReport : Form
    {
        private List<clsStudentsReport> _Source = clsStudentsReport.GetStudentsReport();
        private (string Name, int Index, bool Visible, bool Key)[] Rols = new[]
        {
            ("StudentID", 0, true,  true),
            ("FirstName", 1, true, false),
            ("LastName", 2, true, false),
            ("Phone", 3, true, false),
            ("GradeLevel", 4, true, false),
            ("EnrollmentDate", 5, true, false),
            ("ClassName", 6, true, false)
        };

        private void RefreshTable()
        {
            ucShowTable1.LoadData(_Source);
        }

        private void SortTable(object Failtered)
        {
            ucShowTable1.LoadData(Failtered);
        }

        public frmStudentsReport()
        {
            InitializeComponent();
            ucShowTable1.values = Rols;
            ucShowTable1.LoadData(_Source);
            ucShowTable1.EditSetting.Name = "View";
            ucShowTable1.EditSetting.Value = "View";
            ucShowTable1.DeleteSetting.Visiblet = false;
        }

        private void frmStudentsReport_Load(object sender, EventArgs e)
        {
            RefreshTable();

            cmbClass.Items.Add("All");
            cmbClass.Items.AddRange(_Source
                .Select(s => s.ClassName)
                .Distinct()
                .OrderBy(s => s)
                .ToArray());
            cmbClass.SelectedIndex = 0; // No selection by default

            cmbGrad.Items.Add("All");
            cmbGrad.Items.AddRange(_Source
                .Select(s => s.GradeLevel.ToString())
                .Distinct()
                .OrderBy(s => s)
                .ToArray());
            cmbGrad.SelectedIndex = 0; // No selection by default
        }

        private void ucShowTable1_EditClicked(object sender, int StudentID)
        {
            frmStudentReport frm = new frmStudentReport();
            frm.StudentID = StudentID;
            frm.KeyDown += (s, e) => { if (e.KeyCode == Keys.Escape) frm.Close(); }; // Close on Escape key 
            frm.ShowDialog(this);
        }
    }
}
