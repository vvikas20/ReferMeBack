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
            List<CompanyDTO> companies = new List<CompanyDTO>();
            this._companyRepository.GetAll().ToList().ForEach(c => companies.Add(new CompanyDTO()
            {
                CompanyID = c.CompanyID,
                CompanyName = c.CompanyName,
                Active = c.Active
            }));

            return companies.Where(company => company.Active).ToList();
        }
    }
}
