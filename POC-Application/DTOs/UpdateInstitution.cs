using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POC_Application.DTOs
{
    public class UpdateInstitution
    {
        public long FIRecordID { get; set; } 

        [Required]
        [StringLength(50)]
        public string BaseCurrCode { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Address { get; set; }

        [StringLength(50)]
        public string? City { get; set; }

        [StringLength(50)]
        public string? State { get; set; }

        public string? ZipCode { get; set; }
        [StringLength(1000)]
        public string? Website { get; set; }
        [StringLength(500)]
        public string? DomainName { get; set; }
        [StringLength(500)]
        public string? Email { get; set; }
        [StringLength(20)]
        public string? Telephone1 { get; set; }
        [StringLength(20)]
        public string? Telephone2 { get; set; }

        public byte[]? Logo { get; set; }

        [StringLength(50)]
        public string? SortCode { get; set; }
        [StringLength(50)]
        public string? SwiftCode { get; set; }
        [StringLength(50)]
        public string? IBAN { get; set; }
        [StringLength(50)]
        public string? NubanCode { get; set; }
        [StringLength(50)]
        public string? SoftwareLicenceKey { get; set; }

        [Required]
        [StringLength(50)]
        public string LastModifiedBy { get; set; } = string.Empty;
    }
}
