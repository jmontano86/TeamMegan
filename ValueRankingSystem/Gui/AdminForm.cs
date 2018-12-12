using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using MetroFramework.Forms;
using BusinessData;
using System.Drawing;
using System.IO;
using System.Net;

namespace Gui
{
    public partial class AdminForm : MetroForm
    {
        private Test currentTest;
        private List<Control> imageBoxLabels;
        private List<Item> listItemsList;

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
            if (TestList.getTests(testList, ref stringErrorString))
            {
                foreach (Test test in testList)
                {
                    editTestComboBox.Items.Add(test);
                }
            }
            else
            {
                MessageBox.Show(stringErrorString);
            }
            this.Activate();

            imageBoxLabels = new List<Control>();
            itemsDataGrid.Columns[1].ReadOnly = true;
            imageBoxLabels.Add(heightLabel);
            imageBoxLabels.Add(heightTextLabel);
            imageBoxLabels.Add(widthLabel);
            imageBoxLabels.Add(widthTextLabel);
            imageBoxLabels.Add(sizeLabel);
            imageBoxLabels.Add(sizeTextLabel);
            setImageBoxLabelVisibility(false);
            customTestButton.Enabled = false;
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
                    itemsDataGrid.Columns[1].ValueType = typeof(TextBox);
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
                    itemsDataGrid.Columns[0].Visible = true;
                    itemsDataGrid.Columns[1].Visible = false;
                    setImageBoxLabelVisibility(false);
                    addItemButton.PerformClick();
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
            if (TestList.getTestNames(listTestNameList, ref stringErrorString))
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
        private void setImageBoxLabelVisibility(bool visibility)
        {
            foreach (Control control in imageBoxLabels)
            {
                control.Visible = visibility;
            }
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
            itemsDataGrid_SelectionChanged(this, new EventArgs());
            if (currentTest.TestType != "T")
            {
                imagePictureBox.Image = null;
            }
            itemsDataGrid_SelectionChanged(this, new EventArgs());
        }

        //Adds a row to the data grid
        private void addItemButton_Click(object sender, EventArgs e)
        {
            int intIndex = itemsDataGrid.Rows.Add();
            itemsDataGrid.Rows[intIndex].Cells[0].Value = null;
            if(currentTest.TestType != "T")
            {
                itemsDataGrid.Rows[intIndex].Height = 75;
            }
            else
            {
                itemsDataGrid.Rows[intIndex].Height = 21;
            }
            itemsDataGrid.Focus();
            itemsDataGrid_SelectionChanged(this, new EventArgs());
            deleteItemButton.Enabled = true;
        }

        //Resets test if it exists on the database, clears the form if it doesn't
        private void cancelButton_Click(object sender, EventArgs e)
        {
            string stringErrorString = "";
            if (currentTest.TestID != 0)
            {
                listItemsList = new List<Item>();
                if (ItemList.getItems(listItemsList, currentTest.TestID, ref stringErrorString))
                {
                    itemsDataGrid.Rows.Clear();
                    foreach (Item item in listItemsList)
                    {
                        int intIndex = itemsDataGrid.Rows.Add();
                        if (currentTest.TestType == "T")
                        {
                            itemsDataGrid.Rows[intIndex].Cells[0].Value = item.Name;
                        }
                        else if (currentTest.TestType == "I")
                        {
                            itemsDataGrid.Rows[intIndex].Cells[1].Value = item.getImage();
                        }
                        else if (currentTest.TestType == "TI")
                        {
                            itemsDataGrid.Rows[intIndex].Cells[0].Value = item.Name;
                            itemsDataGrid.Rows[intIndex].Cells[1].Value = item.getImage();
                        }
                    }
                    testTypeComboBox_SelectionChangeCommitted(this, new EventArgs());
                    finishButton.Enabled = false;
                }
            }
            else
            {
                itemsDataGrid.Rows.Clear();
                cancelButton.Enabled = false;
                finishButton.Enabled = false;
                addItemButton.Enabled = false;
                deleteItemButton.Enabled = false;
                testNameLabel.Visible = false;
                customTestButton.Enabled = false;
                deleteTestButton.Enabled = false;
                imagePictureBox.Image = null;
                testTypeComboBox.Enabled = false;
                currentTest.TestName = "";
                currentTest.TestID = 0;
                setImageBoxLabelVisibility(false);
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
                        itemsDataGrid.Rows[i].Cells[0].Value.ToString().ToUpper() ==
                        itemsDataGrid.Rows[o].Cells[0].Value.ToString().ToUpper() && i != o)
                    {
                        MessageBox.Show(itemsDataGrid.Rows[i].Cells[0].Value + " is a duplicate.");
                        itemsDataGrid.Rows[i].Cells[0].Value = null;
                    }
                }
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
            checkCellsForCompletion();
        }

