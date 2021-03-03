using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Security.Claims;
using S3WebAPI.Users;
using S3WebAPI.Library;
using Newtonsoft.Json;
using System.Data;
using System.Web.Http.Results;



namespace S3WebAPI.Controllers
{
    public class TestController : ApiController
    {


        //[Authorize(Roles = "SuperAdmin, Admin, User")]
        [HttpGet]
        [Route("api/test/register")]
        [HttpPost]
        public HttpResponseMessage Register(UsersClass user)
        {
            var identity = (ClaimsIdentity)User.Identity;
            //var roles = identity.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);

            DbAccess oDb = new DbAccess();
            var response = oDb.Register(user);


            //myclass.Role = "superadmin"; //roles.ToString();
            //myclass.Name = identity.Name;

            if (response.Equals("Ok"))
            {
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            else {
                return Request.CreateResponse(HttpStatusCode.Conflict, response);
            }
            
        }



        [Authorize]
        [HttpGet]
        [Route("api/test/getuser")]
        [HttpPost]
        public JsonResult<DataTable> GetUser([FromBody]UsersClass user)
        {
            var identity = (ClaimsIdentity)User.Identity;
            UsersClass oUser = new UsersClass();
            return Json(oUser.GetUser(user.userName).Tables[0]);
        }


        [HttpGet]
        [Route("api/test/GetForm")]
        [HttpPost]
        public string GetForm(string formName)
        {
            var identity = (ClaimsIdentity)User.Identity;
            UsersClass oUser = new UsersClass();
            return oUser.GetForm(formName);
        }



        [HttpGet]
        [Route("api/test/GetForms")]
        [HttpPost]
        public JsonResult<DataTable> GetForms()
        {
            var identity = (ClaimsIdentity)User.Identity;
            UsersClass oUser = new UsersClass();
            DbAccess oDb = new DbAccess();
            return Json(oDb.GetForms().Tables[0]);
        }





        //[Authorize(Roles = "SuperAdmin, Admin, User")]
        //[HttpGet]
        //[Route("api/test/method1")]
        //[HttpPost]
        //public HttpResponseMessage Post(MyClass myclass)
        //{
        //    var identity = (ClaimsIdentity)User.Identity;
        //    var roles = identity.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);

        //    myclass.Role = "superadmin"; //roles.ToString();
        //    myclass.Name = identity.Name;

        //    UsersClass oUsr = new UsersClass();


        //    return Request.CreateResponse(HttpStatusCode.Created, Json(oDb.getTopItems(top).Tables[0]));
        //}


        [Authorize]
        [HttpGet]
        [Route("api/test/method2")]
        [HttpPost]
        public HttpResponseMessage GetMyName()
        {
            //var identity = (ClaimsIdentity)User.Identity;
            //var roles = identity.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);

            //myclass.Role = "superadmin"; //roles.ToString();
            //myclass.Name = identity.Name;

            return Request.CreateResponse(HttpStatusCode.OK, "Silfrido");
        }

        //[Authorize(Roles = "SuperAdmin, Admin, User")]
        //[HttpGet]
        //[Route("api/test/method2")]
        //public HttpResponseMessage GetValue(MyClass myclass)
        //{
        //    var identity = (ClaimsIdentity)User.Identity;
        //    var roles = identity.Claims
        //                .Where(c => c.Type == ClaimTypes.Role)
        //                .Select(c => c.Value);

        //    myclass.Role = roles.ToString();
        //    myclass.Name = identity.Name;

        //    return Request.CreateResponse(HttpStatusCode.Created, myclass);
        //}
    }
}

