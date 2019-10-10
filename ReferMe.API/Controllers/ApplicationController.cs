using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace ReferMe.API.Controllers
{
    [RoutePrefix("api/application")]
    public class ApplicationController : ApiController
    {
        [HttpGet]
        [Route("detail")]
        public IHttpActionResult ApplicationDetail()
        {
            return Json(new { heading = "ReferMe Community" });
        }
    }
}
