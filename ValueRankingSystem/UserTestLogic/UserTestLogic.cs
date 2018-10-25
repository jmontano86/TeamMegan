using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLibrary;

namespace UserTestLogic
{
    public class UserTestLogic
    {
        Test currentTest;
        Item currentItem;

        
        //Load Items using the testId as an indicator
        public static List<Item> loadTests(List<Test> testList, List<Item> itemList)
        {
            //Get all tests
            Test[] t = testList.ToArray();
            TestList.getTests(testList);
  
            //Get all test items
            foreach (var test in testList)
            {
                //Only store test items that match test id for test
                ItemList.getItems(itemList, test.TestID);
            }
            return itemList;
        }
    }
}
