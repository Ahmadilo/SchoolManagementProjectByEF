using StudentManagementSystem.BusinessLogic.Features.Operations.Templates;
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
    public partial class frmStudentExamReport : Form
    {
        private List<tmpStudentExm> StudentsExamList = tmpStudentExm.GetStudentExms();

        public frmStudentExamReport()
        {
            InitializeComponent();
        }

        private List<tmpStudentExm> GetExamReportFailtered(string subjectName, string gradeSelected, bool includeNotSet)
        {
            // نبدأ بكل البيانات
            IEnumerable<tmpStudentExm> query = StudentsExamList;

            // فلترة حسب اسم المادة إذا لم تكن "All"
            if (subjectName != "All")
            {
                query = query.Where(s => s.SubjectName == subjectName);
            }

            // فلترة حسب الدرجة إذا لم تكن "All"
            if (gradeSelected != "All")
            {
                query = query.Where(s => s.Grad == gradeSelected);
            }

            // استبعاد "Not Set" إذا كان المستخدم لا يريدها
            if (!includeNotSet)
            {
                query = query.Where(s => s.Grad != "Not Set");
            }

            return query.ToList();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            ucShowTable1.LoadData(
                GetExamReportFailtered(
                    subjectName: cmbSubjectNames.SelectedItem.ToString(),
                    gradeSelected: cmbGrads.SelectedItem.ToString(),
                    includeNotSet: chkNotSet.Checked
                )
            );

            ucExcelExport1.Visible = true;
            ucShowTable1.Visible = true;
            ucShowTable1.Refresh();
        }

        private void frmStudentExamReport_Load(object sender, EventArgs e)
        {
            cmbGrads.Items.AddRange(new string[] {"All", "A", "B", "C", "D", "E", "F"});
            cmbSubjectNames.Items.AddRange(
                new string[] { "All" }
                .Concat( 
                    StudentsExamList
                    .Select(s => s.SubjectName)
                    .Distinct()
                    .ToArray()
                )
                .ToArray()
            );

            cmbGrads.SelectedIndex = 0;
            cmbSubjectNames.SelectedIndex = 0;

            ucShowTable1.ColumnsSetting = new ucShowTable.clsSettingColumn[]
            {
                new ucShowTable.clsSettingColumn(Name: "StudentID", Index: 0, Key: true),
                new ucShowTable.clsSettingColumn(Name: "FullName", Index: 1),
                new ucShowTable.clsSettingColumn(Name: "SubjectName", Index: 2),
                new ucShowTable.clsSettingColumn(Name: "Mark", Index: 3),
                new ucShowTable.clsSettingColumn(Name: "Grad", Index: 4),
            };


            ucExcelExport1.StartExport += ExportClick;
        }

        private void ExportClick(object sender, EventArgs e)
        {
            ucExcelExport1.SetData(ucShowTable1.GetListOfRowsData<tmpStudentExm>(),
                        ucShowTable1
                        .ColumnsSetting.Select(c => c.Name)
                        .ToArray()
                    );
        }
    }
}
