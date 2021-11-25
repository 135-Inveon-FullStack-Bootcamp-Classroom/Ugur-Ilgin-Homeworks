using Imdb_Clone.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imdb_Clone.Application.ActorOperations.Commands
{
    public class UpdateActorCommand
    {
        private readonly ImdbDbContext _dbContext;
        public int ActorId { get; set; }
        public UpdateActorVM Model { get; set; }

        public UpdateActorCommand(ImdbDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var actor = _dbContext.Actors.SingleOrDefault(x => x.ActorId == ActorId);

            if (actor is null)
            {
                throw new InvalidOperationException("Actor not found");
            }
            actor.Name = Model.Name;
            actor.Surname = Model.Surname;

            _dbContext.SaveChanges();

        }
    }
    public class UpdateActorVM
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
