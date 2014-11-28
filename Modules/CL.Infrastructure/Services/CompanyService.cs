using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.Infrastructure.Services;
using Domain.Entity;

namespace CL.Infrastructure.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IRepository<Company> companyRepository;

        public CompanyService(IRepository<Company> companyRepository)
        {
            this.companyRepository = companyRepository;
        }



        public IList<Company> Search(Criterias.CompanyCriteria criteria)
        {
            Func<Company, bool> exp = null;
            exp = t => (!string.IsNullOrEmpty(criteria.Name) || t.Name.Equals(criteria.Name));

            var result = companyRepository.Get
                        .Where(exp)
                        .OrderBy(t => t.Name)
                        .ToList();

            return result;
        }


        public Company Get(Guid Id)
        {
            return companyRepository.Get.FirstOrDefault(t => t.Id.Equals(Id));
        }

        public Company Add(Company company)
        {
            var result = companyRepository.Add(company);
            companyRepository.Commit();
            return result;
        }

        public Company Update(Company company)
        {
            return companyRepository.Update(company);
        }

        public bool Delete(Guid Id)
        {
            var delete = Get(Id);
            if (delete != null)
            {
                companyRepository.Remove(delete);
                return true;
            }
            return false;
        }
    }
}
