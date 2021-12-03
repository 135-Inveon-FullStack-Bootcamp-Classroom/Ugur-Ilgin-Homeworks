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
    public class TeamService : ITeamService
    {
        private readonly ApplicationDbContext _context;
        public TeamService (ApplicationDbContext context){

            _context=context;
            }

        public async Task<Team> CreateAsync(Team team)
        {
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();

            return team;
        }

        public async Task DeleteAsync(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team == null)
            {
                throw new Exception("Takım Bulunamadı");
            }

            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();

           
        }

        public async Task<IEnumerable<Team>> GetAllAsync()
        {
            return await _context.Teams.ToListAsync();
        }
        public async Task<IEnumerable<Team>> GetTeamswithFootballersAsync()
        {
            return await _context.Teams.Include(p => p.Footballers).ToListAsync();
        }
        public async Task<Team> GetAsync(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            return team;
        }
        private bool TeamExists(int id)
        {
            return _context.Teams.Any(e => e.Id == id);
        }
        public async Task UpdateAsync(int id, Team team)
        {
            if (id != team.Id)
            {
                throw new Exception("IDler uyuşmadı");
            }

            _context.Entry(team).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamExists(id))
                {
                    throw new Exception("Takım Yok");
                }
                else
                {
                    throw;
                }
            }

            
        }

        public async Task<IEnumerable<Team>> GetTeamsWithCoachAsync()
        {
            return await _context.Teams.Include(p => p.Coaches).ToListAsync();
        }

        public async Task<IEnumerable<Team>> GetTeamsWithManagerAsync()
        {
            return await _context.Teams.Include(p => p.Managers).ToListAsync();
        }
        public async Task<IEnumerable<Team>> GetAllValuesAsync()
        {
            return await _context.Teams.Include(p => p.Managers).Include(p=> p.Footballers).Include(p=>p.Managers).ToListAsync();
        }

    }
}
