using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CashierControl.Migrations
{
    /// <inheritdoc />
    public partial class BankSlipValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BankSlipsQuantity",
                table: "Reports",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BankSlipsQuantity",
                table: "Reports");
        }
    }
}
