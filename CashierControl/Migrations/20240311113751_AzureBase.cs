using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CashierControl.Migrations
{
    /// <inheritdoc />
    public partial class AzureBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DayReports");

            migrationBuilder.DropColumn(
                name: "DinamicNegativeBoxClosing",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "DinamicPositiveBoxClosing",
                table: "Reports");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                    Balance = table.Column<float>(type: "real", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NegativeBoxClosing = table.Column<float>(type: "real", nullable: true),
                    PositiveBoxClosing = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayReports", x => x.Id);
                });
        }
    }
}
