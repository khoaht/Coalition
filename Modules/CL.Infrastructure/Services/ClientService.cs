using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.Infrastructure.Services;
using Domain.Entity;

namespace CL.Infrastructure.Services
{
    public class ClientService : IClientService
    {
        private readonly IRepository<Client> clientRepository;

        public ClientService(IRepository<Client> clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        public IList<Client> Search(Criterias.ClientCriteria criteria)
        {
            Func<Client, bool> exp = null;
            exp = t => (!string.IsNullOrEmpty(criteria.FirstName) || t.FirstName.Contains(criteria.FirstName))
                        && (!string.IsNullOrEmpty(criteria.LastName) || t.LastName.Contains(criteria.LastName))
                        && (!string.IsNullOrEmpty(criteria.SurName) || t.SurName.Contains(criteria.SurName));

            var result = clientRepository.Get
                        .Where(exp)
                        .OrderBy(t => t.SurName)
                        .ToList();

            return result;
        }

        public Client Get(Guid Id)
        {
            return clientRepository.Get.FirstOrDefault(t => t.Id.Equals(Id));
        }

        public Client Add(Client client)
        {
            var result = clientRepository.Add(client);
            clientRepository.Commit();
            return result;
        }

        public Client Update(Client client)
        {
            return clientRepository.Update(client);
        }

        public bool Delete(Guid Id)
        {
            var delete = Get(Id);
            if (delete != null)
            {
                clientRepository.Remove(delete);
                return true;
            }
            return false;
        }
    }
}
