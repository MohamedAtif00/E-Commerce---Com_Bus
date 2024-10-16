using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCoupon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "_CreatedAt",
                table: "products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 9, 2, 53, 58, 157, DateTimeKind.Local).AddTicks(5641),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 8, 11, 22, 40, 696, DateTimeKind.Local).AddTicks(982));

            migrationBuilder.AddColumn<Guid>(
                name: "CouponId",
                table: "orders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Coupon",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UsageLimit = table.Column<int>(type: "int", nullable: false),
                    UsageCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupon", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_orders_CouponId",
                table: "orders",
                column: "CouponId");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_Coupon_CouponId",
                table: "orders",
                column: "CouponId",
                principalTable: "Coupon",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_Coupon_CouponId",
                table: "orders");

            migrationBuilder.DropTable(
                name: "Coupon");

            migrationBuilder.DropIndex(
                name: "IX_orders_CouponId",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "CouponId",
                table: "orders");

            migrationBuilder.AlterColumn<DateTime>(
                name: "_CreatedAt",
                table: "products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 8, 11, 22, 40, 696, DateTimeKind.Local).AddTicks(982),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 9, 2, 53, 58, 157, DateTimeKind.Local).AddTicks(5641));
        }
    }
}
