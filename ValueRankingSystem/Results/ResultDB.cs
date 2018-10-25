﻿using System;
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

            SqlConnection Connection = new SqlConnection();
            SqlDataReader ResultDataReader;
            SqlCommand Command;
            Result result;

            try
            {
                Connection = DatabaseHelper.Connect();
                Connection.Open();
                Command = new SqlCommand
                {
                    Connection = Connection,
                    CommandText = "SELECT ResultID, SessionID, ItemID1, ItemID2, UserChoice FROM Results;"
                };
                ResultDataReader = Command.ExecuteReader();

                while (ResultDataReader.Read())
                {
                    result = new Result
                    {
                        ResultID = ResultDataReader.GetInt32(0),
                        SessionID = ResultDataReader.GetInt32(1),
                        ItemID1 = ResultDataReader.GetInt32(2),
                        ItemID2 = ResultDataReader.GetInt32(3),
                        UserChoice = ResultDataReader.GetInt32(4)
                    };

                    resultList.Add(result);

                }
                return true;

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error!");
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
            SqlConnection Connection = new SqlConnection();
            SqlCommand Command = new SqlCommand();


            try
            {
                Connection.Open();
                Command.Connection = Connection;
                Command.CommandText = "INSERT INTO Results (ResultID, SessionID, ItemID1, ItemID2, UserChoice) VALUES (@ResultID, @SessionID, @ItemID1, @ItemID2, @UserChoice);";

                Command.Parameters.AddWithValue("@ResultID, ", result.ResultID);
                Command.Parameters.AddWithValue("@SessionID, ", result.SessionID);
                Command.Parameters.AddWithValue("@ItemID1, ", result.ItemID1);
                Command.Parameters.AddWithValue("@ItemID2, ", result.ItemID2);
                Command.Parameters.AddWithValue("@UserChoice, ", result.UserChoice);

                object a = Command.ExecuteScalar();
                result.ResultID = (int)a;
                result.SessionID = (int)a;
                result.ItemID1 = (int)a;
                result.ItemID2 = (int)a;
                result.UserChoice = (int)a;
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
