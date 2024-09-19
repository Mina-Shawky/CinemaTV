using CinemaTV.Data;
using CinemaTV.Models;
using CinemaTV.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CinemaTV.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IMovieCRUD _repositoryMovie;

    public HomeController(ILogger<HomeController> logger, IMovieCRUD repositoryMovie)
    {
        _logger = logger;
        _repositoryMovie = repositoryMovie;
    }

    public IActionResult Index()
    {
        var listOfMovies = _repositoryMovie.GetAllMovieByYear();
        return View(listOfMovies);
    }
    public IActionResult GetById(int id)
    {
        var movie = _repositoryMovie.GetById(id);
        return View(movie);
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
