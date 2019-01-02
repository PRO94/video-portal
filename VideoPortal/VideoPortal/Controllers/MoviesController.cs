using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using VideoPortal.Models;

namespace VideoPortal.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            var movies = GetMovies();

            return View(movies);
        }

        // GET: Movies/Details/{id}
        public ActionResult Details(int id)
        {
            var movies = GetMovies();
            var movie = movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "Movie 1" },
                new Movie { Id = 2, Name = "Movie 2" }
            };
        }
    }
}