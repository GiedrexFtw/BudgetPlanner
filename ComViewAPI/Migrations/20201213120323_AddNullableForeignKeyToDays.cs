using Microsoft.EntityFrameworkCore.Migrations;

namespace ComView.Migrations
{
    public partial class AddNullableForeignKeyToDays : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Days_Reports_ReportId",
                table: "Days");

            migrationBuilder.AlterColumn<int>(
                name: "ReportId",
                table: "Days",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Days_Reports_ReportId",
                table: "Days",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Days_Reports_ReportId",
                table: "Days");

            migrationBuilder.AlterColumn<int>(
                name: "ReportId",
                table: "Days",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Days_Reports_ReportId",
                table: "Days",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
