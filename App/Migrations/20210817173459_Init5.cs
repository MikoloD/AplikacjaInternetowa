using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class Init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_MalfunctionModel_MalfunctionId",
                table: "Issues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MalfunctionModel",
                table: "MalfunctionModel");

            migrationBuilder.RenameTable(
                name: "MalfunctionModel",
                newName: "Malfunctions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Malfunctions",
                table: "Malfunctions",
                column: "MalfunctionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Malfunctions_MalfunctionId",
                table: "Issues",
                column: "MalfunctionId",
                principalTable: "Malfunctions",
                principalColumn: "MalfunctionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Malfunctions_MalfunctionId",
                table: "Issues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Malfunctions",
                table: "Malfunctions");

            migrationBuilder.RenameTable(
                name: "Malfunctions",
                newName: "MalfunctionModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MalfunctionModel",
                table: "MalfunctionModel",
                column: "MalfunctionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_MalfunctionModel_MalfunctionId",
                table: "Issues",
                column: "MalfunctionId",
                principalTable: "MalfunctionModel",
                principalColumn: "MalfunctionId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
