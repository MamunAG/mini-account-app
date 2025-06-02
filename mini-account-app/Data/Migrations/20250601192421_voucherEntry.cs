using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mini_account_app.Data.Migrations
{
    /// <inheritdoc />
    public partial class voucherEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VoucherEntryService",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoucherNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VoucherTypeId = table.Column<int>(type: "int", nullable: false),
                    VoucherDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReferenceNo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoucherEntry", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VoucherEntryDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterId = table.Column<int>(type: "int", nullable: false),
                    AccountTypeId = table.Column<int>(type: "int", nullable: false),
                    Debit = table.Column<double>(type: "float", nullable: false),
                    Credit = table.Column<double>(type: "float", nullable: false),
                    VoucherEntryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoucherEntryDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VoucherEntryDetails_VoucherEntry_VoucherEntryId",
                        column: x => x.VoucherEntryId,
                        principalTable: "VoucherEntryService",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_VoucherEntryDetails_VoucherEntryId",
                table: "VoucherEntryDetails",
                column: "VoucherEntryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VoucherEntryDetails");

            migrationBuilder.DropTable(
                name: "VoucherEntryService");
        }
    }
}
