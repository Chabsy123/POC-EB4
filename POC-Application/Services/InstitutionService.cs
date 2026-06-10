using POC_Application.DTOs;
using POC_Application.Interfaces;
using POC_Domain.Entities;
using POC_Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace POC_Application.Services
{
    public class InstitutionService
    {
        private readonly IInstitution _institution;
        private readonly IFinancialInstitution _fi;

        // Dependency injection gives us access to both data scopes cleanly
        public InstitutionService(IInstitution institutionRepository, IFinancialInstitution fi)
        {
            _institution = institutionRepository;
            _fi = fi;
        }

        public async Task<IEnumerable<InstitutionDto>> GetAllAsync()
        {
            var data = await _institution.GetAllAsync();
            return data.Select(MapToDto);
        }

        public async Task<InstitutionDto?> GetByIdAsync(long id)
        {
            var data = await _institution.GetByIdAsync(id);
            return data == null ? null : MapToDto(data);
        }

        public async Task<InstitutionDto> CreateAsync(CreateInstitution request)
        {
           //. Fetch parent Financial Institution data 
            var masterFi = await _fi.GetByIdAsync(request.FIRecordID);
            if (masterFi == null)
            {
                throw new ArgumentException("The selected Master Financial Institution does not exist.");
            }

            // Auto-populating common data parameters 
            var entity = new Institution
            {
                FIRecordID = request.FIRecordID,

                //Directly pulling data from the master record primary key to ensure consistency and reduce user input errors
                InstitutionCode = masterFi.FICode,
                InstitutionName = masterFi.FIName,
                Mnemonic = masterFi.Mnemonic,

                BaseCurrCode = request.BaseCurrCode,
                Address = request.Address,
                City = request.City,
                State = request.State,
                ZipCode = request.ZipCode,
                Website = request.Website,
                DomainName = request.DomainName,
                Email = request.Email,
                Telephone1 = request.Telephone1,
                Telephone2 = request.Telephone2,
                Logo = request.Logo,
                SortCode = request.SortCode,
                SwiftCode = request.SwiftCode,
                IBAN = request.IBAN,
                NubanCode = request.NubanCode,
                SoftwareLicenceKey = request.SoftwareLicenceKey,

                DateAdded = DateTime.UtcNow,
                AddedBy = request.AddedBy
            };

            await _institution.AddAsync(entity);
            return MapToDto(entity);
        }

        public async Task<bool> UpdateAsync(long id, UpdateInstitution request)
        {
            var entity = await _institution.GetByIdAsync(id);
            if (entity == null) return false;

            var masterFi = await _fi.GetByIdAsync(request.FIRecordID);
            if (masterFi == null) throw new ArgumentException("Invalid Master Financial Institution pointer.");

            // Sync values if the parent company profile changes
            entity.FIRecordID = request.FIRecordID;
            entity.InstitutionCode = masterFi.FICode;
            entity.InstitutionName = masterFi.FIName;
            entity.Mnemonic = masterFi.Mnemonic;

            entity.BaseCurrCode = request.BaseCurrCode;
            entity.Address = request.Address;
            entity.City = request.City;
            entity.State = request.State;
            entity.ZipCode = request.ZipCode;
            entity.Website = request.Website;
            entity.DomainName = request.DomainName;
            entity.Email = request.Email;
            entity.Telephone1 = request.Telephone1;
            entity.Telephone2 = request.Telephone2;
            entity.Logo = request.Logo;
            entity.SortCode = request.SortCode;
            entity.SwiftCode = request.SwiftCode;
            entity.IBAN = request.IBAN;
            entity.NubanCode = request.NubanCode;
            entity.SoftwareLicenceKey = request.SoftwareLicenceKey;

            entity.DateLastModified = DateTime.UtcNow;
            entity.LastModifiedBy = request.LastModifiedBy;

            await _institution.UpdateAsync(entity);
            return true;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await _institution.GetByIdAsync(id);
            if (entity == null) return false;

            await _institution.DeleteAsync(id);
            return true;
        }

        private static InstitutionDto MapToDto(Institution e) => new()
        {
            RecordID = e.RecordID,
            FIRecordID = e.FIRecordID,
            InstitutionCode = e.InstitutionCode,
            InstitutionName = e.InstitutionName,
            Mnemonic = e.Mnemonic,
            BaseCurrCode = e.BaseCurrCode,
            Address = e.Address,
            City = e.City,
            State = e.State,
            ZipCode = e.ZipCode,
            Website = e.Website,
            DomainName = e.DomainName,
            Email = e.Email,
            Telephone1 = e.Telephone1,
            Telephone2 = e.Telephone2,
            Logo = e.Logo,
            SortCode = e.SortCode,
            SwiftCode = e.SwiftCode,
            IBAN = e.IBAN,
            NubanCode = e.NubanCode,
            SoftwareLicenceKey = e.SoftwareLicenceKey
        };
    }
}
