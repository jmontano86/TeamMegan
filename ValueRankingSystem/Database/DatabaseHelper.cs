using System;
using System.Data.SqlClient;
using System.Data.Sql;


namespace Database
{
    public class DatabaseHelper
    {

        public const string USERS_USERNAME_COLUMN = "Username";
        public const string USERS_PASSWORD_COLUMN = "Password";
        public const string USERS_EMAIL_COLUMN = "Email";
        public const string USERS_TYPE_COLUMN = "Type";
        public const string USERS_USERID_COLUMN = "UserID";

        public static SqlConnection Connect()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "cisdbss.pcc.edu";
            builder.UserID = "234a_Megan";
            builder.Password = "!!!234a_Megan!!!";
            builder.InitialCatalog = "234a_Megan";

            return new SqlConnection(builder.ConnectionString);
        }

        public int CreateAccount(string email, string password, string username)
        {
            SqlConnection conn = DatabaseHelper.Connect();
            SqlCommand cmd = new SqlCommand("SPCreateNewUser", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter(USERS_USERNAME_COLUMN, username));
            cmd.Parameters.Add(new SqlParameter(USERS_PASSWORD_COLUMN, password));
            cmd.Parameters.Add(new SqlParameter(USERS_EMAIL_COLUMN, email));
            cmd.Parameters.Add(USERS_USERID_COLUMN, System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();

                return (int)cmd.Parameters[USERS_USERID_COLUMN].Value;
            } catch
            {
                return 0;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public SqlDataReader LookupUser(string email)
        {
            SqlConnection conn = DatabaseHelper.Connect();
            SqlCommand cmd = new SqlCommand("SPGetUser", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("Email", email));
            try
            {
                conn.Open();
                return cmd.ExecuteReader();
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
    }
}