        private void checkCellsForCompletion()
        {
            //Add a new row if all cells are filled out
            bool allCellsFilledOut = true;
            foreach (DataGridViewRow row in itemsDataGrid.Rows)
            {
                if (currentTest.TestType == "T")
                {
                    if (row.Cells[0].Value == null || row.Cells[0].Value == "")
                    {
                        allCellsFilledOut = false;
                    }
                }
                else if (currentTest.TestType == "I")
                {
                    if (row.Cells[1].Value == null)
                    {
                        allCellsFilledOut = false;
                    }
                }
                else if (currentTest.TestType == "TI")
                {
                    if (row.Cells[0].Value == null || row.Cells[0].Value == "" || row.Cells[1].Value == null)
                    {
                        allCellsFilledOut = false;
                    }
                }
            }
            if (allCellsFilledOut)
            {
                itemsDataGrid.Rows.Add();
                if (currentTest.TestType == "T")
                {
                    itemsDataGrid.Rows[itemsDataGrid.Rows.Count - 1].Cells[0].Selected = true;
                    itemsDataGrid.Rows[itemsDataGrid.Rows.Count - 1].Height = 21;
                }
                else if (currentTest.TestType == "I")
                {
                    itemsDataGrid.Rows[itemsDataGrid.Rows.Count - 1].Cells[1].Selected = true;
                    itemsDataGrid.Rows[itemsDataGrid.Rows.Count - 1].Height = 75;
                }
                else if (currentTest.TestType == "TI")
                {
                    itemsDataGrid.Rows[itemsDataGrid.Rows.Count - 1].Cells[0].Selected = true;
                    itemsDataGrid.Rows[itemsDataGrid.Rows.Count - 1].Height = 75;
                }
            }
        }
        
