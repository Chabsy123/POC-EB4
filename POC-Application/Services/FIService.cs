using POC_Application.DTOs;
using POC_Domain.Entities;
using POC_Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace POC_Application.Services
{
    public class FinancialInstitutionService
    {
        private readonly IFinancialInstitution _repository;

        public FinancialInstitutionService(IFinancialInstitution repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<FinancialInstitutionDto>> GetAllAsync()
        {
            var items = await _repository.GetAllAsync();
            return items.Select(MapToDto);
        }

        public async Task<FinancialInstitutionDto?> GetByIdAsync(long id)
        {
            var item = await _repository.GetByIdAsync(id);
            return item == null ? null : MapToDto(item);
        }

        public async Task<FinancialInstitutionDto> CreateAsync(CreateFIDTO request)
        {
            var entity = new FinancialInstitution
            {
                FIName = request.FIName,
                FICategory = request.FICategory,
                FICode = request.FICode,
                Mnemonic = request.Mnemonic,
                DateAdded = DateTime.UtcNow, // System date generated 
                AddedBy = request.AddedBy,
                DateLastModified = null, // Initial value is NULL 
                LastModifiedBy = null
            };

            await _repository.AddAsync(entity);
            return MapToDto(entity);
        }

        public async Task<bool> UpdateAsync(long id, UpdateFIDTO request)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;

            entity.FIName = request.FIName;
            entity.FICategory = request.FICategory;
            entity.FICode = request.FICode;
            entity.Mnemonic = request.Mnemonic;
            entity.DateLastModified = DateTime.UtcNow; // Tracks update runtime
            entity.LastModifiedBy = request.LastModifiedBy;

            await _repository.UpdateAsync(entity);
            return true;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;

            await _repository.DeleteAsync(id);
            return true;
        }

        private static FinancialInstitutionDto MapToDto(FinancialInstitution entity) => new()
        {
            RecordID = entity.RecordId,
            FIName = entity.FIName,
            FICategory = entity.FICategory,
            FICode = entity.FICode,
            Mnemonic = entity.Mnemonic,
            DateAdded = entity.DateAdded,
            DateLastModified = entity.DateLastModified,
            AddedBy = entity.AddedBy,
            LastModifiedBy = entity.LastModifiedBy
        };
    }
}
