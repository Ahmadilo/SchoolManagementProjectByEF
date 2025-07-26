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

namespace SchoolManagementSystem.WinForm.Apps
{
    public partial class frmAttendacesRecode : Form
    {

        private Dictionary<int, string> dcrClasses =
            clsSchoolClass
            .GetAllClasses()
            .ToDictionary(c => c.ID, c => c.ClassName);

        private Dictionary<int, string> dcrSubjects = null;

        private List<clsStudent> StudentsInClass = null;

        private clsAttendaceRecodesServices AttendaceRecodesServices = null;

        private bool isSave 
        { 
            get
            {
                return (btnActive.Text == "Apply" && btnSave.Text == "Save");
            }
            set
            {
                if (isSave == value)
                    return;

                if(value == true)
                {
                    btnSave.Text = "Save";
                    btnActive.Text = "Apply";
                    return;
                }

                btnActive.Text = "Clear";
                btnSave.Text = "Update";
            }
        }

        private void SetComponents()
        {
            cmbClasses.Items.Clear();
            cmbClasses.Items.AddRange(
                new string[] {"All"}
                .Concat(
                    dcrClasses
                    .Select(d => d.Value)
                    .ToArray()
                )
                .ToArray()
            );

            cmbSubjects.SelectedIndex = -1;
            cmbSubjects.Items.Clear();
            cmbSubjects.Enabled = false;

            var today = DateTime.Today;

            dtpDate.MinDate = today.AddYears(-50);
            dtpDate.MaxDate = today.AddDays(1).AddTicks(-1); // آخر لحظة في اليوم
            dtpDate.Value = today;

            cmbClasses.SelectedIndex = 0;
            ucShowTable1.Visible = false;

            isSave = true;
        }

        public frmAttendacesRecode()
        {
            InitializeComponent();
            SetComponents();
        }

        private void ApplyClick()
        {
            ucShowTable1.Visible = true;
            ucShowTable1.LoadData(AttendaceRecodesServices.GetNewStudentAttendanceRecodes());
            ucShowTable1.Refresh();
        }

        private void ClearClick()
        {
            SetComponents();

            AttendaceRecodesServices = null;
        }

        private void cmbClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbClasses.SelectedItem.ToString() == "All")
            {
                return;
            }

            cmbSubjects.Enabled = true;
            cmbSubjects.Items.Clear();

            string className = cmbClasses.Text.Trim();

            var match = dcrClasses.FirstOrDefault(d => d.Value == className);
            if (match.Equals(default(KeyValuePair<int, string>)))
            {
                MessageBox.Show("Selected class not found!");
                return;
            }

            int classID = match.Key;

            List<clsSubject> lessons =
                clsSchoolClass
                .Find(classID)
                .PeriodsList
                .Where(p => p.Subject != null)
                .Select(p => p.Subject)
                .ToList();

            if (lessons == null || lessons.Count == 0)
            {
                MessageBox.Show("There are no subjects assigned to this class.");
                return;
            }

            dcrSubjects = lessons.GroupBy(l => l.ID).ToDictionary(l => l.Key, l => l.First().SubjectName);

            cmbSubjects.Items.AddRange(lessons.Select(l => l.SubjectName).ToArray());
        }

        private void SetService()
        {
            int ClassID = dcrClasses.First(c => c.Value == cmbClasses.SelectedItem.ToString()).Key;
            int SubjectID = dcrSubjects.First(s => s.Value == cmbSubjects.SelectedItem.ToString()).Key;

            AttendaceRecodesServices = new clsAttendaceRecodesServices(ClassID: ClassID, SubjectID: SubjectID, Date: dtpDate.Value);
        }

        private void cmbSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetService();
        }

        private void SaveClick()
        {
            List<tmpAttendanceRecode> TamplateList = ucShowTable1.ExportData() as List<tmpAttendanceRecode>;
            if(AttendaceRecodesServices.isNew)
            {
                if (AttendaceRecodesServices.AddAttendance(TamplateList))
                {
                    Utilty.SusseccfullyMessage("Add Attendance to Students");
                    isSave = false;
                }
                else
                    Utilty.FaildedMessage("Faild To Add Attendace to Students");
            }

        }

        private void UpdateClick()
        {
            List<tmpAttendanceRecode> TamplateList = ucShowTable1.ExportData() as List<tmpAttendanceRecode>;

            if(!AttendaceRecodesServices.isNew)
            {
                //Utilty.SusseccfullyMessage("Update Funcation work count of list" + TamplateList.Any(a => a.GetAttendanceID() <= 0).ToString());
                if (AttendaceRecodesServices.EditAttendance(TamplateList))
                    Utilty.SusseccfullyMessage("Seccessfully Update Student Attandances");
                else
                    Utilty.FaildedMessage("Faild to Update Student Attandaces");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(isSave)
            {
                SaveClick();
            }
            else
            {
                UpdateClick();
            }
        }

        private void btnActive_Click(object sender, EventArgs e)
        {
            if (isSave)
                ApplyClick();
            else
                ClearClick();
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            SetService();
        }
    }
}
