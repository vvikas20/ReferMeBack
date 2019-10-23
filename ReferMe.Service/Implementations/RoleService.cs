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
    public class RoleService : IRoleService
    {
        IUnitOfWork _unitOfWork;
        IRoleRepository _roleRepository;

        public RoleService(
            IUnitOfWork unitOfWork,
            IRoleRepository roleRepository)
        {
            this._unitOfWork = unitOfWork;
            this._roleRepository = roleRepository;
        }

        public List<RoleDTO> GetAllRoles()
        {
            List<RoleDTO> roles = new List<RoleDTO>();
            this._roleRepository.GetAll().ToList().ForEach(r => roles.Add(CreateRoleDTO(r)));
            return roles;
        }

        public RoleDTO GetRoleDetail(int roleId)
        {
            return CreateRoleDTO(this._roleRepository.Get(r => r.RoleID == roleId));
        }

        private RoleDTO CreateRoleDTO(Model.Entity.Role roleEntity)
        {
            RoleDTO roleDTO = new RoleDTO();
            if (roleEntity != null)
            {
                roleDTO.RoleID = roleEntity.RoleID;
                roleDTO.RoleName = roleEntity.RoleName;
                roleDTO.RoleDisplayName = roleEntity.RoleDisplayName;
            }
            return roleDTO;
        }
    }
}
