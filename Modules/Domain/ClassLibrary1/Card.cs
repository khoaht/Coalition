using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Card
    {
        [Key]
        public Guid Id { get; set; }

        public string CardNumber { get; set; }

        public Guid ClientID { get; set; }

        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }
    }
}

