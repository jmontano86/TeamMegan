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
 * Class to hold results.
 * 
 */


    public class ResultDisplay
    {
        private string _itemName;
        private int _totalScore;
        private int _wins;
        private int _ties;
        private int _losses;

        public string stringItemName
        {
            get { return _itemName; }
            set { _itemName = value; }
        }

        public int intTotalScore
        {
            get { return _totalScore; }
            set { _totalScore = value; }
        }

        public int intWins
        {
            get { return _wins; }
            set { _wins = value; }
        }

        public int intTies
        {
            get { return _ties; }
            set { _ties = value; }
        }

        public int intLosses
        {
            get { return _losses; }
            set { _losses = value; }
        }

        public override string ToString()
        {
            return stringItemName + " " + intTotalScore + "" + intWins + "" + intTies + "" + intLosses;
        }

    }
}
