using System;
using System.Collections.Generic;
using System.Linq;
using StudentManagementSystem.DataAccess.Models;
using StudentManagementSystem.DataAccess.DatabaseContext;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace StudentManagementSystem.DataAccess.Services
{
    public partial class TeacherService
    {
        // إضافة معلم جديد
        public int AddTeacher(Teacher teacher)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    db.Teachers.Add(teacher);
                    db.SaveChanges();
                    return teacher.TeacherID;
                }
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        Console.WriteLine($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}");
                return -1;
            }
        }

        // جلب معلم بواسطة TeacherID
        public Teacher GetTeacherById(int teacherId)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    return db.Teachers
                             .Include("Staff")
                             .FirstOrDefault(t => t.TeacherID == teacherId);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

        // تحديث بيانات معلم
        public bool UpdateTeacher(Teacher teacher)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var existingTeacher = db.Teachers.Find(teacher.TeacherID);
                    if (existingTeacher == null)
                        return false;

                    existingTeacher.StaffID = teacher.StaffID;
                    existingTeacher.SubjectSpecialization = teacher.SubjectSpecialization;

                    db.SaveChanges();
                    return true;
                }
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        Console.WriteLine($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}");
                return false;
            }
        }

        // حذف معلم
        public bool DeleteTeacher(int teacherId)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var teacher = db.Teachers.Find(teacherId);
                    if (teacher == null)
                        return false;

                    db.Teachers.Remove(teacher);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        Console.WriteLine($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}");
                return false;
            }
        }

        // جلب كل المعلمين
        public List<Teacher> GetAllTeachers()
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    return db.Teachers
                             .Include("Staff")
                             .ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<Teacher>();
            }
        }

        public bool DoesTeacherExsit(int TeacherID)
        {
            try
            {
                using(var db = new AppDbContext())
                {
                    return db.Teachers.Any(t => t.TeacherID == TeacherID);
                }
            }
            catch
            {
                return false;
            }
        }

        public Teacher GetTeacherByUserID(int UserID)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    Person person = db.People.FirstOrDefault(p => p.UserID == UserID);
                    if (person == null)
                        return null;
                    Staff staff = db.Staffs.FirstOrDefault(s => s.PersonID == person.PersonID);
                    if (staff == null)
                        return null;
                    return db.Teachers.FirstOrDefault(t => t.StaffID == staff.StaffID);
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
