using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Domain.Entity
{
    public class User : IdentityUser, IEntity
    {
        //[Key]
        //public Guid Id { get; set; }

        public Guid CompanyId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        [ForeignKey("CompanyId")]
        public Company Company { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
