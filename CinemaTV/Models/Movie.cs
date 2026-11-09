using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaTV.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [MaxLength(120)]
        [Required]
        public string Title { get; set; }
        [Required]
        [Range(1,10)]
        public float Rate { get; set; }
        public int Year { get; set; }
        [Required, MaxLength(3000)]
        public string StoryLine { get; set; }
        [Required]
        public byte[] Poster { get; set; }
        [ForeignKey("Genre")]
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
