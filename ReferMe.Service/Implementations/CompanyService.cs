using ReferMe.Common.Helper;
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
    public class CompanyService : ICompanyService
    {
        IUnitOfWork _unitOfWork;
        ICompanyRepository _companyRepository;

        public CompanyService(
            IUnitOfWork unitOfWork,
            ICompanyRepository roleRepository)
        {
            this._unitOfWork = unitOfWork;
            this._companyRepository = roleRepository;
        }

        public List<CompanyDTO> GetAllCompanies()
        {
            var predicate = PredicateBuilder.True<Model.Entity.Company>();
            predicate = predicate.And(i => i.Active);
            List<Model.Entity.Company> queryResult = _companyRepository.GetMany(predicate).ToList();

            List<CompanyDTO> companies = new List<CompanyDTO>();
            queryResult.ForEach(c => companies.Add(new CompanyDTO()
            {
                CompanyID = c.CompanyID,
                CompanyName = c.CompanyName,
                Active = c.Active
            }));

            return companies;
        }
    }
}
