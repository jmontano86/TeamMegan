using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BusinessData
{
    class TestDB
    {
        //Get all the tests from the Tests table and add them to the provided list
        public static bool getTests(List<Test> listTestList, string stringErrorString)
        {
            SqlConnection connection = new SqlConnection();
            SqlDataReader reader;
            SqlCommand command;
            Test test;
            try
            {
                connection = DatabaseHelper.Connect();
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT TestID, TestName, CustomTest FROM Tests";
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    test = new Test();
                    test.TestID = reader.GetInt32(0);
                    test.TestName = reader.GetString(1);
                    listTestList.Add(test);
                }
                reader.Close();
                return true;
            }
            catch(Exception ex)
            {
                stringErrorString = ex.Message.ToString();
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        //Add the test to the database with the name provided and set the ID to the return value from the scalar
        public static bool addTest(Test test, string stringErrorString)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command;
            try
            {
                connection = DatabaseHelper.Connect();
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO Tests(TestName, CreationDate) VALUES (@TestName, @CreationDate); SELECT Scope_Identity()";
                command.Parameters.AddWithValue("@TestName", test.TestName);
                DateTime myDateTime = DateTime.Now;
                string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss");
                command.Parameters.AddWithValue("@CreationDate", sqlFormattedDate);
                object obj = command.ExecuteScalar();
                test.TestID = (int)(decimal)obj;
                return true;
            }
            catch (Exception ex)
            {
                stringErrorString = ex.Message.ToString();
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        //Delete the test with the ID provided
        public static bool deleteTest(int intTestID, string stringErrorString)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command;
            try
            {
                connection = DatabaseHelper.Connect();
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "DELETE FROM Tests WHERE TestID = @TestID";
                command.Parameters.AddWithValue("@TestID", intTestID);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                stringErrorString = ex.Message.ToString();
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        //Gets the ID of the test with the name provided
        public static bool getTestID(Test test, string stringErrorString)
        {
            SqlConnection connection = new SqlConnection();
            SqlDataReader reader;
            SqlCommand command;
            try
            {
                connection = DatabaseHelper.Connect();
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT TestID FROM Tests WHERE TestName = @TestName";
                command.Parameters.AddWithValue("@TestName", test.TestName);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    test.TestID = reader.GetInt32(0);
                }
                reader.Close();
                return true;
            }
            catch (Exception ex)
            {
                stringErrorString = ex.Message.ToString();
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        //Get the test IDs from the TestSessions table and add them to the list provided
        public static bool getTestSessions(List<int> listTestIDList, string stringErrorString)
        {
            SqlConnection connection = new SqlConnection();
            SqlDataReader reader;
            SqlCommand command;
            try
            {
                connection = DatabaseHelper.Connect();
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT DISTINCT(TestID) FROM TestSessions";
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    listTestIDList.Add(reader.GetInt32(0));
                }
                reader.Close();
                return true;
            }
            catch (Exception ex)
            {
                stringErrorString = ex.Message.ToString();
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        //Get all the names of the tests and add them to the list provided
        public static bool getTestNames(List<string> listTestNames, string stringErrorString)
        {
            SqlConnection connection = new SqlConnection();
            SqlDataReader reader;
            SqlCommand command;
            try
            {
                connection = DatabaseHelper.Connect();
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT TestName FROM Tests";
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    listTestNames.Add(reader.GetString(0));
                }
                reader.Close();
                return true;
            }
            catch (Exception ex)
            {
                stringErrorString = ex.Message.ToString();
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
