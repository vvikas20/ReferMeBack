using ReferMe.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferMe.Service.Contracts
{
    public interface IReferralService
    {
        int AddReferral(ReferralDTO referral);
        List<ReferralDTO> ReferralsByPostId(int postId);
        void DeleteReferrals(int userId);
        List<ReferralDTO> ReferralsByUserId(int userId);
    }
}
