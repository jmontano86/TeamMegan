using System;
using System.Net.Mail;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework;
using Users;

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

        private void validateInput()
        {
            //validate to make sure all inputs are valid before creating new account
            myErrorProvider.Clear();
            //check to make sure a username is entered
            if(nameTextBox.Text == "")
            {
                myErrorProvider.SetError(nameTextBox, "Please enter your name");
                return;
            }
            //check for a valid email address
            if (!isEmailValid(emailTextBox.Text))
            {
                myErrorProvider.SetError(emailTextBox, "You must enter a valid email address");
                return;
            }
            //check to make sure password is at least 7 characters
            if(passwordTextBox.Text.Length < 7)
            {
                myErrorProvider.SetError(passwordTextBox, "Password must be at least 7 characters");
                return;
            }
            if(reenterPasswordTextBox.Text != "" && passwordTextBox.Text != reenterPasswordTextBox.Text)
            {
                myErrorProvider.SetError(reenterPasswordTextBox, "Re-Enter Password Confirmation must match Password");
                return;
            }
            createButton.Enabled = false;
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
            this.Close();
        }

        private void CreateAccountForm_Load(object sender, EventArgs e)
        {
            nameTextBox.Focus();
        }

        private void nameTextBox_Leave(object sender, EventArgs e)
        {
            validateInput();
        }

        private void emailTextBox_Leave(object sender, EventArgs e)
        {
            validateInput();
        }

        private void passwordTextBox_Leave(object sender, EventArgs e)
        {
            validateInput();
        }

        private void reenterPasswordTextBox_Leave(object sender, EventArgs e)
        {
            validateInput();
        }
    }
}
