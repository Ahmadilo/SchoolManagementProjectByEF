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
using StudentManagementSystem.BusinessLogic.Features.Operations.Templates;
using SchoolManagementSystem.WinForm.Units;
using System.Data.SqlClient;

namespace SchoolManagementSystem.WinForm
{
    public partial class Form1 : Form
    {
        //const string _connectionString = "Server=.;Database=SchoolManagementSystem;User Id=sa;Password=sa123456;";

        //private class TestView
        //{
        //    public int StudentID { get; set; }
        //    public string SubjectName { get; set; }
        //    public decimal? Score { get; set; }
        //    public decimal? MaxScore { get; set; }
        //}

        //private List<TestView> GetStudentGradesReader()
        //{
        //    var connection = new SqlConnection(_connectionString);
        //    var command = new SqlCommand("SELECT StudentID, SubjectName, Score, MaxScore FROM vw_StudentGradesClean", connection);

        //    connection.Open();
        //    List<TestView> students = new List<TestView>();
        //    // CommandBehavior.CloseConnection: يغلق الاتصال تلقائيًا عند إغلاق الـ Reader
        //    using (SqlDataReader reader = command.ExecuteReader())
        //    {
        //        while (reader.Read())
        //        {
        //            TestView test = new TestView();
        //            test.StudentID = reader.GetInt32(0);
        //            test.SubjectName = reader.GetString(1);
        //            if (reader["Score"] != DBNull.Value)
        //                test.Score = reader.GetDecimal(2);
        //            else
        //                test.Score = null;
        //            if (reader["MaxScore"] != DBNull.Value)
        //                test.MaxScore = reader.GetDecimal(3);
        //            else
        //                test.MaxScore = null;
        //            students.Add(test);
        //        }
        //    }

        //    return students;
        //}

        private List<tmpStudentExm> StudentExmTemplate = tmpStudentExm.GetStudentExms();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ucShowTable1.ColumnsSetting = new ucShowTable.clsSettingColumn[]
            {
                new ucShowTable.clsSettingColumn(Name: "StudentID", Index: 0, Key: true),
                new ucShowTable.clsSettingColumn(Name: "FullName", Index: 1),
                new ucShowTable.clsSettingColumn(Name: "SubjectName", Index: 2),
                new ucShowTable.clsSettingColumn(Name: "Mark", Index: 3),
                new ucShowTable.clsSettingColumn(Name: "Grad", Index: 4),
            };

            ucShowTable1.AddtionlyColumns = new ucShowTable.clsSettingButton[]
            {
                new ucShowTable.clsSettingButton(Name: "Weight", Visible: true, type: typeof(DataGridViewTextBoxColumn), proccessLogic: (id) => tmpStudentExm.Weight),
                new ucShowTable.clsSettingButton(Name: "Max", Visible: true, type: typeof(DataGridViewTextBoxColumn), proccessLogic: (id) => tmpStudentExm.Max)
            };

            ucExcelExport1.SetData(StudentExmTemplate, ucShowTable1.ColumnsSetting.Select(c => c.Name).ToArray());

            ucShowTable1.LoadData(StudentExmTemplate);
            ucShowTable1.Refresh();
        }

        private void ucShowTable1_EditClicked(object sender, int StudentID)
        {
            MessageBox.Show(StudentExmTemplate.Find(s => s.StudentID == StudentID).Mark.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int num = ucShowTable1.GetListOfRowsData<tmpStudentExm>().Count;
            //MessageBox.Show(num.ToString());

            List<tmpStudentExm> list = ucShowTable1.GetListOfRowsData<tmpStudentExm>();
            list.Save();

            bool ismatch = 182 == list.Count;

            MessageBox.Show("is the tmp same view ? 182 = 182? result: " + ismatch.ToString());

            ucShowTable1.LoadData(tmpStudentExm.GetStudentExms());
            ucShowTable1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExcelExporter<tmpStudentExm> StudentExcel = new ExcelExporter<tmpStudentExm>();

            StudentExcel.SetHeader(new string[]
            {
                "StudentID",
                "FullName",
                "SubjectName",
                "Mark",
                "Grad"
            });

            StudentExcel.AddData(StudentExmTemplate);

            StudentExcel.SaveToFile("StudentExcel.xlsx");
        }
    }
}
