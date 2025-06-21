using StudentManagementSystem.BusinessLogic.Humans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.BusinessLogic.Features.Administrative.Auth
{
    public static class clsLogin
    {
        public static clsUser UserLogin = null;
        public static string LoginMessage = string.Empty;

        public static bool LoginByUsernameAndPassword(string username, string password)
        {
            // Simulate That we Get User form Database for Now
            clsUser User = clsUser.Find(username,password);

            if(User == null)
            {
                LoginMessage = "Username or Passwrd Not Valid!";
                return false;
            }

            if(User.IsActive == false)
            {
                LoginMessage = "User is not Active Please Contact Your Administrator!";
                return false;
            }

            UserLogin = User;
            LoginMessage = "Susseccfully Login In";
            UserLogin.LastLogin = DateTime.Now;
            UserLogin.Save();
            return true;
        }

        public static void Logout()
        {
            UserLogin = null;
            LoginMessage = string.Empty;
        }
    }
}
