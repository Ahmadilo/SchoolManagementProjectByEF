using StudentManagementSystem.DataAccess.DatabaseContext;
using StudentManagementSystem.DataAccess.Models;
using System.Data.SqlClient;
using System;
using System.Linq;
using System.Collections.Generic;

namespace StudentManagementSystem.DataAccess.Services
{
    public partial class UserService
    {
        public int AddUser(User user)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    return user.UserID;
                }
            }
            catch
            {
                return -1;
            }
        }

        public bool UpdateUser(User updatedUser)
        {
            try
            {
                using (var db = new AppDbContext())
                {

                    var existingUser = db.Users.Find(updatedUser.UserID);
                    if (existingUser == null) return false;

                    existingUser.Username = updatedUser.Username;
                    existingUser.Password = updatedUser.Password;
                    existingUser.Role = updatedUser.Role;
                    existingUser.LastLogin = updatedUser.LastLogin;
                    existingUser.IsActive = updatedUser.IsActive;

                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteUser(int userId)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var user = db.Users.Find(userId);
                    if (user == null) return false;

                    db.Users.Remove(user);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public List<User> GetAllUsers()
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    return db.Users.ToList();
                }
            }
            catch (Exception e)
            {

                return new List<User>();
            }
        }

        public User GetUserById(int userId)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    return db.Users.FirstOrDefault(u => u.UserID == userId);
                }
            }
            catch
            {
                return null;
            }
        }
        // يمكن تضيف دوال أخرى مثل GetUser, UpdateUser, DeleteUser ...

        public User GetUserByUsernameAndPasseord(string Username, string Passwrod)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    return db.Users
                        .FirstOrDefault(u => u.Username == Username && u.Password == Passwrod);
                }
            }
            catch
            {
                return null;
            }
        }

        public bool ChickUserId(int userId)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var user = db.Users.FirstOrDefault(u => u.UserID == userId);
                    return user != null;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool IsUsernameTaken(string username, int id = -1)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    return db.Users.Any(u => u.Username == username && u.UserID != id);
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
