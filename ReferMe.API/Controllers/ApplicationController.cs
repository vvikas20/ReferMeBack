using Newtonsoft.Json;
using ReferMe.API.Auth;
using ReferMe.Common.Contracts;
using ReferMe.Model.DTO;
using ReferMe.Service.Contracts;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Web.Http;

namespace ReferMe.API.Controllers
{
    [RoutePrefix("api/application")]
    public class ApplicationController : ApiController
    {
        ILogService loggerService;
        IUserService _userService;
        IEmailService _emailService;

        public ApplicationController(ILogService loggerService, IUserService userService, IEmailService emailService)
        {
            this.loggerService = loggerService;
            this._userService = userService;
            this._emailService = emailService;
        }

        [HttpGet]
        [Route("detail")]
        public IHttpActionResult ApplicationDetail()
        {
            return Json(new { heading = "ReferMe Community" });
        }

        [HttpPost]
        [Route("adduser")]
        public int Add(UserDTO user)
        {
            loggerService.Logger().Info("Calling with parameter as : user: " + user);

            if (_userService.DuplicateEmailAddress(user.EmailAddress))
            {
                string payload = JsonConvert.SerializeObject(new
                {
                    code = HttpStatusCode.BadRequest,
                    message = "Email Address already exists",
                    type = "ERROR"
                });

                var response = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(payload, Encoding.UTF8, "application/json"),
                    StatusCode = HttpStatusCode.BadRequest
                };
                throw new HttpResponseException(response);
            }

            int userId = _userService.SaveUser(user);
            if (userId > 0)
            {
                string from = "refermecommunity@gmail.com";
                string to = user.EmailAddress;
                string subject = "Thanks for registering with us.";
                string body = string.Empty;
                using (StreamReader reader = new StreamReader(System.Web.Hosting.HostingEnvironment.MapPath("~/Content/RegistrationTemplate.html")))
                {
                    body = reader.ReadToEnd();
                }
                body = body.Replace("{FIRSTNAME}", user.FirstName);
                body = body.Replace("{USERNAME}", user.EmailAddress);
                body = body.Replace("{PASSWORD}", user.Password);

                _emailService.SendAsyncMail(from, to, subject, body);
            }

            return userId;
        }

    }
}
