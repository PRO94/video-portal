using System.Linq;
using System.Web.Mvc;
using VideoPortal.Models;
using System.Data.Entity;
using VideoPortal.ViewModels;

namespace VideoPortal.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = ApplicationDbContext.Create();
        }

        public ActionResult Index()
        {
            var customers = _context.Customers
                .Include(c => c.MembershipType)
                .ToList();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers
                .SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {
                MembershipTypes = membershipTypes
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}