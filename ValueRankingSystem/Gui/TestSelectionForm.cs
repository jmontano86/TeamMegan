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
using BusinessData;

namespace Gui
{
    public partial class TestSelectionForm : MetroForm
    {
        public TestSelectionForm()
        {
            InitializeComponent();
        }
        Test selectedTest = new Test();
        private UserClass _currentUser;
        public UserClass currentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }
        private void TestSelectionForm_Load(object sender, EventArgs e)
        {
            // Load tests into combobox
            List<Test> testList = new List<Test>();
            String error = "Could not load list of tests";

            if (TestList.getTests(testList, error))
            {
                foreach (Test test in testList)
                {
                    testSelectionComboBox.Items.Add(test);
                }
            }
            else
                MessageBox.Show(error);
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (testSelectionComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please choose a test you would like to take from the dropdown");
            }
            else
            {
                UserTest testForm = new UserTest();
                testForm.currentTest = selectedTest;
                testForm.currentUser = currentUser;
                testForm.ShowDialog();
                this.Close();
            }
           
        }

        private void testSelectionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTest = (Test)testSelectionComboBox.SelectedItem;
        }
    }
}
