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

namespace SchoolManagementSystem.WinForm.Humans
{
    public partial class frmManagementUsers : Form
    {
        private void EidtFailes(object sender, EventArgs e)
        {
            btnClear.Enabled = true;
        }

        private void ConnactToFaildes()
        {
            foreach(Control control in this.Controls)
            {
                if(control is TextBox txtbox)
                {
                    txtbox.TextChanged += EidtFailes;
                }

                if(control is CheckBox chbox && chbox.Name == "chbIsActive")
                {
                    chbox.CheckedChanged += EidtFailes;
                }
            }
        }

        public frmManagementUsers()
        {
            InitializeComponent();
            ConnactToFaildes();
        }

        // Load Form: Get All User And Fill Table With Them.

        private void fromLoad(object sender, EventArgs e)
        {
            UserTable.LoadDataUsers();
        }

        // TODO: Click Button Save: Get Data In Faildes And Save it.

        private clsUser GetUserData(int id = -1)
        {
            clsUser user;
            if (id == -1)
                user = new clsUser();
            else
                user = clsUser.Find(id);

            user.Username = txtUsername.Text;
            user.Password = txtPasswrod.Text;
            user.Role = txtRole.Text;
            user.IsActive = chbIsActive.Checked;

            return user;
        }

        private void ClearFaildes()
        {
            txtUsername.Text = string.Empty;
            txtPasswrod .Text = string.Empty;
            txtRole .Text = string.Empty;
            chbIsActive.Checked = true;
            _UserID = -1;
            btnClear.Enabled = false;
        }

        private void AddUser()
        {
            clsUser newUser = GetUserData();
            if (!newUser.Validate())
            {
                MessageBox.Show("Error: ", string.Join(",\n", newUser.ErrorMessages));
                return;
            }


            if (newUser.Save())
                Utilty.SusseccfullyMessage("SussessFully Save User");
        }

        private void EditUser()
        {
            clsUser User = GetUserData(_UserID);

            if(!User.Validate())
            {
                MessageBox.Show("Error: ", string.Join(",\n", User.ErrorMessages));
                return;
            }

            if (User.Save())
            {
                Utilty.SusseccfullyMessage("Sussessfully Save User");
                _UserID = -1;
            }
        }

        private void ClickToSave(object sender, EventArgs e)
        {
            if(_UserID == -1)
            {
                AddUser();
            }
            else
            {
                EditUser();
            }
            if (chbAutoClear.Checked)
                ClearFaildes();
            UserTable.LoadDataUsers();
        }

        // Click Button Edit: Get Data In Row And Fill them in Faildes.

        private int _UserID = -1;

        private void UserDataToFaildes(clsUser user)
        {
            txtPasswrod.Text = user.Password;
            txtUsername.Text = user.Username;
            txtRole.Text = user.Role;
            chbIsActive.Checked = user.IsActive;
            _UserID = user.ID;
        }

        private void ClickToEditUserRow(int RowIndex)
        {
            UserDataToFaildes(UserTable.Rows[RowIndex].GetUserData());
            btnClear.Enabled = true;
        }

        private void UserTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 6)
                ClickToEditUserRow(e.RowIndex);

            if (e.ColumnIndex == 7)
                UserDelete(UserTable.Rows[e.RowIndex].GetUserId());
        }

        // Click Button Delete: Get ID And Show Message Box And Delete User if get Yes.

        private void UserDelete(int ID)
        {
            DialogResult result = MessageBox.Show("Are you ture To Delete this User: " + ID, "Winnern!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        
            if(result == DialogResult.Yes)
            {
                bool re = clsUser.Delete(ID);

                if (re)
                    Utilty.SusseccfullyMessage("Susseccfully Delete User.");

                UserTable.LoadDataUsers();
            }
        }

        private void chbAutoClear_CheckedChanged(object sender, EventArgs e)
        {

        }

        // TODO: Click Button Clear And Faileds Fill Data = Clear Data

        private void ClickClear(object sender, EventArgs e)
        {
            ClearFaildes();
        }


        // TODO: Click Button Save And Check Box is not Cheched: Don't Clear The Faildes
        // TODO: Click Button Delete And Failed is Filled: Clear Data And Delete it.
        // TODO: Click Button Edit And Faileds is Filled: Message Box To User Clear Faileds if get Yes.

    }
}
