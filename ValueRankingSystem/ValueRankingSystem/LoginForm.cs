using System;
using System.Net.Mail;
using MetroFramework.Forms;
using Users;
using CreateAccount;
using ResultsReporting;
using MetroFramework;
using System.Windows.Forms;
using MetroFramework.Controls;

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
            validateInput(sender);
        }

        private void passwordTextBox_Leave(object sender, EventArgs e)
        {
            //validate password entered. Minimum length 7 characters
            validateInput(sender);
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

        private void validateInput(object sender)
        {
            MetroTextBox mtbSender = (MetroTextBox)sender;
            string strSenderName = mtbSender.Name;
            myErrorProvider.Clear();
            //validate to make sure a valid password was entered as well as a valid email address
            if (strSenderName == "emailTextBox" && !isEmailValid(emailTextBox.Text) && emailTextBox.Text != "")
            {
                loginButton.Enabled = false;
                myErrorProvider.SetError(emailTextBox, "You must enter a valid email address");
                emailTextBox.Focus();
                return;
            }
            if (strSenderName == "passwordTextBox" && passwordTextBox.Text != "" && passwordTextBox.Text.Length < 7)
            {
                loginButton.Enabled = false;
                myErrorProvider.SetError(passwordTextBox, "Passwords must be at least 7 characters");
                passwordTextBox.Focus();
                return;
            } else if(strSenderName == "passwordTextBox" && emailTextBox.Text != "" && passwordTextBox.Text != "") 
            {
                loginButton.Enabled = true;
                loginButton.Focus();
            }
            

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            //All Data is validated, run login info
            //TODO Create login validation
            UserClass user = new UserClass();
            user = user.login(emailTextBox.Text, passwordTextBox.Text);
            if (user.intUserID > 0)
            {
                //send to appropriate form: Admin, User, Therapist
                //TODO: Call appropriate forms.
                switch (user.strRole)
                {
                    case UserClass.ADMIN_ROLE:
                        //AdminForm adminForm = new AdminForm();
                        //adminForm.ShowDiaglog();
                        break;
                    case UserClass.THERAPIST_ROLE:
                        ResultsReportingForm resultForm = new ResultsReportingForm();
                        resultForm.ShowDialog();
                        break;
                    case UserClass.USER_ROLE:
                        //UserTest testForm = new UserTest();
                        //testForm.currentUser = user;
                        //testForm.ShowDialog();
                        break;
                    default:
                        //something seriously went wrong if we hit this
                        break;
                }
                loginButton.Enabled = false;
                passwordTextBox.Text = null;
                emailTextBox.Text = null;
                emailTextBox.Focus();

            } else
            {
                MetroMessageBox.Show(this, "Username/Password Combination not found. Please try again!", "Login Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void createAccountButton_Click(object sender, EventArgs e)
        {
            CreateAccountForm createForm = new CreateAccountForm();
            this.Hide();
            createForm.ShowDialog();
            this.Show();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            emailTextBox.Focus();
        }


    }
}
