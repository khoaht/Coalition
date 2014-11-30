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
    public class CardCriteria : Criteria
    {
        public string CardNumber { get; set; }
        public bool? Active { get; set; }
        public string Email { get; set; }
        public Guid? ClientId { get; set; }
    }
}
