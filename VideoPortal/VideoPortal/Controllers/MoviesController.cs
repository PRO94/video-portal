using System;
using System.Linq;
using System.Web.Mvc;
using VideoPortal.Models;
using System.Data.Entity;
using VideoPortal.ViewModels;

namespace VideoPortal.Controllers
{
    public class MoviesController : Controller
    {
        public ApplicationDbContext _context { get; set; }

        public MoviesController()
        {
            _context = ApplicationDbContext.Create();
        }
        
        public ActionResult Index()
        {
            var movies = _context.Movies
                .Include(m => m.Genre)
                .ToList();

            return View("List", movies);
        }
        
        public ActionResult Details(int id)
        {
            var movie = _context.Movies
                .Include(m => m.Genre)
                .SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        public ActionResult New()
        {
            var viewModel = new MovieFormViewModel
            {
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Single(m => m.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}