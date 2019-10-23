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
        int SaveOrUpdateUser(UserDTO customer);
        bool DuplicateEmailAddress(string email);
        IEnumerable<UserDTO> AllUser();
        UserDTO GetUserByEmail(string email);
        void DeleteUser(int userId);
    }
}
