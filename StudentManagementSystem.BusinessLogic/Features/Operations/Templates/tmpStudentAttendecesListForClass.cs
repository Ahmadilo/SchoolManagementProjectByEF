using StudentManagementSystem.BusinessLogic.Activates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.BusinessLogic.Features.Operations.Templates
{
    public class tmpStudentAttendecesListForClass
    {
        public int StudentID { get; }
        public string StudentName { get; }
        public string SubjectName { get; }
        public string Status { get; }
        public DateTime Date { get; }

        public tmpStudentAttendecesListForClass(clsAttendance attdnce)
        {
            this.StudentID = attdnce.StudentID;
            this.StudentName = attdnce.Student.FullName;
            this.SubjectName = attdnce.ClassSubject.Subject.SubjectName;
            this.Status = attdnce.Status;
            this.Date = attdnce.Date;
        }
    }
}
