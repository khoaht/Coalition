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
            return transactionRepository.Get.FirstOrDefault(t => t.Id.Equals(Id));
        }

        public Transaction Add(Transaction transaction)
        {
            var result = transactionRepository.Add(transaction);
            transactionRepository.Commit();
            return result;
        }

        public Transaction Update(Transaction transaction)
        {
            return transactionRepository.Update(transaction);
        }

        public bool Delete(Guid Id)
        {
            var delete = Get(Id);
            if (delete != null)
            {
                transactionRepository.Remove(delete);
                return true;
            }
            return false;
        }
    }
}
