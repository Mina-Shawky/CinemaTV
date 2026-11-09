using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CinemaTV.ViewModel
{
    public class UpdateMovieViewModel
    {
        public int Id { get; set; }
        [StringLength(120, ErrorMessage = "This filed max char = 120 char")]
        [Required]
        public string Title { get; set; }
        [Required]
        [Range(1, 10, ErrorMessage = "This value between 1 to 10")]
        public float Rate { get; set; }
        [Required(ErrorMessage = "Please select a movie year")]
        public int Year { get; set; }
        [Required, StringLength(3000, ErrorMessage = "This filed max char = 3000 char")]
        [Display(Name = "Story Line")]
        public string StoryLine { get; set; }
        [Required(ErrorMessage = "Please select a movie genre")]
        [Display(Name = "Genre")]
        [Remote(controller: "Movie", action: "Check", ErrorMessage = "Please, Select Genre!")]

        public int GenreId { get; set; }
        public IFormFile? Image { get; set; }
        public byte[]? Poster { get; set; }
    }
}
