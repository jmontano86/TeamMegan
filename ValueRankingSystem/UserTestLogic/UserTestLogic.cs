using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLibrary;
using TestSessions;
using static TestSessions.TestSession;
using Users;

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
    }
}
