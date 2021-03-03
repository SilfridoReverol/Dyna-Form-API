using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using S3WebAPI.Library;


namespace S3WebAPI
{
    public class User
    {
        public static bool UserLogin(string username, string password)
        {
            DbAccess oDb = new DbAccess();
            return oDb.UserLogin(username, password).Equals("logged_in");
        }

    }
}