using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CinemaTV.ViewModel;

public class AddNewMovieViewModel
{
    [MaxLength(255,ErrorMessage ="Please, Max length required 255 character")]
    [Required]
    public string Title { get; set; }
    [Required]
    public string StoryLine { get; set; }
    [Required]
    [Range(1,10)]
    public float Rate { get; set; }
    [Required]
    [Range(1970,2024)]
    public int Year { get; set; }
    [Required]
    public IFormFile Image { get; set; }
    [Required]
    public IFormFile Video { get; set; }
    [Required]
    [Remote(controller: "Movies",action: "Check",ErrorMessage ="Please, Select Genre!")]
    public int Genre { get; set; }
}
