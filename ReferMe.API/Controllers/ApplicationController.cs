using Newtonsoft.Json;
using ReferMe.API.Auth;
using ReferMe.Common.Contracts;
using ReferMe.Model.DTO;
using ReferMe.Service.Contracts;
using System.Collections.Generic;
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
                string messageBody = string.Format("Your user id is {0}, and password is {1} .<br> Follow the link {2}", user.EmailAddress, user.Password, "http://vsvikassingh.co.in");

                _emailService.SendAsyncMail(from, to, subject, messageBody);
            }

            return userId;
        }

    }
}
