// Donna Kim
// Section 03
// Description: This is my Web app for Joel Hilton, who is a film reviewer. It is connected to a database of his favorite films.

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Kim.Models;
using System.Diagnostics;

namespace Mission06_Kim.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext _context;
        public HomeController(MovieContext movieContext)
        {
            _context = movieContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetToKnowJoel() // Connect to GetToKnowJoel page
        {
            return View("GetToKnowJoel");
        }

        public IActionResult EnterMovies() // Connect to page with form to enter movies
        {
            return View("EnterMovies");
        }

        [HttpPost]
        public IActionResult EnterMovies(Movie response)
        {
            _context.Movies.Add(response); // add record to the database
            _context.SaveChanges();

            return View("Confirmation", response);
        }

        public IActionResult MyCollection()
        {
            //Linq to pull all movies by alphabetical order of title
            var movies = _context.Movies.Include("Category")
                .OrderBy(x => x.Title).ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var movieToUpdate = _context.Movies
                .Single(x => x.MovieId == id);

            return View("EnterMovies", movieToUpdate);
        }

        [HttpPost]
        public IActionResult Update(Movie movieToUpdate)
        {
            _context.Update(movieToUpdate);
            _context.SaveChanges();

            return RedirectToAction("MyCollection");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movieToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(movieToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movie movieToDelete)
        {
            _context.Movies.Remove(movieToDelete);
            _context.SaveChanges();

            return RedirectToAction("MyCollection");
        }
    }
}
