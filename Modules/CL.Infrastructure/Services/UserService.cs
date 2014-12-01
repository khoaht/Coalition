using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.Infrastructure.Services;
using Domain.Entity;
using System.Data.Entity;
namespace CL.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> userRepository;

        public UserService(IRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }



        public IList<User> Search(Criterias.UserCriteria criteria)
        {
            Func<User, bool> exp = null;
            exp = t => (criteria.CompanyId == null || t.CompanyId.Equals(criteria.CompanyId));

            var result = userRepository.Get
                        .Where(exp)
                        .OrderBy(t => t.FirstName)
                        .ToList();

            return result;
        }

        public User Get(string Id)
        {
            return userRepository.Get
                .Include(t=>t.Company)
                .FirstOrDefault(t => t.Id.Equals(Id));
        }

        public User Add(User user)
        {
            var result = userRepository.Add(user);
            userRepository.Commit();
            return result;
        }

        public User Update(User user)
        {
            return userRepository.Update(user);
        }

        public bool Delete(string Id)
        {
            var delete = Get(Id);
            if (delete != null)
            {
                userRepository.Remove(delete);
                return true;
            }
            return false;
        }
    }
}
