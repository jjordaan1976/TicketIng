using System;
using System.ComponentModel.DataAnnotations;

namespace TicketIng.Models
{
    public class Client
    {
        public int Id { get; set; }
        [Required, MaxLength(200)]
        public string Name { get; set; }
        [EmailAddress]
        public string ContactEmail { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
