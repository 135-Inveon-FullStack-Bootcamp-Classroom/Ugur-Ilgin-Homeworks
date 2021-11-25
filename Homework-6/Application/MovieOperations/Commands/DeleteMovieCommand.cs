using Imdb_Clone.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imdb_Clone.Application.MovieOperations.Commands
{
    public class DeleteMovieCommand
    {
        private readonly ImdbDbContext _dbContext;
        public int MovieId { get; set; }

        public DeleteMovieCommand(ImdbDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var movie = _dbContext.Movies.SingleOrDefault(x => x.MovieId == MovieId);

            if (movie is null)
            {
                throw new InvalidOperationException("Movie not found");
            }

            _dbContext.Movies.Remove(movie);
            _dbContext.SaveChanges();
        }

    }
}
