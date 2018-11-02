using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLibrary;

namespace UserTestLogic
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
    }
}
