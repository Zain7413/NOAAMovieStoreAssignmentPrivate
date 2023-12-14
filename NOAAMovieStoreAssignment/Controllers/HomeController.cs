using Microsoft.AspNetCore.Mvc;
using NOAAMovieStoreAssignment.Data;
using NOAAMovieStoreAssignment.Models;
using System.Diagnostics;
using NOAAMovieStoreAssignment.ViewModels;
using Microsoft.EntityFrameworkCore;


namespace NOAAMovieStoreAssignment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MovieDbContext _context;


        public HomeController(ILogger<HomeController> logger, MovieDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var vm = new HomeLists
            {
                LatestMovies = _context.Movies.OrderByDescending(m => m.ReleaseYear).Take(10).ToList(),
                MostPopularMovies = _context.Movies.OrderByDescending(x => x.OrderRows.Count).Take(10).ToList(),
                OldestMovies = _context.Movies.OrderBy(m => m.ReleaseYear).Take(10).ToList(),
                CheapestMovies = _context.Movies.OrderBy(x => x.Price).Take(10).ToList(),
                AllMovies = _context.Movies.ToList(),
                ExpensiveOrder = _context.Orders.Include(m => m.Customer).OrderByDescending(m=>m.OrderPrice).FirstOrDefault()
            };

            return View(vm);
        }
        public IActionResult PopularMovies()
        {
            var vm = new CustomerOrder()
            {
                
            };

            

            return View(vm);
        }
        //public IActionResult LatestMovies()
        //{ 
        //    var latestMovies = _context.Movies.OrderByDescending(m => m.ReleaseYear).Take(10).ToList();
        //    return View(latestMovies);
        //}

        public IActionResult SortByYear(string sortOrder, string query)
        {


            ViewData["PriceSortParam"] = sortOrder == "price_asc" ? "price_desc" : "price_asc";
            ViewData["YearSortParam"] = sortOrder == "year_asc" ? "year_desc" : "year_asc";
            ViewData["Query"] = query;

            int.TryParse(query, out var queryAsInt);

            List<Movie> sortedFilms;
            switch (sortOrder)
            {
                case "price_asc":
                    sortedFilms = _context.Movies.Where(f => string.IsNullOrEmpty(query) || f.Title.Contains(query) || f.Genre.Contains(query) || f.ReleaseYear.ToString().Contains(query)).OrderBy(f => f.Price).ToList();
                    break;
                case "price_desc":
                    sortedFilms = _context.Movies.Where(f => string.IsNullOrEmpty(query) || f.Title.Contains(query) || f.Genre.Contains(query) || f.ReleaseYear.ToString().Contains(query)).OrderByDescending(f => f.Price).ToList();
                    break;
                case "year_asc":
                    sortedFilms = _context.Movies.Where(f => string.IsNullOrEmpty(query) || f.Title.Contains(query) || f.Genre.Contains(query) || f.ReleaseYear.ToString().Contains(query)).OrderBy(f => f.ReleaseYear).ToList();
                    break;
                case "year_desc":
                    sortedFilms = _context.Movies.Where(f => string.IsNullOrEmpty(query) || f.Title.Contains(query) || f.Genre.Contains(query) || f.ReleaseYear.ToString().Contains(query)).OrderByDescending(f => f.ReleaseYear).ToList();
                    break;
                default:
                    sortedFilms = _context.Movies.Where(f => string.IsNullOrEmpty(query) || f.Title.Contains(query) || f.Genre.Contains(query) || f.ReleaseYear.ToString().Contains(query)).OrderBy(f => f.Price).ToList();
                    break;
            }

            return View(sortedFilms);

        }

        public IActionResult SortByGenre()
        {
            var genres = _context.Movies.Select(movie => movie.Genre).Distinct().ToList();
            List<Movie> Greansmovies = new List<Movie>();
            foreach (var genre in genres)
            {
                Greansmovies.AddRange(_context.Movies.Where(m => m.Genre == genre).OrderByDescending(M => M.ReleaseYear).Take(10).ToList());
            }
            var SortByGenre = _context.Movies.OrderBy(Movie => Movie.Genre)
                //.Take(10)
                .ToList();

            return View(Greansmovies);
        }
        public IActionResult ContactUS()
        {
            return View();
        }
        public IActionResult TermsAndService()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}