using StudentManagementSystem.DataAccess.Models;
using StudentManagementSystem.DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.BusinessLogic.Humans
{
    public class clsUser : clsBase<clsUser>
    {
        private readonly UserService _userService = new UserService();
        private clsTeacher _teacher = null;
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public DateTime LastLogin { get; set; }
        public bool IsActive { get; set; }

        public clsTeacher Teacher
        {
            get
            {
                if(_teacher == null)
                {
                    _teacher = clsTeacher.FindByUserID(ID);
                }
                return _teacher;
            }
        }

        public clsUser()
        {
            IsNew = true;
        }

        private clsUser(User user)
        {
            this.ModelUserToclsUser(user);
            IsNew = false;
        }

        private User ClsUserToUser()
        {
            return new User
            {
                UserID = _id,
                Username = this.Username,
                Password = this.Password,
                Role = this.Role,
                LastLogin = DateTime.Now, // Assuming LastLogin is set to current time
                IsActive = this.IsActive // Assuming user is active by default
            };
        }

        public override bool Validate()
        {
            _ErrorMessages.Clear();
            _ErrorMessages = UserService.UserValidationBasic(this.ClsUserToUser());
            return !_ErrorMessages.Any();
        }

        private void ModelUserToclsUser(User user)
        {
            this._id = user.UserID;
            this.Username = user.Username;
            this.Password = user.Password;
            this.Role = user.Role;
            this.LastLogin = user.LastLogin ?? DateTime.MinValue; // Default to current time if LastLogin is null
            this.IsActive = user.IsActive ?? true;
        }

        protected override bool _Add()
        {
            User user = ClsUserToUser();

            user.UserID = _userService.AddUser(user);

            if(user.UserID == -1)
            {
                _ErrorMessages.Add(_ErrorStart + "Failed to add user.");
                return false;
            }

            ModelUserToclsUser(user);

            return true;
        }

        protected override bool _Update()
        {
            User user = ClsUserToUser();

            bool Result = _userService.UpdateUser(user);

            if(Result)
            {
                ModelUserToclsUser(user);
                return true;
            }
            else
            {
                _ErrorMessages.Add(_ErrorStart + "Failed to update user.");
                return false;
            }
        }

        protected override clsUser GetByID(int id)
        {
            User user = _userService.GetUserById(id);


            if (user == null)
                return null;

            clsUser User = new clsUser(user);

            return User;
        }

        public static clsUser Find(int id)
        {
            return new clsUser().GetByID(id);
        }

        public static clsUser Find(string Username, string Password)
        {
            User user = new clsUser()._userService.GetUserByUsernameAndPasseord(Username,Password);

            if (user == null)
                return null;

            clsUser User = new clsUser(user);

            return User;
        }

        protected override bool DeleteByID(int id)
        {
            // Logic to delete user by ID
            return _userService.DeleteUser(id);
        }

        public static bool Delete(int id)
        {
            return new clsUser().DeleteByID(id);
        }

        protected override List<clsUser> GetAll()
        {
            List<User> ModelList = _userService.GetAllUsers();

            if (ModelList == null)
                return new List<clsUser>();

            if (ModelList.Count == 0)
                return new List<clsUser>();

            List<clsUser> UserList = new List<clsUser>();

            for (int i = 0; i <  ModelList.Count; i++)
            {
                User user = ModelList[i];

                if (user == null)
                    continue;

                clsUser User = new clsUser(user);

                UserList.Add(User);
            }

            return UserList;
        }

        public static List<clsUser> GetAllUser()
        {
            return new clsUser().GetAll();
        }
    }
}
