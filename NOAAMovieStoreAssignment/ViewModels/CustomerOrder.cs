using NOAAMovieStoreAssignment.Models;
using System.ComponentModel.DataAnnotations;

namespace NOAAMovieStoreAssignment.ViewModels
{
    public class CustomerOrder
    {
        public int Id { get; set; }
        [Display(Name = "Order date")]
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        [Display(Name = "Movie title")]
        public List<Movie> Movies { get; set; }

        public CustomerOrder()
        {
        }
        public CustomerOrder(int id,DateTime date, int total, List<Movie> movies)
        {
            Id = id;
            Date = date;
            Total = total;
            Movies = movies;
        }   
    }
}
