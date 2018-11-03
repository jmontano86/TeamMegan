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

        public int intResultID
        {
            get { return _resultID; }
            set { _resultID = value; }
        }

        public int intSessionID
        {
            get { return _sessionID; }
            set { _sessionID = value; }
        }

        public int intItemID1
        {
            get { return _itemID1; }
            set { _itemID1 = value; }
        }

        public int intItemID2
        {
            get { return _itemID2; }
            set { _itemID2 = value; }
        }

        public int intUserChoice
        {
            get { return _userChoice; }
            set { _userChoice = value; }
        }

        public override string ToString()
        {
            return _itemID1.ToString();
            
        }

           
         public static bool GetResults(List<ResultDisplay> resultList, ref string error, int UserID)
         {
             return ResultDB.GetResults(resultList, ref error, UserID);
         }

         public static bool CreateSession(Result result)
         {
             return ResultDB.CreateResult(result);
         }
        
    }

}
