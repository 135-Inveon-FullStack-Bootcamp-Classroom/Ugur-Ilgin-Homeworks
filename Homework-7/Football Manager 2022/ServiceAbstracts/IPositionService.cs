using Football_Manager_2022.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Football_Manager_2022.ServiceAbstracts
{
    public interface IPositionService
    {
        public Task<IEnumerable<Positions>> GetAllAsync();
        public Task<Positions> GetAsync(int id);
        public Task UpdateAsync(int id, Positions positions);
        public  Task<Positions> CreateAsync(Positions positions);
        public Task  DeleteAsync(int id);
    }
}
