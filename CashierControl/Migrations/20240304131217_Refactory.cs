using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CashierControl.Migrations
{
    /// <inheritdoc />
    public partial class Refactory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "ClientAmount",
                table: "Reports",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<float>(
                name: "BankSlipValue",
                table: "Reports",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<float>(
                name: "BoxOpen",
                table: "Reports",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "CashOutflow",
                table: "Reports",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "DepositValue",
                table: "Reports",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "NegativeBoxClosing",
                table: "Reports",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "PositiveBoxClosing",
                table: "Reports",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Reports",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<float>(
                name: "Transshipment",
                table: "Reports",
                type: "real",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BoxOpen",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "CashOutflow",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "DepositValue",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "NegativeBoxClosing",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "PositiveBoxClosing",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "Transshipment",
                table: "Reports");

            migrationBuilder.AlterColumn<float>(
                name: "ClientAmount",
                table: "Reports",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "BankSlipValue",
                table: "Reports",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);
        }
    }
}
