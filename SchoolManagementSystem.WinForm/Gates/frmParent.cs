using SchoolManagementSystem.WinForm.Assets;
using SchoolManagementSystem.WinForm.Humans;
using SchoolManagementSystem.WinForm.Apps;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SchoolManagementSystem.WinForm.Reports;

namespace SchoolManagementSystem.WinForm.Gates
{
    public partial class frmParent : Form
    {
        public frmParent()
        {
            InitializeComponent();
        }

        private void OpenChildForm(Form formToOpen, Keys key = Keys.Escape)
        {
            formToOpen.MdiParent = this;

            formToOpen.StartPosition = FormStartPosition.Manual;
            formToOpen.MinimizeBox = false;
            formToOpen.MaximizeBox = false;

            int x = (this.ClientSize.Width - formToOpen.Width) / 2;
            int y = (this.ClientSize.Height - formToOpen.Height) / 2;
            formToOpen.Location = new Point(x, y);

            formToOpen.KeyPreview = true;
            formToOpen.KeyDown += (s, e) =>
            {
                if (e.KeyCode == key)
                {
                    formToOpen.Close();
                }
            };

            formToOpen.Show();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmManagementUsers());
        }

        private void personsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmManagementPeople());
        }

        private void staffsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmManagementStaff());
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmManagementStudent());
        }

        private void teachersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmManagementTeachers());
        }

        private void classesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmManagementShoolClass());
        }

        private void subjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmManagementSubject());
        }

        private void studentDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmStudentDetails());
        }

        private void addStudentToClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmAddStudentToClass());
        }

        private void addSubjectToClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmAddSubjectToClass());
        }

        private void classToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmClassAndStudentReport());
        }

        private void studentsRepoeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmStudentsReport());
        }

        private void studentReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmStudentSelecter());
        }

        private void classesRepportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmClassesReport());
        }
    }
}
