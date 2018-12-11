using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BusinessData;
using MetroFramework;

namespace Gui
{

    //Programmer: Jeremiah Montano
    //Date: November 15, 2018
    /*
     * Summary: Allow administrators to define a custom comparison test
     * rather than allow the system to match each item pair together once
     * Allows for multiple comparisons of same item pairs. 
    */
    public partial class CustomTestForm : MetroForm
    {
        public Test currentTest;
        public List<Item> itemList;
        private bool isExisting;
        public string strError;
        private int intShuffleBit;
        public CustomTestForm()
        {
            InitializeComponent();
        }

        private void CustomTestForm_Load(object sender, EventArgs e)
        {
            //Update form text to name of test
            this.Text = "You are now customizing the " + currentTest.TestName + " test!";
            //update ListView with items in the current test
            foreach (Item item in itemList)
            {
                itemsListBox.Items.Add(item);
            }
            //check to see if custom test already exists, if so populate the information
            List<ItemPair> itemPairs = new List<ItemPair>();
            itemPairs = ItemPair.getCustomItemPair(currentTest.TestID);
            if (itemPairs != null)
            {
                isExisting = true;
                foreach (ItemPair listItem in itemPairs)
                {
                    item1ListBox.Items.Add(listItem.Item1);
                    item2ListBox.Items.Add(listItem.Item2);
                }
            }
            if (currentTest.Shuffle == 1)
            {
                shuffleCheckBox.Checked = true;
            }
        }

        private void option1Button_Click(object sender, EventArgs e)
        {
            //Add selected item to Option 1. If no selection, raise error
            if (itemsListBox.SelectedIndex > -1)
            {
                item1ListBox.Items.Add(itemsListBox.SelectedItem);
            }
            else
            {
                customErrorProvider.SetIconAlignment(itemsListBox, ErrorIconAlignment.TopRight);
                customErrorProvider.SetError(itemsListBox, "You must select an Item first!");
            }
        }

        private void itemsListBox_MouseDown(object sender, MouseEventArgs e)
        {
            customErrorProvider.Clear();
            itemsListBox.SelectedIndex = itemsListBox.IndexFromPoint(e.X, e.Y);
        }

        private void option2Button_Click(object sender, EventArgs e)
        {
            //Add selected item to Option 2. If no selection, raise error
            if (itemsListBox.SelectedIndex > -1)
            {
                item2ListBox.Items.Add(itemsListBox.SelectedItem);
            }
            else
            {
                customErrorProvider.SetIconAlignment(itemsListBox, ErrorIconAlignment.TopRight);
                customErrorProvider.SetError(itemsListBox, "You must select an Item first!");
            }
        }

        private void item2ListBox_KeyUp(object sender, KeyEventArgs e)
        {
            //if delete key is pressed on the form, delete index if selected
            if (e.KeyCode == Keys.Delete)
            {
                if (item2ListBox.SelectedIndex > -1)
                {
                    item2ListBox.Items.RemoveAt(item2ListBox.SelectedIndex);
                }
            }
        }

        private void item1ListBox_KeyUp(object sender, KeyEventArgs e)
        {
            //if delete key is pressed on the form, delete index if selected
            if (e.KeyCode == Keys.Delete)
            {
                if (item1ListBox.SelectedIndex > -1)
                {
                    item1ListBox.Items.RemoveAt(item1ListBox.SelectedIndex);
                }
            }
        }

        private void removeOption1Buttn_Click(object sender, EventArgs e)
        {
            if (item1ListBox.SelectedIndex > -1)
            {
                item1ListBox.Items.RemoveAt(item1ListBox.SelectedIndex);
            }
            else
            {
                customErrorProvider.SetIconAlignment(item1ListBox, ErrorIconAlignment.TopLeft);
                customErrorProvider.SetError(item1ListBox, "You must select an Item first!");
            }
        }

        private void removeOption2Button_Click(object sender, EventArgs e)
        {
            if (item2ListBox.SelectedIndex > -1)
            {
                item2ListBox.Items.RemoveAt(item2ListBox.SelectedIndex);
            }
            else
            {
                customErrorProvider.SetIconAlignment(item2ListBox, ErrorIconAlignment.TopLeft);
                customErrorProvider.SetError(item2ListBox, "You must select an Item first!");
            }
        }
        private void item1ListBox_MouseDown(object sender, MouseEventArgs e)
        {
            item1ListBox.AllowDrop = true;
            item2ListBox.AllowDrop = false;
            if (item1ListBox.SelectedItem == null) return;
            item1ListBox.DoDragDrop(item1ListBox.SelectedItem, DragDropEffects.All);

        }

        private void item1ListBox_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void item1ListBox_DragDrop(object sender, DragEventArgs e)
        {
            Point point = item1ListBox.PointToClient(new Point(e.X, e.Y));
            int index = item1ListBox.IndexFromPoint(point);
            if (index < 0) index = item1ListBox.Items.Count - 1;
            object data = e.Data.GetData(typeof(Item));
            item1ListBox.Items.Remove(data);
            item1ListBox.Items.Insert(index, data);
            item1ListBox.AllowDrop = false;
        }

        private void item2ListBox_MouseDown(object sender, MouseEventArgs e)
        {
            item2ListBox.AllowDrop = true;
            item1ListBox.AllowDrop = false;
            if (item2ListBox.SelectedItem == null) return;
            item2ListBox.DoDragDrop(item2ListBox.SelectedItem, DragDropEffects.All);

        }

