﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessData
{
    public class UserTestLogic
    {
        //Duplicate between loadItemList and getItemPair function
        ///// <summary>
        ///// Accidentally wrote this for sprint 1 because I misunderstood my user story but the point of this was 
        ///// to load all the available items that the user can take. Found out that this can be used in sprint 2
        ///// </summary>
        ///// <param name="testList"></param>
        ///// <param name="itemList"></param>
        ///// <param name="user"></param>
        ///// <returns></returns>
        //public static List<Item> loadItemList(int testID, List<ItemPair> itemPairList, UserClass user)
        //{
        //    bool testExist = false;
        //    List<Item> itemList = new List<Item>();
        //    //Get all tests
        //    ItemList.getItems(itemList, testID, "Error getting items");
        //    //Only stores to an array items that are available

        //    // Get all test items
        //    // Need to rewrite this for sprint 2
        //    //foreach (var test in availTest)
        //    //{
        //    //    //Only store test items that match test id and testSession does not exist yet
        //    //    ItemList.getItems(itemList, test.TestID);
        //    //}
        //    return itemList;
        //}


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
                string errorString = "Error Getting Items: ";
                TestList.getTests(testList, ref errorString);
                foreach (var test in testList)
                {
                    if (testSession.intTestID == test.TestID && testSession.intUserID == user.intUserID)
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
        public static List<ItemPair> getItemPair(int testID, List<ItemPair> itemPairList)
        {
            // Get all items from the database
           
            List<Item> itemList = new List<Item>();
            string errorString = "Could not load items: ";
            ItemList.getItems(itemList, testID, ref errorString);

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
                    itemPairList.Add(itemInsta);
                }
            }
            return itemPairList;
        }

        public static int getCurrentSessionId(int testSessionID)
        {
            string error = "Could not return list of test sessions";
            List<TestSession> testSessions = new List<TestSession>();
            // Get sessionID recently written
            TestSessionDB.GetTestSessions(testSessions, ref error);
            testSessionID = testSessions[testSessions.Count - 1].intSessionID;
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
            TestSessionDB.GetTestSessions(currentTestSessions, ref errorStuff);
            // Get list of tests
            int testID = 1;
            foreach (var currentTestSession in currentTestSessions)
            {
                if (currentTestSession.intTestID == testID && currentTestSession.intUserID == currentUser.intUserID)
                {
                    alreadyTookTest = true;
                }
            }
            return alreadyTookTest;
        }
        /// <summary>
        /// Randmizes the number that will be used to assign itempairs to populate radio buttons
        /// </summary>
        public static List<Item> itemToAssign(ItemPair itemPair, List<Item> itemToAssign, Test currentTest)
        {
            List<Item> randomItemList = new List<Item>();
            // Assign "Undecided" as an item
            Item unChoice = new Item(0, "Undecided", itemPair.Item1.TestID);
            //Updated for Custom Test Presentation 
            //If the custom test has the shuffle option selected, shuffle the options. JDM
            if (currentTest.Shuffle == 1)
            {
                // Generate random number
                Random rndNum = new Random();
                // Assigns rndNum to itemPair          
                randomItemList.Add(itemPair.Item1);
                randomItemList.Add(itemPair.Item2);
                randomItemList.Add(unChoice);
                // items to assign
                // puts the itempair in random order
                while (randomItemList.Count > 0)
                {
                    int rndNumAssign = rndNum.Next(0, randomItemList.Count);
                    itemToAssign.Add(randomItemList[rndNumAssign]);
                    randomItemList.RemoveAt(rndNumAssign);
                }
            }
            else
            {
                itemToAssign.Add(itemPair.Item1);
                itemToAssign.Add(itemPair.Item2);
                itemToAssign.Add(unChoice);
            }
            return itemToAssign;
        }
    }
}
