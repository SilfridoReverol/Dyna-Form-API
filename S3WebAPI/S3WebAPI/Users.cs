using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using S3WebAPI.Library;
using System.Data;

namespace S3WebAPI.Users
{
    public class UsersClass
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public string sex { get; set; }
        public int age { get; set; }
        public string password { get; set; }

        public int user_role {get; set;}

        public DataSet GetUser(string userName) {
            DbAccess oDb = new DbAccess();
            return oDb.GetUser(userName);
        }

        public string GetForm(string formName) {
            DbAccess oDb = new DbAccess();
            return oDb.GetForm(formName);
        }

    }
}