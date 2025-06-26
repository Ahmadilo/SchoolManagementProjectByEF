using System;
using System.Collections.Generic;
using System.Linq;
using StudentManagementSystem.DataAccess.Models;
using StudentManagementSystem.DataAccess.DatabaseContext;
using System.Data.Entity.Validation;
using System.Linq.Expressions;

namespace StudentManagementSystem.DataAccess.Services
{
    public partial class StudentService
    {
        // إضافة طالب جديد
        public int AddStudent(Student student)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    db.Students.Add(student);
                    db.SaveChanges();
                    return student.StudentID;  // بعد الحفظ يعيد رقم الطالب الجديد
                }
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Console.WriteLine($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}");
                    }
                }

                return -1; // أو يمكنك عدم إعادة الرمي إذا لا تريد إيقاف البرنامج
            }
        }

        // جلب طالب بواسطة رقم الطالب
        public Student GetStudentById(int studentId)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    return db.Students
                             .Include("Person")   // لتحميل بيانات الشخص (الطالب)
                             .Include("Parent")   // لتحميل بيانات ولي الأمر
                             .FirstOrDefault(s => s.StudentID == studentId);
                }
            }
            catch
            {
                return null;
            }
        }

        // تحديث بيانات طالب موجود
        public bool UpdateStudent(Student student)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var existingStudent = db.Students.Find(student.StudentID);
                    if (existingStudent == null)
                        return false;

                    // تحديث القيم الأساسية (مثال)
                    existingStudent.EnrollmentNumber = student.EnrollmentNumber;
                    existingStudent.EnrollmentDate = student.EnrollmentDate;
                    existingStudent.CurrentGradeLevel = student.CurrentGradeLevel;
                    existingStudent.PersonID = student.PersonID;
                    existingStudent.ParentID = student.ParentID;

                    // لو تريد تحديث بيانات Person أو Parent يمكن إضافتها هنا
                    // ولكن يفضل تحديثها منفصلًا في service خاص بالـ Person

                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        // حذف طالب
        public bool DeleteStudent(int studentId)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var student = db.Students.Find(studentId);
                    if (student == null)
                        return false;

                    db.Students.Remove(student);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        // جلب كل الطلاب
        public List<Student> GetAllStudents()
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    return db.Students
                             .Include("Person")
                             .Include("Parent")
                             .ToList();
                }
            }
            catch
            {
                return new List<Student>();
            }
        }

        public static bool IsEnrollmentNumberUnick(string enrollmentNumber, int id)
        {
            using (var context = new AppDbContext())
            {
                return context.Students.Any(s => s.EnrollmentNumber == enrollmentNumber && s.StudentID != id);
            }
        }

        public List<Student> GetAllStudentInNotClasses()
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    List<int> StudentIDInClass = new StudentClassService().GetAllStudentIDsInClass();
                    if (StudentIDInClass == null || StudentIDInClass.Count == 0)
                        return new List<Student>();
                    return db.Students
                             .Where(s => !StudentIDInClass.Contains(s.StudentID))
                             .ToList();
                }
            }
            catch (Exception e)
            {
                Logger.LogError(ExceptionHelper.GetRootException(e).Message);
                return new List<Student>();
            }
        }

        public List<Student> GetAllStudentByExpression(Expression<Func<Student, bool>> expression)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    return db.Students.Where(expression).ToList();
                }
            }
            catch (Exception e)
            {
                Logger.LogError(ExceptionHelper.GetRootException(e.InnerException).Message);
                return null;
            }
        }


    }
}
