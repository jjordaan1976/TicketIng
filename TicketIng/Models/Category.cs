using System.ComponentModel.DataAnnotations;

namespace TicketIng.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required, MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
    }
}
