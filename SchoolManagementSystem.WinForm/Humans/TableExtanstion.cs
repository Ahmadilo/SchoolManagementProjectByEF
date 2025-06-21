using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentManagementSystem.BusinessLogic.Humans;

namespace SchoolManagementSystem.WinForm.Humans
{
    internal static class TableExtanstion
    {
        public static void LoadDataUsers(this DataGridView Table)
        {
            Table.Rows.Clear();
            List<clsUser> users = clsUser.GetAllUser();

            if (users.Count == 0)
                return;

            for (int i = 0; i < users.Count; i++)
            {
                clsUser User = users[i];

                Table.Rows.Add(
                    User.ID.ToString(),
                    User.Username,
                    User.Password,
                    User.Role,
                    User.LastLogin.ToString("d"),
                    User.IsActive,
                    "Edite",
                    "Delete"
                );
            }
        }

        public static clsUser GetUserData(this DataGridViewRow Row)
        {
            clsUser User = clsUser.Find(Convert.ToInt32( Row.Cells[0].Value));

            return User;
        }

        public static int GetUserId(this DataGridViewRow Row)
        {
            return Convert.ToInt32(Row.Cells[0].Value);
        }
    }
}