        private void item2ListBox_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;

        }

        private void item2ListBox_DragDrop(object sender, DragEventArgs e)
        {
            Point point = item2ListBox.PointToClient(new Point(e.X, e.Y));
            int index = item2ListBox.IndexFromPoint(point);
            if (index < 0) index = item2ListBox.Items.Count - 1;
            object data = e.Data.GetData(typeof(Item));
            item2ListBox.Items.Remove(data);
            item2ListBox.Items.Insert(index, data);
            item2ListBox.AllowDrop = false;
        }

        private void finishButton_Click(object sender, EventArgs e)
        {
            //Time to validate data.
            /* Validate Requirements
             * 1) Item1.Count == Item2.Count
             * 2) Item1.Name != Item2.Name on the same index
             * 3) If 0 pairs given, no custom pairs written
             * 4) if 3 or more pairs, write to database
             * 5) if 1 or 2 pairs, throw error message
             */

            if (item1ListBox.Items.Count < 1 || item2ListBox.Items.Count < 1)
            {
                //validation 3, 0 pairs are given. save shuffle option only
                if (isExisting)
                {
                    bool delResult = ItemPair.delCustomItemPair(currentTest.TestID, strError);
                    if (!delResult)
                    {
                        MetroMessageBox.Show(this, "The following error has occurred: " + strError, "Error Adding Items!",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                Test.updateCustomTest(currentTest.TestID, 0, intShuffleBit);
                //shuffle option successfully saved. Party up!
                myNotifyIcon.BalloonTipTitle = "Custom Test Saved";
                myNotifyIcon.BalloonTipText = "The changes to " + currentTest.TestName + " Test have been saved!";
                myNotifyIcon.Icon = SystemIcons.Information;
                myNotifyIcon.Visible = true;
                myNotifyIcon.ShowBalloonTip(2000);
                return;
            }
            if (item1ListBox.Items.Count != item2ListBox.Items.Count)
            {
                //validation 1 failed, items mismatch
                //Remove extra items and save?
                DialogResult result = MetroMessageBox.Show(this, "The number of items don't match, would you like to remove extra items?",
                    "Remove Extra Items?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    //remove extra results
                    if (item1ListBox.Items.Count > item2ListBox.Items.Count)
                    {
                        for (int i = item1ListBox.Items.Count; i > item2ListBox.Items.Count; i--)
                        {
                            item1ListBox.Items.RemoveAt(i - 1);
                        }
                    }
                    else
                    {
                        for (int i = item2ListBox.Items.Count; i > item1ListBox.Items.Count; i--)
                        {
                            item2ListBox.Items.RemoveAt(i - 1);
                        }
                    }
                    //Continue validation to ensure number of pairs is still valid
                }
                else
                {
                    return;
                }
            }
            if (item1ListBox.Items.Count < 3 || item2ListBox.Items.Count < 3)
            {
                //validation 5 failed, throw error
                MetroMessageBox.Show(this, "You must enter at least 3 pairs of items!", "Not Enough Pairs",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            for (int x = 0; x < item1ListBox.Items.Count; x++)
            {
                Item item1 = (Item)item1ListBox.Items[x];
                Item item2 = (Item)item2ListBox.Items[x];
                if (item1.ItemID == item2.ItemID)
                {
                    MetroMessageBox.Show(this, "You cannot compare an item against itself!", "Invalid Comparison",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    item1ListBox.SelectedIndex = x;
                    item2ListBox.SelectedIndex = x;
                    return;
                }
            }
            //All validation has been made, we will write items to database
            List<ItemPair> pairList = new List<ItemPair>();
            for (int x = 0; x < item1ListBox.Items.Count; x++)
            {
                ItemPair pair = new ItemPair();
                pair.Item1 = (Item)item1ListBox.Items[x];
                pair.Item2 = (Item)item2ListBox.Items[x];
                pairList.Add(pair);
            }
            if (isExisting)
            {
                bool delResult = ItemPair.delCustomItemPair(currentTest.TestID, strError);
                if (!delResult)
                {
                    MetroMessageBox.Show(this, "The following error has occurred: " + strError, "Error Adding Items!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (item1ListBox.Items.Count > 0)
            {
                bool addResult = ItemPair.addCustomItemPair(pairList, currentTest.TestID, strError);
                if (!addResult)
                {
                    MetroMessageBox.Show(this, "The following error has occurred: " + strError, "Error Adding Items!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Test.updateCustomTest(currentTest.TestID, 1, intShuffleBit);
                isExisting = true;
                //items successfully saved. Party up!
                myNotifyIcon.BalloonTipTitle = "Custom Test Saved";
                myNotifyIcon.BalloonTipText = "The changes to " + currentTest.TestName + " Test have been saved!";
                myNotifyIcon.Icon = SystemIcons.Information;
                myNotifyIcon.Visible = true;
                myNotifyIcon.ShowBalloonTip(2000);
            }
        }

        private void shuffleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (shuffleCheckBox.Checked)
            {
                intShuffleBit = 1;
            }
            else
            {
                intShuffleBit = 0;
            }
        }

        private void addToOption1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            option1Button_Click(sender, e);
        }

        private void addToOption2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            option2Button_Click(sender, e);
        }
    }
}
