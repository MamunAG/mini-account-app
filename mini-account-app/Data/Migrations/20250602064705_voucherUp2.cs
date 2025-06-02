using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mini_account_app.Data.Migrations
{
    /// <inheritdoc />
    public partial class voucherUp2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VoucherEntryDetails_VoucherEntry_VoucherEntryId",
                table: "VoucherEntryDetails");

            migrationBuilder.DropIndex(
                name: "IX_VoucherEntryDetails_VoucherEntryId",
                table: "VoucherEntryDetails");

            migrationBuilder.DropColumn(
                name: "VoucherEntryId",
                table: "VoucherEntryDetails");

            migrationBuilder.CreateIndex(
                name: "IX_VoucherEntryDetails_MasterId",
                table: "VoucherEntryDetails",
                column: "MasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_VoucherEntryDetails_VoucherEntry_MasterId",
                table: "VoucherEntryDetails",
                column: "MasterId",
                principalTable: "VoucherEntryService",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VoucherEntryDetails_VoucherEntry_MasterId",
                table: "VoucherEntryDetails");

            migrationBuilder.DropIndex(
                name: "IX_VoucherEntryDetails_MasterId",
                table: "VoucherEntryDetails");

            migrationBuilder.AddColumn<int>(
                name: "VoucherEntryId",
                table: "VoucherEntryDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VoucherEntryDetails_VoucherEntryId",
                table: "VoucherEntryDetails",
                column: "VoucherEntryId");

            migrationBuilder.AddForeignKey(
                name: "FK_VoucherEntryDetails_VoucherEntry_VoucherEntryId",
                table: "VoucherEntryDetails",
                column: "VoucherEntryId",
                principalTable: "VoucherEntryService",
                principalColumn: "Id");
        }
    }
}
