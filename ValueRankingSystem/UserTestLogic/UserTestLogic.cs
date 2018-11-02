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
        Test currentTest;
        Item currentItem;

        
        //Load Items using the testId as an indicator
        public static List<Item> loadTests(List<Test> testList, List<Item> itemList, UserClass user)
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
            //Get all test items
            foreach (var test in availTest)
            {
                //Only store test items that match test id and testSession does not exist yet
                ItemList.getItems(itemList, test.TestID);
            }
            return itemList;
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
    }
}
