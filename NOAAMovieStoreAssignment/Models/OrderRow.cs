using System.ComponentModel.DataAnnotations;

namespace NOAAMovieStoreAssignment.Models
{
    public class OrderRow
    {
        public int Id { get; set; }
        //-------------------------------------------
        public int OrderId { get; set; }
        //-------------------------------------------
        public int MovieId { get; set; }
        //-------------------------------------------
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        //-------------------------------------------
        public virtual Order Order { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
