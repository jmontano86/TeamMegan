using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessData
{
    class ItemPairDB
    {
        public const string ITEMPAIRS_ITEMID1_COLUMN = "ItemID1";
        public const string ITEMPAIRS_ITEMID2_COLUMN = "ItemID2";
        public const string ITEMPAIRS_TESTID_COLUMN = "TestID";

        //Programmer: Jeremiah Montano
        //Date: November 11, 2018
        //Summary: Add Custom Item pairs to the database for custom comparison
        public ItemPairDB() { }

        public bool AddCustomItemPairs(List<ItemPair> itemPairs, int intTestID, string strError)
        {
            SqlConnection conn = DatabaseHelper.Connect();
            try
            {
                conn.Open();
                foreach (ItemPair item in itemPairs)
                {
                    SqlCommand cmd = new SqlCommand("SPInsertItemPair", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter(ITEMPAIRS_ITEMID1_COLUMN, item.Item1.ItemID));
                    cmd.Parameters.Add(new SqlParameter(ITEMPAIRS_ITEMID2_COLUMN, item.Item2.ItemID));
                    cmd.Parameters.Add(new SqlParameter(ITEMPAIRS_TESTID_COLUMN, intTestID));

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                strError = ex.ToString();
                return false;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            //Success we added all items!!!
            return true;
        }
        //Programmer: Jeremiah Montano
        //Date: November 20, 2018
        //Summary: Delete Item Pairs to write new ones to the database
        public bool DelCustomItemPairs(int intTestID, string strError)
        {
            SqlConnection conn = DatabaseHelper.Connect();
            SqlCommand cmd = new SqlCommand("SPDeleteItemPair", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter(ITEMPAIRS_TESTID_COLUMN, intTestID));
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                strError = ex.ToString();
                return false;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        //Programmer: Jeremiah Montano
        //Date: November 11, 2018
        //Summary: Get list of ItemPairs for Custom Comparison
        public List<ItemPair> GetCustomItemPairs(int intTestID)
        {
            SqlConnection conn = DatabaseHelper.Connect();
            SqlCommand cmd = new SqlCommand("SPGetItemPairs", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter(ITEMPAIRS_TESTID_COLUMN, intTestID));
            List<ItemPair> itemPairs = new List<ItemPair>();
            ItemPair itemPair;
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    itemPair = new ItemPair();
                    itemPair.Item1 = Item.getItem(Convert.ToInt32(reader[ITEMPAIRS_ITEMID1_COLUMN]));
                    itemPair.Item2 = Item.getItem(Convert.ToInt32(reader[ITEMPAIRS_ITEMID2_COLUMN]));

                    itemPairs.Add(itemPair);
                }
                return itemPairs;
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
        }


    }
}
