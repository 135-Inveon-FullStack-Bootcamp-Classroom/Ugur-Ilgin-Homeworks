using Imdb_Clone.DbOperations;
using Imdb_Clone.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imdb_Clone.Application.GenreOperations.Queries
{
    public class GetGenresQuery
    {
        private readonly ImdbDbContext _dbContext;

        public GetGenresQuery(ImdbDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Genre> Handle()
        {

            var genres = _dbContext.Genres.ToList();

            return genres;
        }
    }
}
