using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Data.Migrations
{
    public partial class up2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Issues",
                columns: table => new
                {
                    IssueId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Longitude = table.Column<float>(nullable: false),
                    Latitude = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issues", x => x.IssueId);
                });

            migrationBuilder.CreateTable(
                name: "Multimedia",
                columns: table => new
                {
                    MultimediumId = table.Column<int>(nullable: false),
                    Image = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Multimedia", x => x.MultimediumId);
                    table.ForeignKey(
                        name: "FK_Multimedia_Issues_MultimediumId",
                        column: x => x.MultimediumId,
                        principalTable: "Issues",
                        principalColumn: "IssueId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Multimedia");

            migrationBuilder.DropTable(
                name: "Issues");
        }
    }
}
