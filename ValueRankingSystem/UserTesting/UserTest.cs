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
using DataAccessLibrary;
using Users;
using TestSessions;
using ValueRankingSystem; // This is not working. Still trying to figure out a file deletion error that occurred during local merge

namespace UserTesting
{
    public partial class UserTest : MetroForm
    {
        public UserTest()
        {
            InitializeComponent();
        }
        UserClass currentUser = new UserClass();
        List<Test> testItems = new List<Test>();
        List<Item> itemList = new List<Item>();
        private void Form1_Load(object sender, EventArgs e)
        {
            //Get user data
            currentUser = LoginForm.user;
            //Load tests into the radio buttons
            UserTestLogic.UserTestLogic.loadTests(testItems, itemList, currentUser);
            populateRadio();
        }

        // Changes the radio buttons based content in array
        private void populateRadio()
        {
            userChoiceOne.Text = itemList[0].Name;
            userChoiceTwo.Text = itemList[1].Name;
            userChoiceThree.Text = "Undecided";
        }
        private void testButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Get existing test sessions

                if (userChoiceOne.Checked)
                {
                    MessageBox.Show("You chose " + userChoiceOne.Text);
                    //Need to add a function to write to the database
                }
                else if (userChoiceTwo.Checked)
                {
                    MessageBox.Show("You chose " + userChoiceTwo.Text);
                }
                else if (userChoiceThree.Checked)
                {
                    MessageBox.Show("You chose " + userChoiceThree.Text);
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
        
    }
}
