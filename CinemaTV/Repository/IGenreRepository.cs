using CinemaTV.Models;

namespace CinemaTV.Repository
{
    public interface IGenreRepository
    {
        List<Genre> GetAll();
    }
}
