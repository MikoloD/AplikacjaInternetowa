using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class init11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "727a69e2-128b-4bce-8ad6-72b59331b07f", "f94b6bc4-4c5f-419f-b566-ca806718ed2d", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "727a69e2-128b-4bce-8ad6-72b59331b07f");
        }
    }
}
