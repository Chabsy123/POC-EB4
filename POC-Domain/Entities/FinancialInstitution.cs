using System;

namespace POC_Domain.Entities
{
    public class FinancialInstitution
    {
        public long RecordId { get; set; } // bigint, Primary Key, System generated
        public string FIName { get; set; } = string.Empty; // nvarchar(300), Mandatory
        public string FICategory { get; set; } = string.Empty; // nvarchar(50), Mandatory
        public string FICode { get; set; } = string.Empty; // nvarchar(50)
        public string? Mnemonic { get; set; } // nvarchar(50), Optional
        public DateTime DateAdded { get; set; } // datetime, System date
        public DateTime? DateLastModified { get; set; } // datetime, NULL if no update
        public string AddedBy { get; set; } = string.Empty; // nvarchar(50), Login ID
        public string? LastModifiedBy { get; set; } = string.Empty;// nvarchar(50), NULL if no update

        //Establish relationship tracking path
        public ICollection<Institution> Institutions { get; set; } = new List<Institution>();
    }
}