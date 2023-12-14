
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NOAAMovieStoreAssignment.Data;
using NOAAMovieStoreAssignment.Helper;
using NOAAMovieStoreAssignment.Models;
using NOAAMovieStoreAssignment.Models.ViewModels;
using System.Security.Cryptography;

namespace NOAAMovieStoreAssignment.Controllers
{
    public class CartController : Controller
    {
        private readonly MovieDbContext _db;

        //private MovieDbContext _db= new MovieDbContext();

        public CartController(MovieDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {

            return View();
        }
        //Get:AddToCart

        public IActionResult AddToCart(int id, string returnurl)
        {
            if (HttpContext.Session.Get<List<int>>("movieIdList") == default)
            {
                HttpContext.Session.Set<List<int>>("movieIdList", new List<int>());

            }
            var movieIdsList = HttpContext.Session.Get<List<int>>("movieIdList");
            movieIdsList.Add(id);

            TempData["CartMessage"] = "Movie added to cart!";


            HttpContext.Session.Set<List<int>>("movieIdList", movieIdsList);

            return LocalRedirect(returnurl);
            
        }
       

        public IActionResult ShoppingCart()
        {
            var movieIdsList = HttpContext.Session.Get<List<int>>("movieIdList") ?? new List<int>();
            //var cartViewModelList = GetCartViewModel(movieIdsList);

            var listOfVM = new List<CartVM>();

            foreach (var movieId in movieIdsList)
            {
                // get the whole movie obj from only the id
                // convert movie obj to a VMobject
              
                
                var moviesInCart = listOfVM.FirstOrDefault(m=> m.Id == movieId);
               
                if (moviesInCart != null)
                {
                    moviesInCart.Quantity++;
                   
                }
                else
                {
                    var movie = _db.Movies.Find(movieId);
                    if (movie != null)
                    {
                        listOfVM.Add(new CartVM
                        {
                            Id = movieId,
                            Image = movie.PictureUrl,
                            Title= movie.Title,
                            Quantity = 1,
                            Price = movie.Price
                        });
                    }
                }
            }
           
            return View(listOfVM);
        }

        public IActionResult IncreaseBtn(int id, string returnurl ) 
        {
            AddToCart(id,returnurl);
            return LocalRedirect(returnurl);
            //return RedirectToAction("ShoppingCart", "Cart");
        }

        public IActionResult DecreaseBtn(int id)
        {
            var movieIdsList = HttpContext.Session.Get<List<int>>("movieIdList") ?? new List<int>();
            movieIdsList.Remove(id);

            HttpContext.Session.Set("movieIdList", movieIdsList);

            return RedirectToAction("ShoppingCart", "Cart");
        }
        public IActionResult RemoveBtn(int id)
        {
            var movieIdsList = HttpContext.Session.Get<List<int>>("movieIdList") ?? new List<int>();
            movieIdsList.RemoveAll(x => x == id);
            HttpContext.Session.Set("movieIdList", movieIdsList);

            return RedirectToAction("ShoppingCart", "Cart");
        }
        public IActionResult CheckOut()
        {
            
            return View();
        }
       
        public IActionResult Submit(string email) 

        {
            var existingCustomer = _db.Customers.FirstOrDefault(c => c.EmailAddress == email);
            
            if (existingCustomer != null)
            {
                SaveOrder(existingCustomer.Id);
                HttpContext.Session.Remove("movieIdList");
                return View("OrderDone");
            }
            else 
            {
                return RedirectToAction("Register",new {email });
            }
            

        }
        // Action for displaying the registration form
        public ActionResult Register(string email)
        {
            // Pass the email to the registration view
            Customer obj= new Customer();
            obj.EmailAddress = email;
            ViewBag.EmailAddress = email;
            return View();
        }
        [HttpPost]
        public ActionResult Register(Customer newCustomer)
        {
            
                _db.Customers.Add(newCustomer);
                _db.SaveChanges();
            return RedirectToAction("Submit", new { email = newCustomer.EmailAddress});


        }

        //Creating new order and updating order and orderrows table
        public void SaveOrder(int customerId)
        {
            var newOrder = new Order()
            {
                OrderRows = new List<OrderRow>(),
                CustomerId = customerId,
                OrderDate = DateTime.Now,

            };
            var movieIdsList = HttpContext.Session.Get<List<int>>("movieIdList");
            foreach (var movieId in movieIdsList)
            {
                var movie = _db.Movies.Find(movieId);
                if (movie != null)
                {
                    newOrder.OrderRows.Add(new OrderRow
                    {
                        MovieId = movieId,
                        Price = movie.Price,
                    });
                }
            }

            newOrder.OrderPrice = newOrder.OrderRows.Sum(x => x.Price);
            _db.Orders.Add(newOrder);
            _db.SaveChanges();
        }
        public ActionResult OrderDone()
        {
           

            return View();
        }

      

    }
}

