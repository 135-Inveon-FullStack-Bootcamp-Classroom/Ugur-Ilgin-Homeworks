using Imdb_Clone.DbOperations;
using Imdb_Clone.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imdb_Clone.Application.MovieOperations.Queries
{
    public class GetMoviesQuery
    {
        private readonly ImdbDbContext _dbContext;

        public GetMoviesQuery(ImdbDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Movie> Handle()
        {

            var movies = _dbContext.Movies.ToList();

            return movies;
        }
    }
}
