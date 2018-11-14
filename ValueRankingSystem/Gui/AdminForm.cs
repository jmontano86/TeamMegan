using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using MetroFramework.Forms;
using BusinessData;
using System.Drawing;
using System.IO;

namespace Gui
{
    public partial class AdminForm : MetroForm
    {
        Test currentTest;
        List<Item> listItemsList;
        public AdminForm()
        {
            InitializeComponent();
        }
        //Gets tests and puts them in the editTestComboBox
        private void AdminForm_Load(object sender, EventArgs e)
        {
            currentTest = new Test();
            List<Test> testList = new List<Test>();
            string stringErrorString = "";
            if (TestList.getTests(testList, stringErrorString))
            {
                foreach (Test test in testList)
                {
                    editTestComboBox.Items.Add(test.TestName);
                }
            }
            else
            {
                MessageBox.Show(stringErrorString);
            }
            this.Activate();
        }
        //Gets the test name and sets up the new test
        private void addTestButton_Click(object sender, EventArgs e)
        {
            String strInputOne = Interaction.InputBox("Please enter a test name", "Add a test").Trim();
            if (strInputOne != "")
            {
                if (checkTestNames(strInputOne))
                {
                    MessageBox.Show("The " + strInputOne + " test already exists");
                }
                else
                {
                    itemsDataGrid.Rows.Clear();
                    currentTest.TestName = "";
                    currentTest.TestID = 0;
                    currentTest.TestName = strInputOne;
                    currentTest.TestType = "T";
                    cancelButton.Enabled = true;
                    addItemButton.Enabled = true;
                    deleteItemButton.Enabled = true;
                    testNameLabel.Text = "You are now editing the " + currentTest.TestName + " test";
                    testNameLabel.Visible = true;
                    deleteTestButton.Enabled = false;
                    itemsDataGrid.ReadOnly = false;
                    testTypeComboBox.Enabled = true;
                    imagePictureBox.Image = null;
                    imagePictureBox.Enabled = false;
                    imagePictureBox.Visible = false;
                    testTypeComboBox.Text = "Text";
                    itemsDataGrid.Focus();
                }
            }
        }
        //Check the test name provided to see if it already exists
        private bool checkTestNames(string strTestName)
        {
            List<string> listTestNameList = new List<string>();
            bool sameName = false;
            string stringErrorString = "";
            if (TestList.getTestNames(listTestNameList, stringErrorString))
            {
                foreach (string name in listTestNameList)
                {
                    if (strTestName.ToUpper() == name.ToUpper())
                    {
                        sameName = true;
                    }
                }
            }
            return sameName;
        }
        //Deletes the selected item
        private void deleteItemButton_Click(object sender, EventArgs e)
        {
            itemsDataGrid.Rows.RemoveAt(itemsDataGrid.CurrentCell.RowIndex);
            deleteItemButton.Enabled = true;
            if (itemsDataGrid.RowCount == 0)
            {
                deleteItemButton.Enabled = false;
            }
            itemsDataGrid.Focus();
            if (currentTest.TestType == "I" || currentTest.TestType == "TI")
            {
                imagePictureBox.Image = null;
            }
        }

        //Adds a row to the data grid
        private void addItemButton_Click(object sender, EventArgs e)
        {
            int intIndex = itemsDataGrid.Rows.Add();
            itemsDataGrid.Rows[intIndex].Cells[0].Value = null;
            itemsDataGrid.Focus();
            deleteItemButton.Enabled = true;
        }

