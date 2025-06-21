using StudentManagementSystem.DataAccess.DatabaseContext;
using StudentManagementSystem.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagementSystem.DataAccess.Services
{
    public partial class SchoolClassService
    {
        public int AddClass(SchoolClass schoolClass)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    db.Classes.Add(schoolClass);
                    db.SaveChanges();
                    return schoolClass.ClassID;
                }
            }
            catch
            {
                return -1;
            }
        }

        public bool UpdateClass(SchoolClass updatedClass)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var existingClass = db.Classes.Find(updatedClass.ClassID);
                    if (existingClass == null) return false;

                    existingClass.ClassName = updatedClass.ClassName;
                    existingClass.GradeLevel = updatedClass.GradeLevel;
                    existingClass.AcademicYear = updatedClass.AcademicYear;
                    existingClass.HomeroomTeacherID = updatedClass.HomeroomTeacherID;

                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteClass(int classId)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var schoolClass = db.Classes.Find(classId);
                    if (schoolClass == null) return false;

                    db.Classes.Remove(schoolClass);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public List<SchoolClass> GetAllClasses()
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    return db.Classes.ToList();
                }
            }
            catch
            {
                return new List<SchoolClass>();
            }
        }

        public SchoolClass GetClassById(int classId)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    return db.Classes.FirstOrDefault(c => c.ClassID == classId);
                }
            }
            catch
            {
                return null;
            }
        }

        public bool DoesClassExist(int classId)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    return db.Classes.Any(c => c.ClassID == classId);
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
