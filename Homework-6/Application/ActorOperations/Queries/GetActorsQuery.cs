using Imdb_Clone.DbOperations;
using Imdb_Clone.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imdb_Clone.Application.ActorOperations.Queries
{
    public class GetActorsQuery
    {
        private readonly ImdbDbContext _dbContext;

        public GetActorsQuery(ImdbDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Actor> Handle()
        {

            var actors = _dbContext.Actors.ToList();

            return actors;
        }
    }
}
