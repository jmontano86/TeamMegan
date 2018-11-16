﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MetroFramework.Forms;
using BusinessData;

namespace Gui
{
    public partial class UserTest : MetroForm
    {
        public UserTest()
        {
            InitializeComponent();
        }
        private UserClass _currentUser;

        public UserClass currentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }
        private int _testID;
        public int currentTestID
        {
            get { return _testID; }
            set { _testID = value; }
        }
        List<ItemPair> itemPairList = new List<ItemPair>();
        //List<Test> testItems = new List<Test>();
        List<Item> itemList = new List<Item>();
        List<Result> allCurrentResults = new List<Result>();
        ItemPair itemPair = new ItemPair();
        int itemPairListIndex = 0;
        bool testDone = false;

        TestSession currentTestSession = new TestSession();
        private void Form1_Load(object sender, EventArgs e)
        {
            testButton.Enabled = false;
            //Load itemPairs that was selected in test selection form
            BusinessData.UserTestLogic.getItemPair(currentTestID, itemPairList);
            
            // Get Item Pairs and populate groupbox
            populateGroupBox(itemPairList, itemPairListIndex);
        }

        // Changes the radio buttons based content in array
        public void populateRadio(ItemPair itemPair)
        {
            userChoiceOne.Text = itemPair.Item1.Name;
            userChoiceTwo.Text = itemPair.Item2.Name;
            userChoiceThree.Text = "Undecided";
        }
        // Gets the next index in the itemPairList
        private void populateGroupBox(List<ItemPair> listItemPairList, int itemPairListIndex)
        {
            if (itemPairListIndex > listItemPairList.Count-1)
            {
                testDone = true;
                // write to test session table
                List<TestSession> testSessionList = new List<TestSession>();
                currentTestSession.intUserID = currentUser.intUserID;
                currentTestSession.intTestID = 1; // Need to change this for sprint 2
                currentTestSession.datetimeCreationDate = DateTime.Now;
                TestSession.CreateSession(currentTestSession);

                int sessionID = currentTestSession.intSessionID;


                foreach (var currentSesResult in allCurrentResults)
                {
                    currentSesResult.intSessionID = sessionID;
                    Result.CreateSession(currentSesResult);
                }
                userChoiceOne.Visible = false;
                userChoiceTwo.Visible = false;
                userChoiceThree.Visible = false;
                finishedLabel.Visible = true;
                testButton.Visible = false;
            }
            else
            {
                // Populate groupbox radio buttons with itempair by index
                ItemPair newItemPair = new ItemPair();
                newItemPair = itemPairList[itemPairListIndex];
                populateRadio(newItemPair);
                userChoiceOne.Checked = false;
                userChoiceTwo.Checked = false;
                userChoiceThree.Checked = false;
            }
        }
 
        private void testButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Change button to finish if all itemPairs that have been accounted for
                if (testDone == false)
                {
                    if (userChoiceOne.Checked)
                    {
                        //Stores user choice in currentResult
                        Result currentResult = new Result();
                        
                        currentResult.intItemID1 = itemPairList[itemPairListIndex].Item1.ItemID;
                        currentResult.intItemID2 = itemPairList[itemPairListIndex].Item2.ItemID;
                        currentResult.intUserChoice = currentResult.intItemID1;

                        //Stores currentResult into an array of results
                        allCurrentResults.Add(currentResult);
                        itemPairListIndex++;
                        populateGroupBox(itemPairList ,itemPairListIndex);

                    }
                    else if (userChoiceTwo.Checked)
                    {
                        Result currentResult = new Result();

                        currentResult.intItemID1 = itemPairList[itemPairListIndex].Item1.ItemID;
                        currentResult.intItemID2 = itemPairList[itemPairListIndex].Item2.ItemID;
                        currentResult.intUserChoice = currentResult.intItemID2;

                        //Stores currentResults into an array of results
                        allCurrentResults.Add(currentResult);
                        itemPairListIndex++;
                        populateGroupBox(itemPairList, itemPairListIndex);
                        
                    }
                    else if (userChoiceThree.Checked)
                    {
                        Result currentResult = new Result();

                        currentResult.intItemID1 = itemPairList[itemPairListIndex].Item1.ItemID;
                        currentResult.intItemID2 = itemPairList[itemPairListIndex].Item2.ItemID;
                        currentResult.intUserChoice = 0;

                        //Stores currentResults into an array of results
                        allCurrentResults.Add(currentResult);
                        itemPairListIndex++;
                        populateGroupBox(itemPairList, itemPairListIndex);
                        
                    }
                    else
                    {
                        MessageBox.Show("Please make a choice");
                    }
                }
                
            }
            catch
            {
                MessageBox.Show("Something went wrong with gathering item data");
            }
        }

        private void userChoiceOne_CheckedChanged(object sender, EventArgs e)
        {
            testButton.Enabled = true;
        }

        private void userChoiceTwo_CheckedChanged(object sender, EventArgs e)
        {
            testButton.Enabled = true;
        }

        private void userChoiceThree_CheckedChanged(object sender, EventArgs e)
        {
            testButton.Enabled = true;
        }
        public static Result savesResults(Result currentResult, List<ItemPair> itemPairList, int itemPairListIndex)
        {
            return currentResult;
        }
    }
}
