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
        /* 
        * Programmer: Megan Villwock
        * Last Modified Date: 10/30/2018
        * 
        * Gets data from the database and stores it in class/objects.
        * 
        */

        public static bool GetTestSessions(List<TestSession> testSessionList, ref string error)
        {
            List<TestSession> TestSessionList = new List<TestSession>();

            SqlConnection Connection = new SqlConnection();
            SqlDataReader TestSessionDataReader;
            SqlCommand Command;
            TestSession testSession;

            try
            {
                // Connect to database and get data.
                Connection = DatabaseHelper.Connect();
                Connection.Open();
                Command = new SqlCommand();
                Command.Connection = Connection;
                Command.CommandText = "SELECT SessionID, TestID, UserID, CreationDate FROM TestSessions;";
                TestSessionDataReader = Command.ExecuteReader();

                // Add data to list.
                while (TestSessionDataReader.Read())
                {
                    testSession = new TestSession();
                    testSession.intSessionID = TestSessionDataReader.GetInt32(0);
                    testSession.intTestID = TestSessionDataReader.GetInt32(1);
                    testSession.intUserID = TestSessionDataReader.GetInt32(2);
                    testSession.datetimeCreationDate = TestSessionDataReader.GetDateTime(3);

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
            SqlConnection Connection = DatabaseHelper.Connect();
            SqlCommand Command = new SqlCommand();
         

            try
            {
                Connection.Open();
                Command.Connection = Connection;
                Command.CommandText = "INSERT INTO TestSessions (TestID, UserID, CreationDate) VALUES (@TestID, @UserID, @CreationDate);" +
                    "SELECT CAST(scope_identity() AS int)";


                Command.Parameters.AddWithValue("@TestID", testsession.intTestID);
                Command.Parameters.AddWithValue("@UserID", testsession.intUserID);
                Command.Parameters.AddWithValue("@CreationDate", testsession.datetimeCreationDate);

                object a = Command.ExecuteScalar();
                testsession.intSessionID = (int)a;
                
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
