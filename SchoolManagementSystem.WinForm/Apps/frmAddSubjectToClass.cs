using StudentManagementSystem.BusinessLogic.Activates;
using StudentManagementSystem.BusinessLogic.Assets;
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
    public partial class frmAddSubjectToClass : Form
    {
        private void RefreshData()
        {
            SubjectsTable.LoadData(clsSubject.GetAllSubjects());
            ClassesTable.LoadData(clsSchoolClass.GetAllClasses());
        }

        public frmAddSubjectToClass()
        {
            InitializeComponent();

            clsSubject subject = new clsSubject();
            SubjectsTable.values = new[]
            {
                (nameof(subject.ID), 0, true, true),
                (nameof(subject.SubjectName), 1, true, false),
                (nameof(subject.SubjectCode), 2, true, false),
            };
            SubjectsTable.LoadData(clsSubject.GetAllSubjects());

            clsSchoolClass schoolClass = new clsSchoolClass();
            ClassesTable.values = new[]
            {
                (nameof(schoolClass.ID), 0, true, true),
                (nameof(schoolClass.ClassName), 1, true, false),
                (nameof(schoolClass.GradeLevel), 2, true, false),
            };
            ClassesTable.LoadData(clsSchoolClass.GetAllClasses());
        }

        private int SubjectID = 0;
        private int ClassID = 0;

        private void frmAddSubjectToClass_Load(object sender, EventArgs e)
        {
            RefreshData();
            cmbDays.Items.AddRange(Enum.GetNames(typeof(DayOfWeek)));
            cmbDays.SelectedIndex = 0; // Default to the first day of the week
        }

        private void SubjectTableEditClick(object sender, int SubjectID)
        {
            if (SubjectID <= 0)
                return;

            this.SubjectID = SubjectID;
            clsSubject subject = clsSubject.Find(SubjectID);
            txtSubjectName.Text = subject.SubjectName;
        }

        private void ClassTableEditClick(object sender, int ClassID)
        {
            if (ClassID <= 0)
                return;

            this.ClassID = ClassID;
            clsSchoolClass schoolClass = clsSchoolClass.Find(ClassID);
            txtClassName.Text = schoolClass.ClassName;
        }

        private void ClearClick(object sender, EventArgs e)
        {
            SubjectID = 0;
            ClassID = 0;
            txtSubjectName.Clear();
            txtClassName.Clear();
            RefreshData();
        }

        private TimeSpan GetTimeFormText(string Text)
        {
            if(TimeSpan.TryParse(Text, out TimeSpan time))
            {
                return time;
            }
            else
            {
                throw new FormatException("Invalid time format. Please use HH:mm format.");
            }
        }

        private void SaveClick(object sender, EventArgs e)
        {
            if (SubjectID <= 0 || ClassID <= 0)
            {
                MessageBox.Show("Please select a subject and a class.");
                return;
            }

            clsSubject subject = clsSubject.Find(SubjectID);
            clsSchoolClass schoolClass = clsSchoolClass.Find(ClassID);

            if (subject == null || schoolClass == null)
            {
                MessageBox.Show("Invalid subject or class selected.");
                return;
            }

            clsClassSubject SubjectToClass = new clsClassSubject();

            SubjectToClass.SubjectID = SubjectID;
            SubjectToClass.ClassID = ClassID;
            SubjectToClass.StartTime = GetTimeFormText(mskStartTime.Text);
            SubjectToClass.EndTime = GetTimeFormText(mskEndTime.Text);
            if(schoolClass.TeacherID.HasValue)
            {
                SubjectToClass.TeacherID = schoolClass.TeacherID.Value; // Assuming TeacherID is nullable
            }
            SubjectToClass.ScheduleDay = cmbDays.SelectedItem?.ToString() ?? string.Empty;

            if(!SubjectToClass.Save())
            {
                MessageBox.Show("Failed to add subject to class. Please try again." + string.Join(", ", SubjectToClass.ErrorMessages));
                return;
            }


            // Assuming you want to set the current date as the enrollment date
            // Assuming you want to set the current time as the start time

            MessageBox.Show("Subject added to class successfully.");
            RefreshData();
        }
    }
}
