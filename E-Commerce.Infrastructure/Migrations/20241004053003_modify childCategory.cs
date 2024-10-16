using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class modifychildCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChildCategory_categories_CategoryId",
                table: "ChildCategory");

            migrationBuilder.AlterColumn<DateTime>(
                name: "_CreatedAt",
                table: "products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 4, 8, 30, 2, 708, DateTimeKind.Local).AddTicks(8138),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 3, 19, 27, 41, 28, DateTimeKind.Local).AddTicks(1581));

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "ChildCategory",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "ChildCategoryId",
                table: "ChildCategory",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChildCategory_ChildCategoryId",
                table: "ChildCategory",
                column: "ChildCategoryId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChildCategory_ChildCategory_ChildCategoryId",
                table: "ChildCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_ChildCategory_categories_CategoryId",
                table: "ChildCategory");

            migrationBuilder.DropIndex(
                name: "IX_ChildCategory_ChildCategoryId",
                table: "ChildCategory");

            migrationBuilder.DropColumn(
                name: "ChildCategoryId",
                table: "ChildCategory");

            migrationBuilder.AlterColumn<DateTime>(
                name: "_CreatedAt",
                table: "products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 3, 19, 27, 41, 28, DateTimeKind.Local).AddTicks(1581),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 4, 8, 30, 2, 708, DateTimeKind.Local).AddTicks(8138));

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "ChildCategory",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ChildCategory_categories_CategoryId",
                table: "ChildCategory",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
