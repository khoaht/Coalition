using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Infrastructure.Criterias
{
    /// <summary>
    /// Criteria Class
    /// </summary>
    public class TransactionCriteria : Criteria
    {
        public DateTime? DateTime { get; set; }

        public string OriginalPoints { get; set; }

        public Guid? SourceCard { get; set; }

        public Guid? DestinationCard { get; set; }

        public string SourceTransaction { get; set; }

        public Guid? CompanyId { get; set; }

        public Guid? UserId { get; set; }
    }
}
