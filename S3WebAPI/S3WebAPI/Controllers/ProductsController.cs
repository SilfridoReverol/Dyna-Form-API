using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using S3WebAPI.Models;
using S3WebAPI.Library;
using Newtonsoft.Json;
using System.Data;
using System.Web.Http.Results;


namespace S3WebAPI.Controllers
{

    public class ProductsController : ApiController
    {
        public JsonResult<DataTable> GetAllProducts(int top) {
            DbAccess oDb = new DbAccess();
            return Json(oDb.getTopItems(top).Tables[0]);
        }
    }


}
