using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Transaction
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime DateTime { get; set; }

        public string OriginalPoints { get; set; }

        public string SourceCard { get; set; }

        public string DestinationCard { get; set; }

        public string SourceTransaction { get; set; }

        public Guid CompanyId { get; set; }

        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<Company> Companies { get; set; }
    }
}
