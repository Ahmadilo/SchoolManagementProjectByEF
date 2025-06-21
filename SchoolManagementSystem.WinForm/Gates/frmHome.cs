using SchoolManagementSystem.WinForm.Assets;
using SchoolManagementSystem.WinForm.Humans;
using StudentManagementSystem.BusinessLogic.Features.Administrative.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagementSystem.WinForm.Gates
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
            if (clsLogin.UserLogin == null)
            {
                MessageBox.Show("You Must Login First!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblUserLogin.Text = $"Username: {clsLogin.UserLogin.Username}";
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            clsLogin.Logout();
            this.Close();
        }

        private void btnMangeUser_Click(object sender, EventArgs e)
        {
            frmManagementUsers frm = new frmManagementUsers();

            frm.ShowDialog(this);
        }

        private void btnPersonForm_Click(object sender, EventArgs e)
        {
            frmManagementPeople frm = new frmManagementPeople();

            frm.ShowDialog(this);
        }

        private void btnStudentForm_Click(object sender, EventArgs e)
        {
            frmManagementStudent frm = new frmManagementStudent();

            frm.ShowDialog(this);
        }

        private void btnStaffForm_Click(object sender, EventArgs e)
        {
            frmManagementStaff frm = new frmManagementStaff();

            frm.ShowDialog(this);
        }

        private void btnTeacherForm_Click(object sender, EventArgs e)
        {
            frmManagementTeachers frm = new frmManagementTeachers();

            frm.ShowDialog(this);
        }

        private void btnSubjectForm_Click(object sender, EventArgs e)
        {
            frmManagementSubject frm = new frmManagementSubject();

            frm.ShowDialog(this);
        }

        private void btnClassForm_Click(object sender, EventArgs e)
        {
            frmManagementShoolClass frm = new frmManagementShoolClass();

            frm.ShowDialog(this);
        }
    }
}
