using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
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


        private bool isEmailValid(string emailAddress)
        {
            try
            {
                MailAddress mail = new MailAddress(emailAddress);
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
            if (isEmailValid(emailTextBox.Text) && passwordTextBox.Text != "" && passwordTextBox.Text.Length > 7 && nameTextBox.Text != "" &&
                reenterPasswordTextBox.Text != "" && reenterPasswordTextBox.Text == passwordTextBox.Text)
            {
                createButton.Enabled = true;
                return;
            }
            createButton.Enabled = false;
        }
        private void nameTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            validateInput();
        }

        private void reenterPasswordTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            validateInput();
        }

        private void passwordTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            validateInput();
        }

        private void emailTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            validateInput();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            User user = new User();
            user = user.createAccount(emailTextBox.Text, passwordTextBox.Text, nameTextBox.Text);
            //TODO send User to Taking Test Screen. 
            this.Close();
        }

    }
}
