using StudentManagementSystem.DataAccess.DatabaseContext;
using StudentManagementSystem.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagementSystem.DataAccess.Services
{
    public partial class GradeService
    {
        public int AddGrade(Grade grade)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    db.Grades.Add(grade);
                    db.SaveChanges();
                    return grade.GradeID;
                }
            }
            catch
            {
                return -1;
            }
        }

        public bool UpdateGrade(Grade updatedGrade)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var existing = db.Grades.Find(updatedGrade.GradeID);
                    if (existing == null) return false;

                    existing.StudentID = updatedGrade.StudentID;
                    existing.ClassSubjectID = updatedGrade.ClassSubjectID;
                    existing.GradeType = updatedGrade.GradeType;
                    existing.GradeDate = updatedGrade.GradeDate;
                    existing.Score = updatedGrade.Score;
                    existing.MaxScore = updatedGrade.MaxScore;
                    existing.Weight = updatedGrade.Weight;
                    existing.Comments = updatedGrade.Comments;

                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteGrade(int gradeId)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var entity = db.Grades.Find(gradeId);
                    if (entity == null) return false;

                    db.Grades.Remove(entity);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public Grade GetGradeById(int gradeId)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    return db.Grades.FirstOrDefault(g => g.GradeID == gradeId);
                }
            }
            catch
            {
                return null;
            }
        }

        public List<Grade> GetAllGrades()
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    return db.Grades.ToList();
                }
            }
            catch
            {
                return new List<Grade>();
            }
        }

        public bool DoesGradeExist(int gradeId)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    return db.Grades.Any(g => g.GradeID == gradeId);
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
