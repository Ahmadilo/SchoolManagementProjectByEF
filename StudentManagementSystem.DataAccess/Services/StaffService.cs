using System;
using System.Collections.Generic;
using System.Linq;
using StudentManagementSystem.DataAccess.Models;
using StudentManagementSystem.DataAccess.DatabaseContext;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace StudentManagementSystem.DataAccess.Services
{
    public partial class StaffService
    {
        // إضافة موظف جديد
        public int AddStaff(Staff staff)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    db.Staffs.Add(staff);
                    db.SaveChanges();
                    return staff.StaffID;
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

                return -1;
            }
        }

        // جلب موظف بواسطة StaffID
        public Staff GetStaffById(int staffId)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    return db.Staffs
                             .Include("Person")
                             .FirstOrDefault(s => s.StaffID == staffId);
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

                return null;
            }
        }

        // تحديث بيانات موظف
        public bool UpdateStaff(Staff staff)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var existingStaff = db.Staffs.Find(staff.StaffID);
                    if (existingStaff == null)
                        return false;

                    existingStaff.PersonID = staff.PersonID;
                    existingStaff.StaffNumber = staff.StaffNumber;
                    existingStaff.HireDate = staff.HireDate;
                    existingStaff.Position = staff.Position;
                    existingStaff.Department = staff.Department;
                    existingStaff.Salary = staff.Salary;

                    db.SaveChanges();
                    return true;
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

                return false;
            }
        }

        // حذف موظف
        public bool DeleteStaff(int staffId)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    try
                    {
                        var staff = db.Staffs.Find(staffId);
                        if (staff == null)
                            return false;

                        db.Staffs.Remove(staff);
                        db.SaveChanges();
                    }
                    catch(Exception ex)
                    {
                        Logger.LogError(ExceptionHelper.GetRootException(ex).Message);
                        return false;
                    }
                    return true;
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

                return false;
            }
        }

        // جلب كل الموظفين
        public List<Staff> GetAllStaffs()
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    return db.Staffs
                             .Include("Person")
                             .ToList();
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

                return new List<Staff>();
            }
        }
    }
}
