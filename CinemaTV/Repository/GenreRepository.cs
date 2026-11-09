using CinemaTV.Data;
using CinemaTV.Models;

namespace CinemaTV.Repository
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDbContext _context;
        public GenreRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Genre> GetAll()
        {
            return _context.Genres.OrderBy(e=>e.Name).ToList();
        }
    }
}
