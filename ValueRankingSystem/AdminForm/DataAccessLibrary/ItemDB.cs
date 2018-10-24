using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DataAccessLibrary
{
    class ItemDB
    {
        public static bool getItems(List<Item> listItemList, int intTestID)
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
                command.CommandText = "SELECT ItemID, ItemName FROM TestItems WHERE TestID = @TestID";
                command.Parameters.AddWithValue("@TestID", intTestID);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    item = new Item();
                    item.ItemID = reader.GetInt32(0);
                    item.Name = reader.GetString(1);
                    listItemList.Add(item);
                }
                reader.Close();
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public static bool deleteItems(int intTestID)
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
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public static bool addItems(List<string> itemNames, int intTestID)
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
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
