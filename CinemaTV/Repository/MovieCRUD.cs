using CinemaTV.Data;
using CinemaTV.Models;
using CinemaTV.ViewModel;
using NToastNotify;

namespace CinemaTV.Repository;

public class MovieCRUD : IMovieCRUD
{
    private readonly ApplicationDbContext _dbcontext;

    public MovieCRUD(ApplicationDbContext dbcontext)
    {
        _dbcontext = dbcontext;
    }

    public List<Movie> GetAllMovieByRate()
    {
        return _dbcontext.Movies.OrderByDescending(e=>e.Rate).ToList();
    }
    public List<Movie> GetAllMovieByYear()
    {
        return _dbcontext.Movies.OrderByDescending(e => e.Year).ToList();
    }

    public Movie GetById(int id)
    {
        return _dbcontext.Movies.SingleOrDefault(e => e.Id == id);
    }

    public void Add(AddNewMovieViewModel model)
    {
        var memorystream = new MemoryStream();
        model.Image.CopyTo(memorystream);

        var stream = new MemoryStream();
        model.Video.CopyTo(stream);

        Movie movie = new Movie
        {
            Title = model.Title,
            StoryLine = model.StoryLine,
            Rate = model.Rate,
            Year = model.Year,
            Poster = memorystream.ToArray(),
            VideoPoster = stream.ToArray(),
            GenreId = model.Genre,
        };

        _dbcontext.Movies.Add(movie);
        _dbcontext.SaveChanges();

    }

    public void Update(UpdateMovieViewModel model)
    {
        var onemovie = GetById(model.Id);
        if (model.Image != null)
        {
            var memorystream = new MemoryStream();
            model.Image.CopyTo(memorystream);
            model.Imagetrue = memorystream.ToArray();
            onemovie.Poster = model.Imagetrue;
        }
        if (model.Video != null)
        {
            var stream = new MemoryStream();
            model.Video.CopyTo(stream);
            model.Videotrue = stream.ToArray();
            onemovie.VideoPoster = model.Videotrue;
        }


        onemovie.Title = model.Title;
        onemovie.StoryLine = model.StoryLine;
        onemovie.Rate = model.Rate;


        onemovie.Year = model.Year;
        onemovie.GenreId = model.Genre;

        _dbcontext.Update(onemovie);
        _dbcontext.SaveChanges();
    }
    public void Delete(int id)
    {
        var movie = GetById( id);

        if (movie == null)
            throw new ArgumentNullException(nameof(movie), "The movie parameter cannot be null.");

        _dbcontext.Movies.Remove(movie);
        _dbcontext.SaveChanges();
    }

    public List<Genre> GetAllGenre()
    {
        return _dbcontext.Genres.OrderBy(e => e.GenreName).ToList();
    }
}
