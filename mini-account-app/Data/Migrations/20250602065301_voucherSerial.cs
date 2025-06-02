using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mini_account_app.Data.Migrations
{
    /// <inheritdoc />
    public partial class voucherSerial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VoucherSerial",
                table: "VoucherEntryService",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VoucherSerial",
                table: "VoucherEntryService");
        }
    }
}
