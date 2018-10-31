using System;
using System.Net.Mail;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework;
using Users;
using UserTesting;
using MetroFramework.Controls;

namespace CreateAccount
{
    public partial class CreateAccountForm : MetroForm
    {
        /* Programmer: Jeremiah Montano
         * Date: October 13, 2018
         * Summary: Allows user to create a new account in the system.
         */

        public CreateAccountForm()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            //Close form if user cancels registration, returns to login
            this.Close();
        }


        private bool isEmailValid(string strEmailAddress)
        {
            //Checks to make sure the email address is an email address
            try
            {
                MailAddress mail = new MailAddress(strEmailAddress);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool validateAllInput()
        {
            //Validate input for all form. 
            //this prevents user from using shortcut to delete items
            //and still create account
            myErrorProvider.Clear();
            if (nameTextBox.Text == "")
            {
                createButton.Enabled = false;
                //validate a name was entered
                myErrorProvider.SetError(nameTextBox, "Please enter your name");
                nameTextBox.Focus();
                return false;
            }
            //check for a valid email address
            if (!isEmailValid(emailTextBox.Text))
            {
                createButton.Enabled = false;
                myErrorProvider.SetError(emailTextBox, "You must enter a valid email address");
                emailTextBox.Focus();
                return false;
            }
            //check to make sure password is at least 7 characters
            if (passwordTextBox.Text.Length < 7)
            {
                createButton.Enabled = false;
                myErrorProvider.SetError(passwordTextBox, "Password must be at least 7 characters");
                passwordTextBox.Focus();
                return false;
            }
            if (passwordTextBox.Text != reenterPasswordTextBox.Text)
            {
                createButton.Enabled = false;
                myErrorProvider.SetError(reenterPasswordTextBox, "Re-Enter Password Confirmation must match Password");
                reenterPasswordTextBox.Focus();
                return false;
            }
            return true;

        }
        private void createButton_Click(object sender, EventArgs e)
        {
            if (validateAllInput())
            {
                UserClass user = new UserClass();
                user = user.createUser(emailTextBox.Text, passwordTextBox.Text, nameTextBox.Text);
                //TODO send User to Taking Test Screen. 
                if (user == null)
                {
                    MetroMessageBox.Show(this, "You are already registered!", "User Already Exists", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                UserTest testForm = new UserTest();
                testForm.currentUser = user;
                testForm.ShowDialog();
                this.Close();
            }
        }

        private void CreateAccountForm_Load(object sender, EventArgs e)
        {
            nameTextBox.Focus();
        }

        private void nameTextBox_Leave(object sender, EventArgs e)
        {
            myErrorProvider.Clear();
            if (nameTextBox.Text == "")
            {
                createButton.Enabled = false;
                //validate a name was entered
                myErrorProvider.SetError(nameTextBox, "Please enter your name");
                nameTextBox.Focus();
            }
        }

        private void emailTextBox_Leave(object sender, EventArgs e)
        {
            myErrorProvider.Clear();
            //check for a valid email address
            if (!isEmailValid(emailTextBox.Text))
            {
                createButton.Enabled = false;
                myErrorProvider.SetError(emailTextBox, "You must enter a valid email address");
                emailTextBox.Focus();
            }
        }

        private void passwordTextBox_Leave(object sender, EventArgs e)
        {
            myErrorProvider.Clear();
            //check to make sure password is at least 7 characters
            if (passwordTextBox.Text.Length < 7)
            {
                createButton.Enabled = false;
                myErrorProvider.SetError(passwordTextBox, "Password must be at least 7 characters");
                passwordTextBox.Focus();
            }
            if (passwordTextBox.Text != reenterPasswordTextBox.Text)
            {
                createButton.Enabled = false;
                if(reenterPasswordTextBox.Text != "")
                {
                    myErrorProvider.SetError(reenterPasswordTextBox, "Re-Enter Password Confirmation must match Password");
                }
            }
            
        }

        private void reenterPasswordTextBox_Leave(object sender, EventArgs e)
        {
            myErrorProvider.Clear();
            if (reenterPasswordTextBox.Text == "")
            {
                createButton.Enabled = false;
                return;
            }
            if (passwordTextBox.Text != reenterPasswordTextBox.Text)
            {
                createButton.Enabled = false;
                myErrorProvider.SetError(reenterPasswordTextBox, "Re-Enter Password Confirmation must match Password");
                reenterPasswordTextBox.Focus();
                return;
            }
            createButton.Enabled = true;
            if (createButton.Enabled) createButton.Focus();
        }
    }
}
