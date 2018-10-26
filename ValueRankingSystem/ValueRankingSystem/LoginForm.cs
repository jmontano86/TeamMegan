using System;
using System.Net.Mail;
using MetroFramework.Forms;
using Users;
using CreateAccount;
using MetroFramework;
using System.Windows.Forms;

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
            validateInput();
        }
        private void passwordTextBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            //validate password entered. Minimum length 8 characters
            validateInput();
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

        private void validateInput()
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
            //TODO Create login validation
            UserClass user = new UserClass();
            user = user.login(emailTextBox.Text, passwordTextBox.Text);
            if (user._id > 0)
            {
                //send to appropriate form: Admin, User, Therapist
                //TODO: Call appropriate forms.
                switch (user._role)
                {
                    case UserClass.ADMIN_ROLE:
                        //AdminForm adminForm = new AdminForm();
                        //adminForm.User = user;
                        //adminForm.ShowDiaglog();
                        break;
                    case UserClass.THERAPIST_ROLE:
                        //ResultsForm resultForm = new ResultsForm();
                        //resultForm.User = user;
                        //resultForm.ShowDiaglog();
                        break;
                    case UserClass.USER_ROLE:
                        UserTest testForm = new UserTest();
                        testForm.currentUser = user;
                        testForm.ShowDialog();
                        break;
                    default:
                        //something seriously went wrong if we hit this
                        break;
                }

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
