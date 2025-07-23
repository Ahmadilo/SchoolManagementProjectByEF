using StudentManagementSystem.BusinessLogic.Features.Groups;
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

    public partial class frmReoprtSelecter : Form
    {

        public frmReoprtSelecter()
        {
            InitializeComponent();
            SetComponent();
        }

        public Dictionary<string, object> ReportsList = StudentAttendaceReportGroup.GetGroupList().ToDictionary(d => d.ReportName, d => d.ReportExample);

        private void SetComponent()
        {
            cmbReports.Items.AddRange(ReportsList.Select(d => d.Key).ToArray());
        }

        private void ClearReport()
        {
            ucShowTable1.LoadData(null);
        }

        private void ShowReportExample()
        {
            ucShowTable1.LoadData(ReportsList.First(d => d.Key == cmbReports.SelectedItem.ToString()).Value);
        }

        private void cmbReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearReport();
            ShowReportExample();
        }

        private void OpenForm()
        {

        }

        private void btnOkay_Click(object sender, EventArgs e)
        {
            OpenForm();
        }
    }
}
