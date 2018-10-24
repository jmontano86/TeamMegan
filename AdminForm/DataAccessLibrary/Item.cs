using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class Item
    {
        int intItemID;
        string strItemName;

        public int ItemID
        {
            get { return intItemID; }
            set { intItemID = value; }
        }
        public string Name
        {
            get { return strItemName; }
            set { strItemName = value; }
        }
    }

    public static class ItemList
    {
        public static bool getItems(List<Item> listItemList, int intTestID)
        {
            return ItemDB.getItems(listItemList, intTestID);
        }
        public static bool deleteItems(int intTestID)
        {
            return ItemDB.deleteItems(intTestID);
        }
        public static bool addItems(List<string> itemNames, int intTestID)
        {
            return ItemDB.addItems(itemNames, intTestID);
        }
    }
}
