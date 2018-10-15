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

        public const string THERAPIST_ROLE = "T";
        public const string USER_ROLE = "U";
        public const string ADMIN_ROLE = "A";



        public User login(string strEmail, string strPassword)
        {
            DatabaseHelper db = new DatabaseHelper();
            //TODO: LookupUser and match password hash
            return this;
        }

        private string hashPassword(string strPassword)
        {
            var bytes = new UTF8Encoding().GetBytes(strPassword);
            byte[] hashBytes;
            using (var algorithm = new SHA512Managed())
            {
                hashBytes = algorithm.ComputeHash(bytes);
            }
            return Convert.ToBase64String(hashBytes);
        }

        public User createAccount(string strEmail, string strPassword, string strUsername)
        {
            DatabaseHelper db = new DatabaseHelper();
            //TODO: Compare database with email address to ensure no prior registration
            string strHashedPassword = hashPassword(strPassword);
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
