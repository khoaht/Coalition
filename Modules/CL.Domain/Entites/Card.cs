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
    public class Card : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        public string CardNumber { get; set; }

        public Guid ClientId { get; set; }

        [ForeignKey("ClientId")]
        public Client Client { get; set; }
    }
}

