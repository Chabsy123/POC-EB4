using System.Collections.Generic;
using System.Threading.Tasks;
using POC_Domain.Entities;

namespace POC_Domain.Interfaces
{
    public interface IFinancialInstitution
    {
        Task<FinancialInstitution?> GetByIdAsync(long id);
        Task<IEnumerable<FinancialInstitution>> GetAllAsync();
        Task AddAsync(FinancialInstitution institution);
        Task UpdateAsync(FinancialInstitution institution);
        Task DeleteAsync(long id);
    }
}