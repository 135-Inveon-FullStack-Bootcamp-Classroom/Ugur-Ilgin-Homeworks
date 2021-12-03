using Football_Manager_2022.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Football_Manager_2022.ServiceAbstracts
{
    public interface INationalTeamService
    {
        public Task<IEnumerable<NationalTeam>> GetAllAsync();
        public Task<IEnumerable<NationalTeam>> GetTeamswithFootballersAsync();
        public Task<NationalTeam> GetAsync(int id);
        public Task UpdateAsync(int id, NationalTeam nationalTeam);
        public  Task<NationalTeam> CreateAsync(NationalTeam nationalTeam);
        public Task  DeleteAsync(int id);
    }
}
