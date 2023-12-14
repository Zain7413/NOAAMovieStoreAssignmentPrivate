using Microsoft.AspNetCore.Mvc;
using NOAAMovieStoreAssignment.Data;

namespace NOAAMovieStoreAssignment.Controllers
{
    public class AdminController : Controller
    {

        // INJECTION
        private readonly MovieDbContext _db;


        // CONSTRUCTOR

        public AdminController(MovieDbContext db)
        {
            _db = db;
        }




        // METHODS

        public IActionResult Index()
        {
            
            return RedirectToAction("WebshopStatistics");
        }



        public IActionResult WebshopStatistics()
        {

            return View("Statistics");
        }



    }
}
