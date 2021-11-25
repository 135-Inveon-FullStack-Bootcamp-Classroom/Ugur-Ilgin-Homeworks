using Imdb_Clone.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imdb_Clone.Application.DirectorOperations.Commands
{
    public class DeleteDirectorCommand
    {
        private readonly ImdbDbContext _dbContext;
        public int DirectorId { get; set; }

        public DeleteDirectorCommand(ImdbDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var director = _dbContext.Directors.SingleOrDefault(x => x.DirectorId == DirectorId);

            if (director is null)
            {
                throw new InvalidOperationException("Director not found");
            }

            _dbContext.Directors.Remove(director);
            _dbContext.SaveChanges();
        }
    }
}
