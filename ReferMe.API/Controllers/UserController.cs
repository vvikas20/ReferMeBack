using ReferMe.Model.Login;
using ReferMe.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ReferMe.API.Controllers
{
    public class UserController : ApiController
    {
        [HttpPost]
        [Route("api/user/validate")]
        public User validate([FromBody] Login login)
        {
            User loggedInUserDetail = null;

            if (login.UserName == "vvikas20" && login.Password == "vvikas20")
                loggedInUserDetail = new User()
                {
                    FirstName = "vikas",
                    LastName = "singh",
                    UserName = "vvikas20",
                    Email = "vsvikassingh49@gmail.com"
                };

            return loggedInUserDetail;
        }
    }
}
