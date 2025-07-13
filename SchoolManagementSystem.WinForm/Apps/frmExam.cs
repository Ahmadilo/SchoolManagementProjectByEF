using StudentManagementSystem.BusinessLogic.Assets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagementSystem.WinForm.Apps
{
    public partial class frmExam : Form
    {
        private void SetFailterGroup()
        {
            cmbClasses.Items.AddRange(clsSchoolClass.GetAllClasses().Select(sc => sc.ClassName).ToArray());
            cmbLevels.Items.AddRange(new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 });
        }

        public frmExam()
        {
            InitializeComponent();
        }
    }
}
