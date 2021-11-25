using Imdb_Clone.DbOperations;
using Imdb_Clone.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imdb_Clone.Application.DirectorOperations.Commands
{
    public class CreateDirectorCommand
    {

        private readonly ImdbDbContext _dbContext;

        public CreateDirectorCommand(ImdbDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle(Director newDirector)
        {
            var director = _dbContext.Directors.SingleOrDefault(x => x.Name == newDirector.Name);

            if (director is not null)
            {
                throw new InvalidOperationException("Director already exist");
            }

            newDirector.DirectorId = 0;

            _dbContext.Directors.Add(newDirector);
            _dbContext.SaveChanges();

        }

    }
}
