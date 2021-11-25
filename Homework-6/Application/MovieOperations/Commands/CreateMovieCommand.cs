using Imdb_Clone.DbOperations;
using Imdb_Clone.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imdb_Clone.Application.MovieOperations.Commands
{
    public class CreateMovieCommand
    {
        private readonly ImdbDbContext _dbContext;

        public CreateMovieCommand(ImdbDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle(Movie newMovie)
        {
            var movie = _dbContext.Movies.SingleOrDefault(x => x.Name == newMovie.Name);

            if (movie is not null)
            {
                throw new InvalidOperationException("Movie already exist");
            }

            newMovie.MovieId = 0;

            _dbContext.Movies.Add(newMovie);
            _dbContext.SaveChanges();

        }




    }
}
