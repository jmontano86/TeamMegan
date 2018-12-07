using System;
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
        List<Item> itemToAssign = new List<Item>();
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

            // Load denominator for Progress Bar
            denominatorChange(itemPairList.Count);

        }

        // Changes the radio buttons based content in array
        public List<Item> populateRadio(ItemPair itemPair)
        {
            // Randomizes where the item pairs are assigned to the userChoice Radio boxes: Kevin Khlom Sprint 2
            List<Item> itemToAssign = new List<Item>();
            // Function that randomizes the pairings
            UserTestLogic.itemToAssign(itemPair, itemToAssign);
            userChoiceOne.Text = itemToAssign[0].Name;
            userChoiceTwo.Text = itemToAssign[1].Name;
            userChoiceThree.Text = itemToAssign[2].Name;

            return itemToAssign;
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
                currentTestSession.intTestID = currentTestID; // Need to change this for sprint 2
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
                itemToAssign = populateRadio(newItemPair);
                userChoiceOne.Checked = false;
                userChoiceTwo.Checked = false;
                userChoiceThree.Checked = false;
                // Load numerator for progress bar
                numeratorChange(itemPairList.Count, itemPairListIndex);
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
                        // write to current Result of intItemID1 if it is not undecided
                        
                        for (int i = 0; i < itemToAssign.Count; i++)
                        {
                            if (itemToAssign[i].ItemID != 0 && currentResult.intItemID1 == 0)
                            {
                                currentResult.intItemID1 = itemToAssign[i].ItemID;
                                //itemToAssign.RemoveAt(i);
                            }
                            else if (itemToAssign[i].ItemID != 0 && currentResult.intItemID2 == 0)
                            {
                                currentResult.intItemID2 = itemToAssign[i].ItemID;
                                //itemToAssign.RemoveAt(i);
                            }
                        }
                        currentResult.intUserChoice = itemToAssign[0].ItemID;
                        //Stores currentResult into an array of results
                        allCurrentResults.Add(currentResult);
                        itemPairListIndex++;
                        populateGroupBox(itemPairList ,itemPairListIndex);

                    }
                    else if (userChoiceTwo.Checked)
                    {
                        Result currentResult = new Result();

                        for (int i = 0; i < itemToAssign.Count; i++)
                        {
                            if (itemToAssign[i].ItemID != 0 && currentResult.intItemID1 == 0)
                            {
                                currentResult.intItemID1 = itemToAssign[i].ItemID;
                                //itemToAssign.RemoveAt(i);
                            }
                            else if (itemToAssign[i].ItemID != 0 && currentResult.intItemID2 == 0)
                            {
                                currentResult.intItemID2 = itemToAssign[i].ItemID;
                                //itemToAssign.RemoveAt(i);
                            }
                        }

                        currentResult.intUserChoice = itemToAssign[1].ItemID;

                        //Stores currentResults into an array of results
                        allCurrentResults.Add(currentResult);
                        itemPairListIndex++;
                        populateGroupBox(itemPairList, itemPairListIndex);
                        
                    }
                    else if (userChoiceThree.Checked)
                    {
                        Result currentResult = new Result();

                        for (int i = 0; i < itemToAssign.Count; i++)
                        {
                            if (itemToAssign[i].ItemID != 0 && currentResult.intItemID1 == 0)
                            {
                                currentResult.intItemID1 = itemToAssign[i].ItemID;
                                //itemToAssign.RemoveAt(i);
                            }
                            else if (itemToAssign[i].ItemID != 0 && currentResult.intItemID2 == 0)
                            {
                                currentResult.intItemID2 = itemToAssign[i].ItemID;
                               // itemToAssign.RemoveAt(i);
                            }
                        }
                        currentResult.intUserChoice = itemToAssign[2].ItemID;

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
                MessageBox.Show("Could not write current result");
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

        /// Creating progress bar - Kevin Khlom 11/21/18

        private void denominatorChange(int itemPairListIndex)
        {
            denominatorLabel.Text = itemPairListIndex.ToString();
        }
        private void numeratorChange(int numeratorSet, int itemPairListIndex)
        {
            
            int numeratorNum = numeratorSet;
            numeratorNum = +itemPairListIndex + 1;
            numeratorLabel.Text = numeratorNum.ToString();
            testProgressBar.Value = numeratorNum;
            testProgressBar.Maximum = itemPairList.Count();
            testProgressBar.Minimum = 0;
        }
    }
}
