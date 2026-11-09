using CinemaTV.Repository;
using CinemaTV.ViewModel;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Runtime;

namespace CinemaTV.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IToastNotification _toast;
        public MovieController(IMovieRepository movieRepository, IGenreRepository genreRepository, IToastNotification toast)
        {
            _movieRepository = movieRepository;
            _genreRepository = genreRepository;
            _toast = toast;
        }
        public IActionResult Index()
        {
            var movies = _movieRepository.GetAll();
            return View(movies);
        }
        public IActionResult Details(int id)
        {
            var movie = _movieRepository.GetById(id);
            return View(movie);
        }
        public IActionResult Create()
        {
            ViewBag.geners = _genreRepository.GetAll();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MovieViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.geners = _genreRepository.GetAll();
                return View(model);
            }
            _movieRepository.Create(model);
            _toast.AddSuccessToastMessage("Movie Created Successed");
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int id)
        {
            ViewBag.geners = _genreRepository.GetAll();
            var oldmovie = _movieRepository.GetById(id);
            var movie = new UpdateMovieViewModel
            {
                Id = oldmovie.Id,
                Title = oldmovie.Title,
                GenreId = oldmovie.GenreId,
                Poster = oldmovie.Poster,
                Rate = oldmovie.Rate,
                Year = oldmovie.Year,
                StoryLine = oldmovie.StoryLine,

            };
            return View(movie);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(UpdateMovieViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.geners = _genreRepository.GetAll();
                return View(model);
            }
            _movieRepository.Update(model);
            _toast.AddSuccessToastMessage("Movie Updated Successed");
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Check(int GenreId)
        {
            if (GenreId == 0)
            {
                return Json(false);
            }

            return Json(true);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _movieRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
