using StudentManagementSystem.DataAccess.DatabaseContext;
using StudentManagementSystem.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagementSystem.DataAccess.Services
{
    public partial class SubjectService
    {
        public int AddSubject(Subject subject)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    db.Subjects.Add(subject);
                    db.SaveChanges();
                    return subject.SubjectID;
                }
            }
            catch
            {
                return -1;
            }
        }

        public bool UpdateSubject(Subject updatedSubject)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var existingSubject = db.Subjects.Find(updatedSubject.SubjectID);
                    if (existingSubject == null) return false;

                    existingSubject.SubjectName = updatedSubject.SubjectName;
                    existingSubject.SubjectCode = updatedSubject.SubjectCode;
                    existingSubject.Description = updatedSubject.Description;
                    existingSubject.Department = updatedSubject.Department;

                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteSubject(int subjectId)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var subject = db.Subjects.Find(subjectId);
                    if (subject == null) return false;

                    db.Subjects.Remove(subject);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public List<Subject> GetAllSubjects()
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    return db.Subjects.ToList();
                }
            }
            catch
            {
                return new List<Subject>();
            }
        }

        public Subject GetSubjectById(int subjectId)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    return db.Subjects.FirstOrDefault(s => s.SubjectID == subjectId);
                }
            }
            catch
            {
                return null;
            }
        }

        public bool CheckSubjectId(int subjectId)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    return db.Subjects.Any(s => s.SubjectID == subjectId);
                }
            }
            catch
            {
                return false;
            }
        }

        public bool IsSubjectCodeTaken(string subjectCode, int id = -1)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    return db.Subjects.Any(s => s.SubjectCode == subjectCode && s.SubjectID != id);
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
