using StudentManagementSystem.DataAccess.Models;
using System;
using System.Collections.Generic;

namespace StudentManagementSystem.DataAccess.Services
{
    public partial class GradeService
    {
        private static string ErrorStart = "Validation Error: ";

        public static List<string> ValidateGrade(Grade grade)
        {
            var errors = new List<string>();

            if (grade.StudentID <= 0)
                errors.Add(ErrorStart + "StudentID must be a positive integer.");

            if (grade.ClassSubjectID <= 0)
                errors.Add(ErrorStart + "ClassSubjectID must be a positive integer.");

            if (string.IsNullOrWhiteSpace(grade.GradeType))
                errors.Add(ErrorStart + "GradeType is required.");
            else if (grade.GradeType.Length > 20)
                errors.Add(ErrorStart + "GradeType must be 20 characters or less.");

            if (grade.GradeDate > DateTime.Now)
                errors.Add(ErrorStart + "GradeDate cannot be in the future.");

            if (grade.Score < 0)
                errors.Add(ErrorStart + "Score must be zero or positive.");

            if (grade.MaxScore <= 0)
                errors.Add(ErrorStart + "MaxScore must be a positive number.");

            if (grade.Score > grade.MaxScore)
                errors.Add(ErrorStart + "Score cannot be greater than MaxScore.");

            if (grade.Weight < 0)
                errors.Add(ErrorStart + "Weight must be zero or positive.");

            if (!string.IsNullOrWhiteSpace(grade.Comments) && grade.Comments.Length > 200)
                errors.Add(ErrorStart + "Comments must be 200 characters or less.");

            return errors;
        }
    }
}
