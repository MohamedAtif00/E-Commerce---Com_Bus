using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Adddescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "_CreatedAt",
                table: "products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 10, 21, 49, 45, 377, DateTimeKind.Local).AddTicks(2163),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 7, 22, 58, 28, 846, DateTimeKind.Local).AddTicks(3898));

            migrationBuilder.AddColumn<string>(
                name: "_description_Desc_Arb",
                table: "administrations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "_description_Desc_Eng",
                table: "administrations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "_description_Title_Arb",
                table: "administrations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "_description_Title_Eng",
                table: "administrations",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "_description_Desc_Arb",
                table: "administrations");

            migrationBuilder.DropColumn(
                name: "_description_Desc_Eng",
                table: "administrations");

            migrationBuilder.DropColumn(
                name: "_description_Title_Arb",
                table: "administrations");

            migrationBuilder.DropColumn(
                name: "_description_Title_Eng",
                table: "administrations");

            migrationBuilder.AlterColumn<DateTime>(
                name: "_CreatedAt",
                table: "products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 7, 22, 58, 28, 846, DateTimeKind.Local).AddTicks(3898),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 10, 21, 49, 45, 377, DateTimeKind.Local).AddTicks(2163));
        }
    }
}
