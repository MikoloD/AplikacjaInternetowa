using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class init8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Malfunctions");

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Issues",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Issues");

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Malfunctions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
