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
    public class TacticService : ITacticService
    {
        private readonly ApplicationDbContext _context;
        public TacticService(ApplicationDbContext context){

            _context=context;
            }

        public async Task<Tactic> CreateAsync(Tactic tactic)
        {
            _context.Tactics.Add(tactic);
            await _context.SaveChangesAsync();

            return tactic;
        }

        public async Task DeleteAsync(int id)
        {
            var tactic = await _context.Tactics.FindAsync(id);
            if (tactic == null)
            {
                throw new Exception("Taktik Bulunamadı");
            }

            _context.Tactics.Remove(tactic);
            await _context.SaveChangesAsync();

           
        }

        public async Task<IEnumerable<Tactic>> GetAllAsync()
        {
            return await _context.Tactics.ToListAsync();
        }
       
        public async Task<Tactic> GetAsync(int id)
        {
            var tactic = await _context.Tactics.FindAsync(id);
            return tactic;
        }
        private bool TacticExists(int id)
        {
            return _context.Tactics.Any(e => e.Id == id);
        }
        public async Task UpdateAsync(int id, Tactic tactic)
        {
            if (id != tactic.Id)
            {
                throw new Exception("IDler uyuşmadı");
            }

            _context.Entry(tactic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TacticExists(id))
                {
                    throw new Exception("Taktik Maktik Yok Bam Bam Bam" );
                }
                else
                {
                    throw;
                }
            }

            
        }
      
    }
}
