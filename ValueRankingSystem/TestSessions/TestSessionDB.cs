using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Database;
using System.Data;

namespace TestSessions
{
    public class TestSessionDB
    {
        public static bool GetTestSessions(List<TestSession> testSessionList, ref string error)
        {
            List<TestSession> TestSessionList = new List<TestSession>();

            SqlConnection Connection = new SqlConnection();
            SqlDataReader TestSessionDataReader;
            SqlCommand Command;
            TestSession testSession;

            try
            {
                Connection = DatabaseHelper.Connect();
                Connection.Open();
                Command = new SqlCommand();
                Command.Connection = Connection;
                Command.CommandText = "SELECT SessionID, TestID, UserID, CreationDate FROM TestSessions;";
                TestSessionDataReader = Command.ExecuteReader();

                while (TestSessionDataReader.Read())
                {
                    testSession = new TestSession();
                    testSession.SessionID = TestSessionDataReader.GetInt32(0);
                    testSession.TestID = TestSessionDataReader.GetInt32(1);
                    testSession.UserID = TestSessionDataReader.GetInt32(2);
                    testSession.CreationDate = TestSessionDataReader.GetDateTime(3);

                    testSessionList.Add(testSession);

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

        public static bool CreateSession(TestSession testsession)
        {
            SqlConnection Connection = new SqlConnection();
            SqlCommand Command = new SqlCommand();
         

            try
            {
                Connection.Open();
                Command.Connection = Connection;
                Command.CommandText = "INSERT INTO TestSessions (SessionID, TestID, UserID, CreationDate) VALUES (@SessionID, @TestID, @UserID, @CreationDate);";

                Command.Parameters.AddWithValue("@TestID", testsession.TestID);
                Command.Parameters.AddWithValue("@UserID", testsession.UserID);
                Command.Parameters.AddWithValue("@CreationDate", testsession.CreationDate);

                object a = Command.ExecuteScalar();
                testsession.SessionID = (int)a;
                testsession.TestID = (int)a;
                testsession.UserID = (int)a;
                testsession.CreationDate = (DateTime)a;
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
