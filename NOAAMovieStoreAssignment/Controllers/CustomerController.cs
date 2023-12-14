using Microsoft.AspNetCore.Mvc;
using NOAAMovieStoreAssignment.ViewModels;
using NOAAMovieStoreAssignment.Data;

namespace NOAAMovieStoreAssignment.Controllers
{
    public class CustomerController : Controller
    {
        private readonly MovieDbContext _db;

        public CustomerController(MovieDbContext context)
        {
            _db = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("Customer/AllOrders/{email}")]
        public IActionResult AllOrders(string email)
        {
            // Get customer's full name
            string? name = (from c in _db.Customers
                            where c.EmailAddress == email
                            select (c.FirstName + " " + c.LastName)).FirstOrDefault();

            if (name == default(string))
            {
                return View("NoSuchCustomer"); // Bad email address
            }
            else
            {
                ViewData["Name"] = name;

                // Get the customer Id
                int cid = (from c in _db.Customers
                           where c.EmailAddress == email
                           select c.Id).First();

                // Get the customer's orders
                var orders = (from o in _db.Orders
                              where o.CustomerId == cid
                              select o);

                // Join orders with Orderrows and Movies and select (Date, Price, Movies)
                var jointbl = from o in orders
                              join or in _db.OrderRows on o.Id equals or.OrderId
                              join m in _db.Movies on or.MovieId equals m.Id
                              select new { Date = o.OrderDate, Price = or.Price, Movie = m };

                // Group by Date, sum up prices in the group, and list of movies in the group
                var query = from o in jointbl
                            group o by o.Date into grp
                            select new CustomerOrder()
                            {
                                Date = grp.Key,
                                Total = (from g in grp select g.Price).Sum(),
                                Movies = (from g in grp select g.Movie).ToList()
                            };

                return View(query);
            }

            
        }
        public IActionResult Details()
        {
            return View(_db.Customers);
        }
    }
}