        //Resets test if it exists on the database, clears the form if it doesn't
        private void cancelButton_Click(object sender, EventArgs e)
        {
            itemsDataGrid.Rows.Clear();
            if (currentTest.TestID != 0)
            {
                //If test exists, itemList was already populated. Removed extra database call
                foreach (Item item in listItemsList)
                {
                    int intIndex = itemsDataGrid.Rows.Add();
                    itemsDataGrid.Rows[intIndex].Cells[0].Value = item.Name;
                }
            }
            else
            {
                cancelButton.Enabled = false;
                finishButton.Enabled = false;
                addItemButton.Enabled = false;
                deleteItemButton.Enabled = false;
                testNameLabel.Visible = false;
                deleteTestButton.Enabled = false;
                imagePictureBox.Image = null;
                testTypeComboBox.Enabled = false;
                currentTest.TestName = "";
            }
        }

        //When the cell being edited is finished editing:
        private void itemsDataGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //Test all items in the datagrid for duplicate items
            for (int o = 0; o < itemsDataGrid.RowCount; o++)
            {
                for (int i = 0; i < itemsDataGrid.RowCount; i++)
                {
                    if (itemsDataGrid.Rows[i].Cells[0].Value != null
                        && itemsDataGrid.Rows[o].Cells[0].Value != null &&
                        itemsDataGrid.Rows[i].Cells[0].Value.ToString().Trim().ToUpper() ==
                        itemsDataGrid.Rows[o].Cells[0].Value.ToString().Trim().ToUpper() && i != o)
                    {
                        MessageBox.Show(itemsDataGrid.Rows[i].Cells[0].Value + " is a duplicate.");
                        itemsDataGrid.Rows.RemoveAt(i);
                    }
                }
            }
            //Add a new row if you're at the bottom row
            if (itemsDataGrid.CurrentRow.Index == itemsDataGrid.Rows.Count)
            {
                int intCurrentCell = itemsDataGrid.Rows.Add();
                itemsDataGrid.Rows[intCurrentCell].Cells[0].Selected = true;
            }
            //Trim the current cell's content
            if (itemsDataGrid.CurrentCell.Value != null)
            {
                itemsDataGrid.CurrentCell.Value = itemsDataGrid.CurrentCell.Value.ToString().Trim();
            }
            //Enable or disable the finish button based on the number of filled out cells
            if (checkCells())
            {
                finishButton.Enabled = true;
            }
            else
            {
                finishButton.Enabled = false;
            }
        }

