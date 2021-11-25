using Imdb_Clone.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imdb_Clone.Application.DirectorOperations.Commands
{
    public class UpdateDirectorCommand
    {
        private readonly ImdbDbContext _dbContext;
        public int DirectorId { get; set; }
        public UpdateDirectorVM Model { get; set; }

        public UpdateDirectorCommand(ImdbDbContext dbContext)
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
            director.Name = Model.Name;
            director.Surname = Model.Surname;

            _dbContext.SaveChanges();

        }
    }

    public class UpdateDirectorVM
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
