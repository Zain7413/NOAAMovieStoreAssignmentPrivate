using NOAAMovieStoreAssignment.Models;

namespace NOAAMovieStoreAssignment.ViewModels
{
    public class HomeLists
    {
        public List<Movie> AllMovies { get; set; }
        public List<Movie> MostPopularMovies { get; set; }
        public List<Movie> LatestMovies { get; set;}
        public List<Movie> OldestMovies { get; set;}
        public List<Movie> CheapestMovies { get; set; }
        public Order ExpensiveOrder { get; set; }


    }
}
