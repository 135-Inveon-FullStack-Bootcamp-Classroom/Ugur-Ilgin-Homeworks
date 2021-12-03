using Football_Manager_2022.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Football_Manager_2022.ServiceAbstracts
{
    public interface ITacticService
    {
        public Task<IEnumerable<Tactic>> GetAllAsync();
        public Task<Tactic> GetAsync(int id);
        public Task UpdateAsync(int id, Tactic tactic);
        public  Task<Tactic> CreateAsync(Tactic team);
        public Task  DeleteAsync(int id);
    }
}
