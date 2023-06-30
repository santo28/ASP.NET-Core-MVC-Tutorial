using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieContext>>()))
        {
            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }
            context.Movie.AddRange(
                new Movie
                {
                    Title = "Joseph Smith Legacy",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Drama",
                    Rating = "PG-13",
                    Price = 11.99M
                },
                new Movie
                {
                    Title = "The RM",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Genre = "Comedy",
                    Rating = "PG-13",
                    Price = 15.99M
                },
                new Movie
                {
                    Title = "Other Side Of heaven",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Genre = "Drama",
                    Rating = "M",
                    Price = 9.99M
                },
                new Movie
                {
                    Title = "Meet the Mormons",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Genre = "Documentary",
                    Rating = "PG",
                    Price = 20.99M
                }
            );
            context.SaveChanges();
        }
    }
}