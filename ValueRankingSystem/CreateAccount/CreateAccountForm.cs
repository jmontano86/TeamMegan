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

        private void validateInput(object sender)
        {
            //validate to make sure all inputs are valid before creating new account
            myErrorProvider.Clear();
            MetroTextBox tb = (MetroTextBox)sender;
            switch (tb.Name)
            {
                case "nameTextBox":
                    //check to make sure a username is entered
                    if (nameTextBox.Text == "")
                    {
                        myErrorProvider.SetError(nameTextBox, "Please enter your name");
                        nameTextBox.Focus();
                    }
                    break;
                case "emailTextBox":
                    //check for a valid email address
                    if (!isEmailValid(emailTextBox.Text))
                    {
                        myErrorProvider.SetError(emailTextBox, "You must enter a valid email address");
                        emailTextBox.Focus();
                    }
                    break;
                case "passwordTextBox":
                    //check to make sure password is at least 7 characters
                    if (passwordTextBox.Text.Length < 7)
                    {
                        myErrorProvider.SetError(passwordTextBox, "Password must be at least 7 characters");
                        passwordTextBox.Focus();
                    }
                    break;
                case "reenterPasswordTextBox":
                    if (passwordTextBox.Text != reenterPasswordTextBox.Text)
                    {
                        myErrorProvider.SetError(reenterPasswordTextBox, "Re-Enter Password Confirmation must match Password");
                        reenterPasswordTextBox.Focus();
                        break;
                    }
                    createButton.Enabled = true;
                    break;
            }
        
            
        }
        private void createButton_Click(object sender, EventArgs e)
        {
            UserClass user = new UserClass();
            user = user.createUser(emailTextBox.Text, passwordTextBox.Text, nameTextBox.Text);
            //TODO send User to Taking Test Screen. 
            if(user == null)
            {
                MetroMessageBox.Show(this, "You are already registered!","User Already Exists", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            UserTest testForm = new UserTest();
            testForm.currentUser = user;
            testForm.ShowDialog();
            this.Close();
        }

        private void CreateAccountForm_Load(object sender, EventArgs e)
        {
            nameTextBox.Focus();
        }

        private void nameTextBox_Leave(object sender, EventArgs e)
        {
            validateInput(sender);
        }

        private void emailTextBox_Leave(object sender, EventArgs e)
        {
            validateInput(sender);
        }

        private void passwordTextBox_Leave(object sender, EventArgs e)
        {
            validateInput(sender);
        }

        private void reenterPasswordTextBox_Leave(object sender, EventArgs e)
        {
            validateInput(sender);
        }
    }
}
