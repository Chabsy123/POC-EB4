using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POC_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Institution : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Institution",
                schema: "adm",
                columns: table => new
                {
                    RecordID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FIRecordID = table.Column<long>(type: "bigint", nullable: false),
                    InstitutionCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InstitutionName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Mnemonic = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BaseCurrCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Website = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    DomainName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Telephone1 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Telephone2 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Logo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    SortCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SwiftCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IBAN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NubanCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SoftwareLicenceKey = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateLastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AddedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institution", x => x.RecordID);
                    table.ForeignKey(
                        name: "FK_Institution_FinancialInstitutions_FIRecordID",
                        column: x => x.FIRecordID,
                        principalSchema: "adm",
                        principalTable: "FinancialInstitutions",
                        principalColumn: "RecordId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Institution_FIRecordID",
                schema: "adm",
                table: "Institution",
                column: "FIRecordID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Institution",
                schema: "adm");
        }
    }
}
