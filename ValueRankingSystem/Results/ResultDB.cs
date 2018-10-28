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
        public static bool GetResults(List<ResultDisplay> resultList, ref string error, int UserID)
        {
            List<ResultDisplay> ResultList = new List<ResultDisplay>();
            

            SqlConnection Connection = DatabaseHelper.Connect();
            SqlDataReader ResultDataReader;
            SqlCommand Command;
            ResultDisplay result;

            try
            {
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
                Command.CommandText = "INSERT INTO Results (SessionID, ItemID1, ItemID2, UserChoice) VALUES (@SessionID, @ItemID1, @ItemID2, @UserChoice);";

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
