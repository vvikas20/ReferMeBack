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

        public ReferralController(ILogService loggerService, IReferralService referralService)
        {
            this.loggerService = loggerService;
            this._referralService = referralService;
        }

        [HttpPost]
        [Route("add")]
        public int Add(ReferralDTO referral)
        {
            ApplicationUser applicationUser = RequestContext.GetLoggedInUser();
            referral.CreatedBy = applicationUser.UserID;

            int postId = _referralService.AddReferral(referral);
            return postId;
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
