using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddReviews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "_customerId",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "rating_Value",
                table: "Review");

            migrationBuilder.RenameColumn(
                name: "productId",
                table: "Review",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "comment",
                table: "Review",
                newName: "Comment");

            migrationBuilder.AddColumn<bool>(
                name: "IsAllowed",
                table: "Review",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "rating",
                table: "Review",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "_CreatedAt",
                table: "products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 8, 11, 8, 31, 29, DateTimeKind.Local).AddTicks(6905),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 8, 10, 0, 28, 314, DateTimeKind.Local).AddTicks(8046));

            migrationBuilder.CreateIndex(
                name: "IX_Review_ProductId",
                table: "Review",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_products_ProductId",
                table: "Review",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_products_ProductId",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_ProductId",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "IsAllowed",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "rating",
                table: "Review");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Review",
                newName: "productId");

            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "Review",
                newName: "comment");

            migrationBuilder.AddColumn<Guid>(
                name: "_customerId",
                table: "Review",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<double>(
                name: "rating_Value",
                table: "Review",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "_CreatedAt",
                table: "products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 8, 10, 0, 28, 314, DateTimeKind.Local).AddTicks(8046),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 8, 11, 8, 31, 29, DateTimeKind.Local).AddTicks(6905));
        }
    }
}
