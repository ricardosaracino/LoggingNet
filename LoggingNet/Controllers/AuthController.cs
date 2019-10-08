using System;
using System.Web;
using System.Web.Http;
using LoggingNet.Models;

namespace LoggingNet.Controllers
{
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        [HttpGet, Route("login")]
        public void GetLogin()
        {
            var currentUser = new CurrentUser()
            {
                Id = Guid.NewGuid()
            };

            HttpContext.Current.Session.Add("currentUser", currentUser);
            
        }
    }
}