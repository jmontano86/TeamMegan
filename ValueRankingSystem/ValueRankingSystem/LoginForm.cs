using System;
using System.Net.Mail;
using MetroFramework.Forms;
using Users;
using CreateAccount;
using ResultsReporting;
using AdminForm;
using MetroFramework;
using System.Windows.Forms;
using MetroFramework.Controls;
using UserTesting;

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
            myErrorProvider.Clear();
            //check to ensure we have both a valid email and a valid password
            if (!isEmailValid(emailTextBox.Text) && emailTextBox.Text != "")
            {
                loginButton.Enabled = false;
                myErrorProvider.SetError(emailTextBox, "You must enter a valid email address");
                emailTextBox.Focus();
                return;
            }
        }
        private void passwordTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (passwordTextBox.Text != "" && passwordTextBox.Text.Length < 7)
            {
                loginButton.Enabled = false;
                myErrorProvider.SetError(passwordTextBox, "Passwords must be at least 7 characters");
                passwordTextBox.Focus();
                return;
            }
            else if (emailTextBox.Text != "" && passwordTextBox.Text != "")
            {
                myErrorProvider.Clear();
                loginButton.Enabled = true;
            }
            else
            {
                loginButton.Enabled = false;
            }
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

        private void loginButton_Click(object sender, EventArgs e)
        {
            //All Data is validated, run login info
            UserClass user = new UserClass();
            user = user.login(emailTextBox.Text, passwordTextBox.Text);
            if (user.intUserID > 0)
            {
                this.Hide();
                //send to appropriate form: Admin, User, Therapist
                //TODO: Call appropriate forms.
                switch (user.strRole)
                {
                    case UserClass.ADMIN_ROLE:
                        AdminForm.AdminForm adminForm = new AdminForm.AdminForm();
                        adminForm.ShowDialog();
                        break;
                    case UserClass.THERAPIST_ROLE:
                        ResultsReportingForm resultForm = new ResultsReportingForm();
                        resultForm.ShowDialog();
                        break;
                    case UserClass.USER_ROLE:
                        UserTest testForm = new UserTest();
                        testForm.currentUser = user;
                        testForm.ShowDialog();
                        break;
                }
                this.Show();
                this.Activate();
                loginButton.Enabled = false;
                passwordTextBox.Text = null;
                emailTextBox.Text = null;
                emailTextBox.Focus();

            } else
            {
                MetroMessageBox.Show(this, "Username/Password Combination not found. Please try again!", "Login Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                passwordTextBox.Focus();
                passwordTextBox.SelectAll();
            }
        }

        private void createAccountButton_Click(object sender, EventArgs e)
        {
            CreateAccountForm createForm = new CreateAccountForm();
            this.Hide();
            createForm.ShowDialog();
            this.Show();
            this.Activate();
            emailTextBox.Focus();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.Activate();
        }


    }
}
