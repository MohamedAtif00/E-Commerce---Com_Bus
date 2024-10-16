using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class modifychildCategoryrelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChildCategory_ChildCategory_ChildCategoryId",
                table: "ChildCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_ChildCategory_categories_CategoryId",
                table: "ChildCategory");

            migrationBuilder.RenameColumn(
                name: "ChildCategoryId",
                table: "ChildCategory",
                newName: "childCategoryId");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "ChildCategory",
                newName: "categoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ChildCategory_ChildCategoryId",
                table: "ChildCategory",
                newName: "IX_ChildCategory_childCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ChildCategory_CategoryId",
                table: "ChildCategory",
                newName: "IX_ChildCategory_categoryId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "_CreatedAt",
                table: "products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 4, 21, 29, 26, 769, DateTimeKind.Local).AddTicks(4946),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 4, 8, 30, 2, 708, DateTimeKind.Local).AddTicks(8138));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChildCategory_ChildCategory_childCategoryId",
                table: "ChildCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_ChildCategory_categories_categoryId",
                table: "ChildCategory");

            migrationBuilder.RenameColumn(
                name: "childCategoryId",
                table: "ChildCategory",
                newName: "ChildCategoryId");

            migrationBuilder.RenameColumn(
                name: "categoryId",
                table: "ChildCategory",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ChildCategory_childCategoryId",
                table: "ChildCategory",
                newName: "IX_ChildCategory_ChildCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ChildCategory_categoryId",
                table: "ChildCategory",
                newName: "IX_ChildCategory_CategoryId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "_CreatedAt",
                table: "products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 4, 8, 30, 2, 708, DateTimeKind.Local).AddTicks(8138),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 4, 21, 29, 26, 769, DateTimeKind.Local).AddTicks(4946));

            migrationBuilder.AddForeignKey(
                name: "FK_ChildCategory_ChildCategory_ChildCategoryId",
                table: "ChildCategory",
                column: "ChildCategoryId",
                principalTable: "ChildCategory",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChildCategory_categories_CategoryId",
                table: "ChildCategory",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id");
        }
    }
}
