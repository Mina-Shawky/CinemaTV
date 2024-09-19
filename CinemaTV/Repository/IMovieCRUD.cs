using CinemaTV.Models;
using CinemaTV.ViewModel;

namespace CinemaTV.Repository;

public interface IMovieCRUD
{
    List<Movie> GetAllMovieByRate();
    List<Movie> GetAllMovieByYear();
    List<Genre> GetAllGenre();
    Movie GetById(int id);
    void Add(AddNewMovieViewModel movie);
    void Update(UpdateMovieViewModel movie);
    void Delete(int id);
}
