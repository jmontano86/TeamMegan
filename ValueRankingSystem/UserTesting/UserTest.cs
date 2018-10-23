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
using UserTestLogic;

namespace UserTesting
{
    public partial class UserTest : MetroForm
    {
        public UserTest()
        {
            InitializeComponent();
        }
        // Test Variables
        public string firstItem;
        public string secondItem;
        public string thirdItem;
        public string userName;
        public bool stringExist;
        Object[] TestTakerInfo = new object[4];
        private void Form1_Load(object sender, EventArgs e)
        {
            // Sample Data
            firstItem = "Blue";
            secondItem = "Green";
            thirdItem = "Can't Decide";
            userName = "Demo User";
            UserTestLogic.UserTestLogic.populateObjectArray();
            populateRadio();
            checkArray(TestTakerInfo);
        }

        // Changes the radio buttons based content in array
        private void populateRadio()
        {
            userChoiceOne.Text = TestTakerInfo[1].ToString();
            userChoiceTwo.Text = TestTakerInfo[2].ToString();
            userChoiceThree.Text = TestTakerInfo[3].ToString();
        }
        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                // Looks to see if there are any available tests
                // Need to ask the instructor if the same test can be reused
                if (userChoiceOne.Checked)
                {
                    MessageBox.Show("You chose " + TestTakerInfo[1].ToString());
                    //Need to add a function to write to the database
                }
                else if (userChoiceTwo.Checked)
                {
                    MessageBox.Show("You chose " + TestTakerInfo[2].ToString());
                }
                else if (userChoiceThree.Checked)
                {
                    MessageBox.Show("You chose " + TestTakerInfo[3].ToString());
                }
                else
                {
                    MessageBox.Show("Please make a choice");
                }
            }
            catch
            {
                MessageBox.Show("Something went wrong with the display");
            }
        }
        private void addChoiceToDb()
        {
            // Push choice to DB after the user clicks on finish
        }
        // Check to see if the array has any values
        public static void checkArray(Object[] TestTakerInfo)
        {
            bool stringExist = true;
            int counter = 0;
            foreach (var stringItem in TestTakerInfo)
            {
                counter++;
                if (TestTakerInfo[counter-1] == null)
                {
                    stringExist = false;
                }
            }
            if (stringExist == false)
            {
                MessageBox.Show("Unable to load test and user data");
            }
        }
    }
}