        private bool checkCells()
        {
            //Checks the cells to see how many are filled out, based on the test type.
            int intFilledOutCells = 0;
            foreach (DataGridViewRow row in itemsDataGrid.Rows)
            {
                if (currentTest.TestType == "T")
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value != "")
                    {
                        intFilledOutCells++;
                    }
                }
                else if (currentTest.TestType == "I")
                {
                    if (row.Cells[1].Value != null)
                    {
                        intFilledOutCells++;
                    }
                }
                else if (currentTest.TestType == "TI")
                {
                    if (row.Cells[0].Value != null && row.Cells[1].Value != null && row.Cells[0].Value != "")
                    {
                        intFilledOutCells++;
                    }
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
            //Delete null cells
            for (int i = itemsDataGrid.Rows.Count - 1; i > 1; i--)
            {
                if (currentTest.TestType == "T" && itemsDataGrid.Rows[i].Cells[0].Value == null || itemsDataGrid.Rows[i].Cells[0].Value == "")
                {
                    itemsDataGrid.Rows.RemoveAt(i);
                }
                else if (currentTest.TestType == "I" && itemsDataGrid.Rows[i].Cells[1].Value == null)
                {
                    itemsDataGrid.Rows.RemoveAt(i);
                }
                else if (currentTest.TestType == "TI" && itemsDataGrid.Rows[i].Cells[0].Value == null && itemsDataGrid.Rows[i].Cells[1].Value == null ||
                    itemsDataGrid.Rows[i].Cells[0].Value == "")
                {
                    itemsDataGrid.Rows.RemoveAt(i);
                }
            }
            //If the test type is TI, check to see if all rows are completely filled out
            //and warn the user if they aren't
            bool isIncomplete = false;
            if (currentTest.TestType == "TI")
            {
                foreach (DataGridViewRow row in itemsDataGrid.Rows)
                {
                    if (row.Cells[0].Value == null || row.Cells[1].Value == null)
                    {
                        isIncomplete = true;
                    }
                }
            }
            if (isIncomplete)
            {
                MessageBox.Show("There are items with only an image or text.  Please fill out all items completely.");
            }
            else
            {
                if (checkCells())
                {
                    List<Item> listItems = new List<Item>();
                    //Get the items from the itemsDataGrid and add them to the list
                    int i = 0;
                    foreach (DataGridViewRow row in itemsDataGrid.Rows)
                    {
                        if (currentTest.TestType == "T")
                        {
                            Item item = new Item();
                            item.Name = row.Cells[0].Value.ToString();
                            listItems.Add(item);
                        }
                        if (currentTest.TestType == "I")
                        {
                            Item item = new Item();
                            using (MemoryStream ms = new MemoryStream())
                            {
                                ((Image)itemsDataGrid.Rows[i].Cells[1].Value).Save(ms, ((Image)itemsDataGrid.Rows[i].Cells[1].Value).RawFormat);
                                item.ItemImage = ms.ToArray();
                            }
                            listItems.Add(item);
                        }
                        if (currentTest.TestType == "TI")
                        {
                            Item item = new Item();
                            item.Name = row.Cells[0].Value.ToString();
                            using (MemoryStream ms = new MemoryStream())
                            {
                                ((Image)itemsDataGrid.Rows[i].Cells[1].Value).Save(ms, ((Image)itemsDataGrid.Rows[i].Cells[1].Value).RawFormat);
                                item.ItemImage = ms.ToArray();
                            }
                            listItems.Add(item);
                        }
                        i++;
                    }
                    bool isExistingTest = false;
                    //If a test with the same name exists, delete it and its items
                    if (checkTestNames(currentTest.TestName))
                    {
                        ItemList.deleteItems(currentTest.TestID, ref stringErrorString);
                        TestList.deleteTest(currentTest.TestID, ref stringErrorString);
                        isExistingTest = true;
                    }
                    //Add the test and the items to the database
                    if (TestList.addTest(currentTest, ref stringErrorString))
                    {
                        if (ItemList.addItems(listItems, currentTest, ref stringErrorString))
                        {
                            if (isExistingTest)
                            {
                                MessageBox.Show("The " + currentTest.TestName + " test has been overwritten");
                            }
                            else
                            {
                                MessageBox.Show("The " + currentTest.TestName + " test has been added");
                                listItemsList = new List<Item>();
                                listItemsList = listItems;
                                customTestButton.Enabled = true;
                            }
                            deleteTestButton.Enabled = true;
                            //Add the test to the combobox if it isn't there already
                            bool testInComboBox = false;
                            foreach(object item in editTestComboBox.Items)
                            {
                                if(item.ToString() == currentTest.TestName)
                                {
                                    testInComboBox = true;
                                }
                            }
                            if (!testInComboBox)
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
                    finishButton.Enabled = false;
                }
            }
        }
        //Deletes the current test
        private void deleteTestButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the " + currentTest.TestName +
                " test?", "Delete test?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string stringErrorString = "";
                if (ItemList.deleteItems(currentTest.TestID, ref stringErrorString))
                {
                    if (TestList.deleteTest(currentTest.TestID, ref stringErrorString))
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
            /* Commented out as Test is already an item in the drop down.
             * No need to do another database call. JDM */
            Test test = new Test();
            test.TestName = editTestComboBox.SelectedItem.ToString();
            string stringErrorString = "";
            //Get the ID for the selected test and get the items from that test and put them in the itemsDataGrid
            if (TestList.getTestIDAndType(test, ref stringErrorString))
            {
                if(test.TestID == 0)
                {
                    MessageBox.Show("Test does not exist");
                    editTestComboBox.Items.RemoveAt(editTestComboBox.SelectedIndex);
                }
                else
                {
                    listItemsList = new List<Item>();
                    if (ItemList.getItems(listItemsList, test.TestID, ref stringErrorString))
                    {
                        itemsDataGrid.Rows.Clear();
                        //Add the items from the test to the datagrid
                        foreach (Item item in listItemsList)
                        {
                            int intIndex = itemsDataGrid.Rows.Add();
                            if (test.TestType == "T")
                            {
                                itemsDataGrid.Rows[intIndex].Cells[0].Value = item.Name;
                            }
                            else if (test.TestType == "I")
                            {
                                itemsDataGrid.Rows[intIndex].Cells[1].Value = item.getImage();
                            }
                            else if (test.TestType == "TI")
                            {
                                itemsDataGrid.Rows[intIndex].Cells[0].Value = item.Name;
                                itemsDataGrid.Rows[intIndex].Cells[1].Value = item.getImage();
                            }
                        }
                        //Get the test type and set the testTypeComboBox accordingly
                        if (test.TestType == "T")
                        {
                            testTypeComboBox.SelectedIndex = 0;
                            testTypeComboBox_SelectionChangeCommitted(this, new EventArgs());
                            foreach (DataGridViewRow row in itemsDataGrid.Rows)
                            {
                                row.Height = 21;
                            }
                        }
                        else if (test.TestType == "I")
                        {
                            testTypeComboBox.SelectedIndex = 1;
                            testTypeComboBox_SelectionChangeCommitted(this, new EventArgs());
                            foreach (DataGridViewRow row in itemsDataGrid.Rows)
                            {
                                row.Height = 75;
                            }
                        }
                        else if (test.TestType == "TI")
                        {
                            testTypeComboBox.SelectedIndex = 2;
                            testTypeComboBox_SelectionChangeCommitted(this, new EventArgs());
                            foreach (DataGridViewRow row in itemsDataGrid.Rows)
                            {
                                row.Height = 75;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Test type is not valid");
                        }
                        currentTest = test;

                        //Check if selected test is in testsessions and set controls accordingly
                        List<int> listTestSessionIDs = new List<int>();
                        bool isTestSessionID = false;
                        if (TestList.getTestSessions(listTestSessionIDs, ref stringErrorString))
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
                            customTestButton.Enabled = false;
                            finishButton.Enabled = false;
                            itemsDataGrid.ReadOnly = true;
                            testTypeComboBox.Enabled = false;
                            itemsDataGrid.Focus();
                            itemsDataGrid_SelectionChanged(this, new EventArgs());
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
                            customTestButton.Enabled = true;
                            itemsDataGrid.ReadOnly = false;
                            testTypeComboBox.Enabled = true;
                            checkCellsForCompletion();
                            itemsDataGrid.Focus();
                            itemsDataGrid_SelectionChanged(this, new EventArgs());
                        }
                    }
                    else
                    {
                        MessageBox.Show(stringErrorString);
                    }
                }
            }
            else
            {
                MessageBox.Show(stringErrorString);
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
        //Check the file type of the item being dragged into the form and set the drag drop effect accordingly
        private void AdminForm_DragEnter(object sender, DragEventArgs e)
        {
            if (currentTest.TestName == "" || itemsDataGrid.RowCount == 0 || currentTest.TestType == "T")
            {
                e.Effect = DragDropEffects.None;
            }
            else
            {
                //If the image is a URL:
                try
                {
                    string file = e.Data.GetData(DataFormats.Text) as string;
                    if (file.ToLower().EndsWith(".jpg") || file.ToLower().EndsWith(".png") || file.ToLower().EndsWith(".bmp") || 
                        file.ToLower().EndsWith(".jpeg") || file.ToLower().EndsWith(".webp"))
                    {
                        e.Effect = DragDropEffects.Link;
                    }
                    else
                    {
                        e.Effect = DragDropEffects.None;
                    }
                }
                //If the image is a local file:
                catch
                {
                    string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                    if (Path.GetExtension(files[0]).ToLower() == ".jpg" || Path.GetExtension(files[0]).ToLower() == ".bmp" ||
                    Path.GetExtension(files[0]).ToLower() == ".jpeg" || Path.GetExtension(files[0]).ToLower() == ".png" || 
                    Path.GetExtension(files[0]).ToLower() == ".webp")
                    {
                        e.Effect = DragDropEffects.Copy;
                    }
                    else
                    {
                        e.Effect = DragDropEffects.None;
                    }
                }
                itemsDataGrid.EndEdit();
            }

        }
        //Load the image onto the picturebox if the file is an image and write the path to the second column of the data grid
        private void AdminForm_DragDrop(object sender, DragEventArgs e)
        {
            bool isDuplicate = false;
            bool isWrongSize = false;
            //If the image comes from the computer:
            try
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                Image image = Image.FromFile(files[0]);

                //Check if the image dropped is a duplicate
                foreach (DataGridViewRow row in itemsDataGrid.Rows)
                {
                    if (row.Cells[1].Value != null)
                    {
                        byte[] image1Bytes;
                        byte[] image2Bytes;

                        using (var mstream = new MemoryStream())
                        {
                            image.Save(mstream, image.RawFormat);
                            image1Bytes = mstream.ToArray();
                        }

                        using (var mstream = new MemoryStream())
                        {
                            ((Image)row.Cells[1].Value).Save(mstream, ((Image)row.Cells[1].Value).RawFormat);
                            image2Bytes = mstream.ToArray();
                        }

                        var image164 = Convert.ToBase64String(image1Bytes);
                        var image264 = Convert.ToBase64String(image2Bytes);

                        if (string.Equals(image164, image264))
                        {
                            isDuplicate = true;
                        }
                    }
                }
                //Check if the dropped image is the right dimensions
                if (image.Width > 300 || image.Height > 300)
                {
                    isWrongSize = true;
                }
                if (isDuplicate)
                {
                    MessageBox.Show("This image is already in this test");
                }
                else if (isWrongSize)
                {
                    MessageBox.Show("This image has the wrong dimensions.  Please resize this image to 300x300px or less.");
                }
                else
                {
                    //Set the image on the picturebox
                    imagePictureBox.Image = image;
                    //Set the second datagrid column to the image and set the width and height labels to that of the image
                    itemsDataGrid.Rows[itemsDataGrid.CurrentRow.Index].Cells[1].Value = image;
                    setPictureLabelText();
                    setImageBoxLabelVisibility(true);
                    if (checkCells())
                    {
                        finishButton.Enabled = true;
                    }
                    else
                    {
                        finishButton.Enabled = false;
                    }
                }
            }
            //If the image is a URL:
            catch
            {
                string file = e.Data.GetData(DataFormats.Text) as string;
                WebClient client = new WebClient();
                byte[] data;
                data = client.DownloadData(file);
                MemoryStream stream = new MemoryStream(data);
                Image image = Image.FromStream(stream);
                //Check if the dropped image is a duplicate
                foreach (DataGridViewRow row in itemsDataGrid.Rows)
                {
                    if ((Image)row.Cells[1].Value != null)
                    {
                        byte[] image1Bytes;
                        byte[] image2Bytes;

                        using (var mstream = new MemoryStream())
                        {
                            image.Save(mstream, image.RawFormat);
                            image1Bytes = mstream.ToArray();
                        }

                        using (var mstream = new MemoryStream())
                        {
                            ((Image)row.Cells[1].Value).Save(mstream, ((Image)row.Cells[1].Value).RawFormat);
                            image2Bytes = mstream.ToArray();
                        }

                        var image164 = Convert.ToBase64String(image1Bytes);
                        var image264 = Convert.ToBase64String(image2Bytes);

                        if (string.Equals(image164, image264))
                        {
                            isDuplicate = true;
                        }
                    }
                }
                //Check if the dropped image is the right dimensions
                if (image.Width > 300 || image.Height > 300)
                {
                    isWrongSize = true;
                }
                if (isDuplicate)
                {
                    MessageBox.Show("This image is already in this test");
                }
                else if (isWrongSize)
                {
                    MessageBox.Show("This image has the wrong dimensions.  Please resize this image to 300x300px or less.");
                }
                else
                {
                    //Set the image on the picturebox
                    try
                    {
                        imagePictureBox.Image = image;
                        //Set the second datagrid column to the image and set the width and height labels to that of the image
                        itemsDataGrid.Rows[itemsDataGrid.CurrentRow.Index].Cells[1].Value = image;
                        setPictureLabelText();
                        setImageBoxLabelVisibility(true);
                        if (checkCells())
                        {
                            finishButton.Enabled = true;
                        }
                        else
                        {
                            finishButton.Enabled = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            checkCellsForCompletion();
        }
        //Set the test type and adjust controls based on the test type selected
        private void testTypeComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (testTypeComboBox.SelectedIndex == 0)
            {
                currentTest.TestType = "T";
                imagePictureBox.Hide();
                imagePictureBox.Enabled = false;
                imagePictureBox.Visible = false;
                setImageBoxLabelVisibility(false);
                itemsDataGrid.Columns[0].Visible = true;
                itemsDataGrid.Columns[1].Visible = false;
                foreach (DataGridViewRow row in itemsDataGrid.Rows)
                {
                    row.Height = 21;
                }
            }
            else if (testTypeComboBox.SelectedIndex == 1)
            {
                currentTest.TestType = "I";
                imagePictureBox.Show();
                imagePictureBox.Enabled = true;
                imagePictureBox.Visible = true;
                setImageBoxLabelVisibility(true);
                itemsDataGrid.Columns[0].Visible = false;
                itemsDataGrid.Columns[1].Visible = true;
                foreach (DataGridViewRow row in itemsDataGrid.Rows)
                {
                    row.Height = 75;
                }
            }
            else if (testTypeComboBox.SelectedIndex == 2)
            {
                currentTest.TestType = "TI";
                imagePictureBox.Show();
                imagePictureBox.Enabled = true;
                imagePictureBox.Visible = true;
                setImageBoxLabelVisibility(true);
                itemsDataGrid.Columns[0].Visible = true;
                itemsDataGrid.Columns[1].Visible = true;
                foreach (DataGridViewRow row in itemsDataGrid.Rows)
                {
                    row.Height = 75;
                }
            }
            if (checkCells())
            {
                finishButton.Enabled = true;
            }
            else
            {
                finishButton.Enabled = false;
            }
            itemsDataGrid.Focus();
            itemsDataGrid_SelectionChanged(this, new EventArgs());
        }
        //If an image exists on the row selected, display the image and set the label values
        private void itemsDataGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (itemsDataGrid.RowCount > 0 && itemsDataGrid.Rows[itemsDataGrid.CurrentCell.RowIndex].Cells[1].Value != null && currentTest.TestType != "T")
            {
                imagePictureBox.Image = (Image)itemsDataGrid.Rows[itemsDataGrid.CurrentCell.RowIndex].Cells[1].Value;
                setPictureLabelText();
                setImageBoxLabelVisibility(true);
            }
            else if (itemsDataGrid.RowCount > 0 && itemsDataGrid.Rows[itemsDataGrid.CurrentCell.RowIndex].Cells[1].Value == null)
            {
                imagePictureBox.Image = null;
                setImageBoxLabelVisibility(false);
            }
        }
        //Set the values of the labels below the picturebox based on the image on the picturebox
        private void setPictureLabelText()
        {
            widthLabel.Text = imagePictureBox.Image.Width.ToString() + "px";
            heightLabel.Text = imagePictureBox.Image.Height.ToString() + "px";
            long size;
            using (MemoryStream ms = new MemoryStream())
            {
                ((Image)itemsDataGrid.Rows[itemsDataGrid.CurrentCell.RowIndex].Cells[1].Value).Save(ms,
                    ((Image)itemsDataGrid.Rows[itemsDataGrid.CurrentCell.RowIndex].Cells[1].Value).RawFormat);
                size = ms.Length;
            }
            if (size > 1000000)
            {
                sizeLabel.Text = ((float)size / 1048576).ToString("n2") + "MB";
            }
            else if (size > 1000)
            {
                sizeLabel.Text = ((float)size / 1024).ToString("n2") + "KB";
            }
        }

        private void editTestComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}