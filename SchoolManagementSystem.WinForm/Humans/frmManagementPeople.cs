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
    public partial class frmManagementPeople : Form
    {
        private void AddInputFaildes()
        {
            ucSaveBar1.InputControls.Clear();

            ucSaveBar1.InputControls.Add(txtFirstName);
            ucSaveBar1.InputControls.Add(txtLastName);
            ucSaveBar1.InputControls.Add(txtPhoneNumber);
            ucSaveBar1.InputControls.Add(txtAddress);
            ucSaveBar1.InputControls.Add(txtEmail);
            ucSaveBar1.InputControls.Add(txtGender);
            ucSaveBar1.InputControls.Add(dtpDateOfBirth);
        }

        private void RefreshPeopleTable()
        {
            cuPeopleTable.LoadData(clsPerson.GetAllPeople());
        }

        private void SetComponent()
        {
            this.ucSaveBar1.SaveChange += SaveClick;
            this.btnSelectUser.Click += SelectUserClick;
        }

        public frmManagementPeople()
        {
            InitializeComponent();
            cuPeopleTable.values = new[]
            {
                ("ID", 0, true, true),
                ("FirstName", 1, true, false),
                ("LastName", 2, true, false),
                ("DateOfBirth", 3, true, false),
                ("Email", 4, true, false)
            };
            cuPeopleTable.LoadData(clsPerson.GetAllPeople());
            AddInputFaildes();
            SetComponent();
        }

        int PersonID = -1;
        int UserID
        {
            get
            {
                return Convert.ToInt32(lblUserID.Tag);
            }

            set
            {
                lblUserID.Tag = value;
                lblUserID.Text = $"UserID {value}";
            }
        }

        private void SaveClick(object sender, EventArgs e)
        {
            clsPerson Person = null;
            if (PersonID == -1)
            {
                Person = new clsPerson();
                Person.UserID = UserID;
                ucSaveBar1.Save(Person);
                RefreshPeopleTable();
                return;
            }

            Person = clsPerson.Find(PersonID);
            Person.UserID = UserID;
            ucSaveBar1.Save(Person);
            RefreshPeopleTable();

            GC.GetGeneration(Person); // Force garbage collection to clean up the old object
        }

        private void FillPersonInput(clsPerson person)
        {
            txtFirstName.Text = person.FirstName;
            txtLastName.Text = person.LastName;
            txtEmail.Text = person.Email;
            txtGender.Text = person.Gender;
            txtAddress.Text = person.Address;
            dtpDateOfBirth.Value = person.DateOfBirth;
            txtPhoneNumber.Text = person.PhoneNumber;
        }

        private void cuPeopleTable_EditClicked(object sender, int PersonID)
        {
            clsPerson EditPreson = clsPerson.Find(PersonID);

            if (EditPreson == null)
            {
                MessageBox.Show("Dont Find Person!", "Error Message");
                return;
            }

            this.PersonID = PersonID;

            FillPersonInput(EditPreson);
        }

        private void frmManagementPeople_Load(object sender, EventArgs e)
        {
            RefreshPeopleTable();
        }

        private void cuPeopleTable_DeleteClicked(object sender, int PersonID)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this person?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                clsPerson personToDelete = clsPerson.Find(PersonID);
                if (personToDelete != null)
                {
                    clsPerson.Delete(personToDelete.ID);
                    RefreshPeopleTable();
                    MessageBox.Show("Person deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Person not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void ucSaveBar1_ClearInputsChange(object sender, EventArgs e)
        {
            PersonID = -1;
            UserID = 1;
        }

        private void GetUserID(object sender, int UserID)
        {
            this.UserID = UserID;
        }

        private void SelectUserClick(object sender, EventArgs e)
        {
            frmSelectStaff frm = new frmSelectStaff(new[]
            {
                ("ID", 0, true, true),
                ("Username", 1, true, false)
            }, clsUser.GetAllUser());

            frm.SelectHuman += GetUserID;

            frm.ShowDialog();
        }
    }
}
