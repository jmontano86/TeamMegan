using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BusinessData
{
    public class ResultDB
    {

        /* 
        * Programmer: Megan Villwock
        * Last Modified Date: 10/30/2018
        * 
        * Gets results from the database and stores it in class/objects.
        * 
        */
        public static bool GetResults(List<ResultDisplay> resultList, ref string error, int UserID, int TestID, DateTime CreationDate)
        {
            List<ResultDisplay> ResultList = new List<ResultDisplay>();
            

            SqlConnection Connection = DatabaseHelper.Connect();
            SqlDataReader ResultDataReader;
            SqlCommand Command;
            ResultDisplay result;

            try
            {

                // Get data from database for selected user.
                Connection = DatabaseHelper.Connect();

                Connection.Open();
                Command = new SqlCommand
                {
                    Connection = Connection,
                    CommandText = "SELECT ItemName, TotalScore, Wins, Losses, Ties FROM vResults WHERE UserID = @UserID AND TestID = @TestID AND CreationDate = @CreationDate;"   
                };
                Command.Parameters.AddWithValue("@UserID", UserID);
                Command.Parameters.AddWithValue("@TestID", TestID);
                Command.Parameters.AddWithValue("@CreationDate", CreationDate);
                ResultDataReader = Command.ExecuteReader();

                while (ResultDataReader.Read())
                {

                    result = new ResultDisplay();
                    result.stringItemName = ResultDataReader.GetString(0);
                    result.intTotalScore = ResultDataReader.GetInt32(1);
                    result.intWins = ResultDataReader.GetInt32(2);
                    result.intLosses = ResultDataReader.GetInt32(3);
                    result.intTies = ResultDataReader.GetInt32(4);
                 

                    resultList.Add(result);

                }
                return true;

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error! " + ex.ToString());
                return false;
            }
            finally
            {
                if (Connection != null)
                    Connection.Close();
            }
        }

        public static bool CreateResult(Result result)
        {
            SqlConnection Connection = DatabaseHelper.Connect();
            SqlCommand Command = new SqlCommand();


            try
            {
                Connection.Open();
                Command.Connection = Connection;
                Command.CommandText = "INSERT INTO Results (SessionID, ItemID1, ItemID2, UserChoice) VALUES (@SessionID, @ItemID1, @ItemID2, @UserChoice);" +
                    "SELECT CAST(scope_identity() AS int)";

                Command.Parameters.AddWithValue("@SessionID", result.intSessionID);
                Command.Parameters.AddWithValue("@ItemID1", result.intItemID1);
                Command.Parameters.AddWithValue("@ItemID2", result.intItemID2);
                Command.Parameters.AddWithValue("@UserChoice", result.intUserChoice);

                object a = Command.ExecuteScalar();
                result.intResultID = (int)a;
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
