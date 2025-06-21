using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementSystem.DataAccess.Models;
using StudentManagementSystem.DataAccess.Services;

namespace learnEntityFramwork.ConsoleApp
{
    public class ActvitsValidationTest
    {
        public static void TestValidationOfStudentClass(int studentId, int classId, DateTime enrollmentDate)
        {
            var studentClass = new StudentClass
            {
                StudentID = studentId,
                ClassID = classId,
                EnrollmentDate = enrollmentDate
            };

            List<string> errors = StudentClassService.ValidateStudentClass(studentClass);

            Console.WriteLine("🔍 Testing StudentClass Validation:");
            Console.WriteLine($"  StudentID: {studentId}");
            Console.WriteLine($"  ClassID: {classId}");
            Console.WriteLine($"  EnrollmentDate: {enrollmentDate}");

            if (errors.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("✅ StudentClass is valid.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Validation Errors:");
                foreach (var error in errors)
                    Console.WriteLine("   - " + error);
            }

            Console.ResetColor();
            Console.WriteLine();
        }

        public static void TestValidationOfNotification(int senderId, int receiverId, string title, string message, DateTime sentDate)
        {
            var notification = new Notification
            {
                SenderID = senderId,
                ReceiverID = receiverId,
                Title = title,
                Message = message,
                SentDate = sentDate
            };

            List<string> errors = NotificationService.ValidateNotification(notification);

            Console.WriteLine("🔔 Testing Notification Validation:");
            Console.WriteLine($"  SenderID: {senderId}");
            Console.WriteLine($"  ReceiverID: {receiverId}");
            Console.WriteLine($"  Title: {title}");
            Console.WriteLine($"  Message: {message}");
            Console.WriteLine($"  SentDate: {sentDate}");

            if (errors.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("✅ Notification is valid.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Validation Errors:");
                foreach (var error in errors)
                    Console.WriteLine("   - " + error);
            }

            Console.ResetColor();
            Console.WriteLine();
        }

        public static void TestValidationOfGrade(
           int studentId,
           int classSubjectId,
           string gradeType,
           DateTime gradeDate,
           decimal score,
           decimal maxScore,
           decimal weight,
           string comments
        )
        {
            var grade = new Grade
            {
                StudentID = studentId,
                ClassSubjectID = classSubjectId,
                GradeType = gradeType,
                GradeDate = gradeDate,
                Score = score,
                MaxScore = maxScore,
                Weight = weight,
                Comments = comments
            };

            List<string> errors = GradeService.ValidateGrade(grade);

            Console.WriteLine("🎓 Testing Grade Validation:");
            Console.WriteLine($"  StudentID: {studentId}");
            Console.WriteLine($"  ClassSubjectID: {classSubjectId}");
            Console.WriteLine($"  GradeType: {gradeType}");
            Console.WriteLine($"  GradeDate: {gradeDate}");
            Console.WriteLine($"  Score: {score}");
            Console.WriteLine($"  MaxScore: {maxScore}");
            Console.WriteLine($"  Weight: {weight}");
            Console.WriteLine($"  Comments: {comments}");

            if (errors.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("✅ Grade is valid.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Validation Errors:");
                foreach (var error in errors)
                    Console.WriteLine("   - " + error);
            }

            Console.ResetColor();
            Console.WriteLine();
        }

        public static void TestValidationOfClassSubject(
            int classId,
            int subjectId,
            int teacherId,
            string scheduleDay,
            TimeSpan startTime,
            TimeSpan endTime,
            string roomNumber
        )
        {
            var classSubject = new ClassSubject
            {
                ClassID = classId,
                SubjectID = subjectId,
                TeacherID = teacherId,
                ScheduleDay = scheduleDay,
                StartTime = startTime,
                EndTime = endTime,
                RoomNumber = roomNumber
            };

            List<string> errors = ClassSubjectService.ValidateClassSubject(classSubject);

            Console.WriteLine("🧪 Testing ClassSubject Validation:");
            Console.WriteLine($"  ClassID: {classId}");
            Console.WriteLine($"  SubjectID: {subjectId}");
            Console.WriteLine($"  TeacherID: {teacherId}");
            Console.WriteLine($"  ScheduleDay: {scheduleDay}");
            Console.WriteLine($"  StartTime: {startTime}");
            Console.WriteLine($"  EndTime: {endTime}");
            Console.WriteLine($"  RoomNumber: {roomNumber}");

            if (errors.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("✅ ClassSubject is valid.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Validation Errors:");
                foreach (var error in errors)
                    Console.WriteLine("   - " + error);
            }

            Console.ResetColor();
            Console.WriteLine();
        }

        public static void TestValidationOfAttendance(
            int studentId,
            int classSubjectId,
            DateTime date,
            string status,
            string notes
        )
        {
            var attendance = new Attendance
            {
                StudentID = studentId,
                ClassSubjectID = classSubjectId,
                Date = date,
                Status = status,
                Notes = notes
            };

            List<string> errors = AttendanceService.ValidateAttendance(attendance);

            Console.WriteLine("🧪 Testing Attendance Validation:");
            Console.WriteLine($"  StudentID: {studentId}");
            Console.WriteLine($"  ClassSubjectID: {classSubjectId}");
            Console.WriteLine($"  Date: {date}");
            Console.WriteLine($"  Status: {status}");
            Console.WriteLine($"  Notes: {notes}");

            if (errors.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("✅ Attendance is valid.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Validation Errors:");
                foreach (var error in errors)
                    Console.WriteLine("   - " + error);
            }

            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
