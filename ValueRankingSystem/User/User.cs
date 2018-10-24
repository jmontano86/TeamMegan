using System;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
using User;

namespace Users
{
    public class UserClass
    {
        public int _id { get; set; }
        public string _username { get; set; }
        public string _password { get; set; }
        public string _emailAddress { get; set; }
        public string _role { get; set; }

        public const string THERAPIST_ROLE = "T";
        public const string USER_ROLE = "U";
        public const string ADMIN_ROLE = "A";



        public UserClass login(string strEmail, string strPassword)
        {
            UserDB db = new UserDB();
            List<string> strUserItems = new List<string>();
            strUserItems = db.LookupUser(strEmail);
            if (strUserItems.Count > 0)
            {
                //check password to make sure login valid.
                if(hashPassword(strPassword) == strUserItems[2])
                {
                    Int32.TryParse(strUserItems[0], out int intID);
                    this._id = intID;
                    this._username = strUserItems[1];
                    this._password = strUserItems[2];
                    this._emailAddress = strUserItems[3];
                    this._role = strUserItems[4];
                }

            }
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

        public UserClass createUser(string strEmail, string strPassword, string strUsername)
        {
            UserDB db = new UserDB();
            //TODO: Compare database with email address to ensure no prior registration
            string strHashedPassword = hashPassword(strPassword);
            int intID = db.CreateAccount(strEmail, strHashedPassword, strUsername);
            if (intID > 0)
            {
                _id = intID;
                _emailAddress = strEmail;
                _password = strHashedPassword;
                _role = USER_ROLE;
                _username = strUsername;
            }

            return this;
        }

        private bool search(string strEmail)
        {
            //find existing user
            //true for exists
            //false for not exists
            return false;
        }
    }
}
