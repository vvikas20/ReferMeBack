using Newtonsoft.Json;
using ReferMe.API.Auth;
using ReferMe.API.Helper;
using ReferMe.API.Models;
using ReferMe.Common.Contracts;
using ReferMe.Model.DTO;
using ReferMe.Service.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Web;
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
            return _userService.GetUserByUserId(applicationUser.UserID);
        }

        [HttpGet]
        [Route("user-detail")]
        public UserDTO GetUserDetails(int userId)
        {
            return _userService.GetUserByUserId(userId);
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

        [HttpGet]
        [Route("user-profile")]
        public UserDTO UserProfile(int userId)
        {
            var user = _userService.GetUserByUserId(userId);

            if (!string.IsNullOrWhiteSpace(user.ProfilePath))
            {
                string filePath = System.Web.Hosting.HostingEnvironment.MapPath(user.ProfilePath);
                if (File.Exists(filePath))
                {
                    byte[] fileData = File.ReadAllBytes(filePath);
                    user.Profile = fileData;
                }
            }

            if (!string.IsNullOrWhiteSpace(user.ResumePath))
            {
                string filePath = System.Web.Hosting.HostingEnvironment.MapPath(user.ResumePath);
                if (File.Exists(filePath))
                {
                    byte[] fileData = File.ReadAllBytes(filePath);
                    user.Resume = fileData;
                }
            }

            return user;
        }

        [HttpPut]
        [Route("update-profile")]
        public int UpdateUserProfile()
        {
            var httpRequest = HttpContext.Current.Request;
            ApplicationUser applicationUser = RequestContext.GetLoggedInUser();

            var user = new UserDTO()
            {
                UserID = applicationUser.UserID,
                FirstName = httpRequest.Params["firstName"],
                MiddleName = httpRequest.Params["middleName"],
                LastName = httpRequest.Params["lastName"],
                Mobile = httpRequest.Params["mobile"]
            };

            var profileImageFile = httpRequest.Files["profileImageFile"];
            var resumeFile = httpRequest.Files["resumeFile"];

            if (profileImageFile != null)
            {
                string ext = profileImageFile.FileName.Substring(profileImageFile.FileName.LastIndexOf('.'));
                string extension = ext.ToLower();
                string guid = System.Guid.NewGuid().ToString();
                string newFileName = string.Format("{0}{1}", guid, extension);
                var filePath = System.Web.Hosting.HostingEnvironment.MapPath(string.Format("~/Content/ProfileImage/{0}", newFileName));
                profileImageFile.SaveAs(filePath);

                user.ProfilePath = string.Format("~/Content/ProfileImage/{0}", newFileName);
            }

            if (resumeFile != null)
            {
                string ext = resumeFile.FileName.Substring(resumeFile.FileName.LastIndexOf('.'));
                string extension = ext.ToLower();
                string guid = System.Guid.NewGuid().ToString();
                string newFileName = string.Format("{0}{1}", guid, extension);
                var filePath = System.Web.Hosting.HostingEnvironment.MapPath(string.Format("~/Content/Resume/{0}", newFileName));
                resumeFile.SaveAs(filePath);

                user.ResumePath = string.Format("~/Content/Resume/{0}", newFileName);
            }

            int userId = _userService.UpdateProfile(user);
            return userId;
        }

    }
}
