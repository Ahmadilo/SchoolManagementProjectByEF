using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentManagementSystem.BusinessLogic.Features.Services;

namespace SchoolManagementSystem.WinForm.Reports
{
    public partial class frmStudentsMarksReportForSelectedSubject : Form
    {
        private clsClassService _classService = null;
        private clsReportStudentMarksService _mainService = null;

        private Dictionary<string, int> dicClasses = clsClassService.GetAllClasses();
        private Dictionary<string, int> dicSubjects = null;

        public frmStudentsMarksReportForSelectedSubject()
        {
            InitializeComponent();
        }

        private void frmStudentsMarksReportForSelectedSubject_Load(object sender, EventArgs e)
        {
            cmbClasses.Items.AddRange(dicClasses.Select(d => d.Key).ToArray());

            cmbClasses.SelectedIndex = -1; // No class selected initially
        }

        private void cmbClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbClasses.SelectedIndex == -1)
                return;

            string selectedClass = cmbClasses.SelectedItem.ToString();

            if(dicClasses.TryGetValue(selectedClass, out int classId))
            {
                _classService = new clsClassService(classId);
                dicSubjects = _classService.GetAllSubjects();

                if (dicSubjects == null || dicSubjects.Count == 0)
                {
                    MessageBox.Show("No subjects found for the selected class.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbSubjects.Items.Clear();
                    cmbSubjects.SelectedIndex = -1;
                    return;
                }

                cmbSubjects.Enabled = true;
                cmbSubjects.SelectedIndex = -1;
                cmbSubjects.Items.Clear();
                cmbSubjects.Items.AddRange(dicSubjects.Select(d => d.Key).ToArray());

                return;
            }

            Utilty.ErrorMessage("Error: Not Found ClassID");
        }

        private void cmbSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSubjects.SelectedIndex == -1)
                return;

            string selectedSubject = cmbSubjects.SelectedItem.ToString();

            if(!dicSubjects.TryGetValue(selectedSubject, out int subjectId))
            {
                Utilty.ErrorMessage("Error: Not Found SubjectID");
                return;
            }

            _mainService = new clsReportStudentMarksService(classid: _classService.ClassID, subjectID: subjectId);

            if(_mainService == null)
            {
                Utilty.ErrorMessage("Error: Can't Generate Report of Students Marks");
                lblStatus.Text = "Error: Can't Generate Report of Students Marks";
                return;
            }

            if(!_mainService.CheckRoleService())
            {
                Utilty.ErrorMessage("Error: Can't Generate Report of Students Marks");
                lblStatus.Text = "Error: Can't Generate Report of Students Marks";
                return;
            }

            lblStatus.Text = "Status: Report Generated Is Reade";

            btnApply.Enabled = true;
            btnClean.Enabled = true;
        }

        private void ApplyData()
        {
            if (_mainService.CheckRoleService())
                ucShowTable1.LoadData(_mainService.GetStudentMarksReport());
            else
                Utilty.ErrorMessage("Error: Can't Generate Report of Students Marks");
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if(btnApply.Text == "Apply")
            {
                ApplyData();
                return;
            }
        }
    }
}
