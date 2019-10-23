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
    [RoutePrefix("api/user")]
    [JwtAuthentication]
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

        [HttpGet]
        [Route("all")]
        public IEnumerable<UserDTO> All()
        {
            return _userService.AllUser();
        }

        [HttpGet]
        [Route("mydetails")]
        public UserDTO GetMyDetails()
        {
            string loggedInUserEmail = (Request.GetRequestContext().Principal.Identity as ClaimsIdentity).FindFirst(ClaimTypes.Email).Value;
            return _userService.GetUserByEmail(loggedInUserEmail);
        }

        [HttpDelete]
        [Route("delete")]
        public void DeleteUser(int userId)
        {
            _userService.DeleteUser(userId);
        }
    }
}
