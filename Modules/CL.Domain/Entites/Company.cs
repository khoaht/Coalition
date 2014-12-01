using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Domain.Entity
{
    public class Company : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int GiveBackPercentage { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
