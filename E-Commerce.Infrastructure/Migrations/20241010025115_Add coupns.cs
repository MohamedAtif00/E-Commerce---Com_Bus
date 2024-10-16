using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Addcoupns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_Coupon_CouponId",
                table: "orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Coupon",
                table: "Coupon");

            migrationBuilder.RenameTable(
                name: "Coupon",
                newName: "coupons");

            migrationBuilder.AlterColumn<DateTime>(
                name: "_CreatedAt",
                table: "products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 10, 5, 51, 15, 311, DateTimeKind.Local).AddTicks(2435),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 9, 2, 53, 58, 157, DateTimeKind.Local).AddTicks(5641));

            migrationBuilder.AddPrimaryKey(
                name: "PK_coupons",
                table: "coupons",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_coupons_CouponId",
                table: "orders",
                column: "CouponId",
                principalTable: "coupons",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_coupons_CouponId",
                table: "orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_coupons",
                table: "coupons");

            migrationBuilder.RenameTable(
                name: "coupons",
                newName: "Coupon");

            migrationBuilder.AlterColumn<DateTime>(
                name: "_CreatedAt",
                table: "products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 9, 2, 53, 58, 157, DateTimeKind.Local).AddTicks(5641),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 10, 5, 51, 15, 311, DateTimeKind.Local).AddTicks(2435));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Coupon",
                table: "Coupon",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_Coupon_CouponId",
                table: "orders",
                column: "CouponId",
                principalTable: "Coupon",
                principalColumn: "Id");
        }
    }
}
