using Microsoft.EntityFrameworkCore.Migrations;

namespace ComView.Migrations
{
    public partial class AddRefTokenColumnToUsersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefToken",
                table: "Users",
                maxLength: 100,
                nullable: true
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "RefToken", table: "Users");
        }
    }
}
