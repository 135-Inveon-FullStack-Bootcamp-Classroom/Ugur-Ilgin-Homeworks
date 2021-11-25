using Imdb_Clone.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imdb_Clone.Application.GenreOperations.Commands
{
    public class UpdateGenreCommand
    {
        private readonly ImdbDbContext _dbContext;
        public int GenreId { get; set; }
        public UpdateGenreVM Model {get;set;}

        public UpdateGenreCommand(ImdbDbContext dbContext)
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
            genre.Name = Model.Name;

            _dbContext.SaveChanges();

        }

    }

    public class UpdateGenreVM
    {
        public string Name { get; set; }
    }
}
