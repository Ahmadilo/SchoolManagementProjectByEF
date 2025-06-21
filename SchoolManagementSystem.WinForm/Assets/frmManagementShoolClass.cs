using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SchoolManagementSystem.WinForm.Humans;
using StudentManagementSystem.BusinessLogic.Assets;
using StudentManagementSystem.BusinessLogic.Humans;

namespace SchoolManagementSystem.WinForm.Assets
{
    public partial class frmManagementShoolClass : Form
    {
        private void SetComponenet()
        {
            ucSaveBar1.InputControls.Clear();
            ucSaveBar1.InputControls.Add(txtClassName);
            ucSaveBar1.InputControls.Add(txtGradeLevel);
            ucSaveBar1.InputControls.Add(txtAcademicYear);

            lblTeacherID.Tag = -1;
            ucSaveBar1.SaveChange += SaveClick;
            ucSaveBar1.ClearInputsChange += ClearClick;
            humansTable1.DeleteClicked += DeleteClick;
            humansTable1.EditClicked += EditClick;
            btnSelectTeacher.Click += SelectTeacherClick;
        }

        private void RefreshData()
        {
            humansTable1.LoadData(clsSchoolClass.GetAllClasses());
        }
        public frmManagementShoolClass()
        {
            InitializeComponent();
            humansTable1.values = new[]
            {
                ("ID", 0, true, true),
                ("ClassName", 1, true, false),
                ("GradeLevel", 2, true, false),
                ("AcademicYear", 3, true, false),
                ("TeacherID", 4, true, false)
            };
            humansTable1.LoadData(clsSchoolClass.GetAllClasses());
            SetComponenet();
        }

        private int ClassID = -1;
        private int TeacherID
        {
            get
            {
                return Convert.ToInt32(lblTeacherID.Tag);
            }

            set
            {
                lblTeacherID.Tag = value;
                lblTeacherID.Text = $"TeacherID {value}";
            }
        }

        private void frmManagementShoolClass_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void GetTeacherID(object sender, int TeacherID)
        {
            this.TeacherID = TeacherID;
        }

        private void SelectTeacherClick(object sender, EventArgs e)
        {
            frmSelectStaff frm = new frmSelectStaff(new[]
            {
                ("ID", 0, true, true),
                ("SubjectSpecialization", 1,true, false),
                ("StaffID", 2, true, false)
            }, clsTeacher.GetAllTeacher());

            frm.SelectHuman += GetTeacherID;

            frm.ShowDialog();
        }

        private void SaveClick(object sender, EventArgs e)
        {
            clsSchoolClass SchoolClass = null;
            if (ClassID == -1)
            {
                SchoolClass = new clsSchoolClass();

                if (TeacherID == -1)
                    SchoolClass.TeacherID = null;
                else
                    SchoolClass.TeacherID = TeacherID;
                ucSaveBar1.Save(SchoolClass);
                RefreshData();
            }

            SchoolClass = clsSchoolClass.Find(ClassID);

            if (ucSaveBar1 == null)
            {
                MessageBox.Show(Text = "Please fill all fields before saving.",
                    caption: "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (TeacherID == -1)
                SchoolClass.TeacherID = null;
            else
                SchoolClass.TeacherID = TeacherID;
            ucSaveBar1.Save(SchoolClass);
            RefreshData();
        }

        private void ClearClick(object sender, EventArgs e)
        {
            this.TeacherID = -1;
            this.ClassID = -1;
        }

        private void EditClick(object sender, int ClassID)
        {
            clsSchoolClass schoolClass = clsSchoolClass.Find(ClassID);

            if (schoolClass == null)
            {
                MessageBox.Show("Dont Find The Class.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.ClassID = schoolClass.ID;
            this.TeacherID = schoolClass.TeacherID ?? -1;
            txtClassName.Text = schoolClass.ClassName;
            txtGradeLevel.Text = schoolClass.GradeLevel.ToString();
            txtAcademicYear.Text = schoolClass.AcademicYear.ToString();
        }

        private void DeleteClick(object sender, int ClassID)
        {
            clsSchoolClass ClassToDelete = clsSchoolClass.Find(ClassID);

            if (ClassToDelete == null)
            {
                MessageBox.Show("Dont Find The Class.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this class?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (clsSchoolClass.Delete(ClassToDelete.ID))
                {
                    MessageBox.Show("Class deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshData();
                }
                else
                {
                    MessageBox.Show("Failed to delete class. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
