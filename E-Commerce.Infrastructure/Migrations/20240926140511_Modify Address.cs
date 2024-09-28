using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifyAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address_Street",
                table: "orders",
                newName: "Address_stateId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "_CreatedAt",
                table: "products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 17, 5, 11, 287, DateTimeKind.Local).AddTicks(632),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 31, 14, 32, 40, 75, DateTimeKind.Local).AddTicks(8947));

            migrationBuilder.AddColumn<string>(
                name: "Address_Apartment",
                table: "orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Address_BuildingNumber",
                table: "orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Address_FirstLine",
                table: "orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Address_Floor",
                table: "orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Address_SecondLine",
                table: "orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_cityId",
                table: "orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ShipmentInformation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentInformation", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShipmentInformation");

            migrationBuilder.DropColumn(
                name: "Address_Apartment",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "Address_BuildingNumber",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "Address_FirstLine",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "Address_Floor",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "Address_SecondLine",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "Address_cityId",
                table: "orders");

            migrationBuilder.RenameColumn(
                name: "Address_stateId",
                table: "orders",
                newName: "Address_Street");

            migrationBuilder.AlterColumn<DateTime>(
                name: "_CreatedAt",
                table: "products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 31, 14, 32, 40, 75, DateTimeKind.Local).AddTicks(8947),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 17, 5, 11, 287, DateTimeKind.Local).AddTicks(632));
        }
    }
}
