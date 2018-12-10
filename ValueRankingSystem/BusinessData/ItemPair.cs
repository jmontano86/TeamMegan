using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessData
{
    public class ItemPair
    {
        private Item _item1;
        private Item _item2;
        private int _index;
        
        public Item Item1
        {
            get { return _item1; }
            set { _item1 = value; }
        }
        public Item Item2
        {
            get { return _item2; }
            set { _item2 = value; }
        }
        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }

        //Programmer: Jeremiah Montano
        //Date: November 11, 2018
        ///<summary>Gets list of Custom Item Pairs for custom comparison test</summary>
        public static List<ItemPair> getCustomItemPair(int intTestID)
        {
            ItemPairDB db = new ItemPairDB();
            List<ItemPair> itemPair = db.GetCustomItemPairs(intTestID);
            return itemPair;
        }
        public static bool addCustomItemPair(List<ItemPair> itemPair, int intTestID, string strError)
        {
            ItemPairDB db = new ItemPairDB();
            return db.AddCustomItemPairs(itemPair, intTestID, strError);
        }
        public static bool delCustomItemPair(int intTestID, string strError)
        {
            ItemPairDB db = new ItemPairDB();
            return db.DelCustomItemPairs(intTestID, strError);
        }
    }
}
