using System;
using Database;
using System.Security.Cryptography;
using System.Text;

namespace Users
{
    public class User
    {
        public int _id { get; set; }
        public string _username { get; set; }
        public string _password { get; set; }
        public string _emailAddress { get; set; }
        public string _role { get; set; }

        public const string THERAPIST_ROLE = "Therapist";
        public const string USER_ROLE = "User";
        public const string ADMIN_ROLE = "Admin";
        public User()
        {

        }


        public User login(User user)
        {
            //TODO: Build login script. This will query from database to pull email address
            return user;
        }

        public User createAccount(string strEmail, string strPassword, string strUsername)
        {
            var bytes = new UTF8Encoding().GetBytes(strPassword);
            byte[] hashBytes;
            using (var algorithm = new System.Security.Cryptography.SHA512Managed())
            {
                hashBytes = algorithm.ComputeHash(bytes);
            }
            string strHashedPassword = Convert.ToBase64String(hashBytes);
            DatabaseHelper db = new DatabaseHelper();
            int intID = db.CreateAccount(strEmail, strHashedPassword, strUsername);
            if (intID > 0)
            {
                _id = intID;
                _emailAddress = strEmail;
                _password = strHashedPassword;
                _role = "User";
                _username = strUsername;
            }

            return this;
        }
    }
}
