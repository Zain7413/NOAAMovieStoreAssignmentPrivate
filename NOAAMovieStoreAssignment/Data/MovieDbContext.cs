using Microsoft.EntityFrameworkCore;
using NOAAMovieStoreAssignment.Models;
using NOAAMovieStoreAssignment.Models.ViewModels;

namespace NOAAMovieStoreAssignment.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<OrderRow> OrderRows { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure your entities here

            // Exclude a specific view model
            //modelBuilder.Ignore<CustomerOrder>();
        }

    }
}
