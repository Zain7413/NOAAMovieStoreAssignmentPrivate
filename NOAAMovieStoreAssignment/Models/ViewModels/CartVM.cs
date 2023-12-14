using System.ComponentModel.DataAnnotations;
using System.Drawing.Printing;
using System.Reflection;

namespace NOAAMovieStoreAssignment.Models.ViewModels
{
    public class CartVM
    {        
        public int Id { get; set; }
        public string? Title { get; set; }
        public decimal Total => Price * Quantity; 
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string? Image {get; set; }
    }
}

