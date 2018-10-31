using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework;
using TestSessions;
using Database;
using static TestSessions.TestSession;
using Users;
using Results;

/* 
 * Programmer: Megan Villwock
 * Last Modified Date: 10/30/2018
 * 
 * Results reporting form that allows a user to select a user, test, and test date to view results.
 * 
 */

namespace ResultsReporting
{
    public partial class ResultsReportingForm : MetroForm
    {
        public ResultsReportingForm()
        {
            InitializeComponent();
        }

        private void ResultsReporting_Load(object sender, EventArgs e)
        {
            // Loads the form with the list of users registered in the system.

            List<UserClass> userList = new List<UserClass>();
            
            string error = "";

            if (UserClass.GetUsers(userList, ref error))
            {
                foreach (UserClass user in userList)
                {
                    patientComboBox.Items.Add(user);   
                }
            }
            else
                MessageBox.Show(error);

           
        }

        private void patientComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string error = "";

            List<ResultDisplay> resultList = new List<ResultDisplay>();
            UserClass user = (UserClass)patientComboBox.SelectedItem;

            TestScoreListView.Items.Clear();

            // Displays test results for a selected user.
            try
            {
                if (Result.GetResults(resultList, ref error, user._id))
                {
                    

                    foreach (ResultDisplay result in resultList)
                    {
                        // TestScoreListView.Items.Add(result.ToString());
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = (result.ItemName);
                        lvi.SubItems.Add(result.TotalScore.ToString());
                        lvi.SubItems.Add(result.Wins.ToString());
                        lvi.SubItems.Add(result.Ties.ToString());
                        lvi.SubItems.Add(result.Losses.ToString());

                        TestScoreListView.Items.Add(lvi);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error!");
            }
           
                     


            
            
        }
    }
}
