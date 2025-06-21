using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentManagementSystem.BusinessLogic.Humans;

namespace SchoolManagementSystem.WinForm.Humans
{
    public partial class frmManagementTeachers : Form
    {

        private void RefreshTeachersTable()
        {
            humansTable1.LoadData(clsTeacher.GetAllTeacher());
        }

        private void SetComponent()
        {
            this.humansTable1.DeleteClicked += DeleteClick;
            this.humansTable1.EditClicked += EditClick;
            this.ucSaveBar1.SaveChange += SaveClick;
            this.ucSaveBar1.ClearInputsChange += ClearClick;
            this.btnSelectStaff.Click += btnSelectStaffClick;
        }

        private int GetStaffID()
        {
            string[] strs = lblStaffID.Text.Split(' ');

            if (strs.Length > 2 && int.TryParse(strs[2], out int StaffID))
                return StaffID;

            return -1;
        }

        public frmManagementTeachers()
        {
            InitializeComponent();
            SetComponent();
            humansTable1.values = new[]
            {
                ("ID", 0, true, true),
                ("SubjectSpecialization", 1,true, false),
                ("StaffID", 2, true, false)
            };
            humansTable1.LoadData(clsTeacher.GetAllTeacher());
            AddInputFields();
            StaffID = 1;
        }

        private int TeacherID = -1;
        private int StaffID
        {
            get { return GetStaffID(); }
            set
            {
                lblStaffID.Text = $"Staff ID: {value}";
            }
        }

        private void AddInputFields()
        {
            ucSaveBar1.InputControls.Clear();

            ucSaveBar1.InputControls.Add(txtSubjectSpecialization);
        }

        private void frmManagementTeachers_Load(object sender, EventArgs e)
        {
            RefreshTeachersTable();
        }

        private void SaveClick(object sender, EventArgs e)
        {
            if (TeacherID == -1)
            {
                clsTeacher Teacher = new clsTeacher();
                Teacher.StaffID = StaffID;
                ucSaveBar1.Save(Teacher);
            }
            else
            {
                clsTeacher Teacher = clsTeacher.Find(TeacherID);

                if (Teacher == null)
                {
                    MessageBox.Show("Dont Find The Teacher.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Teacher.StaffID = StaffID;

                ucSaveBar1.Save(Teacher);
            }

            RefreshTeachersTable();
        }

        private void ClearClick(object sender, EventArgs e)
        {
            TeacherID = -1;
            StaffID = 1;
        }

        private void EditClick(object sender, int TeachcerID)
        {
            clsTeacher EditTeacher = clsTeacher.Find(TeachcerID);

            if (EditTeacher == null)
            {
                MessageBox.Show("Dont Find The Teacher.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TeacherID = EditTeacher.ID;

            StaffID = EditTeacher.StaffID;

            txtSubjectSpecialization.Text = EditTeacher.SubjectSpecialization;
        }

        private void DeleteClick(object sender, int TeacherID)
        {
            clsTeacher Teacher = clsTeacher.Find(TeacherID);

            if (Teacher == null)
            {
                MessageBox.Show("Dont Find The Teacher.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete this teacher?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (clsTeacher.Delete(Teacher.ID))
                {
                    Utilty.SusseccfullyMessage("Successfully deleted teacher.");
                }
                else
                {
                    MessageBox.Show("Failed to delete the teacher.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                RefreshTeachersTable();
            }
        }

        private void GetStaffID(object sender, int StaffID)
        {
            this.StaffID = StaffID;
        }

        private void btnSelectStaffClick(object sender, EventArgs e)
        {
            frmSelectStaff form = new frmSelectStaff(new[]
            {
                ("ID", 0, true, true),
                ("Position", 1, true, false),
                ("Department", 2, true, false),
                ("StaffNumber", 3,  true, false),
                ("Salary", 4, true, false)
            }, clsStaff.GetAllStaff());

            form.SelectHuman += GetStaffID;

            form.ShowDialog();
        }
    }
}
