using System;
using System.ComponentModel.DataAnnotations;

namespace TicketIng.Models
{
    public class User
    {
        public int Id { get; set; }
        public int? ClientId { get; set; }
        [Required, MaxLength(200)]
        public string UserName { get; set; }
        [Required, EmailAddress, MaxLength(200)]
        public string Email { get; set; }
        [Required]
        public int RoleId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
