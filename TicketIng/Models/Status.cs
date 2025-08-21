using System.ComponentModel.DataAnnotations;

namespace TicketIng.Models
{
    public class Status
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public bool IsFinal { get; set; }
    }
}
