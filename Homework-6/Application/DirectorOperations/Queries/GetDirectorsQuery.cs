using Imdb_Clone.DbOperations;
using Imdb_Clone.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imdb_Clone.Application.DirectorOperations.Queries
{
    public class GetDirectorsQuery
    {
        private readonly ImdbDbContext _dbContext;

        public GetDirectorsQuery(ImdbDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Director> Handle()
        {

            var directors = _dbContext.Directors.ToList();

            return directors;
        }
    }
}
