using Azure.Core;
using CinemaTV.Data;
using CinemaTV.Models;
using CinemaTV.ViewModel;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CinemaTV.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _context;
        public MovieRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Movie> GetAll()
        {
            return _context.Movies.Include(e=>e.Genre).OrderByDescending(e=>e.Rate).ToList();
        }
        public List<Movie> GetAllByYear()
        {
            return _context.Movies.Include(e => e.Genre).OrderByDescending(e => e.Year).ToList();
        }

        public Movie GetById(int id)
        {
            return _context.Movies.Include(e => e.Genre).FirstOrDefault(e => e.Id == id);
        }
        public void Create(MovieViewModel movie)
        {
            var streem = new MemoryStream();
            movie.Image.CopyTo(streem);
            var addMovie = new Movie
            {
                Title = movie.Title,
                Rate = movie.Rate,
                Year = movie.Year,
                StoryLine = movie.StoryLine,
                GenreId = movie.GenreId,
                Poster = streem.ToArray()
                
                
            };
            _context.Movies.Add(addMovie);
            _context.SaveChanges();
        }
        public void Update( UpdateMovieViewModel movie)
        {
            var oldMovie = GetById(movie.Id);
            if (movie.Image != null) 
            {
                var streem =new MemoryStream();
                movie.Image.CopyTo(streem);
                movie.Poster = streem.ToArray();
                oldMovie.Poster = movie.Poster;
            }
            oldMovie.Title = movie.Title;
            oldMovie.Rate = movie.Rate;
            oldMovie.Year = movie.Year;
            oldMovie.StoryLine = movie.StoryLine;
            oldMovie.GenreId = movie.GenreId;
            _context.Movies.Update(oldMovie);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var movie = GetById(id);

            if (movie == null)
                throw new ArgumentNullException(nameof(movie), "The movie parameter cannot be null.");

            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }

    }
}
