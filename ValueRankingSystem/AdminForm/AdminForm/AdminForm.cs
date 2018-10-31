using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using MetroFramework.Forms;
using DataAccessLibrary;

namespace AdminForms
{
    public partial class AdminForm : MetroForm
    {
        Test currentTest;
        public AdminForm()
        {
            InitializeComponent();
        }
        //Gets tests that do not exist in the testsessions table
        //and puts them in the editTestCombobox
        private void AdminForm_Load(object sender, EventArgs e)
        {
            List<Test> testList = new List<Test>();
            if (TestList.getTests(testList))
            {
                foreach(Test test in testList)
                {
                    editTestComboBox.Items.Add(test.TestName);
                }
            }
        }
        //Gets the test name and number of items from the user
        //and sets up the new test based on input
        private void addTestButton_Click(object sender, EventArgs e)
        {
            String strInputOne = Interaction.InputBox("Please enter a test name", "Add a test");
            String strInputTwo = Interaction.InputBox("Please enter the number of items you wish to add", "Add items");
            int intInputTwo = 0;
            try
            {
                Int32.TryParse(strInputTwo, out intInputTwo);
            }
            catch
            {
                MessageBox.Show("Please enter a whole number");
            }

            if (intInputTwo < 2)
            {
                MessageBox.Show("Please enter a number greater than 1");
            }
            else
            {
                itemsDataGrid.Rows.Clear();
                itemsDataGrid.Rows.Add();
                currentTest = new Test();
                currentTest.TestName = strInputOne;
                for (int i = 0; i < intInputTwo; i++)
                {
                    DataGridViewRow row = (DataGridViewRow)itemsDataGrid.Rows[i].Clone();
                    row.Cells[0].Value = (i + 1).ToString();
                    row.Cells[1].Value = null;
                    itemsDataGrid.Rows.Add(row);
                }
                cancelButton.Enabled = true;
                addItemButton.Enabled = true;
                deleteItemButton.Enabled = true;
                testNameLabel.Text = "You are now editing the " + currentTest.TestName + " test";
                testNameLabel.Visible = true;
                deleteTestButton.Enabled = false;
                itemsDataGrid.Rows.RemoveAt(0);
            }
            
        }

        //Deletes the selected item and fixes the indexing of the items after the deleted item
        //Checks the cells for 2+ filled out items
        private void deleteItemButton_Click(object sender, EventArgs e)
        {
            if (itemsDataGrid.RowCount > 0)
            {
                foreach (DataGridViewRow row in itemsDataGrid.Rows)
                {
                    if (row.Index > itemsDataGrid.CurrentRow.Index)
                    {
                        int intCurrentCell;
                        Int32.TryParse(row.Cells[0].Value.ToString(), out intCurrentCell);
                        row.Cells[0].Value = (intCurrentCell - 1).ToString();
                    }
                }
                itemsDataGrid.Rows.RemoveAt(itemsDataGrid.CurrentCell.RowIndex);
                checkCells();
                deleteItemButton.Enabled = true;
            }
            else
            {
                deleteItemButton.Enabled = false;
            }
        }

        //Adds a row to the data grid
        private void addItemButton_Click(object sender, EventArgs e)
        {
            int intIndex = itemsDataGrid.Rows.Add();
            itemsDataGrid.Rows[intIndex].Cells[0].Value = (intIndex + 1).ToString();
            itemsDataGrid.Rows[intIndex].Cells[1].Value = null;
            deleteItemButton.Enabled = true;
        }

        //Clears the rows on the data grid and disables all applicable buttons
        private void cancelButton_Click(object sender, EventArgs e)
        {
            itemsDataGrid.Rows.Clear();
            cancelButton.Enabled = false;
            finishButton.Enabled = false;
            addItemButton.Enabled = false;
            deleteItemButton.Enabled = false;
            testNameLabel.Visible = false;
            deleteTestButton.Enabled = false;
        }

        //When the cell being edited is finished editing, call the checkCells method
        private void itemsDataGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            checkCells();
        }

        //Checks the cells to see how many are filled out.
        //If there are 2+ filled out, then the finish button is enabled
        //If 1 or fewer are filled out, then the finish button is disabled
        private void checkCells()
        {
            int intFilledOutCells = 0;
            foreach (DataGridViewRow row in itemsDataGrid.Rows)
            {
                if (row.Cells[1].Value != null)
                {
                    intFilledOutCells++;
                }
            }
            if (intFilledOutCells > 1)
            {
                finishButton.Enabled = true;
            }
            else
            {
                finishButton.Enabled = false;
            }
        }
        //Adds test to tests table and items to items table
        private void finishButton_Click(object sender, EventArgs e)
        {
            List<string> itemNames = new List<string>();
            //Get the items from the data grid and add them to the list
            foreach(DataGridViewRow row in itemsDataGrid.Rows)
            {
                if(row.Cells[1].Value != null)
                {
                    itemNames.Add(row.Cells[1].Value.ToString());
                }
            }
            //Add the test and the items to the database
            if (TestList.addTest(currentTest))
            {
                if (ItemList.addItems(itemNames, currentTest.TestID))
                {
                    MessageBox.Show(currentTest.TestName + " has been added");
                    finishButton.Enabled = true;
                }
            }
        }
        //Deletes the current test
        private void deleteTestButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the " + currentTest.TestName +
                " test?", "Delete test?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ItemList.deleteItems(currentTest.TestID);
                TestList.deleteTest(currentTest.TestID);
                editTestComboBox.Items.Remove(editTestComboBox.SelectedItem);
            }
        }
        //When the edit test combobox selection changes, get the test ID and the items for that test
        private void editTestComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Test test = new Test();
            test.TestName = editTestComboBox.SelectedItem.ToString();
            if (TestList.getTestID(test))
            {
                List<Item> listItemsList = new List<Item>();
                if (ItemList.getItems(listItemsList, test.TestID))
                {
                    itemsDataGrid.Rows.Clear();
                    itemsDataGrid.Rows.Add();
                    foreach (Item item in listItemsList)
                    {
                        DataGridViewRow row = (DataGridViewRow)itemsDataGrid.Rows[0].Clone();
                        row.Cells[0].Value = item.ItemID.ToString();
                        row.Cells[1].Value = item.Name;
                        itemsDataGrid.Rows.Add(row);
                    }
                    itemsDataGrid.Rows.RemoveAt(0);
                    currentTest = test;
                    testNameLabel.Text = "You are now editing the " + currentTest.TestName + " test";
                    testNameLabel.Visible = true;
                    cancelButton.Enabled = true;
                    addItemButton.Enabled = true;
                    deleteItemButton.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Could not find test '" + editTestComboBox.SelectedValue.ToString() + " test'");
            }
        }
    }
}
