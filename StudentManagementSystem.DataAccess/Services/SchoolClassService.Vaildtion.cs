using StudentManagementSystem.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.DataAccess.Services
{
    public partial class SchoolClassService
    {
        private static string ErrorStart = "Validation Error: ";

        private static List<string> ValidateClassName(string name)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(name))
                errors.Add(ErrorStart + "Class name is required.");
            else if (name.Length > 50)
                errors.Add(ErrorStart + "Class name must be 50 characters or less.");

            return errors;
        }

        private static List<string> ValidateGradeLevel(int grade)
        {
            var errors = new List<string>();

            if (grade < 0 || grade > 12)
                errors.Add(ErrorStart + "Grade level must be between 0 and 12.");

            return errors;
        }

        private static List<string> ValidateAcademicYear(string year)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(year))
                errors.Add(ErrorStart + "Academic year is required.");
            else if (year.Length > 20)
                errors.Add(ErrorStart + "Academic year must be 20 characters or less.");

            return errors;
        }

        private static List<string> ValidateTeacherID(int? teacherID)
        {
            var errors = new List<string>();

            if (!teacherID.HasValue)
                return errors;
            else if (teacherID.Value <= 0)
                errors.Add(ErrorStart + "Homeroom teacher ID must be a valid positive number.");
            else if(!new TeacherService().DoesTeacherExsit(teacherID.Value))
                errors.Add(ErrorStart + "Homeroom teacher does not exist.");

            return errors;
        }

        public static List<string> ValidateSchoolClass(SchoolClass schoolClass)
        {
            var errors = new List<string>();

            errors.AddRange(ValidateClassName(schoolClass.ClassName));
            errors.AddRange(ValidateGradeLevel(schoolClass.GradeLevel));
            errors.AddRange(ValidateAcademicYear(schoolClass.AcademicYear));
            errors.AddRange(ValidateTeacherID(schoolClass.HomeroomTeacherID));

            return errors;
        }
    }
}
