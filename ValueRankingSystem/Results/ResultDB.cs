using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;
using System.Data.SqlClient;

namespace Results
{
    class ResultDB
    {
        public static bool GetResults(List<Result> resultList, ref string error)
        {
            List<Result> ResultList = new List<Result>();

            SqlConnection Connection = DatabaseHelper.Connect();
            SqlDataReader ResultDataReader;
            SqlCommand Command;
            Result result;

            try
            {
                Connection.Open();
                Command = new SqlCommand
                {
                    Connection = Connection,
                    CommandText = "SELECT ResultID, SessionID, ItemID1, ItemID2, UserChoice FROM Results;"
                };
                ResultDataReader = Command.ExecuteReader();

                while (ResultDataReader.Read())
                {
                    result = new Result();
                    result.ResultID = ResultDataReader.GetInt32(0);
                    result.SessionID = ResultDataReader.GetInt32(1);
                    result.ItemID1 = ResultDataReader.GetInt32(2);
                    result.ItemID2 = ResultDataReader.GetInt32(3);
                    result.UserChoice = ResultDataReader.GetInt32(4);

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
