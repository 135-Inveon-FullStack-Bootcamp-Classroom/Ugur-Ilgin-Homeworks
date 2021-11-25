using Imdb_Clone.DbOperations;
using Imdb_Clone.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imdb_Clone.Application.ActorOperations.Commands
{
    public class CreateActorCommand
    {
        private readonly ImdbDbContext _dbContext;

        public CreateActorCommand(ImdbDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle(Actor newActor)
        {
            var actor = _dbContext.Movies.SingleOrDefault(x => x.Name == newActor.Name);

            if (actor is not null)
            {
                throw new InvalidOperationException("Actor already exist");
            }

            newActor.ActorId = 0;

            _dbContext.Actors.Add(newActor);
            _dbContext.SaveChanges();

        }


    }
}
