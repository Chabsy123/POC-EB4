using POC_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace POC_Application.Interfaces
{
    public interface IInstitution
    {
        Task<Institution?> GetByIdAsync(long id);
        Task<IEnumerable<Institution>> GetAllAsync();
        Task AddAsync(Institution institution);
        Task UpdateAsync(Institution institution);
        Task DeleteAsync(long id);
    }

}
