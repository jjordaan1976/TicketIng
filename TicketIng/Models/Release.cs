using System;
using System.ComponentModel.DataAnnotations;

namespace TicketIng.Models
{
    public class Release
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Version { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Notes { get; set; }
    }
}
