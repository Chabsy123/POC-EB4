using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POC_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "adm");

            migrationBuilder.CreateTable(
                name: "FinancialInstitutions",
                schema: "adm",
                columns: table => new
                {
                    RecordId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FIName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    FICategory = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FICode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Mnemonic = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateLastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialInstitutions", x => x.RecordId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinancialInstitutions",
                schema: "adm");
        }
    }
}
