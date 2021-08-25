using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class int10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MalfunctionDescription",
                table: "Malfunctions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MalfunctionDescription",
                table: "Malfunctions");
        }
    }
}
