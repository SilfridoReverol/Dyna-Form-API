using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DynamicFormGenerator.Models;

namespace DynamicFormGenerator.BusinessLogic
{
    public class DBAccessClass
    {
        

        protected void test() {
            UserClass oUsr = new UserClass();
            oUsr.Id = 1;
            oUsr.firstName = "Enrique";
            var Nombre = oUsr.firstName;
        }
    }
}