using System.Linq;
using System.Web.Mvc;
using VideoPortal.Models;
using System.Data.Entity;

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

            return View(movies);
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

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}