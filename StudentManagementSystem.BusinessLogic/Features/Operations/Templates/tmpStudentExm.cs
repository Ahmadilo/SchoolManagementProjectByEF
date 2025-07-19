using StudentManagementSystem.BusinessLogic.Activates;
using StudentManagementSystem.BusinessLogic.Humans;
using StudentManagementSystem.DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace StudentManagementSystem.BusinessLogic.Features.Operations.Templates
{
    public class tmpStudentExm
    {
        public static int Weight = 50;
        public static int Max = 100;

        private int _studenID = -1;
        private int _gradeID = -1;
        private int _classSubjectID = -1;
        private clsStudent _student = null;
        private clsGrade _grade = null;
        public int StudentID { get { return _studenID; } }
        public int GradeID { get { return _gradeID; } }
        public string FullName { get => Student.FullName; }
        public string SubjectName { get; }
        public string Grad { get => GetGrad(); }
        public decimal Mark { get; set; } = -1;
        private string GradeType = "Exam";
        
        public clsStudent Student { get => clsPublic.GetInstansOfID(StudentID, _student); }
        public clsGrade StudentGrade { get => clsPublic.GetInstansOfID(GradeID, _grade); }

        private tmpStudentExm(StudentGradesView sg)
        {
            this._studenID = sg.StudentID;
            this.SubjectName = sg.SubjectName;

            this._gradeID = (sg.GradeID.HasValue == true) ? sg.GradeID.Value : -1;
            this.Mark = sg.Score.HasValue ? sg.Score.Value : -1;

            this._classSubjectID = sg.ClassSubjectID.HasValue ? sg.ClassSubjectID.Value : -1;
        }

        public string GetGrad()
        {
            if (Mark == -1)
                return "Not Set";

            if (Mark >= 90)
                return "A";

            if (Mark >= 80)
                return "B";

            if (Mark >= 70)
                return "C";

            if (Mark >= 60)
                return "D";

            if(Mark >= 50)
                return "E";
            else
                return "F";
        }

        public void Save()
        {
            if(_gradeID < 1 )
            {
                clsGrade Grade = new clsGrade();

                Grade.StudentID = this.StudentID;
                Grade.GradeType = this.GradeType;
                Grade.ClassSubjectID = this._classSubjectID;
                Grade.Score = this.Mark;
                Grade.Weight = tmpStudentExm.Weight;
                Grade.MaxScore = tmpStudentExm.Max;
                Grade.GradeDate = DateTime.Now;
                Grade.Save();
                return;
            }

            clsGrade grade = clsGrade.Find(_gradeID);

            grade.Weight = tmpStudentExm.Weight;
            grade.MaxScore = tmpStudentExm.Max;
            grade.Score = this.Mark;
            grade.Save();
        }

        public static tmpStudentExm Find(int StudentID)
        {
            return GetStudentExms().FirstOrDefault(s => s.StudentID == StudentID);
        }

        private static tmpStudentExm FromViewToTmp(StudentGradesView StudentGrades)
        {
            return new tmpStudentExm(StudentGrades);
        }

        public static List<tmpStudentExm> GetStudentExms()
        {
            return ViewService.GetView<StudentGradesView>(v => true)
                .Select(v => FromViewToTmp(v))
                .Distinct()
                .ToList();
        }

        public static object GetStudentView()
        {
            return ViewService.GetView<StudentGradesView>(v => true)
                .Select(v => new {v.StudentID, v.SubjectName, v.Score, v.MaxScore})
                .ToList();
        }
    }
}
