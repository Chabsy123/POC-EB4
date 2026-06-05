using Microsoft.EntityFrameworkCore;
using POC_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace POC_Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<FinancialInstitution> FinancialInstitutions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Maps explicitly to adm database schema and table [cite: 1]
            modelBuilder.Entity<FinancialInstitution>(entity =>
            {
            entity.ToTable("FinancialInstitutions", "adm");

            entity.HasKey(e => e.RecordId);
             entity.Property(e => e.RecordId).ValueGeneratedOnAdd(); // System generated

             entity.Property(e => e.FIName).IsRequired().HasMaxLength(300);
                entity.Property(e => e.FICategory).IsRequired().HasMaxLength(50);
                 entity.Property(e => e.FICode).IsRequired().HasMaxLength(50); 
                 entity.Property(e => e.Mnemonic).HasMaxLength(50).IsRequired(false); 
                
                entity.Property(e => e.DateAdded).IsRequired();
            entity.Property(e => e.DateLastModified).IsRequired(false); // Null allowed
            entity.Property(e => e.AddedBy).IsRequired().HasMaxLength(50);
            entity.Property(e => e.LastModifiedBy).HasMaxLength(50).IsRequired(false); // Null allowed
        });
        }
}
}
