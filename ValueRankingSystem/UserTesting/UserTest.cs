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
using UserTestLogic;
using DataAccessLibrary;
using Users;
using Results;
using TestSessions;

namespace UserTesting
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
            bool testAlreadyTaken = false;

            UserTestLogic.UserTestLogic.getItemPair(itemPairList);
            //Checks to see if user already took test
            testAlreadyTaken = UserTestLogic.UserTestLogic.userTookTest(currentUser, itemPairList[itemPairListIndex]);
            if (testAlreadyTaken == true)
            {
                MessageBox.Show("You have already taken this test");
                this.Close();
            }
            // Get Item Pairs
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
                currentTestSession.UserID = currentUser.intUserID;
                currentTestSession.TestID = 1; // Need to change this for sprint 2
                currentTestSession.CreationDate = DateTime.Now;
                TestSession.CreateSession(currentTestSession);
                // Get session ID
                int sessionID = 0;
                sessionID = UserTestLogic.UserTestLogic.getCurrentSessionId(sessionID);
                foreach (var currentSesResult in allCurrentResults)
                {
                    currentSesResult.SessionID = sessionID;
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
                        currentResult.UserChoice = currentResult.ItemID1;
                        currentResult.ItemID1 = itemPairList[itemPairListIndex].Item1.ItemID;
                        currentResult.ItemID2 = itemPairList[itemPairListIndex].Item2.ItemID;
                        currentResult.UserChoice = currentResult.ItemID1;
                        //Stores currentResult into an array of results
                        allCurrentResults.Add(currentResult);
                        itemPairListIndex++;
                        Result newResult = new Result();
                        populateGroupBox(itemPairList ,itemPairListIndex);

                    }
                    else if (userChoiceTwo.Checked)
                    {
                        Result currentResult = new Result();
                        currentResult.UserChoice = currentResult.ItemID1;
                        currentResult.ItemID1 = itemPairList[itemPairListIndex].Item1.ItemID;
                        currentResult.ItemID2 = itemPairList[itemPairListIndex].Item2.ItemID;
                        currentResult.UserChoice = currentResult.ItemID1;
                        //Stores currentResults into an array of results
                        allCurrentResults.Add(currentResult);
                        itemPairListIndex++;
                        populateGroupBox(itemPairList, itemPairListIndex);
                        
                    }
                    else if (userChoiceThree.Checked)
                    {
                        Result currentResult = new Result();
                        currentResult.UserChoice = currentResult.ItemID1;
                        currentResult.ItemID1 = itemPairList[itemPairListIndex].Item1.ItemID;
                        currentResult.ItemID2 = itemPairList[itemPairListIndex].Item2.ItemID;
                        currentResult.UserChoice = 0;
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
        
    }
}
