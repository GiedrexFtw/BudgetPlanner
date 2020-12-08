using Microsoft.EntityFrameworkCore.Migrations;

namespace ComView.Migrations
{
    public partial class AddForeignKeyConstraintCategoryForProductsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Products_Categories_CategoryId", table: "Products");
        }
    }
}
