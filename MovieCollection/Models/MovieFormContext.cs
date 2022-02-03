using System;
using Microsoft.EntityFrameworkCore;

namespace MovieCollection.Models
{
    public class MovieFormContext : DbContext
    {
        public MovieFormContext(DbContextOptions<MovieFormContext> options) : base (options)
        {

        }
        public DbSet<MovieForm> Responses { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {

             mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName= "Action"},
                new Category { CategoryId = 2, CategoryName = "Comedy" },
                new Category { CategoryId = 3, CategoryName = "Drama" },
                new Category { CategoryId = 4, CategoryName = "Mystery" },
                new Category { CategoryId = 5, CategoryName = "Romance" }
                );
            mb.Entity<MovieForm>().HasData(



                new MovieForm
                {
                    MovieID = 1,
                    CategoryId = 1,
                    Title = "Spider Man No Way Home",
                    Year = 2021,
                    Director = "Jon Watts",
                    Rating = "PG-13",
                    Edited = false,
                    Lent = " ",
                    Notes = "Love this show so much!"
                },
                new MovieForm
                {
                    MovieID = 2,
                    CategoryId = 5,
                    Title = "Hitch",
                    Year = 2005,
                    Director = "Andy Tennant",
                    Rating = "PG-13",
                    Edited = false,
                    Lent = " ",
                    Notes = "Love this show so much!"
                },
                new MovieForm
                {
                    MovieID = 3,
                    CategoryId = 3,
                    Title = "In the Heights",
                    Year = 2021,
                    Director = "Jon M. Chu",
                    Rating = "PG-13",
                    Edited = false,
                    Lent = " ",
                    Notes = "Love this show so much!"
                }

             ); 
        }
    }
}
