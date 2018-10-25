using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Results
{
    public class Result
    {
        private int _resultID;
        private int _sessionID;
        private int _itemID1;
        private int _itemID2;
        private int _userChoice;

        public int ResultID
        {
            get { return _resultID; }
            set { _resultID = value; }
        }

        public int SessionID
        {
            get { return _sessionID; }
            set { _sessionID = value; }
        }

        public int ItemID1
        {
            get { return _itemID1; }
            set { _itemID1 = value; }
        }

        public int ItemID2
        {
            get { return _itemID2; }
            set { _itemID2 = value; }
        }

        public int UserChoice
        {
            get { return _userChoice; }
            set { _userChoice = value; }
        }

        public override string ToString()
        {
            string m = "megan";
            return m;
        }

           
         public static bool GetResults(List<Result> resultList, ref string error)
         {
             return ResultDB.GetResults(resultList, ref error);
         }

         public static bool CreateSession(Result result)
         {
             return ResultDB.CreateResult(result);
         }
        
    }

}
