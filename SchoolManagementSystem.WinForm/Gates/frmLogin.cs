using StudentManagementSystem.BusinessLogic.Features.Administrative.Auth;
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

namespace SchoolManagementSystem.WinForm.Gates
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            bool LoginResut = clsLogin.LoginByUsernameAndPassword(txtUsername.Text.Trim(),txtPassword.Text.Trim());

            if(!LoginResut)
            {
                MessageBox.Show(clsLogin.LoginMessage, "Error Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // If Login Success Then We Will Show Home Form

            Form home = null;

            if(clsLogin.UserLogin.Teacher != null)
            {
                home = new frmTeacherHome();
            }
            else
            {
                home = new frmParent();
            }
            home.Text = "Home - " + clsLogin.UserLogin.Username.ToUpper();
            this.Cursor= Cursors.Default;

            this.Hide();
            home.ShowDialog();

            if (clsLogin.UserLogin == null)
            {
                this.Show();
                txtUsername.Text = string.Empty;
                txtPassword.Text = string.Empty;
            }
            else
            {
                this.Close();
            }
            
        }
    }
}
