using Newtonsoft.Json;
using ReferMe.Common.Contracts;
using ReferMe.Model.DTO;
using ReferMe.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace ReferMe.API.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        ILogService loggerService;
        IUserService _userService;
        IEmailService _emailService;

        public UserController(ILogService loggerService, IUserService userService, IEmailService emailService)
        {
            this.loggerService = loggerService;
            this._userService = userService;
            this._emailService = emailService;
        }

        [HttpPost]
        [Route("validate")]
        public UserDTO Validate(string email, string password)
        {
            loggerService.Logger().Info("Calling with parameter as : email and password: " + email + " and " + password);
            UserDTO user = _userService.ValidateUser(email, password);
            if (user == null)
            {
                string payload = JsonConvert.SerializeObject(new
                {
                    code = HttpStatusCode.Forbidden,
                    message = "Invalid username or password",
                    type = "ERROR"
                });

                var response = new HttpResponseMessage(HttpStatusCode.Forbidden)
                {
                    Content = new StringContent(payload, Encoding.UTF8, "application/json"),
                    StatusCode = HttpStatusCode.Forbidden
                };
                throw new HttpResponseException(response);
            }
            return user;
        }

        [HttpPost]
        [Route("add")]
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

            int userId = _userService.SaveOrUpdateUser(user);
            if (userId > 0)
            {
                _emailService.sendEmail(user.EmailAddress, "Thanks for registering with us.", string.Format("Your userid is {0}, and password is {1} .<br> Follow the link {2}", user.EmailAddress, user.Password, "http://vsvikassingh.co.in/login"));
            }

            return userId;
        }

        [HttpGet]
        [Route("all")]
        public IEnumerable<UserDTO> All()
        {
            return _userService.AllUser();
        }

        [HttpDelete]
        [Route("delete")]
        public void DeleteUser(int userId)
        {
            _userService.DeleteUser(userId);
        }
    }
}
