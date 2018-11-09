using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLibrary;
using TestSessions;
using static TestSessions.TestSession;
using Users;
using Results;

namespace UserTestLogic
{
    public class UserTestLogic
    {
        
        /// <summary>
        /// Accidentally wrote this for sprint 1 because I misunderstood my user story but the point of this was 
        /// to load all the available tests that the user can take. Found out that this can be used in sprint 2
        /// </summary>
        /// <param name="testList"></param>
        /// <param name="itemList"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static List<Test> loadTests(List<Test> testList, List<Item> itemList, UserClass user)
        {
            bool testExist = false;
            List<Test> availTest = new List<Test>();
            //Get all tests
            TestList.getTests(testList);
            //Only stores to an array tests that are available
            foreach (var test in testList.ToList())
            {
                testExist = checkExistingTestSession(testList, user);
                if (testExist != true)
                {
                    availTest.Add(test);
                }
            }
            // Get all test items
            // Need to rewrite this for sprint 2
            //foreach (var test in availTest)
            //{
            //    //Only store test items that match test id and testSession does not exist yet
            //    ItemList.getItems(itemList, test.TestID);
            //}
            return availTest;
        }


        // Need to check to see if the User already has taken a test
        public static bool checkExistingTestSession(List<Test> testList, UserClass user)
        {
            bool testExist = false;
            List<TestSession> testSessionList = new List<TestSession>();
            string error = "Cannot pull test session";
            // Pull existing test sessions
            TestSession.GetTestSessions(testSessionList, ref error);
            foreach (var testSession in testSessionList)
            {
                TestList.getTests(testList);
                foreach (var test in testList)
                {
                    if (testSession.TestID == test.TestID && testSession.UserID == user.intUserID)
                    {
                        testExist = true;
                    }
                }
            }
            // Test already exist
            return testExist;
        }
        //Objective: Find ItemPairs
        //Create list that pairs up items
        public static List<ItemPair> getItemPair(List<ItemPair> itemPair)
        {
            // Get all items from the database
           
            List<Item> itemList = new List<Item>();
            ItemList.getItems(itemList, 1);

            // Pair up items
      
            for (int j = 0; j<=itemList.Count-2; j++)
            {


                //// Loops through and pairs up item starting at count +1
                for (int i = j+1; i <= itemList.Count-1; i++)
                {

                    // Creates new itempair instance
                    ItemPair itemInsta = new ItemPair();
                    // Populates first parameter of itemPair
                    itemInsta.Item1 = itemList[j];
                    itemInsta.Item2 = itemList[i];
                    itemPair.Add(itemInsta);

                }
            }
            return itemPair;
        }

        public static int getCurrentSessionId(int testSessionID)
        {
            string error = "Could not return list of test sessions";
            List<TestSession> testSessions = new List<TestSession>();
            // Get sessionID recently written
            GetTestSessions(testSessions, ref error);
            testSessionID = testSessions[testSessions.Count - 1].SessionID;
            return testSessionID;
        }
        // Check to see if the user 
        public static bool userTookTest(UserClass currentUser, ItemPair itemPair)
        {
            List<TestSession> currentTestSessions = new List<TestSession>();
            List<Test> testList = new List<Test>();
            bool alreadyTookTest = false;
            int itemID = 0;
            string errorStuff = "Error getting test sessions";
            // Get Test ID but needs item id first
            itemID = itemPair.Item1.ItemID;
            // Grab Existing Test Sessions
            GetTestSessions(currentTestSessions, ref errorStuff);
            // Get list of tests
            int testID = 1;
            foreach (var currentTestSession in currentTestSessions)
            {
                if (currentTestSession.TestID == testID && currentTestSession.UserID == currentUser.intUserID)
                {
                    alreadyTookTest = true;
                }
            }
            return alreadyTookTest;
        }
        
    }
}
