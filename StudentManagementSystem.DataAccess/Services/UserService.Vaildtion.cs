using StudentManagementSystem.DataAccess.DatabaseContext;
using StudentManagementSystem.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.DataAccess.Services
{
    public partial class UserService
    {
        private static string ErrorStart = "Validation Error: ";

        private static List<string> ValidateUsername(string username, int UserID)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(username))
            {
                errors.Add(ErrorStart + "Username is required.");
                return errors;
            }
            else if (username.Length > 50)
                errors.Add(ErrorStart + "Username must be 50 characters or less.");

            if (IsUsernameUnick(username, UserID))
                errors.Add(ErrorStart + "Username already exists.");

            return errors;
        }

        private static List<string> ValidatePassword(string password)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(password))
                errors.Add(ErrorStart + "Password is required.");
            else if (password.Length > 100)
                errors.Add(ErrorStart + "Password must be 100 characters or less.");

            return errors;
        }

        private static List<string> ValidateRole(string role)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(role))
                errors.Add(ErrorStart + "Role is required.");
            else if (role.Length > 20)
                errors.Add(ErrorStart + "Role must be 20 characters or less.");

            return errors;
        }

        private static List<string> ValidateLastLogin(DateTime? lastLogin)
        {
            var errors = new List<string>();

            if (lastLogin.HasValue && lastLogin.Value > DateTime.Now)
                errors.Add(ErrorStart + "Last login cannot be in the future.");

            return errors;
        }

        public static List<string> UserValidationBasic(User user)
        {
            var errors = new List<string>();

            errors.AddRange(ValidateUsername(user.Username, user.UserID));
            errors.AddRange(ValidatePassword(user.Password));
            errors.AddRange(ValidateRole(user.Role));
            errors.AddRange(ValidateLastLogin(user.LastLogin));

            return errors;
        }

        // يمكنك إضافة فحص لتكرار اسم المستخدم (Username موجود مسبقاً) إن أردت:
        public static bool IsUsernameUnick(string username, int id = -1)
        {
            return new UserService().IsUsernameTaken(username, id);
        }
    }
}
