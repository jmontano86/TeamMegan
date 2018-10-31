using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Results
    
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

        public string ItemName
        {
            get { return _itemName; }
            set { _itemName = value; }
        }

        public int TotalScore
        {
            get { return _totalScore; }
            set { _totalScore = value; }
        }

        public int Wins
        {
            get { return _wins; }
            set { _wins = value; }
        }

        public int Ties
        {
            get { return _ties; }
            set { _ties = value; }
        }

        public int Losses
        {
            get { return _losses; }
            set { _losses = value; }
        }

        public override string ToString()
        {
            return ItemName + " " + TotalScore + "" + Wins + "" + Ties + "" + Losses;
        }

    }
}
