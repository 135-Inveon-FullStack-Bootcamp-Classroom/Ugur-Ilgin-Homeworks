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
    public class FootballerServices : IFootballerService
    {
        private readonly ApplicationDbContext _context;
        public FootballerServices(ApplicationDbContext context){

            _context=context;
            }

        public async Task<Footballer> CreateAsync(Footballer footballer)
        {
            _context.Footballers.Add(footballer);
            await _context.SaveChangesAsync();

            return footballer;
        }

        public async Task DeleteAsync(int id)
        {
            var footballer = await _context.Footballers.FindAsync(id);
            if (footballer == null)
            {
                throw new Exception("Futbolcu Bulunamadı");
            }

            _context.Footballers.Remove(footballer);
            await _context.SaveChangesAsync();

           
        }

        public async Task<IEnumerable<Footballer>> GetAllAsync()
        {
            return await _context.Footballers.ToListAsync();
        }
       
        public async Task<Footballer> GetAsync(int id)
        {
            var footballer = await _context.Footballers.FindAsync(id);
            return footballer;
        }
        private bool FootballerExists(int id)
        {
            return _context.Footballers.Any(e => e.Id == id);
        }
        public async Task UpdateAsync(int id, Footballer footballer)
        {
            if (id != footballer.Id)
            {
                throw new Exception("IDler uyuşmadı");
            }

            _context.Entry(footballer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FootballerExists(id))
                {
                    throw new Exception("Takım Yok");
                }
                else
                {
                    throw;
                }
            }

            
        }

       

         async Task<IEnumerable<Footballer>> IFootballerService.GetFootballerwithPosition()
        {
            return await _context.Footballers.Include(p => p.Positions).ToListAsync();
        }
    }
}
