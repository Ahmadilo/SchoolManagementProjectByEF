using StudentManagementSystem.DataAccess.DatabaseContext;
using StudentManagementSystem.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagementSystem.DataAccess.Services
{
    public partial class StudentClassService
    {
        public int AddStudentClass(StudentClass studentClass)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    db.StudentClasses.Add(studentClass);
                    db.SaveChanges();
                    return studentClass.StudentClassID;
                }
            }
            catch
            {
                return -1;
            }
        }

        public bool UpdateStudentClass(StudentClass updatedStudentClass)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var existing = db.StudentClasses.Find(updatedStudentClass.StudentClassID);
                    if (existing == null) return false;

                    existing.StudentID = updatedStudentClass.StudentID;
                    existing.ClassID = updatedStudentClass.ClassID;
                    existing.EnrollmentDate = updatedStudentClass.EnrollmentDate;

                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteStudentClass(int studentClassId)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var entity = db.StudentClasses.Find(studentClassId);
                    if (entity == null) return false;

                    db.StudentClasses.Remove(entity);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public StudentClass GetStudentClassById(int studentClassId)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    return db.StudentClasses.FirstOrDefault(sc => sc.StudentClassID == studentClassId);
                }
            }
            catch
            {
                return null;
            }
        }

        public List<StudentClass> GetAllStudentClasses()
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    return db.StudentClasses.ToList();
                }
            }
            catch
            {
                return new List<StudentClass>();
            }
        }

        public bool DoesStudentClassExist(int studentClassId)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    return db.StudentClasses.Any(sc => sc.StudentClassID == studentClassId);
                }
            }
            catch
            {
                return false;
            }
        }

        public List<int> GetAllStudentIDsInClass()
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    return db.StudentClasses.Where(sc => sc.StudentID > 0)
                                            .Select(sc => sc.StudentID)
                                            .Distinct()
                                            .ToList();
                }
            }
            catch (Exception e)
            {
                Logger.LogError(ExceptionHelper.GetRootException(e).Message);
                return new List<int>();
            }
        }
    }
}
