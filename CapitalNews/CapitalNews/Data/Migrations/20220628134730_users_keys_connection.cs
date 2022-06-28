using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CapitalNews.Data.Migrations
{
    public partial class users_keys_connection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Jornalistas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a",
                column: "ConcurrencyStamp",
                value: "3e3df178-7ad0-43ec-836d-908728ea8993");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "j",
                column: "ConcurrencyStamp",
                value: "b560b8df-5b99-4f86-8c18-8ed855e1694c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "l",
                column: "ConcurrencyStamp",
                value: "6f4eedb3-7c1b-4ed1-9b20-d2f057f7289f");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Jornalistas");

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
    }
}
