using System;
using System.Collections.Generic;
using StudentManagementSystem.DataAccess.Models;

namespace StudentManagementSystem.DataAccess.Services
{
    public partial class SubjectService
    {
        private static string ErrorStart = "Validation Error: ";

        public static List<string> ValidateSubjectName(string name)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(name))
                errors.Add(ErrorStart + "Subject name is required.");
            else if (name.Length > 100)
                errors.Add(ErrorStart + "Subject name must be 100 characters or less.");

            return errors;
        }

        public static List<string> ValidateSubjectCode(string code, int SubjectID = -1)
        {
            var errors = new List<string>();

            if (!string.IsNullOrWhiteSpace(code) && code.Length > 20)
            {
                errors.Add(ErrorStart + "Subject code must be 20 characters or less.");
                return errors;
            }

            if(new SubjectService().IsSubjectCodeTaken(code, SubjectID))
            {
                errors.Add(ErrorStart + "Subject code is already taken.");
            }

            return errors;
        }

        public static List<string> ValidateDescription(string description)
        {
            var errors = new List<string>();

            if (!string.IsNullOrWhiteSpace(description) && description.Length > 500)
                errors.Add(ErrorStart + "Description must be 500 characters or less.");

            return errors;
        }

        public static List<string> ValidateDepartment(string department)
        {
            var errors = new List<string>();

            if (!string.IsNullOrWhiteSpace(department) && department.Length > 50)
                errors.Add(ErrorStart + "Department must be 50 characters or less.");

            return errors;
        }

        public static List<string> SubjectValidationBasic(Subject subject)
        {
            var errors = new List<string>();

            errors.AddRange(ValidateSubjectName(subject.SubjectName));
            errors.AddRange(ValidateSubjectCode(subject.SubjectCode,subject.SubjectID));
            errors.AddRange(ValidateDescription(subject.Description));
            errors.AddRange(ValidateDepartment(subject.Department));

            return errors;
        }
    }
}
