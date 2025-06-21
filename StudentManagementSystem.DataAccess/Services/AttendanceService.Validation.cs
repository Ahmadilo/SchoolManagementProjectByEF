using StudentManagementSystem.DataAccess.Models;
using System;
using System.Collections.Generic;

namespace StudentManagementSystem.DataAccess.Services
{
    public partial class AttendanceService
    {
        private static string ErrorStart = "Validation Error: ";

        private static List<string> ValidateStudentID(int studentId)
        {
            var errors = new List<string>();

            if (studentId <= 0)
                errors.Add(ErrorStart + "StudentID must be a positive integer.");
            // يمكنك إضافة تحقق وجود الطالب في قاعدة البيانات
            return errors;
        }

        private static List<string> ValidateClassSubjectID(int classSubjectId)
        {
            var errors = new List<string>();

            if (classSubjectId <= 0)
                errors.Add(ErrorStart + "ClassSubjectID must be a positive integer.");
            // تحقق وجود المادة في الصف في قاعدة البيانات ممكن
            return errors;
        }

        private static List<string> ValidateDate(DateTime date)
        {
            var errors = new List<string>();

            if (date > DateTime.Now)
                errors.Add(ErrorStart + "Date cannot be in the future.");

            return errors;
        }

        private static List<string> ValidateStatus(string status)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(status))
                errors.Add(ErrorStart + "Status is required.");
            else if (status.Length > 20)
                errors.Add(ErrorStart + "Status must be 20 characters or less.");

            return errors;
        }

        private static List<string> ValidateNotes(string notes)
        {
            var errors = new List<string>();

            if (!string.IsNullOrWhiteSpace(notes) && notes.Length > 200)
                errors.Add(ErrorStart + "Notes must be 200 characters or less.");

            return errors;
        }

        public static List<string> ValidateAttendance(Attendance attendance)
        {
            var errors = new List<string>();

            errors.AddRange(ValidateStudentID(attendance.StudentID));
            errors.AddRange(ValidateClassSubjectID(attendance.ClassSubjectID));
            errors.AddRange(ValidateDate(attendance.Date));
            errors.AddRange(ValidateStatus(attendance.Status));
            errors.AddRange(ValidateNotes(attendance.Notes));

            return errors;
        }
    }
}
