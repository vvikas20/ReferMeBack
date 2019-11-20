using ReferMe.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferMe.Service.Contracts
{
    public interface IUserService
    {
        UserDTO ValidateUser(string email, string password);
        int SaveUser(UserDTO user);
        int UpdateUser(UserDTO user);
        int UpdateProfile(UserDTO user);
        bool DuplicateEmailAddress(string email);
        IEnumerable<UserDTO> AllUser();
        UserDTO GetUserByEmail(string email);
        UserDTO GetUserByUserId(int userId);
        void DeleteUser(int userId);
    }
}
