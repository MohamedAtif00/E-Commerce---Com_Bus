using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateadministration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "_CreatedAt",
                table: "products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 15, 11, 27, 52, 808, DateTimeKind.Local).AddTicks(5357),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 14, 14, 41, 40, 838, DateTimeKind.Local).AddTicks(9877));

            migrationBuilder.AddColumn<string>(
                name: "_description_Marquee_Arb",
                table: "administrations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "_description_Marquee_Eng",
                table: "administrations",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "_description_Marquee_Arb",
                table: "administrations");

            migrationBuilder.DropColumn(
                name: "_description_Marquee_Eng",
                table: "administrations");

            migrationBuilder.AlterColumn<DateTime>(
                name: "_CreatedAt",
                table: "products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 14, 14, 41, 40, 838, DateTimeKind.Local).AddTicks(9877),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 15, 11, 27, 52, 808, DateTimeKind.Local).AddTicks(5357));
        }
    }
}
