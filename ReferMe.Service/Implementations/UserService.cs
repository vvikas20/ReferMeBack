using ReferMe.DAL.Contracts;
using ReferMe.Model.DTO;
using ReferMe.Repository;
using ReferMe.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace ReferMe.Service.Implementations
{
    public class UserService : IUserService
    {
        IUnitOfWork _unitOfWork;
        IUserRepository _userRepository;
        IRoleRepository _roleRepository;
        IPostRepository _postRepository;
        IUserRoleMappingRepository _userRoleMappingRepository;

        IPostService _postService;
        IReferralService _referralService;

        public UserService(
            IUnitOfWork unitOfWork,
            IUserRepository userRepository,
            IRoleRepository roleRepository,
            IPostRepository postRepository,
            IUserRoleMappingRepository userRoleMappingRepository,
            IPostService postService,
            IReferralService referralService)
        {
            this._unitOfWork = unitOfWork;
            this._userRepository = userRepository;
            this._roleRepository = roleRepository;
            this._postRepository = postRepository;
            this._userRoleMappingRepository = userRoleMappingRepository;
            this._postService = postService;
            this._referralService = referralService;
        }

        //Below method will create any random strigs of given size. Basically this type of algorithm reads the memory at random locations to form
        //the complete random string each time
        private static string CreateSalt(int size)
        {
            // Generate a cryptographic random number using the cryptographic
            // service provider
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[size];
            rng.GetBytes(buff);
            // Return a Base64 string representation of the random number
            return Convert.ToBase64String(buff);
        }

        //The salt created in above function will be appended to the real password
        //and again SHA1 algorithm will be used to generate the hash which will eventually stored in database
        private static string CreatePasswordHash(string pwd, string salt)
        {
            string saltAndPwd = String.Concat(pwd, salt);
            string hashedPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(saltAndPwd, "SHA1");
            hashedPwd = String.Concat(hashedPwd, salt);
            return hashedPwd;
        }

        public UserDTO ValidateUser(string email, string password)
        {
            Model.Entity.User objUser = _userRepository.Get(user => user.EmailAddress.Equals(email));
            if (objUser == null)
                return null;
            string strPasswordHash = objUser.PasswordHash;
            string strPasswordSalt = strPasswordHash.Substring(strPasswordHash.Length - 8);
            string strPasword = CreatePasswordHash(password, strPasswordSalt);

            if (strPasword.Equals(strPasswordHash))
                return CreateUserDTO(objUser);
            else
                return null;
        }

        public int SaveUser(UserDTO user)
        {
            string passwordSalt = CreateSalt(5);
            string pasword = CreatePasswordHash(user.Password, passwordSalt);

            Model.Entity.User objUser = new Model.Entity.User();
            objUser.UserID = getNewUserId();
            objUser.PasswordHash = pasword;
            objUser.PasswordSalt = passwordSalt;
            objUser.FirstName = user.FirstName;
            objUser.MiddleName = user.MiddleName;
            objUser.LastName = user.LastName;
            objUser.EmailAddress = user.EmailAddress;
            objUser.Mobile = user.Mobile;
            objUser.CreatedOnDate = DateTime.Now;
            objUser.ModifiedDate = DateTime.Now;

            _userRepository.Add(objUser);
            _unitOfWork.Commit();

            Model.Entity.UserRoleMapping roleMapping = new Model.Entity.UserRoleMapping();
            roleMapping.UserRoleMappingID = getNewUserRoleMappingId();
            roleMapping.RoleID = 2;
            roleMapping.UserID = objUser.UserID;

            _userRoleMappingRepository.Add(roleMapping);
            _unitOfWork.Commit();


            return objUser.UserID;
        }

        public int UpdateUser(UserDTO user)
        {
            Model.Entity.User objUser = _userRepository.GetById(user.UserID);
            objUser.FirstName = user.FirstName;
            objUser.MiddleName = user.MiddleName;
            objUser.LastName = user.LastName;
            objUser.EmailAddress = user.EmailAddress;
            objUser.Mobile = user.Mobile;
            objUser.ModifiedDate = DateTime.Now;

            _userRepository.Update(objUser);
            _unitOfWork.Commit();

            Model.Entity.UserRoleMapping userRoleMapping = _userRoleMappingRepository.Get(m => m.UserID == user.UserID);
            userRoleMapping.RoleID = user.UserRoleID;

            _userRoleMappingRepository.Update(userRoleMapping);
            _unitOfWork.Commit();

            return objUser.UserID;
        }


        public int UpdateProfile(UserDTO user)
        {
            Model.Entity.User objUser = _userRepository.GetById(user.UserID);
            objUser.FirstName = user.FirstName;
            objUser.MiddleName = user.MiddleName;
            objUser.LastName = user.LastName;
            objUser.Mobile = user.Mobile;

            if (!string.IsNullOrWhiteSpace(user.ProfilePath)) objUser.ProfileImagePath = user.ProfilePath;
            if (!string.IsNullOrWhiteSpace(user.ResumePath)) objUser.ResumePath = user.ResumePath;

            objUser.ModifiedDate = DateTime.Now;

            _userRepository.Update(objUser);
            _unitOfWork.Commit();

            return objUser.UserID;
        }


        private UserDTO CreateUserDTO(Model.Entity.User user)
        {
            UserDTO objCustomerDTO = new UserDTO();
            if (user != null)
            {
                int roleId = user.UserRoleMapping.First().RoleID;
                objCustomerDTO.UserID = user.UserID;
                objCustomerDTO.FirstName = user.FirstName;
                objCustomerDTO.MiddleName = user.MiddleName;
                objCustomerDTO.LastName = user.LastName;
                objCustomerDTO.EmailAddress = user.EmailAddress;
                objCustomerDTO.Mobile = user.Mobile;
                objCustomerDTO.ProfilePath = user.ProfileImagePath;
                objCustomerDTO.ResumePath = user.ResumePath;
                objCustomerDTO.UserRoleID = this._roleRepository.Get(r => r.RoleID == roleId).RoleID;
                objCustomerDTO.UserRole = this._roleRepository.Get(r => r.RoleID == roleId).RoleName;
            }
            return objCustomerDTO;
        }

        private int getNewUserId()
        {
            int userId = _userRepository.GetAll().Count() > 0 ? _userRepository.GetAll().Max(u => u.UserID) + 1 : 1;
            return userId;
        }

        private int getNewUserRoleMappingId()
        {
            int userRoleMappingId = _userRoleMappingRepository.GetAll().Count() > 0 ? _userRoleMappingRepository.GetAll().Max(u => u.UserRoleMappingID) + 1 : 1;
            return userRoleMappingId;
        }

        public bool DuplicateEmailAddress(string email)
        {
            return _userRepository.GetMany(user => user.EmailAddress.Equals(email, StringComparison.InvariantCultureIgnoreCase)).Count() > 0;
        }

        public IEnumerable<UserDTO> AllUser()
        {
            List<UserDTO> users = new List<UserDTO>();
            _userRepository.GetAll().ToList<Model.Entity.User>().ForEach(u => users.Add(CreateUserDTO(u)));
            return users;
        }

        public UserDTO GetUserByEmail(string email)
        {
            Model.Entity.User user = new Model.Entity.User();
            user = _userRepository.GetAll().FirstOrDefault(u => u.EmailAddress == email);
            return CreateUserDTO(user);
        }

        public void DeleteUser(int userId)
        {
            Model.Entity.User user = _userRepository.Get(u => u.UserID == userId);
            if (user != null)
            {
                //Remove posts
                var posts = _postService.PostsByUserId(userId);
                posts.ForEach(post => _postService.DeletePost(post.PostID));

                //Delete all referral created by user
                _referralService.DeleteReferrals(userId);

                //Delete user role mapping 
                _userRoleMappingRepository.Delete(rm => rm.UserID == userId);

                //Now Delete user object
                _userRepository.Delete(u => u.UserID == userId);
                _unitOfWork.Commit();
            }

        }

        public UserDTO GetUserByUserId(int userId)
        {
            Model.Entity.User user = new Model.Entity.User();
            user = _userRepository.GetAll().FirstOrDefault(u => u.UserID == userId);
            return CreateUserDTO(user);
        }
    }
}
