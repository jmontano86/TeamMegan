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
        List<Test> testItems = new List<Test>();
        List<Item> itemList = new List<Item>();
        int itemID1 = 0;
        int itemID2 = 0;
        int userChoice = 0;
        Result currentResult = new Result();
        TestSession currentTestSession = new TestSession();
        private void Form1_Load(object sender, EventArgs e)
        {
            //Get user data
            //currentUser = LoginForm.user;
            //Load tests into the radio buttons
            UserTestLogic.UserTestLogic.loadTests(testItems, itemList, currentUser);
            populateRadio();
        }

        // Changes the radio buttons based content in array
        private void populateRadio()
        {
            userChoiceOne.Text = itemList[0].Name;
            userChoiceTwo.Text = itemList[1].Name;
            userChoiceThree.Text = "Undecided";
            // Populate variables
            currentResult.intItemID1 = itemList[0].ItemID;
            currentResult.intItemID2 = itemList[1].ItemID;
        }
        private void testButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Get existing test sessions

                if (userChoiceOne.Checked)
                {
                    currentResult.intUserChoice = itemID1;
                   
                    testButton.Text = "Finished";
                    itemGroupBox.Visible = false;
                    finishedLabel.Visible = true;
                    currentTestSession.intUserID = 1;//currentUser._id;
                    currentTestSession.intTestID = testItems[0].TestID;
                    currentTestSession.datetimeCreationDate = DateTime.Now;
                    TestSession.CreateSession(currentTestSession);
                    currentResult.intSessionID = currentTestSession.intSessionID;
                    Result.CreateSession(currentResult);
                }
                else if (userChoiceTwo.Checked)
                {
                    currentResult.intUserChoice = itemID2;
                    Result.CreateSession(currentResult);
                    testButton.Text = "Finished";
                    itemGroupBox.Visible = false;
                    finishedLabel.Visible = true;
                    currentTestSession.intUserID = currentUser.intUserID;
                    currentTestSession.intTestID = testItems[0].TestID;
                    currentTestSession.datetimeCreationDate = DateTime.Now;
                    TestSession.CreateSession(currentTestSession);

                }
                else if (userChoiceThree.Checked)
                {
                    userChoice = 0;
                    currentResult.intUserChoice = userChoice;
                    Result.CreateSession(currentResult);
                    testButton.Text = "Finished";
                    itemGroupBox.Visible = false;
                    finishedLabel.Visible = true;
                    currentTestSession.intUserID = currentUser.intUserID;
                    currentTestSession.intTestID = testItems[0].TestID;
                    currentTestSession.datetimeCreationDate = DateTime.Now;
                    TestSession.CreateSession(currentTestSession);
                }
                else
                {
                    MessageBox.Show("Please make a choice");
                }
            }
            catch
            {
                MessageBox.Show("Something went wrong with the display");
            }
        }
        
    }
}
