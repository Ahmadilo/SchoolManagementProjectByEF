using StudentManagementSystem.DataAccess.Models;
using System;
using System.Collections.Generic;

namespace StudentManagementSystem.DataAccess.Services
{
    public partial class StudentClassService
    {
        private static string ErrorStart = "Validation Error: ";

        public static List<string> ValidateStudentClass(StudentClass studentClass)
        {
            var errors = new List<string>();

            // تحقق StudentID
            if (studentClass.StudentID <= 0)
                errors.Add(ErrorStart + "StudentID must be a positive integer.");

            // تحقق ClassID
            if (studentClass.ClassID <= 0)
                errors.Add(ErrorStart + "ClassID must be a positive integer.");

            // تحقق EnrollmentDate (مثلاً لا تقبل تاريخ مستقبلي)
            if (studentClass.EnrollmentDate > DateTime.Now)
                errors.Add(ErrorStart + "EnrollmentDate cannot be in the future.");

            return errors;
        }
    }
}
