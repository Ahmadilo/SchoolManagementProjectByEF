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

namespace SchoolManagementSystem.WinForm
{
    public partial class Form1 : Form
    {
        List<clsStudent> students = clsStudent.GetAllStudent();
        ucShowTable.clsSettingColumn[] ColumnsSettings = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {


            List<clsStudent> StudentRecodes = ucShowTable1.GetListOfRowsData<clsStudent>();


            if (StudentRecodes.Equals(students))
                Utilty.SusseccfullyMessage("The Two List Equals :-)");

            if (StudentRecodes.Count == students.Count)
                Utilty.SusseccfullyMessage("The two List have same Count");

            ucShowTable1.LoadData(StudentRecodes);
            ucShowTable1.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            clsStudent student = new clsStudent();
            ucShowTable1.ColumnsSetting = new ucShowTable.clsSettingColumn[]
            {
                new ucShowTable.clsSettingColumn(nameof(student.ID), 0, true, true, true),
                new ucShowTable.clsSettingColumn(nameof(student.FullName), 1, true),
                new ucShowTable.clsSettingColumn(Name: nameof(student.CurrentGradeLevel), Index: 2)
            };
            ucShowTable1.LoadData(students);
            ucShowTable1.Refresh();
        }
    }
}
