using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BusinessData
{
    class TestDB
    {
        public const string TESTS_TESTID_COLUMN = "TestID";
        public const string TESTS_TESTNAME_COLUMN = "TestName";
        public const string TESTS_CREATIONDATE_COLUMN = "CreationDate";
        public const string TESTS_CUSTOMTEST_COLUMN = "CustomTest";
        public const string TESTS_SHUFFLE_COLUMN = "Shuffle";
        public const string TESTS_TESTTYPE_COLUMN = "TestType";
        //Get all the tests from the Tests table and add them to the provided list
        public static bool getTests(List<Test> listTestList, ref string stringErrorString)
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
                command.CommandText = "SELECT TestID, TestName, CustomTest, Shuffle, TestType FROM Tests";
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    test = new Test();
                    test.TestID = Convert.ToInt32(reader[TESTS_TESTID_COLUMN]);
                    test.TestName = Convert.ToString(reader[TESTS_TESTNAME_COLUMN]);
                    test.TestType = Convert.ToString(reader[TESTS_TESTTYPE_COLUMN]);
                    if (!reader.IsDBNull(reader.GetOrdinal(TESTS_CUSTOMTEST_COLUMN)))
                    {
                        test.CustomTest = Convert.ToInt32(reader[TESTS_CUSTOMTEST_COLUMN]);
                    }
                    else
                    {
                        test.CustomTest = 0;
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal(TESTS_SHUFFLE_COLUMN)))
                    {
                        test.Shuffle = Convert.ToInt32(reader[TESTS_SHUFFLE_COLUMN]);
                    }
                    else
                    {
                        test.Shuffle = 0;
                    }
                    listTestList.Add(test);
                }
                reader.Close();
                return true;
            }
            catch (Exception ex)
            {
                stringErrorString = "Error retriving the tests from the database: ";
                stringErrorString += ex.Message.ToString();
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public bool updateCustomTest(int intTestID, int intCustomBit, int intShuffleBit)
        {
            SqlConnection conn = DatabaseHelper.Connect();
            try
            {

                SqlCommand cmd = new SqlCommand("SPUpdateCustomTest", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter(TESTS_TESTID_COLUMN, intTestID));
                cmd.Parameters.Add(new SqlParameter(TESTS_CUSTOMTEST_COLUMN, intCustomBit));
                cmd.Parameters.Add(new SqlParameter(TESTS_SHUFFLE_COLUMN, intShuffleBit));

                conn.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        //Add the test to the database with the name provided and set the ID to the return value from the scalar
        public static bool addTest(Test test, ref string stringErrorString)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command;
            try
            {
                connection = DatabaseHelper.Connect();
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO Tests(TestName, TestType, CreationDate) VALUES (@TestName, @TestType, @CreationDate); SELECT Scope_Identity()";
                command.Parameters.AddWithValue("@TestName", test.TestName);
                command.Parameters.AddWithValue("@TestType", test.TestType);
                DateTime myDateTime = DateTime.Now;
                string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss");
                command.Parameters.AddWithValue("@CreationDate", sqlFormattedDate);
                object obj = command.ExecuteScalar();
                test.TestID = (int)(decimal)obj;
                return true;
            }
            catch (Exception ex)
            {
                stringErrorString = "Error adding the test to the database: ";
                stringErrorString += ex.Message.ToString();
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        //Delete the test with the ID provided
        public static bool deleteTest(int intTestID, ref string stringErrorString)
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
                stringErrorString = "Error deleting the test from the database: ";
                stringErrorString += ex.Message.ToString();
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        //Gets the ID of the test with the name provided
        public static bool getTestIDAndType(Test test, ref string stringErrorString)
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
                command.CommandText = "SELECT TestID, TestType FROM Tests WHERE TestName = @TestName";
                command.Parameters.AddWithValue("@TestName", test.TestName);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    test.TestID = reader.GetInt32(0);
                    test.TestType = reader.GetString(1);
                }
                reader.Close();
                return true;
            }
            catch (Exception ex)
            {
                stringErrorString = "Error getting the test ID and type from the database: ";
                stringErrorString += ex.Message.ToString();
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public static bool getTestType(ref string testType, int testID, ref string errorMessage)
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
                command.CommandText = "SELECT TestType FROM Tests WHERE TestID = @TestID";
                command.Parameters.AddWithValue("@TestID", testID);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    testType = reader.GetString(0);
                }
                reader.Close();
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = "Error getting the test type from the database: ";
                errorMessage += ex.Message.ToString();
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        //Get the test IDs from the TestSessions table and add them to the list provided
        public static bool getTestSessions(List<int> listTestIDList, ref string stringErrorString)
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
                stringErrorString = "Error getting the test sessions from the database: ";
                stringErrorString += ex.Message.ToString();
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        //Get all the names of the tests and add them to the list provided
        public static bool getTestNames(List<string> listTestNames, ref string stringErrorString)
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
                stringErrorString = "Error getting the test names from the database: ";
                stringErrorString += ex.Message.ToString();
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
