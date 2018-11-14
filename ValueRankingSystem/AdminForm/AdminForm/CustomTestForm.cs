using DataAccessLibrary;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserTestLogic;

namespace AdminForm
{
    public partial class CustomTestForm : MetroForm
    {
        public Test currentTest;
        public List<Item> itemList;
        public CustomTestForm()
        {
            InitializeComponent();
        }

        private void CustomTestForm_Load(object sender, EventArgs e)
        {
            //Update form text to name of test
            this.Text = "You are now customizing the " + currentTest.TestName + " test!";
            //update ListView with items
            foreach (Item item in itemList)
            {
                itemListBox.Items.Add(item);
            }
            //check to see if custom test already exists, if so populate the information
            List<ItemPair> itemPairs = new List<ItemPair>();
            itemPairs = ItemPair.getCustomItemPair(currentTest.TestID);
            if (itemPairs.Count > 0)
            {
                //add item pairs to list boxes
            }
        }
    }
}
