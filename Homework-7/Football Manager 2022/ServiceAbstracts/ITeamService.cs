using Football_Manager_2022.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Football_Manager_2022.ServiceAbstracts
{
    public interface ITeamService
    {
        public Task<IEnumerable<Team>> GetAllAsync();
        public Task<IEnumerable<Team>> GetTeamswithFootballersAsync();
        public Task<IEnumerable<Team>> GetTeamsWithCoachAsync();
        public Task<IEnumerable<Team>> GetTeamsWithManagerAsync();
        public Task<IEnumerable<Team>> GetAllValuesAsync();
        public Task<Team> GetAsync(int id);
        public Task UpdateAsync(int id, Team team);
        public  Task<Team> CreateAsync(Team team);
        public Task  DeleteAsync(int id);
    }
}
