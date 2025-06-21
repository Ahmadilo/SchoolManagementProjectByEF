using StudentManagementSystem.DataAccess.Models;
using StudentManagementSystem.DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnEntityFramwork.ConsoleApp
{
    internal class ActvitsManpultionTest
    {
        public static void TestAttendanceService(
            int studentId,
            int classSubjectId,
            DateTime date,
            string status,
            string notes = null
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

            var service = new AttendanceService();

            // Add
            int id = service.AddAttendance(attendance);
            Console.WriteLine(id > 0 ? $"✅ Added Attendance with ID: {id}" : "❌ Failed to add Attendance.");
            if (id <= 0) return;

            // Get by ID
            var fetched = service.GetAttendanceById(id);
            Console.WriteLine(fetched != null
                ? $"✅ Fetched Attendance: Status={fetched.Status}, Date={fetched.Date.ToShortDateString()}"
                : "❌ Fetch failed.");
            if (fetched == null) return;

            // Update
            fetched.Status = "Present";
            fetched.Notes = "Updated notes";
            bool updated = service.UpdateAttendance(fetched);
            Console.WriteLine(updated ? "✅ Update succeeded." : "❌ Update failed.");

            // Check existence
            bool exists = service.DoesAttendanceExist(id);
            Console.WriteLine(exists ? "✅ Attendance exists." : "❌ Attendance not found.");

            // Delete
            bool deleted = service.DeleteAttendance(id);
            Console.WriteLine(deleted ? "✅ Delete succeeded." : "❌ Delete failed.");
        }

        public static void TestClassSubjectService(
            int classId,
            int subjectId,
            int teacherId,
            string scheduleDay,
            TimeSpan startTime,
            TimeSpan endTime,
            string roomNumber = null
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

            var service = new ClassSubjectService();

            // Add
            int id = service.AddClassSubject(classSubject);
            Console.WriteLine(id > 0 ? $"✅ Added ClassSubject with ID: {id}" : "❌ Failed to add ClassSubject.");
            if (id <= 0) return;

            // Get by ID
            var fetched = service.GetClassSubjectById(id);
            Console.WriteLine(fetched != null
                ? $"✅ Fetched ClassSubject: Day={fetched.ScheduleDay}, Room={fetched.RoomNumber}"
                : "❌ Fetch failed.");
            if (fetched == null) return;

            // Update
            fetched.RoomNumber = roomNumber ?? "UpdatedRoom101";
            fetched.ScheduleDay = "Friday";
            bool updated = service.UpdateClassSubject(fetched);
            Console.WriteLine(updated ? "✅ Update succeeded." : "❌ Update failed.");

            // Check existence
            bool exists = service.DoesClassSubjectExist(id);
            Console.WriteLine(exists ? "✅ ClassSubject exists." : "❌ ClassSubject not found.");

            // Delete
            bool deleted = service.DeleteClassSubject(id);
            Console.WriteLine(deleted ? "✅ Delete succeeded." : "❌ Delete failed.");
        }

        public static void TestGradeService(
            int studentId,
            int classSubjectId,
            string gradeType,
            DateTime gradeDate,
            decimal score,
            decimal maxScore,
            decimal weight,
            string comments = null
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

            var service = new GradeService();

            // إضافة
            int id = service.AddGrade(grade);
            Console.WriteLine(id > 0 ? $"✅ Added Grade with ID: {id}" : "❌ Failed to add Grade.");
            if (id <= 0) return;

            // استرجاع
            var fetched = service.GetGradeById(id);
            Console.WriteLine(fetched != null
                ? $"✅ Fetched Grade: Type = {fetched.GradeType}, Score = {fetched.Score}"
                : "❌ Fetch failed.");

            if (fetched == null) return;

            // تعديل
            fetched.GradeType = "Final Exam";
            fetched.Score = fetched.Score + 5; // تعديل بسيط على النتيجة
            fetched.Comments = "Updated score after review";

            bool updated = service.UpdateGrade(fetched);
            Console.WriteLine(updated ? "✅ Update succeeded." : "❌ Update failed.");

            // تحقق من وجود الدرجة
            bool exists = service.DoesGradeExist(id);
            Console.WriteLine(exists ? "✅ Grade exists." : "❌ Grade not found.");

            // حذف
            bool deleted = service.DeleteGrade(id);
            Console.WriteLine(deleted ? "✅ Delete succeeded." : "❌ Delete failed.");
        }

        public static void TestNotificationService(int senderId, int receiverId, string title, string message, DateTime? sentDate = null)
        {
            var notification = new Notification
            {
                SenderID = senderId,
                ReceiverID = receiverId,
                Title = title,
                Message = message,
                SentDate = sentDate ?? DateTime.Now,
                IsRead = false
            };

            var service = new NotificationService();

            // إضافة
            int id = service.AddNotification(notification);
            Console.WriteLine(id > 0 ? $"✅ Added Notification with ID: {id}" : "❌ Failed to add Notification.");
            if (id <= 0) return;

            // استرجاع
            var fetched = service.GetNotificationById(id);
            Console.WriteLine(fetched != null
                ? $"✅ Fetched Notification: Title = {fetched.Title}"
                : "❌ Fetch failed.");

            if (fetched == null) return;

            // تعديل
            fetched.Title = "Updated Title";
            fetched.Message = "Updated message body";
            fetched.IsRead = true;

            bool updated = service.UpdateNotification(fetched);
            Console.WriteLine(updated ? "✅ Update succeeded." : "❌ Update failed.");

            // تحقق من وجود الإشعار
            bool exists = service.DoesNotificationExist(id);
            Console.WriteLine(exists ? "✅ Notification exists." : "❌ Notification not found.");

            // حذف
            bool deleted = service.DeleteNotification(id);
            Console.WriteLine(deleted ? "✅ Delete succeeded." : "❌ Delete failed.");
        }

        public static void TestStudentClassService(int studentId, int classId, DateTime enrollmentDate)
        {
            var studentClass = new StudentClass
            {
                StudentID = studentId,
                ClassID = classId,
                EnrollmentDate = enrollmentDate
            };

            var service = new StudentClassService();

            // إضافة
            int id = service.AddStudentClass(studentClass);
            Console.WriteLine(id > 0 ? $"✅ Added StudentClass with ID: {id}" : "❌ Failed to add StudentClass.");
            if (id <= 0) return;

            // استرجاع
            var fetched = service.GetStudentClassById(id);
            Console.WriteLine(fetched != null
                ? $"✅ Fetched StudentClass: StudentID={fetched.StudentID}, ClassID={fetched.ClassID}"
                : "❌ Fetch failed.");

            if (fetched == null) return;

            // تحديث
            fetched.EnrollmentDate = DateTime.Now.AddDays(-1); // تعديل التاريخ كمثال
            bool updated = service.UpdateStudentClass(fetched);
            Console.WriteLine(updated ? "✅ Update succeeded." : "❌ Update failed.");

            // تحقق من وجوده
            bool exists = service.DoesStudentClassExist(id);
            Console.WriteLine(exists ? "✅ StudentClass exists." : "❌ StudentClass not found.");

            // حذف
            bool deleted = service.DeleteStudentClass(id);
            Console.WriteLine(deleted ? "✅ Delete succeeded." : "❌ Delete failed.");
        }

    }
}
