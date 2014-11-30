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
            exp = t => (criteria.CompanyId == null || t.CompanyId.Equals(criteria.CompanyId))
                       && (criteria.DateTime == null || t.DateTime.Equals(criteria.DateTime))
                       && (criteria.SourceCard == null || t.SourceCard.Equals(t.SourceCard))
                       && (criteria.DestinationCard == null || t.DestinationCard.Equals(criteria.DestinationCard));

            var result = transactionRepository.Get
                        .Where(exp)
                        .OrderByDescending(t => t.DateTime)
                        .Select(t => new Transaction()
                        {
                            CompanyId = t.CompanyId,
                            DateTime = t.DateTime,
                            DestinationCard = t.DestinationCard,
                            Id = t.Id,
                            OriginalPoints = t.OriginalPoints,
                            RemmainingPoints = t.RemmainingPoints,
                            SourceCard = t.SourceCard,
                            SourceTransaction = t.SourceTransaction,
                            UserId = t.UserId
                        })
                        .ToList();

            return result;
        }

        public Transaction Get(Guid Id)
        {
            return transactionRepository.Get.FirstOrDefault(t => t.Id.Equals(Id));
        }

        public Transaction Add(Transaction transaction)
        {
            //transaction.Id = Guid.NewGuid();
            transaction.DateTime = DateTime.Now;
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
