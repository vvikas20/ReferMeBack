using ReferMe.DAL.Contracts;
using ReferMe.Model.DTO;
using ReferMe.Repository;
using ReferMe.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferMe.Service.Implementations
{
    public class ReferralService : IReferralService
    {
        IUnitOfWork _unitOfWork;
        IReferralRepository _referralRepository;

        public ReferralService(
            IUnitOfWork unitOfWork,
            IReferralRepository referralRepository)
        {
            this._unitOfWork = unitOfWork;
            this._referralRepository = referralRepository;
        }

        public int AddReferral(ReferralDTO referral)
        {
            Model.Entity.Referral referralEntity = new Model.Entity.Referral();

            referralEntity.ReferralID = getNewReferralId();
            referralEntity.PostID = referral.PostID;
            referralEntity.Subject = referral.Subject;
            referralEntity.Message = referral.Message;
            referralEntity.CreatedBy = referral.CreatedBy;
            referralEntity.CreatedOn = DateTime.Now;

            _referralRepository.Add(referralEntity);

            _unitOfWork.Commit();
            return referralEntity.ReferralID;
        }

        public List<ReferralDTO> ReferralsByPostId(int postId)
        {
            List<ReferralDTO> referralsForPost = new List<ReferralDTO>();
            List<Model.Entity.Referral> referrals = _referralRepository.GetMany(p => p.PostID == postId).ToList();
            foreach (Model.Entity.Referral referral in referrals)
            {
                referralsForPost.Add(new ReferralDTO
                {
                    ReferralID = referral.ReferralID,
                    PostID = referral.PostID,
                    Subject = referral.Subject,
                    Message = referral.Message,
                    CreatedBy = referral.CreatedBy,
                    CreatedByUserDetail = new UserDTO()
                    {
                        FirstName = referral.User.FirstName,
                        MiddleName = referral.User.MiddleName,
                        LastName = referral.User.LastName,
                        EmailAddress = referral.User.EmailAddress,
                        Mobile = referral.User.Mobile

                    },
                    CreatedOn = referral.CreatedOn
                });
            }
            return referralsForPost;
        }

        public List<ReferralDTO> ReferralsByUserId(int userId)
        {
            List<ReferralDTO> referralsCreatedByUser = new List<ReferralDTO>();
            List<Model.Entity.Referral> referrals = _referralRepository.GetMany(p => p.CreatedBy == userId).ToList();
            foreach (Model.Entity.Referral referral in referrals)
            {
                referralsCreatedByUser.Add(new ReferralDTO
                {
                    ReferralID = referral.ReferralID,
                    PostID = referral.PostID,
                    Subject = referral.Subject,
                    Message = referral.Message,
                    CreatedBy = referral.CreatedBy,
                    CreatedByUserDetail = new UserDTO()
                    {
                        FirstName = referral.User.FirstName,
                        MiddleName = referral.User.MiddleName,
                        LastName = referral.User.LastName,
                        EmailAddress = referral.User.EmailAddress,
                        Mobile = referral.User.Mobile

                    },
                    CreatedOn = referral.CreatedOn
                });
            }
            return referralsCreatedByUser;
        }

        public void DeleteReferrals(int userId)
        {
            _referralRepository.Delete(p => p.CreatedBy == userId);
        }

        private int getNewReferralId()
        {
            int referralId = _referralRepository.GetAll().Count() > 0 ? _referralRepository.GetAll().Max(u => u.ReferralID) + 1 : 1;
            return referralId;
        }
    }
}
