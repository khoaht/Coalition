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
    public class UserCriteria : Criteria
    {
        public Guid? CompanyId { get; set; }
    }
}
