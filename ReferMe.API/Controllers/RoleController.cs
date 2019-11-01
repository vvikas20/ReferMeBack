using ReferMe.API.Auth;
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
    [RoutePrefix("api/roles")]
    [JwtAuthentication]
    public class RoleController : ApiController
    {
        ILogService loggerService;
        IRoleService _roleService;

        public RoleController(ILogService loggerService, IRoleService roleService)
        {
            this.loggerService = loggerService;
            this._roleService = roleService;
        }

        [HttpGet]
        [Route("all")]
        public IEnumerable<RoleDTO> SystemRoles()
        {
            return _roleService.GetAllRoles();
        }
    }
}
