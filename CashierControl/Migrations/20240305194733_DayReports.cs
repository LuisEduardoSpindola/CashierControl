using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CashierControl.Migrations
{
    /// <inheritdoc />
    public partial class DayReports : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NegativeBoxClosing",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "PositiveBoxClosing",
                table: "Reports");

            migrationBuilder.AddColumn<float>(
                name: "DinamicNegativeBoxClosing",
                table: "Reports",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "DinamicPositiveBoxClosing",
                table: "Reports",
                type: "real",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DayReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositiveBoxClosing = table.Column<float>(type: "real", nullable: true),
                    NegativeBoxClosing = table.Column<float>(type: "real", nullable: true),
                    Balance = table.Column<float>(type: "real", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayReports", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DayReports");

            migrationBuilder.DropColumn(
                name: "DinamicNegativeBoxClosing",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "DinamicPositiveBoxClosing",
                table: "Reports");

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
        }
    }
}
