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
    }
}
