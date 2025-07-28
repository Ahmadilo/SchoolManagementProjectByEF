using StudentManagementSystem.BusinessLogic.Assets;
using StudentManagementSystem.BusinessLogic.Features.Operations.Templates;
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
        private List<tmpStudentExm> StudentExamInputList = tmpStudentExm.GetStudentExms();

        private readonly string All = "All";

        private void SetFailterGroup()
        {
            cmbSubjcetName.Items.AddRange( 
                new string[] {All}
                .Concat(
                    StudentExamInputList
                    .Select(e => e.SubjectName)
                    .Distinct()
                    .ToArray()
                )
                .ToArray()
            );
            cmbSubjcetName.SelectedIndex = 0;

            cmbGrade.Items.AddRange(
                new string[] 
                { 
                    All, "A", "B", "C", "D", "E", "F", "Not Set" 
                }
            );
            cmbGrade.SelectedIndex = 0;
        }

        private void SetActiveBar()
        {
            ucSaveBar1.SecondActiveText = "Apply";
            ucSaveBar1.ThirdActiveText = "Set Marks";

            ucSaveBar1.FirstActiveEnabel = false;

            ucSaveBar1.ClearInputsChange += ApplyClick;
            ucSaveBar1.SaveChange += SaveClick;
            ucSaveBar1.MarkChange += MarkChange;
        }

        private void SetShowTable()
        {
            ucShowTable1.DeleteSetting.Visiblet = false;
            ucShowTable1.EditSetting.Visiblet = false;

            ucShowTable1.ColumnsSetting = new ucShowTable.clsSettingColumn[]
            {
                new ucShowTable.clsSettingColumn(Name: "StudentID", Index: 0, Key: true),
                new ucShowTable.clsSettingColumn(Name: "FullName", Index: 1),
                new ucShowTable.clsSettingColumn(Name: "SubjectName", Index: 2),
                new ucShowTable.clsSettingColumn(Name: "Mark", Index: 3),
                new ucShowTable.clsSettingColumn(Name: "Grad", Index: 4)
            };
        }

        public frmExam()
        {
            InitializeComponent();
            SetFailterGroup();
            SetActiveBar();
            SetShowTable();
        }

        private List<tmpStudentExm> GetStudentExmTeplateFailtered()
        {
            IEnumerable<tmpStudentExm> qoury = StudentExamInputList;

            if (qoury?.Count() == 0)
                return new List<tmpStudentExm>();

            if(cmbGrade.SelectedItem.ToString() != All && cmbGrade.Enabled)
            {
                qoury = qoury.Where(s => s.Grad == cmbGrade.SelectedItem.ToString());
            }
            

            if (cmbSubjcetName.SelectedItem.ToString() != All)
                qoury = qoury.Where(s => s.SubjectName == cmbSubjcetName.SelectedItem.ToString());

            return qoury.ToList();

        }

        private void SaveClick(object sender,  EventArgs e)
        {
            ucShowTable1.GetListOfRowsData<tmpStudentExm>().Save();

            StudentExamInputList = tmpStudentExm.GetStudentExms();

            ucShowTable1.LoadData(StudentExamInputList);
            ucShowTable1.Refresh();
        }

        private void ApplyClick(object sender, EventArgs e)
        {
            ucShowTable1.LoadData(GetStudentExmTeplateFailtered());
            ucShowTable1.Refresh();
            ucSaveBar1.FirstActiveEnabel = true;
        }

        private void MarkChange(object sender, EventArgs e)
        {
            cmbGrade.Enabled = !ucSaveBar1.ThirdActiveMark;
        }
    }
}
