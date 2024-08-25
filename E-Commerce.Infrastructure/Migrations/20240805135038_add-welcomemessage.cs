using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addwelcomemessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "_CreatedAt",
                table: "products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 5, 16, 50, 37, 733, DateTimeKind.Local).AddTicks(7092),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 4, 1, 24, 14, 833, DateTimeKind.Local).AddTicks(929));

            migrationBuilder.AddColumn<string>(
                name: "_welcomeMessage_Desc_Arb",
                table: "administrations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "_welcomeMessage_Desc_Eng",
                table: "administrations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "_welcomeMessage_Title_Arb",
                table: "administrations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "_welcomeMessage_Title_Eng",
                table: "administrations",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "_welcomeMessage_Desc_Arb",
                table: "administrations");

            migrationBuilder.DropColumn(
                name: "_welcomeMessage_Desc_Eng",
                table: "administrations");

            migrationBuilder.DropColumn(
                name: "_welcomeMessage_Title_Arb",
                table: "administrations");

            migrationBuilder.DropColumn(
                name: "_welcomeMessage_Title_Eng",
                table: "administrations");

            migrationBuilder.AlterColumn<DateTime>(
                name: "_CreatedAt",
                table: "products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 4, 1, 24, 14, 833, DateTimeKind.Local).AddTicks(929),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 5, 16, 50, 37, 733, DateTimeKind.Local).AddTicks(7092));
        }
    }
}
