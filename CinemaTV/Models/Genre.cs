using System.ComponentModel.DataAnnotations;

namespace CinemaTV.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [MaxLength(40)]
        [Required]
        public string Name { get; set; }
    }
}
