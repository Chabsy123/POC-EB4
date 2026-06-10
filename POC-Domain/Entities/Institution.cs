using System;
using System.Collections.Generic;
using System.Text;

namespace POC_Domain.Entities
{
    public class Institution
    {
        public long RecordID { get; set; } // bigint, Primary Key, System generated
        public long FIRecordID { get; set; } // bigint, Foreign Key to FinancialInstitution
        public string InstitutionCode { get; set; } = string.Empty; // nvarchar(50)
        public string InstitutionName { get; set; } = string.Empty; // nvarchar(300), Mandatory
        public string? Mnemonic { get; set; } //sourced from Mnemonic in FinancialInstitution, nvarchar(50),

        public string BaseCurrCode { get; set; } = string.Empty; // nvarchar(3), sourced from gl.currencies
        public string? Address { get; set;} //max 500
        public string? City { get; set; } //max 50

        public string? State { get; set; } //max 50
        public string? ZipCode { get; set; } //max 10

        public string? Website { get; set; } //max 1000
        public string? DomainName { get; set; } //max 500
        public string? Email { get; set; } //max 500
        public string? Telephone1 { get; set; } //max 20
        public string? Telephone2 { get; set; } //max 20
        public byte[]? Logo { get; set; } //binary storage for image upload
        public string? SortCode { get; set; } //max 50
        public string? SwiftCode { get; set; } //max 50
        public string? IBAN { get; set; } //max 50
        public string? NubanCode { get; set; } //max 50
        public string? SoftwareLicenceKey { get; set; } //max 50
        public DateTime DateAdded { get; set; } // datetime, System date
        public DateTime? DateLastModified { get; set; } // datetime, NULL if no update
        public string AddedBy { get; set; } = string.Empty; // nvarchar(50), Login ID
        public string? LastModifiedBy { get; set; }// nvarchar(50), NULL if no update

        //Relationship Link built by EF Core
        public FinancialInstitution? FinancialInstitution { get; set; }
    }
}
