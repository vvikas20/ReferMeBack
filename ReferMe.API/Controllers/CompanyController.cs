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
    [RoutePrefix("api/companies")]
    [JwtAuthentication]
    public class CompanyController : ApiController
    {
        ILogService loggerService;
        ICompanyService _companyService;

        public CompanyController(ILogService loggerService, ICompanyService companyService)
        {
            this.loggerService = loggerService;
            this._companyService = companyService;
        }

        [HttpGet]
        [Route("all")]
        public IEnumerable<CompanyDTO> Companies()
        {
            return _companyService.GetAllCompanies();
        }
    }
}
