using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class Test
    {
        int intTestID;
        string strTestName;
        int intCustomTest; //there is a custom comparison test if this equal 1
        string strTestType;

        public int TestID
        {
            get { return intTestID; }
            set { intTestID = value; }
        }
        public string TestName
        {
            get { return strTestName; }
            set { strTestName = value; }
        }
        public int CustomTest
        {
            get { return intCustomTest; }
            set { intCustomTest = value; }
		}
        public string TestType
        {
            get { return strTestType; }
            set { strTestType = value; }
        }
    }

    public static class TestList
    {
        public static bool getTests(List<Test> listTestList, string stringErrorString)
        {
            return TestDB.getTests(listTestList, stringErrorString);
        }
        public static bool getTestSessions(List<int> listTestIDList, string stringErrorString)
        {
            return TestDB.getTestSessions(listTestIDList, stringErrorString);
        }
        public static bool getTestNames(List<string> listTestNames, string stringErrorString)
        {
            return TestDB.getTestNames(listTestNames, stringErrorString);
        }
        //TODO: ADD TEST TYPE
        public static bool addTest(Test test, string stringErrorString)
        {
            return TestDB.addTest(test, stringErrorString);
        }
        public static bool deleteTest(int intTestID, string stringErrorString)
        {
            return TestDB.deleteTest(intTestID, stringErrorString);
        }
        public static bool getTestID(Test test, string stringErrorString)
        {
            return TestDB.getTestID(test, stringErrorString);
        }
        public static bool getTestType(Test test, string stringErrorString)
        {
            return TestDB.getTestType(test, stringErrorString);
        }
    }
}
