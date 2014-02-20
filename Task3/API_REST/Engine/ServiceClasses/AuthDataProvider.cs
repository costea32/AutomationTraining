using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API_REST
{
    class AuthDataProvider
    {
        string username = "ikulpin";
        string password = "bla33com";

        public string AuthorizationString
        {
            get
            {
                string auth = string.Format("{0}:{1}", username, password);
                string enc = Convert.ToBase64String(Encoding.ASCII.GetBytes(auth));
                string cred = string.Format("{0} {1}", "Basic", enc);
                return cred;
            }
        }

        public string Username
        { get { return username; } }

        public void setUsername(string usrname)
        {
            this.username = usrname;
        }

        public void setPassword(string pwd)
        {
            this.password = pwd;
        }


    }
}
