using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class modifynullablevaluesinaddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "_CreatedAt",
                table: "products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 28, 0, 22, 45, 710, DateTimeKind.Local).AddTicks(3032),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 27, 21, 7, 26, 460, DateTimeKind.Local).AddTicks(542));

            migrationBuilder.AlterColumn<int>(
                name: "floor",
                table: "PickupAddress",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "buildingNumber",
                table: "PickupAddress",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "apartment",
                table: "PickupAddress",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "_CreatedAt",
                table: "products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 27, 21, 7, 26, 460, DateTimeKind.Local).AddTicks(542),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 28, 0, 22, 45, 710, DateTimeKind.Local).AddTicks(3032));

            migrationBuilder.AlterColumn<int>(
                name: "floor",
                table: "PickupAddress",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "buildingNumber",
                table: "PickupAddress",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "apartment",
                table: "PickupAddress",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
