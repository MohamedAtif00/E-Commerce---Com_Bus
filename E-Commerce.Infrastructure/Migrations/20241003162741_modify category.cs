using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class modifycategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_categories_categories_CategoryId",
                table: "categories");

            migrationBuilder.DropForeignKey(
                name: "FK_categories_superCategories_SuperCategoryId",
                table: "categories");

            migrationBuilder.DropTable(
                name: "superCategories");

            migrationBuilder.DropIndex(
                name: "IX_categories_CategoryId",
                table: "categories");

            migrationBuilder.DropIndex(
                name: "IX_categories_SuperCategoryId",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "SuperCategoryId",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "_parentCategoryId",
                table: "categories");

            migrationBuilder.AlterColumn<DateTime>(
                name: "_CreatedAt",
                table: "products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 3, 19, 27, 41, 28, DateTimeKind.Local).AddTicks(1581),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 2, 12, 10, 21, 666, DateTimeKind.Local).AddTicks(6608));

            migrationBuilder.CreateTable(
                name: "ChildCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    _name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _parentCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    _parentChildCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    _visible = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChildCategory_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChildCategory_CategoryId",
                table: "ChildCategory",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChildCategory");

            migrationBuilder.AlterColumn<DateTime>(
                name: "_CreatedAt",
                table: "products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 2, 12, 10, 21, 666, DateTimeKind.Local).AddTicks(6608),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 3, 19, 27, 41, 28, DateTimeKind.Local).AddTicks(1581));

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "categories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SuperCategoryId",
                table: "categories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "_parentCategoryId",
                table: "categories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "superCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    _name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_superCategories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_categories_CategoryId",
                table: "categories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_categories_SuperCategoryId",
                table: "categories",
                column: "SuperCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_categories_categories_CategoryId",
                table: "categories",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_categories_superCategories_SuperCategoryId",
                table: "categories",
                column: "SuperCategoryId",
                principalTable: "superCategories",
                principalColumn: "Id");
        }
    }
}
