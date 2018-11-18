using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BusinessData
{
    class ItemDB
    {
        //Get all the items from the test ID that is provided and add them to the list that is provided
        /// <summary>
        /// Need to get test items with testID included in the pull.
        /// Looks like this was already added by somebody.
        /// Sprint 2
        /// </summary>
        /// <param name="listItemList"></param>
        /// <param name="intTestID"></param>
        /// <param name="stringErrorString"></param>
        /// <returns> listeItemList </returns>
        public static bool getItems(List<Item> listItemList, int intTestID, string stringErrorString)
        {
            SqlConnection connection = new SqlConnection();
            SqlDataReader reader;
            SqlCommand command;
            Item item;
            try
            {
                connection = DatabaseHelper.Connect();
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT ItemID, ItemName, TestID FROM TestItems WHERE TestID = @TestID";
                command.Parameters.AddWithValue("@TestID", intTestID);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    item = new Item();
                    item.Name = reader.GetString(1);
                    item.ItemID = reader.GetInt32(0);
                    item.TestID = reader.GetInt32(2);
                    listItemList.Add(item);
                }
                reader.Close();
                return true;
            }
            catch(Exception ex)
            {
                stringErrorString = ex.Message.ToString();
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        //TODO: GET IMAGES
        //Delete the items from the test with the test ID that is provided
        public static bool deleteItems(int intTestID, string stringErrorString)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command;
            try
            {
                connection = DatabaseHelper.Connect();
                connection.Open();
                command= new SqlCommand();
                command.Connection = connection;
                command.CommandText = "DELETE FROM TestItems WHERE TestID = @TestID";
                command.Parameters.AddWithValue("@TestID", intTestID);
                command.ExecuteNonQuery();
                return true;
            }
            catch(Exception ex)
            {
                stringErrorString = ex.Message.ToString();
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        //Add items to the test form the list that is provided to the test with the ID that is provided
        public static bool addItems(List<string> itemNames, int intTestID, string stringErrorString)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command;
            try
            {
                connection = DatabaseHelper.Connect();
                connection.Open();
                
                for (int i = 0; i < itemNames.Count; i++)
                {
                    command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = "SELECT Scope_Identity(); INSERT INTO TestItems(ItemName, TestID) VALUES (@ItemName, @TestID)";
                    command.Parameters.AddWithValue("@ItemName", itemNames[i]);
                    command.Parameters.AddWithValue("@TestID", intTestID);
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch(Exception ex)
            {
                stringErrorString = ex.Message.ToString();
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        //TODO: ADD IMAGES
    }
}
