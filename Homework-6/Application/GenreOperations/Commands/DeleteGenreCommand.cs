using Imdb_Clone.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imdb_Clone.Application.GenreOperations.Commands
{
    public class DeleteGenreCommand
    {
        private readonly ImdbDbContext _dbContext;
        public int GenreId { get; set; }

        public DeleteGenreCommand(ImdbDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(x => x.GenreId == GenreId);

            if (genre is null)
            {
                throw new InvalidOperationException("Genre not found");
            }

            _dbContext.Genres.Remove(genre);
            _dbContext.SaveChanges();
        }
    }
}
