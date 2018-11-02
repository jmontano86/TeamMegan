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
using System.Data;
using MetroFramework.Forms;
using UserTestLogic;
using DataAccessLibrary;
using Users;
using Results;
using TestSessions;
//using ValueRankingSystem; // This is not working. Still trying to figure out a file deletion error that occurred during local merge

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
            //Get user data
            //currentUser = LoginForm.user;
            //Load tests into the radio buttons
            //UserTestLogic.UserTestLogic.loadTests(testItems, itemList, currentUser);
            UserTestLogic.UserTestLogic.getItemPair(itemPairList);
            //populateRadio();
            // Get Item Pairs
            populateGroupBox(itemPairList, itemPairListIndex);
        }

        // Changes the radio buttons based content in array
        public void populateRadio(ItemPair itemPair, Result currentResult)
        {
            userChoiceOne.Text = itemPair.Item1.Name;
            userChoiceTwo.Text = itemPair.Item2.Name;
            userChoiceThree.Text = "Undecided";
            // Populate variables
            currentResult.ItemID1 = itemPair.Item1.ItemID;
            currentResult.ItemID2 = itemPair.Item2.ItemID;
        }
        // Gets the next index in the itemPairList
        private void populateGroupBox(List<ItemPair> listItemPairList, int itemPairListIndex)
        {
            Result currentResult = new Result();
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
                populateRadio(newItemPair, currentResult);
                
            }
        }
 
        private void testButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Change button to finish if all itemPairs have been accounted for
                if (testDone == false)
                {
                    if (userChoiceOne.Checked)
                    {
                        //Stores user choice in currentResult
                        
                        currentResult.UserChoice = currentResult.ItemID1;
                        //Stores currentResult into an array of results
                        allCurrentResults.Add(currentResult);
                        itemPairListIndex++;
                        populateGroupBox(itemPairList ,itemPairListIndex);

                    }
                    else if (userChoiceTwo.Checked)
                    {
                        //Stores user choice in currentResult
                        currentResult.UserChoice = currentResult.ItemID2;
                        //Stores currentResults into an array of results
                        allCurrentResults.Add(currentResult);
                        itemPairListIndex++;
                        populateGroupBox(itemPairList, itemPairListIndex);
                        
                    }
                    else if (userChoiceThree.Checked)
                    {
                        //Stores user choice in currentResult
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
