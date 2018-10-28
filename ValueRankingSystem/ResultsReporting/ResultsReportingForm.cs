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

           


            if(Result.GetResults(resultList, ref error, user.intUserID))
            {

            }
                     


            
            
        }
    }
}
