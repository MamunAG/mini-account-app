using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mini_account_app.Data.Migrations
{
    /// <inheritdoc />
    public partial class voucherEntryUp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ChartOfAccounts",
                table: "ChartOfAccounts");

            migrationBuilder.DropColumn(
                name: "VoucherTypeId",
                table: "VoucherEntryService");

            migrationBuilder.RenameTable(
                name: "ChartOfAccounts",
                newName: "ChartOfAccounts");

            migrationBuilder.AddColumn<string>(
                name: "VoucherType",
                table: "VoucherEntryService",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChartOfAccounts",
                table: "ChartOfAccounts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_VoucherEntryDetails_AccountTypeId",
                table: "VoucherEntryDetails",
                column: "AccountTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_VoucherEntryDetails_ChartOfAccounts_AccountTypeId",
                table: "VoucherEntryDetails",
                column: "AccountTypeId",
                principalTable: "ChartOfAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VoucherEntryDetails_ChartOfAccounts_AccountTypeId",
                table: "VoucherEntryDetails");

            migrationBuilder.DropIndex(
                name: "IX_VoucherEntryDetails_AccountTypeId",
                table: "VoucherEntryDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChartOfAccounts",
                table: "ChartOfAccounts");

            migrationBuilder.DropColumn(
                name: "VoucherType",
                table: "VoucherEntryService");

            migrationBuilder.RenameTable(
                name: "ChartOfAccounts",
                newName: "ChartOfAccount");

            migrationBuilder.AddColumn<int>(
                name: "VoucherTypeId",
                table: "VoucherEntryService",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChartOfAccount",
                table: "ChartOfAccount",
                column: "Id");
        }
    }
}
