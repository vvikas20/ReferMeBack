using ReferMe.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferMe.Service.Contracts
{
    public interface IRoleService
    {
        RoleDTO GetRoleDetail(int roleId);
        List<RoleDTO> GetAllRoles();
    }
}
