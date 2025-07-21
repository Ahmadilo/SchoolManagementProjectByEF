using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementSystem.BusinessLogic.Activates;
using StudentManagementSystem.BusinessLogic.Assets;
using StudentManagementSystem.BusinessLogic.Features.Operations.Templates;
using StudentManagementSystem.BusinessLogic.Humans;

namespace StudentManagementSystem.BusinessLogic.Features.Services
{
    public class clsAttendaceRecodesServices
    {
        public DateTime AttendanceDate { get; set; }
        public int ClassID { get; set; } = -1;
        public int SubjectID { get; set; } = -1;
        public bool isNew { get; set; } = true;

        public clsAttendaceRecodesServices()
        {

        }

        public clsAttendaceRecodesServices(int ClassID, int SubjectID)
        {
            this.ClassID = ClassID;
            this.SubjectID = SubjectID;
        }

        public List<tmpAttendanceRecode> GetNewStudentAttendanceRecodes()
        {
            return clsStudent
                .GetAllStudentInClass(this.ClassID)
                .Select(s => new tmpAttendanceRecode(s))
                .ToList();
        }

        public List<tmpAttendanceRecode> GetStudentAttendanceReocdes()
        {
            throw new NotImplementedException();
        }

        public bool AddAttendance(List<tmpAttendanceRecode> recodes)
        {
            foreach(tmpAttendanceRecode recode in recodes)
            {
                clsStudent student = clsStudent.Find(recode.StudentID);

                clsClassSubject lesson = clsClassSubject.GetAllClassSubjects(cs => cs.ClassID == this.ClassID && cs.SubjectID == this.SubjectID).FirstOrDefault();

                if (lesson == null)
                    continue;

                if (lesson.Equals(default(clsClassSubject)))
                    continue;

                clsAttendance attendance = new clsAttendance();

                attendance.ClassSubjectID = lesson.ID;
                attendance.StudentID = student.ID;
                attendance.Status = recode.Present ? "Persent" : "Absant";
                attendance.Date = this.AttendanceDate;
                attendance.Notes = string.IsNullOrEmpty(recode.Note) ? null : recode.Note;

                if(attendance.Save())
                    recode.SetAttendanceID(attendance.ID);
            }

            isNew = !recodes.All(r => r.GetAttendanceID() > 0);
            return !isNew;
        }

        public bool EditAttendance()
        {
            throw new NotImplementedException();
        }
    }
}
