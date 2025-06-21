using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace StudentManagementSystem.DataAccess
{
    internal static class clsGloble
    {
        public static SqlConnection connection = new SqlConnection("Server=.;Database=SchoolManagementSystem;User Id=sa;Password=sa123456;");
        public static SqlCommand command = connection.CreateCommand();

        public static void FillParametersCommand(string[] Names, object[] Valus)
        {
            command.Parameters.Clear();
            for(int i = 0; i < Names.Length; i++)
            {
                command.Parameters.AddWithValue(Names[i], Valus[i]);
            }
        }
    }
}
