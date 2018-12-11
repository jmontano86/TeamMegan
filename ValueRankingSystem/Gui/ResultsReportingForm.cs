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
          // BusinessData.Statistics.FillData();
        
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
            //this.reportViewer2.RefreshReport();
        }

        private void patientComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TestScoreListView.Items.Clear();
            testComboBox.Items.Clear();
            dateComboBox.Items.Clear();
            resultsButton.Enabled = false;
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

            if (testComboBox.Items.Count == 1)
            {
                testComboBox.SelectedIndex = 0;
            }
                  
        }

        private void testComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TestScoreListView.Items.Clear();
            dateComboBox.Items.Clear();
            
            string error = "";

            List<ResultDisplay> resultList = new List<ResultDisplay>();
            List<TestSession> sessionList = new List<TestSession>();

            UserClass user = (UserClass)patientComboBox.SelectedItem;
            Test test = (Test)testComboBox.SelectedItem;
            TestSession testsession = (TestSession)dateComboBox.SelectedItem;
            

            // Displays test results for a selected user.
            try
            {
                if (TestSession.GetTestDate(sessionList, ref error, user.intUserID, test.TestID))
                {
                    foreach (TestSession session in sessionList)
                    {
                        dateComboBox.Items.Add(session);
                    }
                }
                else
                    MessageBox.Show("Grr");
            }
            catch
            {
                MessageBox.Show("Error in form!");
            }
            //If there is only one test taken for the user, select it
            if (dateComboBox.Items.Count == 1)
            {
                dateComboBox.SelectedIndex = 0;
            }
        }

        private void resultsButton_Click(object sender, EventArgs e)
        {
            UserClass user = (UserClass)patientComboBox.SelectedItem;
            Test test = (Test)testComboBox.SelectedItem;
            TestSession session = (TestSession)dateComboBox.SelectedItem;

            ResultsDisplayForm form = new ResultsDisplayForm(user.intUserID, test.TestID, session.datetimeCreationDate);
            form.ShowDialog();
        }

        private void dateComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TestScoreListView.Items.Clear();
            if (dateComboBox.SelectedIndex > -1)
            {
                resultsButton.Enabled = true;
            } else
            {
                resultsButton.Enabled = false;
            }

            List<ResultDisplay> resultList = new List<ResultDisplay>();
            string error = "";
            Test test = (Test)testComboBox.SelectedItem;
            UserClass user = (UserClass)patientComboBox.SelectedItem;
            TestSession session = (TestSession)dateComboBox.SelectedItem;

            if (Result.GetResults(resultList, ref error, user.intUserID, test.TestID, session.datetimeCreationDate))
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
    }
}
