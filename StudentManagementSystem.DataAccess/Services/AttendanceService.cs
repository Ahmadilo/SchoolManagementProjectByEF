using StudentManagementSystem.DataAccess.DatabaseContext;
using StudentManagementSystem.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagementSystem.DataAccess.Services
{
    public partial class AttendanceService
    {
        public int AddAttendance(Attendance attendance)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    db.Attendances.Add(attendance);
                    db.SaveChanges();
                    return attendance.AttendanceID;
                }
            }
            catch
            {
                return -1;
            }
        }

        public bool UpdateAttendance(Attendance updated)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var existing = db.Attendances.Find(updated.AttendanceID);
                    if (existing == null) return false;

                    existing.StudentID = updated.StudentID;
                    existing.ClassSubjectID = updated.ClassSubjectID;
                    existing.Date = updated.Date;
                    existing.Status = updated.Status;
                    existing.Notes = updated.Notes;

                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteAttendance(int id)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var entity = db.Attendances.Find(id);
                    if (entity == null) return false;

                    db.Attendances.Remove(entity);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public Attendance GetAttendanceById(int id)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    return db.Attendances.FirstOrDefault(a => a.AttendanceID == id);
                }
            }
            catch
            {
                return null;
            }
        }

        public List<Attendance> GetAllAttendances()
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    return db.Attendances.ToList();
                }
            }
            catch
            {
                return new List<Attendance>();
            }
        }

        public bool DoesAttendanceExist(int id)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    return db.Attendances.Any(a => a.AttendanceID == id);
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
