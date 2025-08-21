using System;
using System.ComponentModel.DataAnnotations;

namespace TicketIng.Models
{
    public class Issue
    {
        public int Id { get; set; }
        [Required, MaxLength(200)]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public int CreatedByUserId { get; set; }
        public int? AssignedToUserId { get; set; }
        [Required]
        public int ClientId { get; set; }
        public int? CategoryId { get; set; }
        [Required]
        public int StatusId { get; set; }
        public int? ReleaseId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
