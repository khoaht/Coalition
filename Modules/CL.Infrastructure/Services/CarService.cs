using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.Infrastructure.Services;
using Domain.Entity;

namespace CL.Infrastructure.Services
{
    public class CardService : ICardService
    {
        private readonly IRepository<Card> cardRepository;

        public CardService(IRepository<Card> cardRepository)
        {
            this.cardRepository = cardRepository;
        }

        public IList<Card> Search(Criterias.CardCriteria criteria)
        {
            Func<Card, bool> exp = null;
            exp = t => (criteria.ClientId == null || t.ClientId.Equals(criteria.ClientId))
                       && (string.IsNullOrEmpty(criteria.CardNumber) || t.CardNumber.Contains(criteria.CardNumber));

            var result = cardRepository.Get
                        .Where(exp)
                        .OrderByDescending(t => t.CardNumber)
                        .ToList();

            return result;
        }

        public Card Get(Guid Id)
        {
            return cardRepository.Get.FirstOrDefault(t => t.Id.Equals(Id));
        }

        public Card Add(Card card)
        {
            var result = cardRepository.Add(card);
            cardRepository.Commit();
            return result;
        }

        public Card Update(Card card)
        {
            return cardRepository.Update(card);
        }

        public bool Delete(Guid Id)
        {
            var delete = Get(Id);
            if (delete != null)
            {
                cardRepository.Remove(delete);
                return true;
            }
            return false;
        }
    }
}
