using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Domain.Entity
{
    public class Role : IdentityRole
    {
        public string Description { get; set; }
        public virtual ICollection<IdentityUserRole> UserRoles { get; set; }
    }
}
