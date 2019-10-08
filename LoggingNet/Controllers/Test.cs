using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;


namespace LoggingNet.Controllers
{
    public class Test : Controller
    {
        public IEnumerable<object> Get()
        {
            var context = System.Web.HttpContext.Current;
            context.Session.Add("id", (Guid.NewGuid()).ToString());

            return new List<object>();
        }
    }
}