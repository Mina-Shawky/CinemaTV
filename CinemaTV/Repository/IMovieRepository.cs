using CinemaTV.Models;
using CinemaTV.ViewModel;

namespace CinemaTV.Repository
{
    public interface IMovieRepository
    {
        List<Movie> GetAll();
        List<Movie> GetAllByYear();
        Movie GetById(int id);
        void Create(MovieViewModel movie);
        void Update(UpdateMovieViewModel movie);
        void Delete(int id);
    }
}
