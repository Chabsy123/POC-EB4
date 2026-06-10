using Microsoft.EntityFrameworkCore;
using POC_Application.Interfaces;
using POC_Domain.Entities;
using POC_Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace POC_Infrastructure.Repositories
{
    public class InstitutionRepository : IInstitution
    {
        private readonly ApplicationDbContext _context;

        public InstitutionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Institution?> GetByIdAsync(long id)
        {
            return await _context.Institutions.FindAsync(id);
        }

        public async Task<IEnumerable<Institution>> GetAllAsync()
        {
            return await _context.Institutions.ToListAsync();
        }

        public async Task AddAsync(Institution institution)
        {
            await _context.Institutions.AddAsync(institution);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Institution institution)
        {
            _context.Institutions.Update(institution);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var entity = await _context.Institutions.FindAsync(id);
            if (entity != null)
            {
                _context.Institutions.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
