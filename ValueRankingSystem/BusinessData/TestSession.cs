using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessData
{

 /* 
 * Programmer: Megan Villwock
 * Last Modified Date: 10/30/2018
 * 
 * Class to hold test sessions.
 * 
 */

    public class TestSession
    {
        private int _sessionID;
        private int _testID;
        private int _userID;
        private DateTime _creationDate;
  

        public int intSessionID
        {
            get { return _sessionID; }
            set { _sessionID = value; }
        }

        public int intTestID
        {
            get { return _testID; }
            set { _testID = value; }
        }

        public int intUserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        public DateTime datetimeCreationDate
        {
            get { return _creationDate; }
            set { _creationDate = value; }
        }

        public override string ToString()
        {
            return datetimeCreationDate.ToString();
        }

      
        public static bool GetTestSessions(List<TestSession> testSessionList, ref string error)
        {
            return TestSessionDB.GetTestSessions(testSessionList, ref error);
        }

        public static bool GetUserTests(List<Test> testList, ref string error, int TestID)
        {
            return TestSessionDB.GetUserTests(testList, ref error, TestID);
        }

        public static bool CreateSession(TestSession testsession)
        {
            return TestSessionDB.CreateSession(testsession);
        }

        public static bool getTestID(Test test, string stringErrorString)
        {
            return TestDB.getTestID(test, stringErrorString);
        }

    }
}

