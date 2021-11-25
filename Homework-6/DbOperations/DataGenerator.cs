using Imdb_Clone.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imdb_Clone.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            List<string> harryPottersActors = new List<string>() { "Daniel ", "Pierce", "Sean" };
            List<string> jamesBondActors = new List<string>() { "Daniel", "Rami", "Ralp" };
            using (var context = new ImdbDbContext(serviceProvider.GetRequiredService<DbContextOptions<ImdbDbContext>>()))
            {
                if (context.Movies.Any())
                {
                    return;
                }

                context.Movies.AddRange(
                    new Movie
                    {
                        Name= "Harry Potter and the Philosopher's Stone",
                        Year= "2001",
                        Actors= "harryPottersActors",
                        Director = "Chris Columbus",
                        Genre = "Fantastic"

                    },
                    new Movie
                    {
                        Name = "Bond 25",
                        Year = "2021",
                        Actors = "jamesBondActors",
                        Director = "Cary Joji Fukunaga",
                        Genre = "History"
                    }
                    );

                context.Genres.AddRange(
                    new Genre
                    {
                        Name="Fantastic"
                    },
                    new Genre
                    {
                        Name= "Comedy"
                    }
                    );

                context.Directors.AddRange(
                    new Director
                    {
                        Name = "Chris",
                        Surname = "Columbus"
                    },
                    new Director
                    {
                      
                         Name = "Cary Joji",
                        Surname = "Fukunaga"
                    }
                    );

                context.Actors.AddRange(
                    new Actor
                    {
                        Name= "Daniel",
                        Surname= "radcliffe"
                    },
                    new Actor
                    {
                        Name="Emma",
                        Surname="Watson"
                    },
                    new Actor
                    {
                        Name="Rupert",
                        Surname="Grint"
                    },
                    new Actor
                    {
                        Name="Daniel",
                        Surname="Craig"
                    },
                    new Actor
                    {
                        Name="Rami",
                        Surname="Malek"
                    },
                    new Actor
                    {
                        Name="Ralp",
                        Surname="Fiennes"
                    }
                    );

                context.SaveChanges();

            }
        }


    }
}
