using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaTV.ViewModel;

public class UpdateMovieViewModel
{
    public int Id { get; set; }

    [MaxLength(255, ErrorMessage = "Please, Max length required 255 character")]
    [Required]
    public string Title { get; set; }
    [Required]
    public string StoryLine { get; set; }
    [Required]
    [Range(1, 10)]
    public float Rate { get; set; }
    [Required]
    [Range(1970, 2024)]
    public int Year { get; set; }
    public byte[]? Imagetrue { get; set; }
    public IFormFile? Image { get; set; }
    public byte[]? Videotrue { get; set; }
    public IFormFile? Video { get; set; }
    [Required]
    [Remote(controller: "Movies", action: "Check", ErrorMessage = "Please, Select Genre!")]
    public int Genre { get; set; }
}
