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
using BusinessData;
using System.Data.SqlClient;




/* 
 * Programmer: Megan Villwock
 * Last Modified Date: 10/30/2018
 * 
 * Results reporting form that allows a user to select a user, test, and test date to view results.
 * 
 */

namespace Gui
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
            TestScoreListView.Items.Clear();
            testComboBox.Items.Clear();

            string error = "";

            List<ResultDisplay> resultList = new List<ResultDisplay>();
            List<Test> testList = new List<Test>();
            UserClass user = (UserClass)patientComboBox.SelectedItem;
            Test test = (Test)testComboBox.SelectedItem;

            // Displays test results for a selected user.
            try

            {

                if (TestSession.GetUserTests(testList, ref error, user.intUserID))
                {
                    foreach (Test tests in testList)
                    {
                        testComboBox.Items.Add(tests);
                    }

                    
                }
                else
                    MessageBox.Show(error);

             
            }
            catch
            {
                MessageBox.Show("Error in form!");
            }
                  
        }

        private void testComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TestScoreListView.Items.Clear();
            resultsButton.Enabled = true;
            
            List<ResultDisplay> resultList = new List<ResultDisplay>();
            string error = "";
            Test test = (Test)testComboBox.SelectedItem;
            UserClass user = (UserClass)patientComboBox.SelectedItem;

            if (Result.GetResults(resultList, ref error, user.intUserID, test.TestID))
            {
                foreach (ResultDisplay result in resultList)
                {
                    // TestScoreListView.Items.Add(result.ToString());
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = (result.stringItemName);
                    lvi.SubItems.Add(result.intTotalScore.ToString());
                    lvi.SubItems.Add(result.intWins.ToString());
                    lvi.SubItems.Add(result.intTies.ToString());
                    lvi.SubItems.Add(result.intLosses.ToString());

                    TestScoreListView.Items.Add(lvi);
                }
            }
        }

        private void resultsButton_Click(object sender, EventArgs e)
        {
           ResultsDisplayForm form = new ResultsDisplayForm();
            form.ShowDialog();
        }
    }
}
