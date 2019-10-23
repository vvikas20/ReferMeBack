using Newtonsoft.Json;
using ReferMe.API.Auth;
using ReferMe.Common.Contracts;
using ReferMe.Model.DTO;
using ReferMe.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Web.Http;

namespace ReferMe.API.Controllers
{
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        ILogService loggerService;
        IUserService _userService;

        public AuthController(ILogService loggerService, IUserService userService)
        {
            this.loggerService = loggerService;
            this._userService = userService;
        }

        [HttpPost]
        [Route("token")]
        public HttpResponseMessage Validate(string email, string password)
        {
            loggerService.Logger().Info("Calling with parameter as : email and password: " + email + " and " + password);
            UserDTO user = _userService.ValidateUser(email, password);
            if (user == null)
            {
                var errorPayload = new
                {
                    code = HttpStatusCode.Forbidden,
                    message = "Invalid username or password",
                    type = "ERROR"
                };

                return Request.CreateResponse(HttpStatusCode.Unauthorized, errorPayload, Configuration.Formatters.JsonFormatter);
            }

            var tokenPayload = new
            {
                access_token = JwtAuthManager.GenerateJWTToken(user)
            };

            return Request.CreateResponse(HttpStatusCode.OK, tokenPayload, Configuration.Formatters.JsonFormatter);
        }
    }
}
