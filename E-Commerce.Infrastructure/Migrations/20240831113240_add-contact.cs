using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addcontact : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "_CreatedAt",
                table: "products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 31, 14, 32, 40, 75, DateTimeKind.Local).AddTicks(8947),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 26, 13, 53, 30, 54, DateTimeKind.Local).AddTicks(9004));

            migrationBuilder.CreateTable(
                name: "contacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contacts", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contacts");

            migrationBuilder.AlterColumn<DateTime>(
                name: "_CreatedAt",
                table: "products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 26, 13, 53, 30, 54, DateTimeKind.Local).AddTicks(9004),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 31, 14, 32, 40, 75, DateTimeKind.Local).AddTicks(8947));
        }
    }
}
