using StudentManagementSystem.BusinessLogic.Activates;
using StudentManagementSystem.BusinessLogic.Assets;
using StudentManagementSystem.BusinessLogic.Features.Operations.Templates;
using StudentManagementSystem.BusinessLogic.Features.Services;
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
    public partial class frmClassAttendacesReport : Form
    {
        private clsStudentAttendacesReportServices services = null;

        private void SetComponent()
        {
            ucShowTable1.DeleteSetting.Visiblet = false;
            ucShowTable1.EditSetting.Visiblet = false;
        }

        public frmClassAttendacesReport()
        {
            InitializeComponent();
            SetComponent();
        }

        private void frmClassAttendacesReport_Load(object sender, EventArgs e)
        {
            cmbClasses.Items.Clear();
            cmbClasses.Items.AddRange(clsSchoolClass.GetAllClasses().Select(c => c.ClassName).ToArray());

            cmbClasses.SelectedIndex = -1;
        }

        private void cmbClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbClasses.SelectedIndex != -1)
            {
                string selectClass = cmbClasses.SelectedItem.ToString().Trim();

                string[] subjectsNames = clsClassSubject.GetAllClassSubjects()
                    .Where(cs => cs.SchoolClass.ClassName == selectClass)
                    .Select(cs => cs.Subject.SubjectName)
                    .Distinct()
                    .ToArray();

                cmbSubjets.Items.Clear();
                cmbSubjets.SelectedIndex = -1;
                cmbSubjets.Items.AddRange(subjectsNames);


                cmbSubjets.Enabled = true;
            }
        }

        private List<tmpStudentAttendecesListForClass> GetFilteredList()
        {
            IEnumerable<tmpStudentAttendecesListForClass> list = services.GetClassStudentAttendaces();

            if(cmbStatus.SelectedIndex != -1)
            {
                list = list.Where(l => l.Status == cmbStatus.SelectedItem.ToString().Trim());
            }

            return list.ToList();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            ucShowTable1.LoadData(GetFilteredList());

            btnClear.Enabled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbClasses.SelectedIndex = -1;

            cmbSubjets.Items.Clear();
            cmbSubjets.Enabled = false;
            

            ucShowTable1.LoadData(null);

            btnClear.Enabled = false;
        }

        private void cmbSubjets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbSubjets.SelectedIndex != -1)
            {
                string selectSubject = cmbSubjets.SelectedItem.ToString();

                services = new clsStudentAttendacesReportServices(className: cmbClasses.SelectedItem.ToString(), subjectName: selectSubject);

                cmbStatus.Enabled = true;
                cmbStatus.SelectedIndex = -1;
            }
        }

        private void ucExcelExport1_StartExport(object sender, EventArgs e)
        {
            // جمع رؤوس الأعمدة المرئية فقط
            List<string> columnHeaders = new List<string>();

            foreach (DataGridViewColumn column in ucShowTable1.GetTable().Columns)
            {
                if (column.Visible)
                {
                    columnHeaders.Add(column.HeaderText);
                }
            }

            // استخراج البيانات
            var exportedData = Convert.ChangeType(ucShowTable1.ExportData(), typeof(List<tmpStudentAttendecesListForClass>));
            if (exportedData is List<tmpStudentAttendecesListForClass> data)
            {
                // تمرير البيانات إلى وحدة التصدير
                ucExcelExport1.SetData(data, columnHeaders.ToArray());
                return;
            }

            MessageBox.Show("Exported data is not in the expected format.");
        }

    }
}
