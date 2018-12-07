using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace BusinessData
{
    class ItemDB
    {
        private const string TESTITEMS_ITEMID_COLUMN = "ItemID";
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
        public static bool getItems(List<Item> listItemList, int intTestID, ref string stringErrorString)
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
                command.CommandText = "SELECT ISNULL(ItemImage, 0), ISNULL(ItemName, 0) FROM TestItems WHERE TestID = @TestID";
                command.Parameters.AddWithValue("@TestID", intTestID);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    item = new Item();
                    if(reader[0] != "null")
                    {
                        item.ItemImage = (byte[])reader[0];
                    }
                    if(reader[1] != "null")
                    {
                        item.Name = reader.GetString(1);
                    }
                    listItemList.Add(item);
                }
                return true;
            }
            catch (Exception ex)
            {
                stringErrorString = "Error getting items from the database: ";
                stringErrorString += ex.Message.ToString();
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public Item getItem(int intItemID)
        {
            SqlConnection conn = DatabaseHelper.Connect();
            SqlCommand cmd = new SqlCommand("SPGetItem", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter(TESTITEMS_ITEMID_COLUMN, intItemID));
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    Item newItem = new Item();
                    newItem.ItemID = reader.GetInt32(0);
                    newItem.TestID = reader.GetInt32(1);
                    newItem.Name = reader.GetString(2);
                    return newItem;
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return null;
        }

        //Delete the items from the test with the test ID that is provided
        public static bool deleteItems(int intTestID, ref string stringErrorString)
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
                stringErrorString = "Error deleting items from the database: ";
                stringErrorString += ex.Message.ToString();
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        //Add items to the test form the list that is provided to the test with the ID that is provided
        public static bool addItems(List<Item> listItems, Test test, ref string stringErrorString)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command;
            try
            {
                connection = DatabaseHelper.Connect();
                connection.Open();

                for (int i = 0; i < listItems.Count; i++)
                {
                    if (test.TestType == "T")
                    {
                        command = new SqlCommand();
                        command.Connection = connection;
                        command.CommandText = "SELECT Scope_Identity(); INSERT INTO TestItems(ItemName, TestID) VALUES (@ItemName, @TestID)";
                        command.Parameters.AddWithValue("@ItemName", listItems[i].Name);
                        command.Parameters.AddWithValue("@TestID", test.TestID);
                        command.ExecuteNonQuery();
                    }
                    else if (test.TestType == "I")
                    {
                        command = new SqlCommand();
                        command.Connection = connection;
                        command.CommandText = "SELECT Scope_Identity(); INSERT INTO TestItems(ItemImage, TestID) VALUES (@ItemImage, @TestID)";
                        command.Parameters.AddWithValue("@ItemImage", listItems[i].ItemImage);
                        command.Parameters.AddWithValue("@TestID", test.TestID);
                        command.ExecuteNonQuery();
                    }
                    else if (test.TestType == "TI")
                    {
                        command = new SqlCommand();
                        command.Connection = connection;
                        command.CommandText = "SELECT Scope_Identity(); INSERT INTO TestItems(ItemName, TestID, ItemImage) VALUES (@ItemName, @TestID, @ItemImage)";
                        command.Parameters.AddWithValue("@ItemName", listItems[i].Name);
                        command.Parameters.AddWithValue("@ItemImage", listItems[i].ItemImage);
                        command.Parameters.AddWithValue("@TestID", test.TestID);
                        command.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                stringErrorString = "Error adding items to the database: ";
                stringErrorString += ex.Message.ToString();
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
