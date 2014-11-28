using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.Infrastructure.Services;
using Domain.Entity;

namespace CL.Infrastructure.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IRepository<Transaction> transactionRepository;

        public TransactionService(IRepository<Transaction> transactionRepository)
        {
            this.transactionRepository = transactionRepository;
        }



        public IList<Transaction> Search(Criterias.TransactionCriteria criteria)
        {
            Func<Transaction, bool> exp = null;
            exp = t => (criteria.CompanyId == null || criteria.CompanyId.Equals(t.CompanyId))
                       && (criteria.DateTime == null || criteria.DateTime.Equals(t.DateTime))
                       && (!string.IsNullOrEmpty(criteria.DestinationCard) || criteria.DestinationCard.Equals(t.DestinationCard));

            var result = transactionRepository.Get
                        .Where(exp)
                        .OrderByDescending(t => t.DateTime)
                        .ToList();

            return result;
        }

        public Transaction Get(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Transaction Add(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public Transaction Update(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
