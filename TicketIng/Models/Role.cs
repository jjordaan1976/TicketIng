using System;
using System.ComponentModel.DataAnnotations;

namespace TicketIng.Models
{
    public class Role
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
