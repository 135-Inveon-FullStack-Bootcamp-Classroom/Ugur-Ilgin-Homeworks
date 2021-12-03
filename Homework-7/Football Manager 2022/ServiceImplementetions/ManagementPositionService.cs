﻿using Football_Manager_2022.Entities;
using Football_Manager_2022.Data;

using Football_Manager_2022.ServiceAbstracts;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace Football_Manager_2022.ServiceImplementetions
{
    public class ManagementPositionService : IManagementPositionService
    {
        private readonly ApplicationDbContext _context;
        public ManagementPositionService(ApplicationDbContext context){

            _context=context;
            }

        public async Task<ManagementPosition> CreateAsync(ManagementPosition management)
        {
            _context.ManagementPositions.Add(management);
            await _context.SaveChangesAsync();

            return management;
        }

        public async Task DeleteAsync(int id)
        {
            var management = await _context.ManagementPositions.FindAsync(id);
            if (management == null)
            {
                throw new Exception("Yönetim Pozisyonu Bulunamadı");
            }

            _context.ManagementPositions.Remove(management);
            await _context.SaveChangesAsync();

           
        }

        public async Task<IEnumerable<ManagementPosition>> GetAllAsync()
        {
            return await _context.ManagementPositions.ToListAsync();
        }
       
        public async Task<ManagementPosition> GetAsync(int id)
        {
            var management = await _context.ManagementPositions.FindAsync(id);
            return management;
        }
        private bool ManagementPositionExists(int id)
        {
            return _context.ManagementPositions.Any(e => e.Id == id);
        }
        public async Task UpdateAsync(int id, ManagementPosition management)
        {
            if (id != management.Id)
            {
                throw new Exception("IDler uyuşmadı");
            }

            _context.Entry(management).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManagementPositionExists(id))
                {
                    throw new Exception("Yönetici Pozisyonu Yok");
                }
                else
                {
                    throw;
                }
            }

            
        }
      
    }
}
