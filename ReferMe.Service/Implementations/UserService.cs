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

        public UserService(
            IUnitOfWork unitOfWork,
            IUserRepository userRepository)
        {
            this._unitOfWork = unitOfWork;
            this._userRepository = userRepository;
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

        public int SaveOrUpdateUser(UserDTO user)
        {
            string passwordSalt = CreateSalt(5);
            string pasword = CreatePasswordHash(user.Password, passwordSalt);
            Model.Entity.User objUser;

            if (user.UserID != 0)
                objUser = _userRepository.GetById(user.UserID);
            else
            {
                objUser = new Model.Entity.User();
                objUser.CreatedOnDate = DateTime.Now;
                objUser.UserID = getNewUserId();
            }

            objUser.FirstName = user.FirstName;
            objUser.MiddleName = user.MiddleName;
            objUser.LastName = user.LastName;
            objUser.EmailAddress = user.EmailAddress;
            objUser.Mobile = user.Mobile;
            objUser.PasswordHash = pasword;
            objUser.PasswordSalt = passwordSalt;
            objUser.ModifiedDate = DateTime.Now;

            if (user.UserID != 0)
                _userRepository.Update(objUser);
            else
                _userRepository.Add(objUser);

            _unitOfWork.Commit();
            return objUser.UserID;
        }

        private UserDTO CreateUserDTO(Model.Entity.User customer)
        {
            UserDTO objCustomerDTO = new UserDTO();
            objCustomerDTO.UserID = customer.UserID;
            objCustomerDTO.FirstName = customer.FirstName;
            objCustomerDTO.MiddleName = customer.MiddleName;
            objCustomerDTO.LastName = customer.LastName;
            objCustomerDTO.EmailAddress = customer.EmailAddress;
            objCustomerDTO.Mobile = customer.Mobile;

            return objCustomerDTO;
        }

        private int getNewUserId()
        {
            int userId = _userRepository.GetAll().Count() > 0 ? _userRepository.GetAll().Max(u => u.UserID) + 1 : 1;
            return userId;
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

        public void DeleteUser(int userId)
        {
            _userRepository.Delete(u => u.UserID == userId);
            _unitOfWork.Commit();
        }
    }
}
