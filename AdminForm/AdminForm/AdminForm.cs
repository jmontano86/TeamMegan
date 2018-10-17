using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using MetroFramework.Forms;

namespace AdminForm
{
    public partial class AdminForm : MetroForm
    {
        string strCurrentTest;
        public AdminForm()
        {
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }

        //Works
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
                strCurrentTest = strInputOne;
                testNameLabel.Text = "You are now editing the " + strCurrentTest + " test";
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
            strCurrentTest = "";
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

        //When the combobox's selected index is changed, 
        private void editTestComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            strCurrentTest = editTestComboBox.SelectedItem.ToString();
            testNameLabel.Text = "You are now editing the " + strCurrentTest + " test";
        }

        private void finishButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You better have filled this out correctly, fucker");
        }
    }
}
