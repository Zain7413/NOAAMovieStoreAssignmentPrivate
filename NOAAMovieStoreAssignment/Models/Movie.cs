using NOAAMovieStoreAssignment.Models.ViewModels;
using System.ComponentModel.DataAnnotations;
namespace NOAAMovieStoreAssignment.Models
{
    public class Movie
    {
        public int Id { get; set; }
        //-------------------------------------------
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        //-------------------------------------------
        public string Genre { get; set; }
        //-------------------------------------------
        [Required]
        [StringLength(100)]
        public string Director { get; set; }
        //-------------------------------------------
        [Required]
        public int ReleaseYear { get; set; }
        //-------------------------------------------
        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        //-------------------------------------------
        [Required]
        [Range(0, int.MaxValue)]
        public int Sales { get; set; }

        public string PictureUrl { get; set; }

        public virtual ICollection<OrderRow> OrderRows { get; set; }
      
    }
}
