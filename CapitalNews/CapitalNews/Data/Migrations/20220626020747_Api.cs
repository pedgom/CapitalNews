using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CapitalNews.Data.Migrations
{
    public partial class Api : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a",
                column: "ConcurrencyStamp",
                value: "30c565c6-4934-426d-a9ba-b9de9cae11ce");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "j",
                column: "ConcurrencyStamp",
                value: "a994ddca-a369-4857-ba05-d581b5c46607");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "l",
                column: "ConcurrencyStamp",
                value: "f5509c8e-54a6-40ab-b8b8-11ca096f1206");
        }
    }
}
