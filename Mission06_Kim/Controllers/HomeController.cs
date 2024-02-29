// Donna Kim
// Section 03
// Description: This is my Web app for Joel Hilton, who is a film reviewer. It is connected to a database of his favorite films.
// You can add, update, and delete movies in the collection.

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
            return View("EnterMovies", new Movie());
        }

        [HttpPost]
        public IActionResult EnterMovies(Movie response)
        {
            if (ModelState.IsValid) // Check if valid input
            {
                _context.Movies.Add(response); // add record to the database
                _context.SaveChanges();

                return View("Confirmation", response);
            }
            else
            {
                return View(response);
            }
            
        }

        public IActionResult MyCollection()
        {
            //Linq to pull all movies by alphabetical order of title
            var movies = _context.Movies.Include("Category")
                .OrderBy(x => x.Title).ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Update(int id) // Grab the MovieId of movie to edit and send to editable form
        {
            var movieToUpdate = _context.Movies
                .Single(x => x.MovieId == id);

            return View("EnterMovies", movieToUpdate);
        }

        [HttpPost]
        public IActionResult Update(Movie movieToUpdate) // Grab movie to update and save the changes
        {
            _context.Update(movieToUpdate);
            _context.SaveChanges();

            return RedirectToAction("MyCollection"); // Redirect to collection table display
        }

        [HttpGet]
        public IActionResult Delete(int id) // grab MovieId of movie to delete and send to delete view
        {
            var movieToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(movieToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movie movieToDelete) // confirm deletion and delete movie
        {
            _context.Movies.Remove(movieToDelete);
            _context.SaveChanges();

            return RedirectToAction("MyCollection"); // return to view of collection table display
        }
    }
}
