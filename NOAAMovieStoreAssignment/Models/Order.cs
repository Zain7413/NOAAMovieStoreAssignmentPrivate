using System.ComponentModel.DataAnnotations;
namespace NOAAMovieStoreAssignment.Models
{
    public class Order
    {
        public int Id { get; set; }
        //-------------------------------------------
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime OrderDate { get; set; }
        //-------------------------------------------
        [Required]
        [DataType(DataType.Currency)]
        public decimal OrderPrice { get; set; }
        //-------------------------------------------
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual ICollection<OrderRow> OrderRows { get; set; }
    }
}
