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
    public class ClientCriteria : Criteria
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string SurName { get; set; }
    }
}
