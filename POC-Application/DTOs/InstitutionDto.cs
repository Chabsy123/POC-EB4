using System;
using System.Collections.Generic;
using System.Text;

namespace POC_Application.DTOs
{
    public class InstitutionDto
    {
        public long RecordID { get; set; }
        public long FIRecordID { get; set; }
        public string InstitutionCode { get; set; } = string.Empty;
        public string InstitutionName { get; set; } = string.Empty;
        public string? Mnemonic { get; set; }
        public string BaseCurrCode { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
        public string? Website { get; set; }
        public string? DomainName { get; set; }
        public string? Email { get; set; }
        public string? Telephone1 { get; set; }
        public string? Telephone2 { get; set; }
        public byte[]? Logo { get; set; }   
        public string? SortCode { get; set; }
        public string? SwiftCode { get; set; }
        public string? IBAN { get; set; }
        public string? NubanCode { get; set; }

        public string? SoftwareLicenceKey { get; set; }
    }
}
