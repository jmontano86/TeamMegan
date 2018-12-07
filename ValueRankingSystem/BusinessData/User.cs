using System;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;

namespace BusinessData
{
    public class UserClass
    {
        private int _id;
        private string _username;
        private string _password;
        private string _emailAddress;
        private string _role;

        public const string THERAPIST_ROLE = "T";
        public const string USER_ROLE = "U";
        public const string ADMIN_ROLE = "A";

        public int intUserID
        {
            get {  return this._id; }
            set { this._id = value; }
        }

        public string strUsername
        {
            get { return this._username; }
            set { this._username = value; }
        }

        public string strPassword
        {
            get { return this._password; }
            set { this._password = value; }
        }

        public string strEmailAddress
        {
            get { return this._emailAddress; }
            set { this._emailAddress = value; }
        }

        public string strRole
        {
            get { return this._role; }
            set { this._role = value; }
        }
               
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
                    int intID = 0;
                    Int32.TryParse(strUserItems[0], out intID);
                    intUserID = intID;
                    strUsername = strUserItems[1];
                    strPassword = strUserItems[2];
                    strEmailAddress = strUserItems[3];
                    strRole = strUserItems[4];
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
            string strHashedPassword = hashPassword(strPassword);
            if (!UserClass.search(strEmail))
            {
                int intID = db.CreateAccount(strEmail, strHashedPassword, strUsername);
                if (intID > 0)
                {
                    intUserID = intID;
                    strEmailAddress = strEmail;
                    strPassword = strHashedPassword;
                    strRole = USER_ROLE;
                    this.strUsername = strUsername;
                }

                return this;
            }
            else
            {
                return null;
            }
        }

        public override string ToString()
        {
            //ToString method override to display username for default method
            return strUsername;
        }

        public static bool search(string strEmail)
        {
            //find existing user
            UserDB db = new UserDB();
            List<string> strUsers = new List<string>();
            strUsers = db.LookupUser(strEmail);
            if (strUsers.Count > 0)
            {
                if (strUsers[3] == strEmail)
                {
                    //already registered
                    return true;
                }
            }//not registered, ok to process
            return false;
        }

        public static bool GetUsers(List<UserClass> userList, ref string error)
        {
            return UserDB.GetUsers(userList, ref error);
        }
    }
}
