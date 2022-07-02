using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CapitalNews.Data.Migrations
{
    public partial class VModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a",
                column: "ConcurrencyStamp",
                value: "0028d95f-fab8-4e8d-978f-4eab02d91a99");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "j",
                column: "ConcurrencyStamp",
                value: "db02bc9a-f1b2-4324-b6cc-4504567d76c5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "l",
                column: "ConcurrencyStamp",
                value: "be2c6ab1-dbdf-4bd1-82ab-5d1be0edc83e");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a",
                column: "ConcurrencyStamp",
                value: "430daa4e-4a8a-48d1-8eb9-228602d924b2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "j",
                column: "ConcurrencyStamp",
                value: "5e11ae98-bbef-4ca3-9ffa-050b225b8ef4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "l",
                column: "ConcurrencyStamp",
                value: "37a25c98-4bc4-43a6-ab2a-486499a3f6c0");
        }
    }
}
