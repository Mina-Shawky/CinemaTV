using CinemaTV.Data;
using CinemaTV.Models;
using CinemaTV.Repository;
using CinemaTV.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;

namespace CinemaTV.Controllers;
public class MoviesController : Controller
{
    private readonly IMovieCRUD _repositoryMovie;
    private readonly IToastNotification _toast;

    public MoviesController(IMovieCRUD imovie, IToastNotification toast)
    {
        _repositoryMovie = imovie;
        _toast = toast;
    }
    public IActionResult Check(int genra)
    {
        if(genra == 0)
        {
            return Json(true);
        }
        else
        {
            return Json(false);
        }
    }
    public IActionResult Index()
    {
        var listOfMovies = _repositoryMovie.GetAllMovieByRate();
        return View(listOfMovies);
    }
    public IActionResult Create()
    {
        ViewBag.Geners = _repositoryMovie.GetAllGenre();
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(AddNewMovieViewModel model)
    {
        if (ModelState.IsValid && model.Genre != 0)
        {
            _repositoryMovie.Add(model);

            _toast.AddSuccessToastMessage("Movie Created Successed");

            return RedirectToAction(nameof(Index));
        }
        ViewBag.Geners = _repositoryMovie.GetAllGenre();
        return View(model);
    }
    public IActionResult Update(int id)
    {
        ViewBag.Geners = _repositoryMovie.GetAllGenre();
        var movie = _repositoryMovie.GetById(id);
        var model = new UpdateMovieViewModel
        {
            Id = movie.Id,
            Title = movie.Title,
            StoryLine = movie.StoryLine,
            Rate = movie.Rate,
            Year = movie.Year,
            Imagetrue = movie.Poster,
            Videotrue = movie.VideoPoster,
            Genre = movie.GenreId,
        };
        return View(model);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Update(UpdateMovieViewModel model)
    {
        

        if (ModelState.IsValid && model.Genre != 0)
        {
            _repositoryMovie.Update(model);

            _toast.AddSuccessToastMessage("Movie Updated Successed");

            return RedirectToAction(nameof(Index));
        }
        ViewBag.Geners = _repositoryMovie.GetAllGenre();
        return View(model);
    }
    public IActionResult Details(int id)
    {
        var movie = _repositoryMovie.GetById(id);
        return View(movie);
    }
    public IActionResult Delete(int id)
    {

        _repositoryMovie.Delete(id);
        return RedirectToAction(nameof(Index));
    }

}
