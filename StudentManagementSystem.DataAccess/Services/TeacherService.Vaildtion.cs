using StudentManagementSystem.DataAccess.DatabaseContext;
using StudentManagementSystem.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.DataAccess.Services
{
    public partial class TeacherService
    {
        private static string ErrorStart = "Validation Error: ";

        private static List<string> ValidateSubjectSpecialization(string subject)
        {
            var errors = new List<string>();

            if (!string.IsNullOrWhiteSpace(subject) && subject.Length > 100)
                errors.Add(ErrorStart + "Subject Specialization must be 100 characters or less.");

            return errors;
        }

        public static List<string> TeacherValidationBasic(Teacher teacher)
        {
            var errors = new List<string>();

            errors.AddRange(ValidateSubjectSpecialization(teacher.SubjectSpecialization));

            return errors;
        }

        private static bool StaffExists(int staffId)
        {
            using (var context = new AppDbContext())
            {
                return context.Staffs.Any(s => s.StaffID == staffId);
            }
        }
    }
}
