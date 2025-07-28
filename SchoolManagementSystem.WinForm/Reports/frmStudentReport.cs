using StudentManagementSystem.BusinessLogic.Activates;
using StudentManagementSystem.BusinessLogic.Assets;
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

namespace SchoolManagementSystem.WinForm.Reports
{
    public partial class frmStudentReport : Form
    {
        public frmStudentReport()
        {
            InitializeComponent();
        }

        public int StudentID { 
            get
            {
                return ucStudentCard1.StudentID;
            }
            set
            {
                ucStudentCard1.StudentID = value;
            }

        }

        private void frmStudentReport_Load(object sender, EventArgs e)
        {

        }
    }
}
