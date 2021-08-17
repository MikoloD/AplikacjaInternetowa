using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class init6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MalfunctionName",
                table: "Malfunctions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MalfunctionName",
                table: "Malfunctions");
        }
    }
}
