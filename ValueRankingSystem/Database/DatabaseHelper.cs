using System;
using System.Data.SqlClient;
using System.Data.Sql;


namespace Database
{
    public class DatabaseHelper
    {
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

            cmd.Parameters.Add(new SqlParameter("Username", username));
            cmd.Parameters.Add(new SqlParameter("Password", password));
            cmd.Parameters.Add(new SqlParameter("Email", email));
            cmd.Parameters.Add("id", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();

                return (int)cmd.Parameters["id"].Value;
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
