using Football_Manager_2022.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Football_Manager_2022.ServiceAbstracts
{
    public interface ICoachService
    {
        public Task<IEnumerable<Coach>> GetAllAsync();
        public Task<IEnumerable<Coach>> GetCoachwithTacticssAsync();
        public Task<Coach> GetAsync(int id);
        public Task UpdateAsync(int id, Coach coach);
        public  Task<Coach> CreateAsync(Coach coach);
        public Task  DeleteAsync(int id);
    }
}
