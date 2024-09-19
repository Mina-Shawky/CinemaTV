using System.ComponentModel.DataAnnotations;

namespace CinemaTV.Models;

public class Movie
{
    public int Id { get; set; }
    [MaxLength(255)]
    public string Title { get; set; }
    public string StoryLine { get; set; }
    public float Rate { get; set; }
    public int Year { get; set; }
    public byte[] Poster { get; set; }
    public byte[] VideoPoster { get; set; }
    public int GenreId {  get; set; }
    public virtual Genre Genre { get; set; }
}
