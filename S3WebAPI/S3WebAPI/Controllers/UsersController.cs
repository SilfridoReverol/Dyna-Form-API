using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using S3WebAPI.Library;


namespace S3WebAPI.Controllers
{
    public class UsersController : ApiController
    {

        [HttpPost]
        public HttpResponseMessage Authenticate([FromBody] Usuario oUsr)
        {
            DbAccess oDb = new DbAccess();
            var message = new HttpResponseMessage();
            if (oDb.UserLogin(oUsr.username, oUsr.password).Equals("logged_in"))
                {
                message = Request.CreateResponse(HttpStatusCode.OK,"200");
                }
            else
                message = Request.CreateResponse(HttpStatusCode.NotFound);
            return message;
        }


        public HttpResponseMessage CreateUser([FromBody] Usuario oUsr)
        {
            DbAccess oDb = new DbAccess();
            var message = new HttpResponseMessage();
            if (oDb.UserLogin(oUsr.username, oUsr.password).Equals("logged_in"))
            {
                message = Request.CreateResponse(HttpStatusCode.OK);
            }
            else
                message = Request.CreateResponse(HttpStatusCode.NotFound);
            return message;
        }


        public class Usuario {
            public string username { get; set; }
            public string password { get; set; }
        }
    }
}
