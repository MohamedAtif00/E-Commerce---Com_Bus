using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class modifychildCategoryrelationkeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChildCategory_ChildCategory_childCategoryId",
                table: "ChildCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_ChildCategory_categories_categoryId",
                table: "ChildCategory");

            migrationBuilder.DropIndex(
                name: "IX_ChildCategory_categoryId",
                table: "ChildCategory");

            migrationBuilder.DropIndex(
                name: "IX_ChildCategory_childCategoryId",
                table: "ChildCategory");

            migrationBuilder.DropColumn(
                name: "categoryId",
                table: "ChildCategory");

            migrationBuilder.DropColumn(
                name: "childCategoryId",
                table: "ChildCategory");

            migrationBuilder.AlterColumn<DateTime>(
                name: "_CreatedAt",
                table: "products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 5, 4, 25, 45, 796, DateTimeKind.Local).AddTicks(3355),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 4, 21, 29, 26, 769, DateTimeKind.Local).AddTicks(4946));

            migrationBuilder.CreateIndex(
                name: "IX_ChildCategory__parentCategoryId",
                table: "ChildCategory",
                column: "_parentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ChildCategory__parentChildCategoryId",
                table: "ChildCategory",
                column: "_parentChildCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChildCategory_ChildCategory__parentChildCategoryId",
                table: "ChildCategory",
                column: "_parentChildCategoryId",
                principalTable: "ChildCategory",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChildCategory_categories__parentCategoryId",
                table: "ChildCategory",
                column: "_parentCategoryId",
                principalTable: "categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChildCategory_ChildCategory__parentChildCategoryId",
                table: "ChildCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_ChildCategory_categories__parentCategoryId",
                table: "ChildCategory");

            migrationBuilder.DropIndex(
                name: "IX_ChildCategory__parentCategoryId",
                table: "ChildCategory");

            migrationBuilder.DropIndex(
                name: "IX_ChildCategory__parentChildCategoryId",
                table: "ChildCategory");

            migrationBuilder.AlterColumn<DateTime>(
                name: "_CreatedAt",
                table: "products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 4, 21, 29, 26, 769, DateTimeKind.Local).AddTicks(4946),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 5, 4, 25, 45, 796, DateTimeKind.Local).AddTicks(3355));

            migrationBuilder.AddColumn<Guid>(
                name: "categoryId",
                table: "ChildCategory",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "childCategoryId",
                table: "ChildCategory",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChildCategory_categoryId",
                table: "ChildCategory",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ChildCategory_childCategoryId",
                table: "ChildCategory",
                column: "childCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChildCategory_ChildCategory_childCategoryId",
                table: "ChildCategory",
                column: "childCategoryId",
                principalTable: "ChildCategory",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChildCategory_categories_categoryId",
                table: "ChildCategory",
                column: "categoryId",
                principalTable: "categories",
                principalColumn: "Id");
        }
    }
}
