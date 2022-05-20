using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CapitalNews.Data.Migrations
{
    public partial class SeedJornalistas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Jornalistas",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Jornalistas",
                columns: new[] { "Id", "Email", "Fotojor", "Nome" },
                values: new object[] { 1, "jose@gmail.com", "Jose.jpg", "José Silva" });

            migrationBuilder.InsertData(
                table: "Jornalistas",
                columns: new[] { "Id", "Email", "Fotojor", "Nome" },
                values: new object[] { 2, "maria@gmail.com", "Maria.jpg", "Maria Gomes dos Santos" });

            migrationBuilder.InsertData(
                table: "Jornalistas",
                columns: new[] { "Id", "Email", "Fotojor", "Nome" },
                values: new object[] { 3, "ricardo@gmail.com", "Ricardo.jpg", "Ricardo Sousa" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Jornalistas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Jornalistas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Jornalistas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Jornalistas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
