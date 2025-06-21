using StudentManagementSystem.DataAccess.DatabaseContext;
using StudentManagementSystem.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagementSystem.DataAccess.Services
{
    public partial class ClassSubjectService
    {
        public int AddClassSubject(ClassSubject classSubject)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    db.ClassSubjects.Add(classSubject);
                    db.SaveChanges();
                    return classSubject.ClassSubjectID;
                }
            }
            catch
            {
                return -1;
            }
        }

        public bool UpdateClassSubject(ClassSubject updated)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var existing = db.ClassSubjects.Find(updated.ClassSubjectID);
                    if (existing == null) return false;

                    existing.ClassID = updated.ClassID;
                    existing.SubjectID = updated.SubjectID;
                    existing.TeacherID = updated.TeacherID;
                    existing.ScheduleDay = updated.ScheduleDay;
                    existing.StartTime = updated.StartTime;
                    existing.EndTime = updated.EndTime;
                    existing.RoomNumber = updated.RoomNumber;

                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteClassSubject(int id)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var entity = db.ClassSubjects.Find(id);
                    if (entity == null) return false;

                    db.ClassSubjects.Remove(entity);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public ClassSubject GetClassSubjectById(int id)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    return db.ClassSubjects.FirstOrDefault(cs => cs.ClassSubjectID == id);
                }
            }
            catch
            {
                return null;
            }
        }

        public List<ClassSubject> GetAllClassSubjects()
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    return db.ClassSubjects.ToList();
                }
            }
            catch
            {
                return new List<ClassSubject>();
            }
        }

        public bool DoesClassSubjectExist(int id)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    return db.ClassSubjects.Any(cs => cs.ClassSubjectID == id);
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
