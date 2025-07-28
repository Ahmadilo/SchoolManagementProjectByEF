using StudentManagementSystem.BusinessLogic.Activates;
using StudentManagementSystem.BusinessLogic.Assets;
using StudentManagementSystem.BusinessLogic.Features.Roles;
using StudentManagementSystem.BusinessLogic.Features.Services;
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

namespace SchoolManagementSystem.WinForm.Apps
{
    public partial class frmAssignStudentMark : Form
    {
        private clsStudentMarksRecordingService service = null;
        private Dictionary<int, string> Classes = null;
        private Dictionary<int, string> Subjects = null;
        private static readonly Dictionary<enmGradesType, (int Weight, int MaxScore)> GradeTypeSettings =
        new Dictionary<enmGradesType, (int Weight, int MaxScore)>
        {
            { enmGradesType.Homework,      (10, 10)  },
            { enmGradesType.Quiz,          (15, 10)  },
            { enmGradesType.Test,          (30, 100) },
            { enmGradesType.Project,       (20, 100) },
            { enmGradesType.Practical,     (15, 50)  },
            { enmGradesType.Participation, (10, 10)  }
        };

        private int ClassSubjectID { 
            get
            {
                try
                {
                    if (cmbClasses.SelectedItem == null || cmbSubjects.SelectedItem == null)
                        throw new Exception("Class or Subject not selected.");

                    string className = cmbClasses.SelectedItem.ToString().Trim();
                    string subjectName = cmbSubjects.SelectedItem.ToString().Trim();

                    if (!Classes.ContainsValue(className))
                        throw new Exception("Invalid class name.");

                    if (!Subjects.ContainsValue(subjectName))
                        throw new Exception("Invalid subject name.");

                    int classID = Classes.First(kv => kv.Value == className).Key;
                    int subjectID = Subjects.First(kv => kv.Value == subjectName).Key;

                    return clsClassSubject.GetAllClassSubjects()
                        .FirstOrDefault(cs => cs.ClassID == classID && cs.SubjectID == subjectID)?.ID ?? throw new Exception("Match not found.");
                }
                catch (Exception ex)
                {
                    Utilty.ErrorMessage("There is Error: " + ex.Message);
                    return -1;
                }

            }
        }
        public frmAssignStudentMark()
        {
            InitializeComponent();
        }

        private void frmAssignStudentMark_Load(object sender, EventArgs e)
        {
            Classes = clsSchoolClass.GetAllClasses().ToDictionary(c => c.ID, c => c.ClassName);
            
            cmbClasses.Items.AddRange(
                Classes.Values.ToArray()
            );

            cmbClasses.SelectedIndex = -1;

            ucShowTable1.DeleteSetting.Visiblet = false;
            ucShowTable1.EditSetting.Visiblet = false;
        }

        private void cmbClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbClasses.SelectedIndex != -1)
            {
                //Subjects = clsClassSubject
                //.GetAllClassSubjects(cs => Classes.ContainsKey(cs.ClassID))
                //.GroupBy(cs => cs.SubjectID)
                //.ToDictionary(g => g.Key, g => g.First().Subject.SubjectName);
                if (Subjects != null)
                    Subjects.Clear();

                Subjects = clsClassSubject
                    .GetAllClassSubjects(
                    cs => cs.SchoolClass.ClassName.Trim() 
                    == 
                    cmbClasses.SelectedItem.ToString().Trim()
                    )
                    .GroupBy(cs => cs.Subject.ID)
                    .ToDictionary(d => d.First().Subject.ID, d => d.First().Subject.SubjectName);

                cmbSubjects.SelectedIndex = -1;
                cmbSubjects.Items.Clear();
                cmbSubjects.Items.AddRange(Subjects.Values.ToArray());

                cmbSubjects.SelectedIndex = -1;
                cmbSubjects.Enabled = true;
            }
        }

        private void cmbSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbSubjects.SelectedIndex != -1)
            {
                cmbGradeTypes.Items.Clear();
                cmbGradeTypes.Items.AddRange(Enum.GetNames(typeof(enmGradesType)));
                cmbGradeTypes.SelectedIndex = -1;

                cmbGradeTypes.Enabled = true;
            }
        }

        private void SetWeightAndMarks()
        {
            enmGradesType gradeType = (enmGradesType)Enum.Parse(typeof(enmGradesType), cmbGradeTypes.SelectedItem.ToString().Trim());

            if (GradeTypeSettings.TryGetValue(gradeType, out var settings))
            {
                txtweight.Text = settings.Weight.ToString();
                txtMaxScore.Text = settings.MaxScore.ToString();
            }
            else
            {
                Utilty.ErrorMessage("Error In Select Grade Type!");
            }

        }

        private void newService()
        {
            service = new clsStudentMarksRecordingService(
                    classSubject: clsClassSubject.Find(ClassSubjectID),
                    MaxScore: Convert.ToInt32(txtMaxScore.Text.Trim()),
                    Weight: Convert.ToInt32(txtweight.Text.Trim()),
                    gradType: (enmGradesType)Enum.Parse(typeof(enmGradesType), cmbGradeTypes.SelectedItem.ToString().Trim()),
                    date: dateTimePicker1.Value
                );
        }

        private void cmbGradeTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbGradeTypes.SelectedIndex != -1)
            {
                SetWeightAndMarks();
                newService();


                dateTimePicker1.Enabled = true;
                btnApply.Enabled = true;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            newService();

            btnApply.Enabled = true;
        }

        private void ApplyAction()
        {
            ucShowTable1.LoadData(service.GetStudentListToAddMark());

            btnApply.Text = "Save";
            btnClear.Enabled = true;
        }

        private void SaveAction()
        {
            var StudentMarksList = ucShowTable1.ExportData() as List<tmpAddStudentMark>;

            if(!service.ValidtionStudentMarks(StudentMarksList))
            {
                Utilty.ErrorMessage("Error: " + service.ErrorMessage);
                return;
            }

            if (service.AddStudentMarks(StudentMarksList))
            {
                Utilty.SusseccfullyMessage("Save The Marks of Students");
                btnApply.Text = "Update";
            }
            else
                Utilty.FaildedMessage("Don't Save The Marks of Students");


        }

        private void UpdateAction()
        {
            var list = ucShowTable1.ExportData() as List<tmpAddStudentMark>;

            if(!service.ValidtionStudentMarks(list))
            {
                Utilty.ErrorMessage("Error: " + service.ErrorMessage);
                return;
            }

            if (service.UpdateStudentMarks(list))
                Utilty.SusseccfullyMessage("Update the Marks of Student");
            else
                Utilty.FaildedMessage("Faild Update the Marks of Student");
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (btnApply.Text == "Apply")
            {
                ApplyAction();
                return;
            }

            if(btnApply.Text == "Save")
            {
                SaveAction();
                return;
            }

            if(btnApply.Text == "Update")
            {
                UpdateAction();
                return;
            }
        }

        private void Reset()
        {
            service = null;

            cmbSubjects.SelectedIndex = -1;
            cmbSubjects.Items.Clear();
            cmbSubjects.Enabled = false;

            Subjects.Clear();

            cmbGradeTypes.SelectedIndex = -1;
            cmbGradeTypes.Items.Clear();
            cmbGradeTypes.Enabled = false;

            txtMaxScore.Text = "";
            txtweight.Text = "";

            btnApply.Text = "Apply";
            btnApply.Enabled = false;

            btnClear.Enabled = false;

            ucShowTable1.LoadData(null);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
