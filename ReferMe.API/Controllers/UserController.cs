using Newtonsoft.Json;
using ReferMe.API.Auth;
using ReferMe.API.Helper;
using ReferMe.API.Models;
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
    [RoutePrefix("api/users")]
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
        [Route("my-detail")]
        public UserDTO GetMyDetails()
        {
            ApplicationUser applicationUser = RequestContext.GetLoggedInUser();
            return _userService.GetUserById(applicationUser.UserID);
        }

        [HttpGet]
        [Route("user-detail")]
        public UserDTO GetUserDetails(int userId)
        {
            return _userService.GetUserById(userId);
        }

        [HttpPut]
        [Route("update")]
        public int UpdateUser(UserDTO user)
        {
            int userId = _userService.UpdateUser(user);
            return userId;
        }

        [HttpDelete]
        [Route("delete")]
        public void DeleteUser(int userId)
        {
            _userService.DeleteUser(userId);
        }
    }
}
