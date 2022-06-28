using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CapitalNews.Data.Migrations
{
    public partial class fotos_new_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Fotografias",
                columns: new[] { "Id", "Descritores", "NomeFoto" },
                values: new object[,]
                {
                    { 1, "foto1 descritores1", "foto1" },
                    { 2, "foto1 descritores2", "foto2" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Fotografias",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Fotografias",
                keyColumn: "Id",
                keyValue: 2);

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
    }
}
