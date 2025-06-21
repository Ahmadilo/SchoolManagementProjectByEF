using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentManagementSystem.BusinessLogic.Assets;

namespace SchoolManagementSystem.WinForm.Assets
{
    public partial class frmManagementSubject : Form
    {
        private void SetComponenet()
        {
            ucSaveBar1.InputControls.Clear();
            ucSaveBar1.InputControls.Add(txtSubjectName);
            ucSaveBar1.InputControls.Add(txtSubjectCode);
            ucSaveBar1.InputControls.Add(txtDescription);
            ucSaveBar1.InputControls.Add(txtDepartment);

            ucSaveBar1.SaveChange += SaveClick;
            ucSaveBar1.ClearInputsChange += ClearClick;

            humansTable1.DeleteClicked += DeleteClick;
            humansTable1.EditClicked += EditClick;
        }

        private void RefreshData()
        {
            humansTable1.LoadData(clsSubject.GetAllSubjects());
        }
        
        public frmManagementSubject()
        {
            InitializeComponent();
            humansTable1.values = new[]
            {
                ("ID", 0, true, true),
                ("SubjectName", 1, true, false),
                ("SubjectCode", 2, true, false),
                ("Description", 3, true, false),
                ("Department", 4, true, false)
            };
            humansTable1.LoadData(clsSubject.GetAllSubjects());
            SetComponenet();
        }

        private int SubjectID = -1;

        private void frmManagementSubject_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void SaveClick(object sender, EventArgs e)
        {
            clsSubject subject = null;
            if(SubjectID == -1)
            {
                subject = new clsSubject();
            }
            else
            {
                subject = clsSubject.Find(SubjectID);
            }

            if(subject == null)
            {
                MessageBox.Show("Dont Find The Subject target!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ucSaveBar1.Save(subject);
            RefreshData();
        }

        private void ClearClick(object sendr, EventArgs e)
        {
            this.SubjectID = -1;
        }

        private void EditClick(object sender, int SubjectID)
        {
            clsSubject subject = clsSubject.Find(SubjectID);

            if(subject == null)
            {
                MessageBox.Show("Dont Find The Subject target!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.SubjectID = subject.ID;
            txtSubjectName.Text = subject.SubjectName;
            txtSubjectCode.Text = subject.SubjectCode;
            txtDescription.Text = subject.Description;
            txtDepartment.Text = subject.Department;
        }

        private void DeleteClick(object sender, int SubjectID)
        {
            clsSubject subject = clsSubject.Find(SubjectID);

            if (subject == null)
            {
                MessageBox.Show("Dont Find The Subject target!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show($"Are you sure you want to delete the subject: {subject.SubjectName}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                if (clsSubject.Delete(SubjectID))
                {
                    MessageBox.Show("Subject deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshData();
                }
                else
                {
                    MessageBox.Show("Failed to delete subject.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
