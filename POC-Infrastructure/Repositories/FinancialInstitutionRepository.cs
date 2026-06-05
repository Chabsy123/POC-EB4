using Microsoft.EntityFrameworkCore;
using POC_Domain.Entities;
using POC_Domain.Interfaces;
using POC_Infrastructure.Data;

namespace POC_Infrastructure.Repositories
{
    public class FinancialInstitutionRepository : IFinancialInstitution
{
    private readonly ApplicationDbContext _context;

    public FinancialInstitutionRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<FinancialInstitution?> GetByIdAsync(long id)
    {
        return await _context.FinancialInstitutions.FindAsync(id);
    }

    public async Task<IEnumerable<FinancialInstitution>> GetAllAsync()
    {
        return await _context.FinancialInstitutions.ToListAsync();
    }

    public async Task AddAsync(FinancialInstitution institution)
    {
        await _context.FinancialInstitutions.AddAsync(institution);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(FinancialInstitution institution)
    {
        _context.FinancialInstitutions.Update(institution);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(long id)
    {
        var institution = await _context.FinancialInstitutions.FindAsync(id);
        if (institution != null)
        {
            _context.FinancialInstitutions.Remove(institution);
            await _context.SaveChangesAsync();
        }
    }
}

}
