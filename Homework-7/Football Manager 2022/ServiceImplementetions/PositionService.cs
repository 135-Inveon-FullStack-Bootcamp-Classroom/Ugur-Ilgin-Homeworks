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
    public class PositionService : IPositionService
    {
        private readonly ApplicationDbContext _context;
        public PositionService(ApplicationDbContext context){

            _context=context;
            }

        public async Task<Positions> CreateAsync(Positions positions)
        {
            _context.Positions.Add(positions);
            await _context.SaveChangesAsync();

            return positions;
        }

        public async Task DeleteAsync(int id)
        {
            var positions = await _context.Positions.FindAsync(id);
            if (positions == null)
            {
                throw new Exception("Pozisyon Bulunamadı");
            }

            _context.Positions.Remove(positions);
            await _context.SaveChangesAsync();

           
        }

        public async Task<IEnumerable<Positions>> GetAllAsync()
        {
            return await _context.Positions.ToListAsync();
        }
       
        public async Task<Positions> GetAsync(int id)
        {
            var positions = await _context.Positions.FindAsync(id);
            return positions;
        }
        private bool PositionExists(int id)
        {
            return _context.Positions.Any(e => e.Id == id);
        }
        public async Task UpdateAsync(int id, Positions positions)
        {
            if (id != positions.Id)
            {
                throw new Exception("IDler uyuşmadı");
            }

            _context.Entry(positions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PositionExists(id))
                {
                    throw new Exception("Pozisyon Yok");
                }
                else
                {
                    throw;
                }
            }

            
        }
      
    }
}
