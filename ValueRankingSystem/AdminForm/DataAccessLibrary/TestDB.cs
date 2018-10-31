using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DataAccessLibrary
{
    class TestDB
    {
        public static bool getTests(List<Test> listTestList)
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
                command.CommandText = "SELECT TestID, TestName FROM Tests";
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
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public static bool addTest(Test test)
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
                //Datetime wrong format
                DateTime myDateTime = DateTime.Now;
                string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss");
                command.Parameters.AddWithValue("@CreationDate", sqlFormattedDate);
                object obj = command.ExecuteScalar();
                test.TestID = (int)(decimal)obj;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public static bool deleteTest(int intTestID)
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
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public static bool getTestID(Test test)
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
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
