using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

// This class fills the datasets needed for the global reports

namespace BusinessData
{

    public class Statistics
    {
        public static DataTable dataTable = new DataTable();

        // fill the user data set
   
        public static DataTable FillData(int UserID, int TestID, DateTime CreationDate)
        {
           dataTable.Clear();

            SqlCommand Command;
            SqlConnection Connection = DatabaseHelper.Connect();

            string queryString =
               "SELECT * FROM dbo.vResults WHERE UserID = @UserID AND TestID = @TestID AND CreationDate = @CreationDate;";
            Command = new SqlCommand
            {
                Connection = Connection,
                CommandText = queryString
            };
            Command.Parameters.AddWithValue("@UserID", UserID);
            Command.Parameters.AddWithValue("@TestID", TestID);
            Command.Parameters.AddWithValue("@CreationDate", CreationDate);
            
            Connection.Open();

            SqlDataAdapter daResults = new SqlDataAdapter(Command);

            daResults.Fill(dataTable);

            Connection.Close();        

            return dataTable;
        }

        public static DataTable WinsDataTable = new DataTable();

        // Fill the wins data set
        public static DataTable WinsFillData(int TestID)
        {
            WinsDataTable.Clear();

            SqlCommand Command;
            SqlConnection Connection = DatabaseHelper.Connect();

            string queryString =
               "SELECT TestName, ItemName, SUM(Wins) TotalWins, SUM(Losses) TotalLosses ,SUM(TotalScore) TotalScore FROM vResults WHERE TestID = @TestID GROUP BY TestName, ItemName ORDER BY SUM(TotalScore) DESC; ";
            Command = new SqlCommand
            {
                Connection = Connection,
                CommandText = queryString
            };
            Command.Parameters.AddWithValue("@TestID", TestID);

            Connection.Open();

            SqlDataAdapter daResults = new SqlDataAdapter(Command);

            daResults.Fill(WinsDataTable);

            Connection.Close();

            return WinsDataTable;
        }

        public static DataTable PercentDataTable = new DataTable();

        // fill the percentage data set

        public static DataTable PercentFillData(int TestID)
        {
            PercentDataTable.Clear();

            SqlCommand Command;
            SqlConnection Connection = DatabaseHelper.Connect();

            string queryString =
               "WITH T AS (SELECT DISTINCT TS.TestID, TS.SessionID ,UserID, MAX(CASE WHEN ItemID1 = TI.ItemID THEN ItemName END) AS Item1, MAX(CASE WHEN ItemID2 = TI.ItemID THEN ItemName END) AS Item2, ISNULL(MAX(CASE WHEN UserChoice = TI.ItemID THEN ItemName END), 'Undecided') AS UserChoice " +
               "FROM Tests T JOIN TestSessions TS ON T.TestID = TS.TestID JOIN Results R ON TS.SessionID = R.SessionID JOIN TestItems TI ON T.TestID = TI.TestID GROUP BY TS.SessionID, TS.TestID, UserID, ItemID1, ItemID2) " +
               "SELECT TestID, Item1,  Item2, ((CAST(SUM(CASE WHEN UserChoice = Item1 THEN 1 ELSE 0 END) AS DECIMAL(8, 2))) / COUNT(*)) *100 AS pItem1,	((CAST(SUM(CASE WHEN UserChoice = Item2 THEN 1 ELSE 0 END) AS DECIMAL(8, 2))) / COUNT(*)) *100  AS pItem2, COUNT(*) FROM T  WHERE TestID = @TestID GROUP BY Item1, Item2, TestID ORDER BY Item1";
            Command = new SqlCommand
            {
                Connection = Connection,
                CommandText = queryString
            };
            Command.Parameters.AddWithValue("@TestID", TestID);

            Connection.Open();

            SqlDataAdapter daResults = new SqlDataAdapter(Command);

            daResults.Fill(PercentDataTable);

            Connection.Close();

            return PercentDataTable;
        }


    }
}

