using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MalfunctionId",
                table: "Issues",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "date",
                table: "Issues",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "MalfunctionModel",
                columns: table => new
                {
                    MalfunctionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MalfunctionModel", x => x.MalfunctionId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Issues_MalfunctionId",
                table: "Issues",
                column: "MalfunctionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_MalfunctionModel_MalfunctionId",
                table: "Issues",
                column: "MalfunctionId",
                principalTable: "MalfunctionModel",
                principalColumn: "MalfunctionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_MalfunctionModel_MalfunctionId",
                table: "Issues");

            migrationBuilder.DropTable(
                name: "MalfunctionModel");

            migrationBuilder.DropIndex(
                name: "IX_Issues_MalfunctionId",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "MalfunctionId",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "date",
                table: "Issues");
        }
    }
}
