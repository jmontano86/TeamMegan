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
        public override string ToString()
        {
            return this.Name;
        }
    }



    public static class ItemList
    {
        public static bool getItems(List<Item> listItemList, int intTestID, string stringErrorString)
        {
            return ItemDB.getItems(listItemList, intTestID, stringErrorString);
        }
        public static bool deleteItems(int intTestID, string stringErrorString)
        {
            return ItemDB.deleteItems(intTestID, stringErrorString);
        }
        public static bool addItems(List<string> itemNames, int intTestID, string stringErrorString)
        {
            return ItemDB.addItems(itemNames, intTestID, stringErrorString);
        }
    }
}
