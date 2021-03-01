using ReferMe.API.Auth;
using ReferMe.API.Helper;
using ReferMe.API.Models;
using ReferMe.Common.Contracts;
using ReferMe.Model.DTO;
using ReferMe.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ReferMe.API.Controllers
{
    [RoutePrefix("api/referrals")]
    [JwtAuthentication]
    public class ReferralController : ApiController
    {
        ILogService loggerService;
        IReferralService _referralService;
        IEmailService _emailService;
        IUserService _userService;
        IPostService _postService;

        public ReferralController(ILogService loggerService, IReferralService referralService, IEmailService emailService, IUserService userService, IPostService postService)
        {
            this.loggerService = loggerService;
            this._referralService = referralService;
            this._emailService = emailService;
            this._userService = userService;
            this._postService = postService;
        }

        [HttpPost]
        [Route("add")]
        public int Add(ReferralDTO referral)
        {
            ApplicationUser applicationUser = RequestContext.GetLoggedInUser();
            referral.CreatedBy = applicationUser.UserID;
            var userDetails = _userService.GetUserByUserId(applicationUser.UserID);
            int referrralId = _referralService.AddReferral(referral);

            //Send referral request
            if (referrralId > 0)
            {
                this._emailService.SendAsyncMail(applicationUser.EmailAddress, referral.To, referral.Subject, referral.Message, userDetails.ResumePath);
            }

            return referrralId;
        }

        [HttpGet]
        [Route("referrals")]
        public IEnumerable<ReferralDTO> Get(int postId)
        {
            IEnumerable<ReferralDTO> referrals = _referralService.ReferralsByPostId(postId);
            return referrals;
        }
    }
}
