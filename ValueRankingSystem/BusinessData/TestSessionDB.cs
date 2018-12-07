using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace BusinessData
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

        public static bool GetUserTests(List<Test> testList, ref string error, int UserID)
        {
            List<Test> TestSessionList = new List<Test>();

            SqlConnection Connection = new SqlConnection();
            SqlDataReader TestDataReader;
            SqlCommand Command;
            Test test;

            try
            {
                // Connect to database and get data.
                Connection = DatabaseHelper.Connect();
                Connection.Open();
                Command = new SqlCommand();
                Command.Connection = Connection;
                Command.CommandText = "SELECT DISTINCT TestSessions.TestID, Tests.TestName FROM TestSessions" +
                    "                  LEFT OUTER JOIN Tests ON TestSessions.TestID = Tests.TestID WHERE UserID = @UserID;";
                Command.Parameters.AddWithValue("@UserID", UserID);
                TestDataReader = Command.ExecuteReader();

                // Add data to list.
                while (TestDataReader.Read())
                {
                    test = new Test();
                    test.TestID = TestDataReader.GetInt32(0);
                    test.TestName = TestDataReader.GetString(1);
                    testList.Add(test);

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

        public static bool GetTestDate(List<TestSession> dateList, ref string error, int UserID, int TestID)
        {
            List<TestSession> TestSessionList = new List<TestSession>();

            SqlConnection Connection = new SqlConnection();
            SqlDataReader TestSessionDataReader;
            SqlCommand Command;
            TestSession testsession;

            try
            {
                // Connect to database and get data.
                Connection = DatabaseHelper.Connect();
                Connection.Open();
                Command = new SqlCommand();
                Command.Connection = Connection;
                Command.CommandText = "SELECT TestSessions.TestID, TestSessions.CreationDate FROM TestSessions" +
                    "                  WHERE TestSessions.UserID = @UserID AND TestSessions.TestID = @TestID;";
                Command.Parameters.AddWithValue("@UserID", UserID);
                Command.Parameters.AddWithValue("@TestID", TestID);
                TestSessionDataReader = Command.ExecuteReader();

                // Add data to list.
                while (TestSessionDataReader.Read())
                {
                    testsession = new TestSession();
                    testsession.intTestID = TestSessionDataReader.GetInt32(0);
                    testsession.datetimeCreationDate = TestSessionDataReader.GetDateTime(1);
                    dateList.Add(testsession);

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
