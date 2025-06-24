using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementSystem.DataAccess.Views;
using StudentManagementSystem.DataAccess.Services;

namespace StudentManagementSystem.BusinessLogic.Features.Operations
{
    public class clsTeacherSubjects
    {
        public int SubjectID        { get; set; }
        public string SubjectName   { get; set; }

        public string SubjectCode   { get; set; }

        public string Description   { get; set; }

        public string Department    { get; set; }

        public int TeacherID        { get; set; }

        private clsTeacherSubjects(ClassSubjectForTeacher STs)
        {
            FromMode(STs);
        }

        private void FromMode(ClassSubjectForTeacher TeacherSubjet)
        {
            this.SubjectID = TeacherSubjet.SubjectID;
            this.SubjectName = TeacherSubjet.SubjectName;
            this.SubjectCode = TeacherSubjet.SubjectCode;
            this.Description = TeacherSubjet.Description;
            this.Department = TeacherSubjet.Department;
            this.TeacherID = TeacherSubjet.TeacherID;
        }

        public static List<clsTeacherSubjects> GetTeacherSubjectsByTeacherID(int TeacherID)
        {
            List<clsTeacherSubjects> TeacherSubjects = new List<clsTeacherSubjects>();
            if (TeacherID <= 0)
                return TeacherSubjects;

            List<ClassSubjectForTeacher> subjects = ViewService.GetSubjectsForTeacher(s => s.TeacherID == TeacherID);

            foreach(var sub in subjects)
            {
                TeacherSubjects.Add(new clsTeacherSubjects(sub));
            }

            return TeacherSubjects;
        }
    }
}
