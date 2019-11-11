using ReferMe.API.Models;
using ReferMe.Model.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace ReferMe.API.Helper
{
    public static class Helper
    {
        public static ApplicationUser GetLoggedInUser(this HttpRequestContext requestContext)
        {
            ClaimsPrincipal principal = requestContext.Principal as ClaimsPrincipal;
            var claims = principal.Claims.Select(x => new { type = x.Type, value = x.Value });

            var UserID = claims.Where(x => x.type == "UserID").FirstOrDefault().value;
            var EmailAddress = claims.Where(x => x.type == "EmailAddress").FirstOrDefault().value;
            var UserRole = claims.Where(x => x.type == "UserRole").FirstOrDefault().value;
            var FirstName = claims.Where(x => x.type == "FirstName").FirstOrDefault().value;
            var MiddleName = claims.Where(x => x.type == "MiddleName").FirstOrDefault().value;
            var LastName = claims.Where(x => x.type == "LastName").FirstOrDefault().value;
            var Mobile = claims.Where(x => x.type == "Mobile").FirstOrDefault().value;

            return new ApplicationUser()
            {
                UserID = Int32.Parse(UserID),
                EmailAddress = EmailAddress,
                UserRole = UserRole,
                FirstName = FirstName,
                MiddleName = MiddleName,
                LastName = LastName,
                Mobile = Mobile
            };
        }
    }
}