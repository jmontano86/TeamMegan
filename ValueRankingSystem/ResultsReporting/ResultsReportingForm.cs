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
            List<TestSession> testSessionList = new List<TestSession>();
            string error = "";

            if (TestSessionList.GetTestSessions(testSessionList, ref error))
            {
                foreach (TestSession testsession in testSessionList)
                {
                    patientComboBox.Items.Add(testsession.UserID);
                    
                }
            }
            else
                MessageBox.Show(error);
        }
        
    }
}
