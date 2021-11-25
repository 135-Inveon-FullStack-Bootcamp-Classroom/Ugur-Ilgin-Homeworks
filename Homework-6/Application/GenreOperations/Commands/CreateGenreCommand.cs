using Imdb_Clone.DbOperations;
using Imdb_Clone.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imdb_Clone.Application.GenreOperations.Commands
{
    public class CreateGenreCommand
    {
        private readonly ImdbDbContext _dbContext;

        public CreateGenreCommand(ImdbDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle(Genre newGenre)
        {
            var genre = _dbContext.Genres.SingleOrDefault(x => x.Name == newGenre.Name);

            if (genre is not null)
            {
                throw new InvalidOperationException("Genre already exist");
            }

            newGenre.GenreId = 0;

            _dbContext.Genres.Add(newGenre);
            _dbContext.SaveChanges();

        }
    }
}
