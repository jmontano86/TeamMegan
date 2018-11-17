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
        private string strDragName;
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
                itemsListBox.Items.Add(item);
            }
            //check to see if custom test already exists, if so populate the information
            List<ItemPair> itemPairs = new List<ItemPair>();
            itemPairs = ItemPair.getCustomItemPair(currentTest.TestID);
                if (itemPairs != null)
                {
                    isExisting = true;
                    //add item pairs to list boxes
                }
        }

        private void option1Button_Click(object sender, EventArgs e)
        {
            //Add selected item to Option 1. If no selection, raise error
            if(itemsListBox.SelectedIndex > -1)
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
            } else
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

            if(item1ListBox.Items.Count < 1 || item2ListBox.Items.Count <1)
            {
                //validation 3 failed, 0 pairs are given. save shuffle option only
                return;
            }
            if (item1ListBox.Items.Count != item2ListBox.Items.Count)
            {
                //validation 1 failed, items mismatch
                //Remove extra items and re-validate?
                DialogResult result = MetroMessageBox.Show(this, "The number of items don't match, would you like to remove extra items?",
                    "Remove Extra Items?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    //remove extra results
                    if(item1ListBox.Items.Count > item2ListBox.Items.Count)
                    {
                        for(int i = item1ListBox.Items.Count; i > item2ListBox.Items.Count; i--)
                        {
                            item1ListBox.Items.RemoveAt(i - 1);
                        }
                    } else
                    {
                        for (int i = item2ListBox.Items.Count; i > item1ListBox.Items.Count; i--)
                        {
                            item2ListBox.Items.RemoveAt(i - 1);
                        }
                    }
                    MetroMessageBox.Show(this, "Please double check your entries and press 'Finish' when completed", "Extra Items Deleted",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else
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
        }
    }
}
