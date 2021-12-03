using Football_Manager_2022.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Football_Manager_2022.ServiceAbstracts
{
    public interface IManagementPositionService
    {
        public Task<IEnumerable<ManagementPosition>> GetAllAsync();
        public Task<ManagementPosition> GetAsync(int id);
        public Task UpdateAsync(int id, ManagementPosition managementPosition);
        public  Task<ManagementPosition> CreateAsync(ManagementPosition managementPosition);
        public Task  DeleteAsync(int id);
    }
}
