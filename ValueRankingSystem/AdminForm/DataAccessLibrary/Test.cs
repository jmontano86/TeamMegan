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
        public static bool getTests(List<Test> testList)
        {
            return TestDB.getTests(testList);
        }
        public static bool addTest(Test test)
        {
            return TestDB.addTest(test);
        }
        public static bool deleteTest(int intTestID)
        {
            return TestDB.deleteTest(intTestID);
        }
        public static bool getTestID(Test test)
        {
            return TestDB.getTestID(test);
        }
    }
}
