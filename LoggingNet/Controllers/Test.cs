using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;


namespace LoggingNet.Controllers
{
    public class TestController : ApiController
    {
        // GET: api/test
        public IEnumerable<object> Get()
        {
            return new List<object>()
            {
                "TEST"
            };
        }
    }
}