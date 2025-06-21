using StudentManagementSystem.DataAccess.DatabaseContext;
using StudentManagementSystem.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagementSystem.DataAccess.Services
{
    public partial class StaffService
    {
        private static string ErrorStart = "Validation Error: ";

        private static List<string> ValidateStaffNumber(string staffNumber, int staffID)
        {
            var errors = new List<string>();

            if (!string.IsNullOrWhiteSpace(staffNumber))
            {
                if (staffNumber.Length > 20)
                    errors.Add(ErrorStart + "Staff Number must be 20 characters or less.");

                if (IsStaffNumberTaken(staffNumber, staffID))
                    errors.Add(ErrorStart + "Staff Number already exists.");
            }

            return errors;
        }

        private static List<string> ValidateHireDate(DateTime? hireDate)
        {
            var errors = new List<string>();

            if (hireDate.HasValue && hireDate.Value > DateTime.Now)
                errors.Add(ErrorStart + "Hire Date cannot be in the future.");

            return errors;
        }

        private static List<string> ValidatePosition(string position)
        {
            var errors = new List<string>();

            if (!string.IsNullOrWhiteSpace(position) && position.Length > 50)
                errors.Add(ErrorStart + "Position must be 50 characters or less.");

            return errors;
        }

        private static List<string> ValidateDepartment(string department)
        {
            var errors = new List<string>();

            if (!string.IsNullOrWhiteSpace(department) && department.Length > 50)
                errors.Add(ErrorStart + "Department must be 50 characters or less.");

            return errors;
        }

        private static List<string> ValidateSalary(decimal? salary)
        {
            var errors = new List<string>();

            if (salary.HasValue && (salary < 0 || salary > 9999999999.99m))
                errors.Add(ErrorStart + "Salary must be between 0 and 9999999999.99.");

            return errors;
        }

        public static List<string> StaffValidationBasic(Staff staff)
        {
            var errors = new List<string>();

            errors.AddRange(ValidateStaffNumber(staff.StaffNumber, staff.StaffID));
            errors.AddRange(ValidateHireDate(staff.HireDate));
            errors.AddRange(ValidatePosition(staff.Position));
            errors.AddRange(ValidateDepartment(staff.Department));
            errors.AddRange(ValidateSalary(staff.Salary));

            return errors;
        }

        private static bool PersonExists(int personId)
        {
            using (var context = new AppDbContext())
            {
                return context.People.Any(p => p.PersonID == personId);
            }
        }

        public static bool IsStaffNumberTaken(string staffNumber, int id = -1)
        {
            using (var context = new AppDbContext())
            {
                return context.Staffs.Any(s => s.StaffNumber == staffNumber && s.StaffID != id);
            }
        }
    }
}
