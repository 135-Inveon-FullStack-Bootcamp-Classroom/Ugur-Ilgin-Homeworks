using Imdb_Clone.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imdb_Clone.Application.ActorOperations.Commands
{
    public class DeleteActorCommand
    {
        private readonly ImdbDbContext _dbContext;
        public int ActorId { get; set; }

        public DeleteActorCommand(ImdbDbContext dbContext)
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

            _dbContext.Actors.Remove(actor);
            _dbContext.SaveChanges();
        }
    }
}
