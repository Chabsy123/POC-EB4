using System;
using System.Collections.Generic;
using System.Text;

namespace POC_Application.DTOs
{
    public class FinancialInstitutionDto
    {
        public long RecordID { get; set; }
        public string FIName { get; set; } = string.Empty;
        public string FICategory { get; set; } = string.Empty;
        public string FICode { get; set; } = string.Empty;
        public string? Mnemonic { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? DateLastModified { get; set; }
        public string AddedBy { get; set; } = string.Empty;
        public string? LastModifiedBy { get; set; }
    }
}
