using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.DataAccess
{
    public struct stUser
    {
        public int UserID;
        public string Username;
        public string Password;
        public string Role;
        public DateTime LastLogin;
        public bool IsActive;
        public bool IsContaindData;

        public  string[] GetAllNames()
        {
            string[] Names = new string[]
            {
                "@" + nameof(this.UserID),
                "@" + nameof(this.Username),
                "@" + nameof(this.Password),
                "@" + nameof(this.Role),
                "@" + nameof(this.LastLogin),
                "@" + nameof(this.IsActive)
            };

            return Names;
        }

        public object[] GetAllValus()
        {
            return new object[]
            {
                this.UserID,
                this.Username,
                this.Password,
                this.Role,
                this.LastLogin,
                this.IsActive
            };
        }

        public void FillUserWithDataReader(SqlDataReader reader)
        {
            this.UserID = reader.GetInt32(0);
            this.Username = reader.GetString(1);
            this.Password = reader.GetString(2);
            this.Role = reader.GetString(3);
            this.LastLogin = reader.GetDateTime(4);
            this.IsActive = reader.GetBoolean(5);
        }

        public static stUser GetUser(SqlCommand com)
        {
            SqlDataReader reader = com.ExecuteReader();
            stUser user = new stUser();
            if(reader.Read())
            {
                user.IsContaindData = true;
                user.FillUserWithDataReader(reader);
            }

            reader.Close();

            return user;
        }
    }

    public class clsUserDataAccess
    {
        public stUser GetUser(int Id)
        {
            stUser user = new stUser();
            string qoury = $@"SELECT [UserID]
                  ,[Username]
                  ,[Password]
                  ,[Role]
                  ,[LastLogin]
                  ,[IsActive]
              FROM [dbo].[Users] WHERE [UserID] = @UserID;";

            clsGloble.command.CommandText = qoury;

            //clsGloble.FillParametersCommand(str)

            try
            {
                clsGloble.connection.Open();
                user.FillUserWithDataReader(clsGloble.command.ExecuteReader());
                
            }
            catch(Exception ex)
            {

            }
            finally
            {
                clsGloble.connection.Close();
            }
            return user;
        }

        public int InsertUser(stUser user)
        {
            int ID = -1;
            string qoury = $@"INSERT INTO [dbo].[Users]
                           ([Username]
                           ,[Password]
                           ,[Role]
                           ,[LastLogin]
                           ,[IsActive])
                     VALUES
                           (@Username
                           ,@Password
                           ,@Role
                           ,@LastLogin
                           ,@IsActive)
                            SELECT SCOPE_IDENTITY();";
            clsGloble.command.CommandText = qoury;

            clsGloble.FillParametersCommand(
                new string[] 
                { 
                    "@Username", 
                    "@Password" , 
                    "@LastLogin", 
                    "@IsActive" 
                },
                new object[]
                {
                    user.Username,
                    user.Password,
                    user.Role,
                    user.LastLogin,
                    user.IsActive
                });

            try
            {
                clsGloble.connection.Open();

                ID = Convert.ToInt32(clsGloble.command.ExecuteScalar());
            }
            catch(Exception e)
            {

            }
            finally
            {
                clsGloble.connection.Close();
            }
            return ID;
        }

        public bool UpdateUser(stUser user)
        {
            bool Result = false;
            string qoury = $@"UPDATE [dbo].[Users]
                                SET [Username] = @Username
                                    ,[Password] = @Password
                                    ,[Role] = @Role
                                    ,[LastLogin] = @LastLogin
                                    ,[IsActive] = @IsActive
                                WHERE [UserID] = @UserID";
            clsGloble.command.CommandText = qoury;

            clsGloble.FillParametersCommand(user.GetAllNames(),user.GetAllValus());

            try
            {
                clsGloble.connection.Open();
                int re = clsGloble.command.ExecuteNonQuery();
                if(re == 1)
                    Result = true;

            }
            catch(Exception ex)
            {

            }
            finally
            {
                clsGloble.connection.Close();
            }
            return Result;
        }

        public bool DeleteUser(int ID)
        {
            bool Result = false;
            string qoury = $@"DELETE FROM [dbo].[Users]
                              WHERE [UserID] = @UserID";

            clsGloble.FillParametersCommand(new string[] { "@UserID" }, new object[] { ID });

            try
            {
                clsGloble.connection.Open();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                clsGloble.connection.Close();
            }
            return true;
        }
    }
}
