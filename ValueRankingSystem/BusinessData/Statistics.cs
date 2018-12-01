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
        

        private DataSet dataTable = new DataSet();
        

        private void FillData()
        {
            string queryString =
               "SELECT * FROM dbo.vResults";

            SqlConnection Connection = DatabaseHelper.Connect();
            Connection.Open();

            SqlDataAdapter daResults = new SqlDataAdapter(queryString, Connection);

            daResults.Fill(dataTable, "Results");

            Connection.Close();
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

