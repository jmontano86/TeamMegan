using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MetroFramework;
using MetroFramework.Forms;
using Users;
using CreateAccount;

namespace ValueRankingSystem
{
    /* Project: Login Form
     * Programmer: Jeremiah Montano
     * Date: October 11, 2018
     * Summary: Allows user to login to application to take test
     * or create an account if user hasn't signed up. Signing up
     * for an account will automatically log user into system
     * to take test. 
     */
    public partial class LoginForm : MetroForm
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void emailTextBox_Leave(object sender, EventArgs e)
        {
            //check to ensure we have both a valid email and a valid password
            validateInput(emailTextBox.Text, passwordTextBox.Text);
        }
        private void passwordTextBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            //validate password entered. Minimum length 8 characters
            //TODO: Validate valid keypress. Ex: No spaces, quotes, semi-colon, etc.
            validateInput(emailTextBox.Text, passwordTextBox.Text);
        }

        private void emailTextBox_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            //TODO: Validate the following characters are not used: Space, quotes, semi-colon, etc.
        }

        private bool isEmailValid(string emailAddress)
        {
            try
            {
                MailAddress mail = new MailAddress(emailAddress);
                return true;
            } catch
            {
                return false;
            }
        }

        private void validateInput(string email, string password)
        {
            //validate to make sure a valid password was entered as well as a valid email address
            if (isEmailValid(emailTextBox.Text) && passwordTextBox.Text != "" && passwordTextBox.Text.Length > 7)
            {
                loginButton.Enabled = true;
                return;
            }
            loginButton.Enabled = false;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            //All Data is validated, run login info
            User user = new User();
            user = user.login(user);
            if (user._id < 0)
            {
                //send to appropriate form: Admin, User, Therapist
                switch (user._role)
                {
                    case User.ADMIN_ROLE:
                        //do stuff
                        break;
                    case User.THERAPIST_ROLE:
                        //do stuff
                        break;
                    case User.USER_ROLE:
                        //do stuff
                        break;
                }

            } else
            {
                //password mismatch, try again
            }
        }

        private void createAccountButton_Click(object sender, EventArgs e)
        {
            CreateAccountForm form = new CreateAccountForm();
            form.ShowDialog();
        }
    }
}
