using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class init9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Img",
                table: "Multimedia");

            migrationBuilder.DropColumn(
                name: "MalfunctionName",
                table: "Malfunctions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Img",
                table: "Multimedia",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MalfunctionName",
                table: "Malfunctions",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
