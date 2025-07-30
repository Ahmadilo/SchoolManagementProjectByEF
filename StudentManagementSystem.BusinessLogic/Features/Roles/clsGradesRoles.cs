using StudentManagementSystem.BusinessLogic.Activates;
using StudentManagementSystem.BusinessLogic.Features.Services;
using StudentManagementSystem.BusinessLogic.Humans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.BusinessLogic.Features.Roles
{
    public static class clsGradesRoles
    {
        public static Dictionary<enmGradesType, (int Weight, int MaxScore)> GradeTypeRoles =
        new Dictionary<enmGradesType, (int Weight, int MaxScore)>
        {
            { enmGradesType.Homework,      (10, 10)  },
            { enmGradesType.Quiz,          (15, 10)  },
            { enmGradesType.Test,          (30, 100) },
            { enmGradesType.Project,       (20, 100) },
            { enmGradesType.Practical,     (15, 50)  },
            { enmGradesType.Participation, (10, 10)  }
        };

        public static bool InGradesType(IEnumerable<clsGrade> marks)
        {
            var groupedGradeTypes = marks
                                .GroupBy(m => m.GradeType)
                                .Select(g => g.Key)
                                .Distinct()
                                .ToHashSet(); // لتسهيل المقارنة

            var allEnumValues = Enum.GetNames(typeof(enmGradesType));

            return allEnumValues.All(e => groupedGradeTypes.Contains(e));
        }

        internal static bool StudentHaveAllMarksType(clsStudent Student)
        {
            List<clsGrade> marks = clsGrade.GetAllGrades().Where(m => m.StudentID == Student.ID).ToList();

            if (marks.Count == 0)
                return false;

            return InGradesType(marks);
        }

        internal static bool CanGeneratStudentMarksReportList(int ClassID, int SubjectID)
        {
            List<clsStudent> students = clsStudentService.GetStudents(ClassID: ClassID, SubjectID: SubjectID);

            if (students == null)
                return false;

            return students.All(s => StudentHaveAllMarksType(s));
        }
    }
}
