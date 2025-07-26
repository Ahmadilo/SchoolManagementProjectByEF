using StudentManagementSystem.BusinessLogic.Activates;
using StudentManagementSystem.BusinessLogic.Assets;
using StudentManagementSystem.BusinessLogic.Features.Operations.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.BusinessLogic.Features.Services
{
    public class clsStudentAttendacesReportServices
    {
        public int ClassID { get; private set; }
        public int SubjectID { get; private set; }

        public clsStudentAttendacesReportServices(string className, string subjectName) 
        {
            this.ClassID = clsSchoolClass.GetAllClasses().First(c => c.ClassName == className).ID;
            this.SubjectID = clsSubject.GetAllSubjects().First(s => s.SubjectName == subjectName).ID;
        }

        public List<tmpStudentAttendecesListForClass> GetClassStudentAttendaces()
        {
            int[] lessens = clsClassSubject
                .GetAllClassSubjects(cs => cs.ClassID == this.ClassID && cs.SubjectID == this.SubjectID)
                .Select(cs => cs.ID)
                .ToArray();

            List<tmpStudentAttendecesListForClass> StudentAttendaceList = new List<tmpStudentAttendecesListForClass>();

            foreach (var item in lessens)
            {
                List<clsAttendance> AttandceList = clsAttendance
                    .GetAllAttendances()
                    .Where(a => a.ClassSubjectID == item)
                    .ToList();

                StudentAttendaceList.AddRange(
                    AttandceList.Select(a => new tmpStudentAttendecesListForClass(a))
                );
            }

            return StudentAttendaceList;
        }

    }
}
