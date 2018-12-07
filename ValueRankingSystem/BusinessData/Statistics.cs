using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace BusinessData
{

    public class Statistics
    {
        public static DataTable dataTable = new DataTable();
   
        public static DataTable FillData(int UserID, int TestID, DateTime CreationDate)
        {
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


        /*private int testID;

        public Statistics(int test)
        {
            testID = test;
        }

        public int Test
        {
            get
            {
                return testID;
            }
        }

        public class GetDataSet
        {
            public GetDataSet()
            {
                string queryString =
                "SELECT TestID FROM dbo.Tests";

                SqlConnection Connection = DatabaseHelper.Connect();

                SqlDataAdapter Results = new SqlDataAdapter(queryString, Connection);

                DataSet results = new DataSet();

                Results.Fill(results, "Results");

                Connection.Close();
            }

                public List<Statistics> ReturnStats()
                {
                    return testID;
                }

            }


        }





    }*/
    }
}

