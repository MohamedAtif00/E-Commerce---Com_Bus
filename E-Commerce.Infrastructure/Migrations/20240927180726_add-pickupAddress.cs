using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addpickupAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "_CreatedAt",
                table: "products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 27, 21, 7, 26, 460, DateTimeKind.Local).AddTicks(542),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 17, 5, 11, 287, DateTimeKind.Local).AddTicks(632));

            migrationBuilder.CreateTable(
                name: "PickupAddress",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stateId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cityId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    firstLine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    secondLine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    buildingNumber = table.Column<int>(type: "int", nullable: false),
                    floor = table.Column<int>(type: "int", nullable: false),
                    apartment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    ShipmentInformationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PickupAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PickupAddress_ShipmentInformation_ShipmentInformationId",
                        column: x => x.ShipmentInformationId,
                        principalTable: "ShipmentInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PickupAddress_ShipmentInformationId",
                table: "PickupAddress",
                column: "ShipmentInformationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PickupAddress");

            migrationBuilder.AlterColumn<DateTime>(
                name: "_CreatedAt",
                table: "products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 17, 5, 11, 287, DateTimeKind.Local).AddTicks(632),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 27, 21, 7, 26, 460, DateTimeKind.Local).AddTicks(542));
        }
    }
}
