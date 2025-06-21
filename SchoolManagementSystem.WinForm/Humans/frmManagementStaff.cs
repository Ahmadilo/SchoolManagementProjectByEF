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
    public partial class frmManagementStaff : Form
    {
        private void RefreshStaffTable()
        {
            humansTable1.LoadData(clsStaff.GetAllStaff());
        }

        private void AddInputFaildes()
        {
            ucSaveBar1.InputControls.Clear();

            ucSaveBar1.InputControls.Add(txtPosition);
            ucSaveBar1.InputControls.Add(txtDepartment);
            ucSaveBar1.InputControls.Add(txtSalary);
            ucSaveBar1.InputControls.Add(txtStaffNumber);
        }

        private void SetComponent()
        {
            this.humansTable1.EditClicked += EditClick;
            this.humansTable1.DeleteClicked += DeleteClick;
            this.ucSaveBar1.SaveChange += SaveClick;
            this.ucSaveBar1.ClearInputsChange += ClearClick;
            this.btnSelectPerson.Click += SelectClick;
        }

        public frmManagementStaff()
        {
            InitializeComponent();
            humansTable1.values = new[]
            {
                ("ID", 0, true, true),
                ("Position", 1, true, false),
                ("Department", 2, true, false),
                ("StaffNumber", 3,  true, false),
                ("Salary", 4, true, false)
            };
            humansTable1.LoadData(clsStaff.GetAllStaff());
            AddInputFaildes();
            SetComponent();
            PersonID = 1;
        }

        int StaffID = -1;
        int PersonID { 
            get
            {
                return Convert.ToInt32(lblPersonID.Tag);
            }

            set
            {
                lblPersonID.Tag = value;
                lblPersonID.Text = $"PersonID {value}";
            }
        }

        private void frmManagementStaff_Load(object sender, EventArgs e)
        {
            RefreshStaffTable();
        }

        private void SaveClick(object sender, EventArgs e)
        {
            clsStaff Staff;
            if(StaffID == -1)
            {
                Staff = new clsStaff();

                Staff.PersonID = PersonID;
                ucSaveBar1.Save(Staff);
                RefreshStaffTable();
                return;
            }

            Staff = clsStaff.Find(StaffID);

            if(Staff == null)
            {
                MessageBox.Show("Dont Find The Staff.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ucSaveBar1.Save(Staff);
            RefreshStaffTable();
            return;
        }

        private void ClearClick(object sender, EventArgs e)
        {
            StaffID = -1;
            PersonID = 1;
        }

        private void DeleteClick(object sender, int StaffID)
        {
            clsStaff Staff = clsStaff.Find(StaffID);

            if(Staff == null)
            {
                MessageBox.Show("Dont Find The Staff.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("are you sure To Delete This Staff.", "Config Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
                return;

            if (clsStaff.Delete(Staff.ID))
                Utilty.SusseccfullyMessage("Susseccfully Delete Staff.");
            else
                MessageBox.Show("Dont delete The Staff.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            RefreshStaffTable();
        }

        private void EditClick(object sender, int StaffID)
        {
            clsStaff EditStaff = clsStaff.Find(StaffID);

            if(EditStaff == null)
            {
                MessageBox.Show("Dont Find The Staff.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtPosition.Text = EditStaff.Position.ToString();
            txtDepartment.Text = EditStaff.Department.ToString();
            txtSalary.Text = EditStaff.Salary.ToString();
            txtStaffNumber.Text = EditStaff.StaffNumber.ToString();
            this.StaffID = EditStaff.ID;
        }

        private void GetPersonID(object sender, int PersonID)
        {
            this.PersonID = PersonID;
        }

        private void SelectClick(object sender, EventArgs e)
        {
            frmSelectStaff frm = new frmSelectStaff(new[]
            {
                ("ID", 0, true, true),
                ("FirstName", 1, true, false),
                ("LastName", 2, true, false),
                ("DateOfBirth", 3, true, false),
                ("Email", 4, true, false)
            }, clsPerson.GetAllPeople());

            frm.SelectHuman += GetPersonID;

            frm.ShowDialog();
        }
    }
}
