using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initchange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "_price__total",
                table: "products",
                newName: "Price_total");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "products",
                newName: "Price_price");

            migrationBuilder.RenameColumn(
                name: "Discount",
                table: "products",
                newName: "Price_discount");

            migrationBuilder.AlterColumn<DateTime>(
                name: "_CreatedAt",
                table: "products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 1, 13, 43, 53, 551, DateTimeKind.Local).AddTicks(9432),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 7, 1, 13, 38, 37, 42, DateTimeKind.Local).AddTicks(2765));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price_total",
                table: "products",
                newName: "_price__total");

            migrationBuilder.RenameColumn(
                name: "Price_price",
                table: "products",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "Price_discount",
                table: "products",
                newName: "Discount");

            migrationBuilder.AlterColumn<DateTime>(
                name: "_CreatedAt",
                table: "products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 1, 13, 38, 37, 42, DateTimeKind.Local).AddTicks(2765),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 7, 1, 13, 43, 53, 551, DateTimeKind.Local).AddTicks(9432));
        }
    }
}
