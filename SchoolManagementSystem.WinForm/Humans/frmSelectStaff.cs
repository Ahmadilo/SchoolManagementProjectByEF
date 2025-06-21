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
    public partial class frmSelectStaff : Form
    {
        public delegate void DataHandlerSelect(object sender, int ID);

        public event DataHandlerSelect SelectHuman;

        private void RefreshStaffTable()
        {
            humansTable1.LoadData(this.DataSourse);
        }

        private void SetComponent()
        {
            this.humansTable1.EditClicked += EditClick;
            this.btnSelectHuman.Click += SelectClick;
        }

        private object DataSourse = null;

        public frmSelectStaff()
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
            this.DataSourse = clsStaff.GetAllStaff();
            humansTable1.LoadData(this.DataSourse);
            SetComponent();
        }

        public frmSelectStaff((string Name, int index, bool Visible, bool Key)[] values, object DataSourse)
        {
            InitializeComponent();
            this.DataSourse = DataSourse;
            humansTable1.values = values;
            humansTable1.LoadData(this.DataSourse);
            SetComponent();
        }

        private void frmSelectStaff_Load(object sender, EventArgs e)
        {
            RefreshStaffTable();
        }

        private void EditClick(object sender, int StaffID)
        {
            lblHumanID.Text = $"ID {StaffID}";
        }

        private void SelectClick(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(lblHumanID.Text.Split(' ')[1]);
            DialogResult result = MessageBox.Show("The ID Choose is " + ID, "Config Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Cancel)
                return;
            
            SelectHuman?.Invoke(this, ID);
            this.Close();
        }
    }
}
