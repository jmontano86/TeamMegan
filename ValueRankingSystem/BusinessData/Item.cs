using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessData
{
    public class Item
    {
        int intItemID;
        string strItemName;
        int intTestID;

        public int ItemID
        {
            get { return intItemID; }
            set { intItemID = value; }
        }
        //TODO: ADD TESTID IN ORDER TO POPULATE MULTIPLE TESTS FOR USERTESTING. Added by Kevin for Sprint 2
        public int TestID
        {
            get { return intTestID; }
            set { intTestID = value; }
        }

        //TODO: ADD IMAGE/IMAGE LOCATION
        public string Name
        {
            get { return strItemName; }
            set { strItemName = value; }
        }
        public override string ToString()
        {
            return this.Name;
        }

        public static Item getItem(int intItemID)
        {
            ItemDB db = new ItemDB();
            return db.getItem(intItemID);
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
