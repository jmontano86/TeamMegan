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
        private string testType;
        public UserClass currentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }
        private Test _currentTest;
        public Test currentTest
        {
            get { return _currentTest; }
            set { _currentTest = value; }
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
            if (currentTest.CustomTest == 1)
            {
                itemPairList = ItemPair.getCustomItemPair(currentTest.TestID);
            }
            else
            {
                UserTestLogic.getItemPair(currentTest.TestID, itemPairList);
            }
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
            UserTestLogic.itemToAssign(itemPair, itemToAssign, currentTest);
            //Gets the test type and sets the text/images accordingly
            int i = 0;
            string errorString = "Error getting test type: ";
            if (TestList.getTestType(ref testType, currentTest.TestID, ref errorString))
            {
                if(testType == "T")
                {
                    
                    // 
                    // userChoiceOne
                    // 
                    this.userChoiceOne.Location = new System.Drawing.Point(61, 49);
                    // 
                    // userChoiceTwo
                    // 
                    this.userChoiceTwo.Location = new System.Drawing.Point(165, 49);
                    // 
                    // userChoiceThree
                    // 
                    this.userChoiceThree.Location = new System.Drawing.Point(269, 49);
                    // 
                    // testButton
                    // 
                    this.testButton.Location = new System.Drawing.Point(214, 275);
                    // 
                    // directionLabel
                    // 
                    this.directionLabel.Location = new System.Drawing.Point(150, 96);
                    // 
                    // finishedLabel
                    // 
                    this.finishedLabel.Location = new System.Drawing.Point(54, 44);
                    // 
                    // testProgressBar
                    // 
                    this.testProgressBar.Location = new System.Drawing.Point(197, 372);
                    // 
                    // numeratorLabel
                    // 
                    this.numeratorLabel.Location = new System.Drawing.Point(416, 372);
                    // 
                    // slashLabel
                    // 
                    this.slashLabel.Location = new System.Drawing.Point(433, 372);
                    // 
                    // denominatorLabel
                    // 
                    this.denominatorLabel.Location = new System.Drawing.Point(449, 372);
                    // 
                    // itemGroupBox
                    // 
                    this.itemGroupBox.Location = new System.Drawing.Point(79, 142);
                    this.itemGroupBox.Size = new System.Drawing.Size(440, 100);
                    //
                    // UserTest
                    //
                    this.ClientSize = new System.Drawing.Size(600, 426);
                }
                foreach (Control control in itemGroupBox.Controls)
                {
                    if (control is RadioButton)
                    {
                        control.Width = 300;
                        ((RadioButton)control).BackColor = Color.Transparent;
                        if (currentTest.TestType == "T")
                        {
                            control.Text = itemToAssign[i].Name;
                        }
                        else if (currentTest.TestType == "I")
                        {
                            if (itemToAssign[i].ItemImage != null)
                            {
                                ((RadioButton)control).TextImageRelation = TextImageRelation.TextAboveImage;
                                ((RadioButton)control).Image = itemToAssign[i].getImage();
                            }
                            else
                            {
                                ((RadioButton)control).Image = Image.FromFile("../../Undecided.png");
                            }
                        }
                        else if (currentTest.TestType == "TI")
                        {
                            if (itemToAssign[i].ItemImage != null)
                            {
                                ((RadioButton)control).TextImageRelation = TextImageRelation.TextAboveImage;
                                ((RadioButton)control).Image = itemToAssign[i].getImage();
                            }
                            else
                            {
                                ((RadioButton)control).Image = Image.FromFile("../../Undecided.png");
                            }
                            control.Text = itemToAssign[i].Name;
                        }
                    }
                    i++;
                }
            }
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
                currentTestSession.intTestID = currentTest.TestID; // Need to change this for sprint 2
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
                if(currentTest.Shuffle == 1)
                {
                    //if custom test is set to Shuffle, will randomize order of pairings
                    itemToAssign = populateRadio(newItemPair);
                } else
                {
                    itemToAssign.Clear();
                    itemToAssign.Add(newItemPair.Item1);
                    itemToAssign.Add(newItemPair.Item2);
                    itemToAssign.Add(new Item(0, "Undecided", currentTest.TestID));
                    if (currentTest.TestType == "T")
                    { 
                        userChoiceOne.Text = newItemPair.Item1.Name;
                        userChoiceTwo.Text = newItemPair.Item2.Name;
                        userChoiceThree.Text = "Undecided";
                    }
                    else if (currentTest.TestType == "I")
                    {
                        if (itemToAssign[0].ItemImage != null)
                        {
                            userChoiceOne.Text = null;
                            userChoiceOne.TextImageRelation = TextImageRelation.TextAboveImage;
                            userChoiceOne.Image = itemToAssign[0].getImage();
                        }
                        else
                        {
                            userChoiceOne.Image = null;
                        }
                        if (itemToAssign[1].ItemImage != null)
                        {
                            userChoiceTwo.Text = null;
                            userChoiceTwo.TextImageRelation = TextImageRelation.TextAboveImage;
                            userChoiceTwo.Image = itemToAssign[1].getImage();
                        }
                        else
                        {
                            userChoiceTwo.Image = null;
                        }
                        userChoiceThree.TextImageRelation = TextImageRelation.TextAboveImage;
                        userChoiceThree.Image = Image.FromFile("../../Undecided.png");
                        userChoiceThree.Text = null;
                    }
                    else if (currentTest.TestType == "TI")
                    {
                        if (itemToAssign[0].ItemImage != null)
                        {
                            userChoiceOne.TextImageRelation = TextImageRelation.TextAboveImage;
                            userChoiceOne.Image = itemToAssign[0].getImage();
                        }
                        else
                        {
                            userChoiceOne.Image = null;
                        }
                        if (itemToAssign[1].ItemImage != null)
                        {
                            userChoiceTwo.TextImageRelation = TextImageRelation.TextAboveImage;
                            userChoiceTwo.Image = itemToAssign[1].getImage();
                        }
                        else
                        {
                            userChoiceTwo.Image = null;
                        }
                        userChoiceThree.TextImageRelation = TextImageRelation.TextAboveImage;
                        userChoiceOne.Text = newItemPair.Item1.Name;
                        userChoiceTwo.Text = newItemPair.Item2.Name;
                        userChoiceThree.Text = "Undecided";
                        userChoiceThree.Image = Image.FromFile("../../Undecided.png");
                    }

                }
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
