using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Domain.Entity
{
    public class Transaction : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime DateTime { get; set; }

        public int OriginalPoints { get; set; }

        public int RemmainingPoints { get; set; }

        public string SourceCard { get; set; }

        public string DestinationCard { get; set; }

        public string SourceTransaction { get; set; }

        public Guid CompanyId { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("CompanyId")]
        public Company Company { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<Company> Companies { get; set; }
    }
}
