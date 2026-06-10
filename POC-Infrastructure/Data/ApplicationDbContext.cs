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
        public DbSet<Institution> Institutions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Maps explicitly to adm database schema and table
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

            modelBuilder.Entity<Institution>(entity =>
            {
                entity.ToTable("Institution", "adm"); // Explicitly matches 'adm.Institution' schema 
                entity.HasKey(e => e.RecordID);
                entity.Property(e => e.RecordID).ValueGeneratedOnAdd();

                entity.Property(e => e.InstitutionCode).IsRequired().HasMaxLength(50);
                entity.Property(e => e.InstitutionName).IsRequired().HasMaxLength(300);
                entity.Property(e => e.Mnemonic).HasMaxLength(50);
                entity.Property(e => e.BaseCurrCode).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Address).HasMaxLength(500);
                entity.Property(e => e.City).HasMaxLength(50);
                entity.Property(e => e.State).HasMaxLength(50);
                entity.Property(e => e.ZipCode).HasMaxLength(10);
                entity.Property(e => e.Website).HasMaxLength(1000);
                entity.Property(e => e.DomainName).HasMaxLength(500);
                entity.Property(e => e.Email).HasMaxLength(500);
                entity.Property(e => e.Telephone1).HasMaxLength(20);
                entity.Property(e => e.Telephone2).HasMaxLength(20);
                entity.Property(e => e.Logo).HasColumnType("varbinary(max)"); // Matches varbinary(-1) [cite: 89]
                entity.Property(e => e.SortCode).HasMaxLength(50);
                entity.Property(e => e.SwiftCode).HasMaxLength(50);
                entity.Property(e => e.IBAN).HasMaxLength(50);
                entity.Property(e => e.NubanCode).HasMaxLength(50);
                entity.Property(e => e.SoftwareLicenceKey).HasMaxLength(50);

                entity.Property(e => e.AddedBy).IsRequired().HasMaxLength(50);
                entity.Property(e => e.LastModifiedBy).HasMaxLength(50);

                // RELATIONAL SETUP: Configures the 1-to-many dependency mapping link
                entity.HasOne(d => d.FinancialInstitution)
                      .WithMany(p => p.Institutions)
                      .HasForeignKey(d => d.FIRecordID)
                      .OnDelete(DeleteBehavior.Restrict); // Prevents accidental cascading data loss
            });
        }
}
}
