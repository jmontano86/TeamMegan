using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessData
{
    public class Test
    {
        int intTestID;
        string strTestName;
        int intCustomTest; //there is a custom comparison test if this equal 1
        string strTestType;
        int intShuffle; //If 1, shuffle enabled

        public int TestID
        {
            get { return intTestID; }
            set { intTestID = value; }
        }
        public string TestType
        {
            get { return strTestType; }
            set { strTestType = value; }
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
        public int Shuffle
        {
            get { return intShuffle; }
            set { intShuffle = value; }
        }
        public override string ToString()
        {
            return TestName.ToString();
        }

        public static void updateCustomTest(int intTestID, int intCustomTest, int intShuffleBit)
        {
            TestDB db = new TestDB();
            db.updateCustomTest(intTestID, intCustomTest, intShuffleBit);
        }
    }
    
    public static class TestList
    {
        public static bool getTests(List<Test> listTestList, ref string stringErrorString)
        {
            return TestDB.getTests(listTestList, ref stringErrorString);
        }
        public static bool getTestSessions(List<int> listTestIDList, ref string stringErrorString)
        {
            return TestDB.getTestSessions(listTestIDList, ref stringErrorString);
        }
        public static bool getTestNames(List<string> listTestNames, ref string stringErrorString)
        {
            return TestDB.getTestNames(listTestNames, ref stringErrorString);
        }
        public static bool addTest(Test test, ref string stringErrorString)
        {
            return TestDB.addTest(test, ref stringErrorString);
        }
        public static bool deleteTest(int intTestID, ref string stringErrorString)
        {
            return TestDB.deleteTest(intTestID, ref stringErrorString);
        }
        public static bool getTestIDAndType(Test test, ref string stringErrorString)
        {
            return TestDB.getTestIDAndType(test, ref stringErrorString);
        }
        public static bool getTestType(ref string testType, int testID, ref string errorString)
        {
            return TestDB.getTestType(ref testType, testID, ref errorString);
        }
    }
}
