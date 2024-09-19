using System.ComponentModel.DataAnnotations;

namespace CinemaTV.Models;

public class Genre
{
    public int Id { get; set; }
    [MaxLength(100)]
    public string GenreName { get; set; }
}
