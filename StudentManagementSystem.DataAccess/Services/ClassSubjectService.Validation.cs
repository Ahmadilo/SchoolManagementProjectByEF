using StudentManagementSystem.DataAccess.Models;
using System;
using System.Collections.Generic;

namespace StudentManagementSystem.DataAccess.Services
{
    public partial class ClassSubjectService
    {
        private static string ErrorStart = "Validation Error: ";

        private static List<string> ValidateClassID(int classId)
        {
            var errors = new List<string>();

            if (classId <= 0)
                errors.Add(ErrorStart + "ClassID must be a positive integer.");
            else if(!new SchoolClassService().DoesClassExist(classId))
                errors.Add(ErrorStart + "ClassID does not exist in the database.");
            // هنا يمكن إضافة تحقق من وجود الصف في قاعدة البيانات عبر خدمة SchoolClassService إن أردت
            return errors;
        }

        private static List<string> ValidateSubjectID(int subjectId)
        {
            var errors = new List<string>();

            if (subjectId <= 0)
                errors.Add(ErrorStart + "SubjectID must be a positive integer.");
            else if (!new SubjectService().CheckSubjectId(subjectId))
                errors.Add(ErrorStart + "SubjectID does not exist in the database.");
            // يمكن تحقق وجود المادة في SubjectService
            return errors;
        }

        private static List<string> ValidateTeacherID(int teacherId)
        {
            var errors = new List<string>();

            if (teacherId <= 0)
                errors.Add(ErrorStart + "TeacherID must be a positive integer.");
            else if(!new TeacherService().DoesTeacherExsit(teacherId))
                errors.Add(ErrorStart + "TeacherID does not exist in the database.");
            // يمكن تحقق وجود المعلم في TeacherService
            return errors;
        }

        private static List<string> ValidateScheduleDay(string day)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(day))
                errors.Add(ErrorStart + "ScheduleDay is required.");
            else if (day.Length > 10)
                errors.Add(ErrorStart + "ScheduleDay must be 10 characters or less.");

            return errors;
        }

        private static List<string> ValidateTimeSpan(TimeSpan start, TimeSpan end)
        {
            var errors = new List<string>();

            if (start >= end)
                errors.Add(ErrorStart + "StartTime must be earlier than EndTime.");

            return errors;
        }

        private static List<string> ValidateRoomNumber(string roomNumber)
        {
            var errors = new List<string>();

            if (!string.IsNullOrWhiteSpace(roomNumber) && roomNumber.Length > 20)
                errors.Add(ErrorStart + "RoomNumber must be 20 characters or less.");

            return errors;
        }

        public static List<string> ValidateClassSubject(ClassSubject classSubject)
        {
            var errors = new List<string>();

            errors.AddRange(ValidateClassID(classSubject.ClassID));
            errors.AddRange(ValidateSubjectID(classSubject.SubjectID));
            errors.AddRange(ValidateTeacherID(classSubject.TeacherID));
            errors.AddRange(ValidateScheduleDay(classSubject.ScheduleDay));
            errors.AddRange(ValidateTimeSpan(classSubject.StartTime, classSubject.EndTime));
            errors.AddRange(ValidateRoomNumber(classSubject.RoomNumber));

            return errors;
        }
    }
}
