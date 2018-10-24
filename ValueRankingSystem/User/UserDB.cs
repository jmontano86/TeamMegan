using System.Collections.Generic;
using System.Data.SqlClient;
using Database;
using System.Data;
using Users;
using System;

namespace User
{
    class UserDB
    {
        public const string USERS_USERNAME_COLUMN = "Username";
        public const string USERS_PASSWORD_COLUMN = "Password";
        public const string USERS_EMAIL_COLUMN = "Email";
        public const string USERS_TYPE_COLUMN = "Type";
        public const string USERS_USERID_COLUMN = "UserID";

        public int CreateAccount(string strEmail, string strPassword, string strUsername)
        {
            SqlConnection conn = DatabaseHelper.Connect();
            SqlCommand cmd = new SqlCommand("SPCreateNewUser", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter(USERS_USERNAME_COLUMN, strUsername));
            cmd.Parameters.Add(new SqlParameter(USERS_PASSWORD_COLUMN, strPassword));
            cmd.Parameters.Add(new SqlParameter(USERS_EMAIL_COLUMN, strEmail));
            cmd.Parameters.Add(USERS_USERID_COLUMN, SqlDbType.Int).Direction = ParameterDirection.Output;
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();

                return (int)cmd.Parameters[USERS_USERID_COLUMN].Value;
            }
            catch
            {
                return -1;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public List<string> LookupUser(string strEmail)
        {
            SqlConnection conn = DatabaseHelper.Connect();
            SqlCommand cmd = new SqlCommand("SPGetUser", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter(USERS_EMAIL_COLUMN, strEmail));
            List<string> strUserItem = new List<string>();
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    for (int x = 0; x < reader.FieldCount; x++)
                    {
                        strUserItem.Add(reader[x].ToString());
                    }
                    reader.Close();
                }
                return strUserItem;
            }
            catch
            {
                return null;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public static bool GetUsers(List<UserClass> userList, ref string error)
        {
            List<UserClass> UserList = new List<UserClass>();

            SqlConnection Connection = new SqlConnection();
            SqlDataReader UsersDataReader;
            SqlCommand Command;
            UserClass user;

            try
            {
                Connection = DatabaseHelper.Connect();
                Connection.Open();
                Command = new SqlCommand();
                Command.Connection = Connection;
                Command.CommandText = "SELECT UserID, Username FROM Users;";
                UsersDataReader = Command.ExecuteReader();

                while (UsersDataReader.Read())
                {
                    user = new UserClass();
                    user._id = UsersDataReader.GetInt32(0);
                    user._username = UsersDataReader.GetString(1);

                    userList.Add(user);
                }
                return true;

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                if (Connection != null)
                    Connection.Close();
            }
        }
    }
}
