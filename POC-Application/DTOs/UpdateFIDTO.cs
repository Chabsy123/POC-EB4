using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POC_Application.DTOs
{
    public class UpdateFIDTO
    {
    [Required]
    [StringLength(300)]
    public string FIName { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string FICategory { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string FICode { get; set; } = string.Empty;

    [StringLength(50)]
    public string? Mnemonic { get; set; }

    [Required]
    [StringLength(50)]
    public string LastModifiedBy { get; set; } = string.Empty;
    }
}
