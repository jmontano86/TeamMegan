using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace DataAccessLibrary
{
    public class DatabaseHelper
    {

        public static SqlConnection Connect()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "cisdbss.pcc.edu";
            builder.UserID = "234a_Megan";
            builder.Password = "!!!234a_Megan!!!";
            builder.InitialCatalog = "234a_Megan";

            return new SqlConnection(builder.ConnectionString);
        }


    }
}