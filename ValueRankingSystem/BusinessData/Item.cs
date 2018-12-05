using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BusinessData
{
    public class Item
    {
        int intItemID;
        string strItemName;
        int intTestID;
        private byte[] byteImage;

        public int ItemID
        {
            get { return intItemID; }
            set { intItemID = value; }
        }
        public byte[] ItemImage
        {
            get { return byteImage; }
            set { byteImage = value; }
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

        public Image getImage()
        {
            Image image;
            if(byteImage != null)
            {
                MemoryStream ms = new MemoryStream(byteImage, 0, byteImage.Length);
                image = Image.FromStream(ms, true);
                return image;
            }
            else
            {
                return null;
            }
        }
    }

    public static class ItemList
    {
        public static bool getItems(List<Item> listItemList, int intTestID, ref string stringErrorString)
        {
            return ItemDB.getItems(listItemList, intTestID, ref stringErrorString);
        }
        public static bool deleteItems(int intTestID, ref string stringErrorString)
        {
            return ItemDB.deleteItems(intTestID, ref stringErrorString);
        }
        public static bool addItems(List<Item> items, Test test, ref string stringErrorString)
        {
            return ItemDB.addItems(items, test, ref stringErrorString);
        }
    }
}
