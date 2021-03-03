using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using S3WebAPI.Library;

namespace S3WebAPI
{
    public class UserAuthentication : IDisposable
    {
        public string ValidateUser(string username, string password) {
            DbAccess oDb = new DbAccess();
            if (oDb.UserLogin(username, password).Equals("logged_in"))
                return "true";
            else 
                return "false";
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}