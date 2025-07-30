using StudentManagementSystem.BusinessLogic.Activates;
using StudentManagementSystem.BusinessLogic.Assets;
using StudentManagementSystem.BusinessLogic.Humans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.BusinessLogic.Features.Services
{
    internal static class clsStudentService
    {
        public static List<clsStudent> GetStudents(int ClassID, int SubjectID = -1)
        {
            List<clsStudent> students = clsSchoolClass.Find(id: ClassID).Students;

            if(SubjectID != -1)
            {
                if (students.All(s =>
                    {
                        if (s == null)
                            return false;

                        clsClassSubject lessen = clsClassSubject
                        .GetAllClassSubjects(cs => cs.ClassID == ClassID && cs.SubjectID == SubjectID)
                        .FirstOrDefault();

                        if (lessen.Equals(default(clsClassSubject)))
                            return false;

                        List<clsGrade> Marks = lessen.Marks;

                        if (!Marks?.Any(m => m.StudentID == s.ID) ?? true)
                            return false;

                        return true;
                    }))
                    return students;
                else
                    return null;
            }

            return students;
        }
    }
}