        //Checks the cells to see how many are filled out.
        private bool checkCells()
        {
            int intFilledOutCells = 0;
            foreach (DataGridViewRow row in itemsDataGrid.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    intFilledOutCells++;
                }
            }
            if (intFilledOutCells > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Adds test to tests table and items to items table
        private void finishButton_Click(object sender, EventArgs e)
        {
            string stringErrorString = "";
            bool isExistingTest = false;
            //If a test with the same name exists, delete it and its items
            if (checkTestNames(currentTest.TestName))
            {
                ItemList.deleteItems(currentTest.TestID, stringErrorString);
                TestList.deleteTest(currentTest.TestID, stringErrorString);
                isExistingTest = true;
            }
            //Delete null cells
            for (int i = itemsDataGrid.Rows.Count - 1; i > 1; i--)
            {
                if (itemsDataGrid.Rows[i].Cells[0].Value == null)
                {
                    itemsDataGrid.Rows.RemoveAt(i);
                }
            }
            if (checkCells())
            {
                List<string> listItemNames = new List<string>();
                //Get the items from the itemsDataGrid and add them to the list
                //TODO: ADD IMAGES TO A LIST IF TESTTYPECOMBOBOX INDEX == 2 OR 3
                foreach (DataGridViewRow row in itemsDataGrid.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        listItemNames.Add(row.Cells[0].Value.ToString());
                    }
                }
                //Add the test and the items to the database
                //TODO: ADD TEST TYPE
                if (TestList.addTest(currentTest, stringErrorString))
                {
                    if (ItemList.addItems(listItemNames, currentTest.TestID, stringErrorString))
                    {
                        if (isExistingTest)
                        {
                            MessageBox.Show("The " + currentTest.TestName + " test has been overwritten");
                        }
                        else
                        {
                            MessageBox.Show("The " + currentTest.TestName + " test has been added");
                            customButton.Enabled = true;
                        }
                        deleteTestButton.Enabled = true;
                        if (!editTestComboBox.Items.Contains(currentTest.TestName))
                        {
                            editTestComboBox.Items.Add(currentTest.TestName);
                        }
                    }
                    else
                    {
                        MessageBox.Show(stringErrorString);
                    }
                }
                else
                {
                    MessageBox.Show(stringErrorString);
                }
            }
            else
            {
                MessageBox.Show("Duplicate items were removed.  There are now less than 2 items for this test.  Please add more items");
            }
        }
        //Deletes the current test
        private void deleteTestButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the " + currentTest.TestName +
                " test?", "Delete test?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string stringErrorString = "";
                if (ItemList.deleteItems(currentTest.TestID, stringErrorString))
                {
                    if (TestList.deleteTest(currentTest.TestID, stringErrorString))
                    {
                        MessageBox.Show("The " + currentTest.TestName + " test has been deleted");
                        editTestComboBox.Items.Remove(currentTest.TestName);
                        currentTest.TestID = 0;
                        currentTest.TestName = "";
                        cancelButton.PerformClick();
                    }
                    else
                    {
                        MessageBox.Show(stringErrorString);
                    }
                }
                else
                {
                    MessageBox.Show(stringErrorString);
                }
            }
        }
        //When the edit test combobox selection changes, get the test ID and the items for that test
        private void editTestComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Test test = new Test();
            test.TestName = editTestComboBox.SelectedItem.ToString();
            string stringErrorString = "";
            //Get the ID for the selected test and get the items from that test and put them in the itemsDataGrid
            if (TestList.getTestID(test, stringErrorString))
            {
                //Updated items LIst to a class variable so it only needs to get loaded once, when the test is loaded. 
                listItemsList = new List<Item>();
                if (ItemList.getItems(listItemsList, test.TestID, stringErrorString))
                {
                    itemsDataGrid.Rows.Clear();
                    foreach (Item item in listItemsList)
                    {
                        int intIndex = itemsDataGrid.Rows.Add();
                        itemsDataGrid.Rows[intIndex].Cells[0].Value = item.Name;
                    }
                    //Get the test type and set the testTypeComboBox accordingly
                    /*if (TestList.getTestType(test, stringErrorString))
                    {
                        if(test.TestType == "T")
                        {
                            testTypeComboBox.SelectedIndex = 0;
                        }
                        else if(test.TestType == "I")
                        {
                            testTypeComboBox.SelectedIndex = 1;
                        }
                        else if(test.TestType == "TI")
                        {
                            testTypeComboBox.SelectedIndex = 2;
                        }
                        else
                        {
                            MessageBox.Show("Test type is not valid");
                        }
                    }
                    else
                    {
                        MessageBox.Show(stringErrorString);
                    }*/
                    currentTest = test;

                    //Check if selected test is in testsessions and set controls accordingly
                    List<int> listTestSessionIDs = new List<int>();
                    bool isTestSessionID = false;
                    if (TestList.getTestSessions(listTestSessionIDs, stringErrorString))
                    {
                        foreach (int intTestID in listTestSessionIDs)
                        {
                            if (test.TestID == intTestID)
                            {
                                isTestSessionID = true;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(stringErrorString);
                        cancelButton.PerformClick();
                    }
                    if (isTestSessionID)
                    {
                        testNameLabel.Text = "You are now viewing the " + currentTest.TestName + " test";
                        testNameLabel.Visible = true;
                        cancelButton.Enabled = true;
                        addItemButton.Enabled = false;
                        deleteItemButton.Enabled = false;
                        deleteTestButton.Enabled = false;
                        finishButton.Enabled = false;
                        customButton.Enabled = true;
                        itemsDataGrid.ReadOnly = true;
                        testTypeComboBox.Enabled = false;
                    }
                    else
                    {
                        testNameLabel.Text = "You are now editing the " + currentTest.TestName + " test";
                        testNameLabel.Visible = true;
                        cancelButton.Enabled = true;
                        addItemButton.Enabled = true;
                        deleteItemButton.Enabled = true;
                        deleteTestButton.Enabled = true;
                        finishButton.Enabled = true;
                        customButton.Enabled = true;
                        itemsDataGrid.ReadOnly = true;
                        testTypeComboBox.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("Error finding items for the " + test.TestName + " test.");
                }
            }
            else
            {
                MessageBox.Show("Could not find the '" + editTestComboBox.SelectedValue.ToString() + " test'");
            }
        }
        private void customButton_Click(object sender, EventArgs e)
        {
            //Programmer: Jeremiah Montano
            //Date: November 11, 2018
            //Summary: Allows the administrator define a custom comparison test
            CustomTestForm customForm = new CustomTestForm();
            customForm.currentTest = currentTest;
            customForm.itemList = listItemsList;
            customForm.ShowDialog();
        }
        private void AdminForm_DragEnter(object sender, DragEventArgs e)
        {
            int x = this.PointToClient(new Point(e.X, e.Y)).X;
            int y = this.PointToClient(new Point(e.X, e.Y)).Y;
            if (currentTest.TestName == "" || itemsDataGrid.RowCount == 0 || currentTest.TestType == "T")
            {
                e.Effect = DragDropEffects.None;
            }
            else
            {
                string[] file = (string[])e.Data.GetData(DataFormats.FileDrop);
                //MessageBox.Show(Path.GetExtension(file[0]));
                if (Path.GetExtension(file[0]) == ".url")
                {
                    e.Effect = DragDropEffects.Link;
                }
                else if (Path.GetExtension(file[0]) == ".png" || Path.GetExtension(file[0]) == ".jpg" || Path.GetExtension(file[0]) == ".bmp" ||
                    Path.GetExtension(file[0]) == ".jpeg")
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
        }

        private void AdminForm_DragDrop(object sender, DragEventArgs e)
        {
            int x = this.PointToClient(new Point(e.X, e.Y)).X;
            int y = this.PointToClient(new Point(e.X, e.Y)).Y;
            if (x >= imagePictureBox.Location.X && x <= imagePictureBox.Location.X + imagePictureBox.Width &&
                y >= imagePictureBox.Location.Y && y <= imagePictureBox.Location.Y + imagePictureBox.Height)
            {
                string[] file = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (Path.GetExtension(file[0]) == ".url")
                {
                    imagePictureBox.Load(file[0]);
                }
                else if (Path.GetExtension(file[0]) == ".png" || Path.GetExtension(file[0]) == ".jpg" || Path.GetExtension(file[0]) == ".bmp" ||
                    Path.GetExtension(file[0]) == ".jpeg")
                {
                    imagePictureBox.Image = Image.FromFile(file[0]);
                }
                itemsDataGrid.Rows[itemsDataGrid.CurrentRow.Index].Cells[1].Value = Path.GetFullPath(file[0]);
            }
        }

        private void imagePictureBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap) && testTypeComboBox.SelectedIndex == 1 || testTypeComboBox.SelectedIndex == 2)
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void testTypeComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (testTypeComboBox.SelectedIndex == 0)
            {
                currentTest.TestType = "T";
                imagePictureBox.Hide();
                imagePictureBox.Enabled = false;
                imagePictureBox.Visible = false;
            }
            else if (testTypeComboBox.SelectedIndex == 1)
            {
                currentTest.TestType = "I";
                imagePictureBox.Show();
                imagePictureBox.Enabled = true;
                imagePictureBox.Visible = true;
            }
            else if (testTypeComboBox.SelectedIndex == 2)
            {
                currentTest.TestType = "TI";
                imagePictureBox.Show();
                imagePictureBox.Enabled = true;
                imagePictureBox.Visible = true;
            }
        }
    }
}
