using StudentManagementSystem.BusinessLogic.Activates;
using StudentManagementSystem.BusinessLogic.Features.Operations.Templates;
using StudentManagementSystem.BusinessLogic.Features.Roles;
using StudentManagementSystem.BusinessLogic.Humans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.BusinessLogic.Features.Services
{
    public class clsStudentMarksRecordingService
    {
        public clsClassSubject ClassSubject { get; set; }
        public int MaxScore { get; set; }
        public int Weight { get; set; }
        public enmGradesType GradType { get; set; }
        public DateTime Date { get; set; }
        public string ErrorMessage { get; private set; }

        public List<tmpAddStudentMark> tmpListMarks { get; internal set; }
        public bool isNew = true;

        public clsStudentMarksRecordingService(clsClassSubject classSubject, int MaxScore, int Weight, enmGradesType gradType, DateTime date)
        {
            this.ClassSubject = classSubject;
            this.MaxScore = MaxScore;
            this.Weight = Weight;
            this.GradType = gradType;
            this.Date = date;
        }

        public List<tmpAddStudentMark> GetStudentListToAddMark()
        {
            if (ClassSubject == null || ClassSubject.ClassID <= 0)
                return new List<tmpAddStudentMark>();

            List<clsStudent> Students = clsStudent.GetAllStudentInClass(ClassSubject.ClassID);

            if (Students == null || Students.Count == 0)
                return new List<tmpAddStudentMark>();

            return Students.Select(s => new tmpAddStudentMark(s)).ToList();
        }

        private bool SaveStudentMark(tmpAddStudentMark item)
        {
            clsGrade grade = new clsGrade
            {
                ClassSubjectID = ClassSubject.ID,
                StudentID = item.StudentID,
                MaxScore = MaxScore,
                GradeType = this.GradType.ToString().Trim(),
                Weight = Weight,
                GradeDate = Date,
                Score = item.Mark
            };
            return grade.Save();
        }

        public bool AddStudentMarks(List<tmpAddStudentMark> marksList)
        {
            bool allSaved = marksList.All(item => SaveStudentMark(item));

            if (!allSaved)
                return false;

            tmpListMarks = marksList.Select(m => new tmpAddStudentMark(clsStudent.Find(m.StudentID), m.Mark)).ToList();
            isNew = false;
            return true;
        }

        public bool UpdateStudentMarks(List<tmpAddStudentMark> editMarks)
        {
            tmpListMarks.Sort((x, y) => x.StudentID.CompareTo(y.StudentID));
            editMarks.Sort((x, y) => x.StudentID.CompareTo(y.StudentID));

            if (tmpListMarks.Count != editMarks.Count)
                return false;

            List<bool> results = new List<bool>();

            for (int i = 0; i < editMarks.Count; i++)
            {
                if (editMarks[i].StudentID == tmpListMarks[i].StudentID &&
                    editMarks[i].Mark != tmpListMarks[i].Mark)
                {
                    results.Add(SaveStudentMark(editMarks[i]));
                }
            }

            if (results.All(r => r))
            {
                tmpListMarks = editMarks.Select(m => new tmpAddStudentMark(clsStudent.Find(m.StudentID), m.Mark)).ToList();
                return true;
            }

            return false;
        }

        public bool VaildMark(tmpAddStudentMark item)
        {
            clsGrade grade = new clsGrade
            {
                ClassSubjectID = ClassSubject.ID,
                StudentID = item.StudentID,
                GradeType = this.GradType.ToString().Trim(),
                MaxScore = MaxScore,
                Weight = Weight,
                GradeDate = Date,
                Score = item.Mark
            };

            bool result = grade.Validate();

            if (result)
                return true;
            else
            {
                ErrorMessage = grade.ErrorMessages?.First() ?? "Ocourd Error!!!";
                return false;
            }

            return grade.Validate();
        }

        public bool ValidtionStudentMarks(List<tmpAddStudentMark> unvalidMarks)
        {
            ErrorMessage = string.Empty;
            return unvalidMarks.All(item => VaildMark(item));
        }

    }
}
