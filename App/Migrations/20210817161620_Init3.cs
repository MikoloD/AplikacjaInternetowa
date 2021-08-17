using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class Init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_MalfunctionModel_MalfunctionId",
                table: "Issues");

            migrationBuilder.AlterColumn<int>(
                name: "MalfunctionId",
                table: "Issues",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_MalfunctionModel_MalfunctionId",
                table: "Issues",
                column: "MalfunctionId",
                principalTable: "MalfunctionModel",
                principalColumn: "MalfunctionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_MalfunctionModel_MalfunctionId",
                table: "Issues");

            migrationBuilder.AlterColumn<int>(
                name: "MalfunctionId",
                table: "Issues",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_MalfunctionModel_MalfunctionId",
                table: "Issues",
                column: "MalfunctionId",
                principalTable: "MalfunctionModel",
                principalColumn: "MalfunctionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
