using Football_Manager_2022.Entities;
using Football_Manager_2022.Data;

using Football_Manager_2022.ServiceAbstracts;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace Football_Manager_2022.ServiceImplementetions
{
    public class ManagerService : IManagerService
    {
        private readonly ApplicationDbContext _context;
        public ManagerService(ApplicationDbContext context){

            _context=context;
            }

        public async Task<Manager> CreateAsync(Manager manager)
        {
            _context.Managers.Add(manager);
            await _context.SaveChangesAsync();

            return manager;
        }

        public async Task DeleteAsync(int id)
        {
            var manager = await _context.Managers.FindAsync(id);
            if (manager == null)
            {
                throw new Exception("Yönetici Bulunamadı");
            }

            _context.Managers.Remove(manager);
            await _context.SaveChangesAsync();

           
        }

        public async Task<IEnumerable<Manager>> GetAllAsync()
        {
            return await _context.Managers.ToListAsync();
        }
       
        public async Task<Manager> GetAsync(int id)
        {
            var manager = await _context.Managers.FindAsync(id);
            return manager;
        }
        private bool ManagerExists(int id)
        {
            return _context.Managers.Any(e => e.Id == id);
        }
        public async Task UpdateAsync(int id, Manager manager)
        {
            if (id != manager.Id)
            {
                throw new Exception("IDler uyuşmadı");
            }

            _context.Entry(manager).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManagerExists(id))
                {
                    throw new Exception("Yönetici  Yok");
                }
                else
                {
                    throw;
                }
            }

            
        }

        

        public async Task<IEnumerable<Manager>> GetManagerWithPositions()
        {
            return await _context.Managers.Include(p => p.ManagementPosition).ToListAsync();
        }
    }
}
