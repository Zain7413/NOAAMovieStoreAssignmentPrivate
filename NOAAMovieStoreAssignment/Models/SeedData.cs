using Microsoft.EntityFrameworkCore;
using NOAAMovieStoreAssignment.Data;
using System.Net.Mail;

namespace NOAAMovieStoreAssignment.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MovieDbContext>>()))  // Allows the method to interact with the database
            {
                //if (context.Movies.Any())  // Checks if Movies-table already includes any movies
                //{
                //    return;  // DB has already been seeded
                //}
                //context.Movies.AddRange(
                //    new Movie
                //    {
                //        Title = "Iron Man",
                //        Genre = "Action",
                //        Director = "Jon Favreau",
                //        ReleaseYear = 2008,
                //        Price = 99,
                //        Sales = 0,
                //        PictureUrl = "https://m.media-amazon.com/images/M/MV5BMTczNTI2ODUwOF5BMl5BanBnXkFtZTcwMTU0NTIzMw@@._V1_FMjpg_UX1000_.jpg"
                //    },
                //    new Movie
                //    {
                //        Title = "The Polar Express",
                //        Genre = "Adventure/Comedy",
                //        Director = "Robert Zemeckis",
                //        ReleaseYear = 2004,
                //        Price = 79,
                //        Sales = 0,
                //        PictureUrl = "https://m.media-amazon.com/images/M/MV5BMTM1NTU0NTE4MV5BMl5BanBnXkFtZTcwMTQ0MjEzMw@@._V1_FMjpg_UX1000_.jpg"
                //    },
                //    new Movie
                //    {
                //        Title = "The Shining",
                //        Genre = "Drama/Horror",
                //        Director = "Stanley Kubrick",
                //        ReleaseYear = 1980,
                //        Price = 99,
                //        Sales = 0,
                //        PictureUrl = "https://resizing.flixster.com/-XZAfHZM39UwaGJIFWKAE8fS0ak=/v3/t/assets/p40_v_v12_sk.jpg"
                //    },
                //    new Movie
                //    {
                //        Title = "Interstellar",
                //        Genre = "Science fiction",
                //        Director = "Christopher Nolan",
                //        ReleaseYear = 2014,
                //        Price = 99,
                //        Sales = 0,
                //        PictureUrl = "https://m.media-amazon.com/images/I/91vIHsL-zjL._AC_UF1000,1000_QL80_.jpg"
                //    },
                //    new Movie
                //    {
                //        Title = "Ghostbusters",
                //        Genre = "Comedy",
                //        Director = "Ivan Reitman",
                //        ReleaseYear = 1984,
                //        Price = 79,
                //        Sales = 0,
                //        PictureUrl = "https://m.media-amazon.com/images/M/MV5BMTkxMjYyNzgwMl5BMl5BanBnXkFtZTgwMTE3MjYyMTE@._V1_FMjpg_UX1000_.jpg"
                //    },
                //    new Movie
                //    {
                //        Title = "Planet of the Apes",
                //        Genre = "Adventure/Science fiction",
                //        Director = "Franklin J. Schaffner",
                //        ReleaseYear = 1968,
                //        Price = 135,
                //        Sales = 0,
                //        PictureUrl = "https://m.media-amazon.com/images/I/514623QANFL._AC_UF1000,1000_QL80_.jpg"
                //    },
                //    new Movie
                //    {
                //        Title = "Jurassic park",
                //        Genre = "Adventure",
                //        Director = "Steven Spielberg",
                //        ReleaseYear = 1993,
                //        Price = 79,
                //        Sales = 0,
                //        PictureUrl = "https://m.media-amazon.com/images/M/MV5BMjM2MDgxMDg0Nl5BMl5BanBnXkFtZTgwNTM2OTM5NDE@._V1_FMjpg_UX1000_.jpg"
                //    }
                //);  // Inserts movies into Movies-table
                //-------------------------------------------------------------------------------
                if (context.Customers.Any())  // Checks if Customers-table already includes any customer
                {
                    return;  // DB has already been seeded
                }
                context.Customers.AddRange(
                    //1
                    new Customer
                    {
                        FirstName = "Boel",
                        LastName = "Boelson",
                        BillingAddress = "Dagsbergsvägen2A",
                        BillingCity = "Norrkoping",
                        BillingZip = "73622",
                        DeliveryAddress = "Dagsbergsvägen2A",
                        DeliveryCity = "Norrkoping",
                        DeliveryZip = "73622",
                        EmailAddress = "boelboelson@gmail.com",
                        Phone = "0704565593"
                    },
                    //2
                    new Customer
                    {
                        FirstName = "Maral",
                        LastName = "Ohanesian",
                        BillingAddress = "Klostergtan40",
                        BillingCity = "Linköping",
                        BillingZip = "53726",
                        DeliveryAddress = "Klostergtan40",
                        DeliveryCity = "Linköping",
                        DeliveryZip = "53726",
                        EmailAddress = "maralohanesian@gmail.com",
                        Phone = "0704725583"
                    },
                    //3
                    new Customer
                    {
                        FirstName = "Eva",
                        LastName = "Karlsson",
                        BillingAddress = "Pioneargatan14",
                        BillingCity = "Linköping",
                        BillingZip = "53727",
                        DeliveryAddress = "Pioneargatan14",
                        DeliveryCity = "Linköping",
                        DeliveryZip = "53727",
                        EmailAddress = "evakarlsson@gmail.com",
                        Phone = "0704725584"
                    },
                    //4
                    new Customer
                    {
                        FirstName = "Seta",
                        LastName = "Hakopian",
                        BillingAddress = "Kungsgatan20",
                        BillingCity = "Linköping",
                        BillingZip = "53728",
                        DeliveryAddress = "Kungsgatan20",
                        DeliveryCity = "Linköping",
                        DeliveryZip = "53728",
                        EmailAddress = "setahakopian@gmail.com",
                        Phone = "0704725585"
                    },
                    //5
                    new Customer
                    {
                        FirstName = "Oscar",
                        LastName = "Petersson",
                        BillingAddress = "Drottningsgatan30",
                        BillingCity = "Norköping",
                        BillingZip = "53729",
                        DeliveryAddress = "Drottningsgatan30",
                        DeliveryCity = "Norköping",
                        DeliveryZip = "53729",
                        EmailAddress = "oscarpetersson@gmail.com",
                        Phone = "0704725586"
                    },
                    //6
                    new Customer
                    {
                        FirstName = "Peter",
                        LastName = "Davidsson",
                        BillingAddress = "Prestbolisgatan15",
                        BillingCity = "Stockholm",
                        BillingZip = "53815",
                        DeliveryAddress = "Prestbolisgatan15",
                        DeliveryCity = "Stockholm",
                        DeliveryZip = "53815",
                        EmailAddress = "peterdavidsson@gmail.com",
                        Phone = "0704725587"
                    },
                    //7
                    new Customer
                    {
                        FirstName = "Jude ",
                        LastName = "Bellingham",
                        BillingAddress = "Santiago Bernabeu-stadion",
                        BillingCity = " Madrid,",
                        BillingZip = "28036",
                        DeliveryAddress = "Santiago Bernabeu-stadion",
                        DeliveryCity = "Madrid",
                        DeliveryZip = "28036",
                        EmailAddress = "judebellingham@realmadrid.com",
                        Phone = "0704725580"
                    },
                    //8
                    new Customer
                    {
                        FirstName = "Bella",
                        LastName = "Svensson",
                        BillingAddress = "Snickaregatan16",
                        BillingCity = "Uppsala",
                        BillingZip = "53816",
                        DeliveryAddress = "Snickaregatan16",
                        DeliveryCity = "Uppsala",
                        DeliveryZip = "53816",
                        EmailAddress = "bellasvensson@gmail.com",
                        Phone = "0704725588"
                    },
                    //9
                    new Customer
                    {
                        FirstName = "Vera",
                        LastName = "Gustavsson",
                        BillingAddress = "Vistvägen17",
                        BillingCity = "Västerås",
                        BillingZip = "53817",
                        DeliveryAddress = "Vistvägen17",
                        DeliveryCity = "Västerås",
                        DeliveryZip = "53817",
                        EmailAddress = "veragustavesson@gmail.com",
                        Phone = "0704725589"
                    },
                    //10
                    new Customer
                    {
                        FirstName = "Fredrik",
                        LastName = "Fransson",
                        BillingAddress = "Stiglötsgatan18",
                        BillingCity = "Örebro",
                        BillingZip = "53818",
                        DeliveryAddress = "Stiglötsgatan18",
                        DeliveryCity = "Örebro",
                        DeliveryZip = "53818",
                        EmailAddress = "fredrikfransson@gmail.com",
                        Phone = "0704725590"
                    }

                );  // Inserts customers into Customers-table

                context.SaveChanges();  // Saves changes to the database



            }
        }
    }
}
