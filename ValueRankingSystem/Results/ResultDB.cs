using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;
using System.Data.SqlClient;

namespace Results
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
        public static bool GetResults(List<ResultDisplay> resultList, ref string error, int UserID)
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
                    CommandText = "SELECT ItemName, TotalScore, Wins, Losses, Ties FROM vResults WHERE UserID = @UserID;"   
                };
                Command.Parameters.AddWithValue("@UserID", UserID);
                ResultDataReader = Command.ExecuteReader();

                while (ResultDataReader.Read())
                {

                    result = new ResultDisplay();
                    result.ItemName = ResultDataReader.GetString(0);
                    result.TotalScore = ResultDataReader.GetInt32(1);
                    result.Wins = ResultDataReader.GetInt32(2);
                    result.Losses = ResultDataReader.GetInt32(3);
                    result.Ties = ResultDataReader.GetInt32(4);
                 

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

                Command.Parameters.AddWithValue("@SessionID", result.SessionID);
                Command.Parameters.AddWithValue("@ItemID1", result.ItemID1);
                Command.Parameters.AddWithValue("@ItemID2", result.ItemID2);
                Command.Parameters.AddWithValue("@UserChoice", result.UserChoice);

                object a = Command.ExecuteScalar();
                result.ResultID = (int)a;
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
