using StudentManagementSystem.BusinessLogic.Activates;
using StudentManagementSystem.BusinessLogic.Humans;
using StudentManagementSystem.DataAccess.Services;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.BusinessLogic.Features.Operations.Templates
{
    public class tmpStudentExm
    {
        private int _studenID = -1;
        private int _gradeID = -1;
        public int StudentID { get { return _studenID; } }
        public int GradeID { get { return _gradeID; } }
        public string FullName { get; }
        public string SubjectName { get; }
        public char Grad { get; }
        public decimal Mark { get; set; }
        private string GradeType = "Exam";
        
        public clsStudent Student { get; }
        public clsGrade Grade { get; }

        private tmpStudentExm(StudentGradesView sg)
        {
            this._studenID = sg.StudentID;
            this.SubjectName = sg.SubjectName;
            
            if(sg.GradeID.HasValue)
            {
                this._gradeID = sg.GradeID.Value;
                this.Mark = (sg.Score.HasValue == true) ? sg.Score.Value : 0;
            }
        }

        private static tmpStudentExm FromViewToTmp(StudentGradesView StudentGrades)
        {
            return new tmpStudentExm(StudentGrades);
        }

        public static List<tmpStudentExm> GetStudentExms()
        {
            return ViewService.GetView<StudentGradesView>(v => true)
                .Select(v => FromViewToTmp(v))
                .ToList();
        }
    }
}
