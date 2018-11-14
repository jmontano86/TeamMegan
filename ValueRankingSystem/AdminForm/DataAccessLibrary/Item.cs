using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class Item
    {
        string strItemName;
        //TODO: ADD IMAGE/IMAGE LOCATION

        public string Name
        {
            get { return strItemName; }
            set { strItemName = value; }
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
