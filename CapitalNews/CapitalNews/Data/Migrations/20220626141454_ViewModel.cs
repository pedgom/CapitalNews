using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CapitalNews.Data.Migrations
{
    public partial class ViewModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a",
                column: "ConcurrencyStamp",
                value: "38ea82ff-f174-46ae-8d3d-1e2cb720480d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "j",
                column: "ConcurrencyStamp",
                value: "3c849742-2c3c-4799-9ce4-512e54334721");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "l",
                column: "ConcurrencyStamp",
                value: "b34967ca-6cbe-4d20-bbc5-de520e3cd678");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a",
                column: "ConcurrencyStamp",
                value: "df6938bb-10ea-4d7f-b5a1-5079e5a066e1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "j",
                column: "ConcurrencyStamp",
                value: "96ef4782-8dfa-4346-a1e8-eac328b51d25");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "l",
                column: "ConcurrencyStamp",
                value: "339e0657-481c-4f1e-8026-b1459ed1c1dc");
        }
    }
}
