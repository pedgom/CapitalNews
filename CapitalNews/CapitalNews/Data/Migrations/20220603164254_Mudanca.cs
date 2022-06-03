using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CapitalNews.Data.Migrations
{
    public partial class Mudanca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FotografiasNoticias");

            migrationBuilder.DropTable(
                name: "JornalistasNoticias");

            migrationBuilder.AddColumn<int>(
                name: "FotografiaFK",
                table: "Noticias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "JornalistaFK",
                table: "Noticias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Noticias_FotografiaFK",
                table: "Noticias",
                column: "FotografiaFK");

            migrationBuilder.CreateIndex(
                name: "IX_Noticias_JornalistaFK",
                table: "Noticias",
                column: "JornalistaFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Noticias_Fotografias_FotografiaFK",
                table: "Noticias",
                column: "FotografiaFK",
                principalTable: "Fotografias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Noticias_Jornalistas_JornalistaFK",
                table: "Noticias",
                column: "JornalistaFK",
                principalTable: "Jornalistas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Noticias_Fotografias_FotografiaFK",
                table: "Noticias");

            migrationBuilder.DropForeignKey(
                name: "FK_Noticias_Jornalistas_JornalistaFK",
                table: "Noticias");

            migrationBuilder.DropIndex(
                name: "IX_Noticias_FotografiaFK",
                table: "Noticias");

            migrationBuilder.DropIndex(
                name: "IX_Noticias_JornalistaFK",
                table: "Noticias");

            migrationBuilder.DropColumn(
                name: "FotografiaFK",
                table: "Noticias");

            migrationBuilder.DropColumn(
                name: "JornalistaFK",
                table: "Noticias");

            migrationBuilder.CreateTable(
                name: "FotografiasNoticias",
                columns: table => new
                {
                    ListaFotografiasId = table.Column<int>(type: "int", nullable: false),
                    ListaNoticiasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FotografiasNoticias", x => new { x.ListaFotografiasId, x.ListaNoticiasId });
                    table.ForeignKey(
                        name: "FK_FotografiasNoticias_Fotografias_ListaFotografiasId",
                        column: x => x.ListaFotografiasId,
                        principalTable: "Fotografias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FotografiasNoticias_Noticias_ListaNoticiasId",
                        column: x => x.ListaNoticiasId,
                        principalTable: "Noticias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JornalistasNoticias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JornalistaFK = table.Column<int>(type: "int", nullable: false),
                    NoticiaFK = table.Column<int>(type: "int", nullable: false),
                    Funcao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JornalistasNoticias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JornalistasNoticias_Jornalistas_JornalistaFK",
                        column: x => x.JornalistaFK,
                        principalTable: "Jornalistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JornalistasNoticias_Noticias_NoticiaFK",
                        column: x => x.NoticiaFK,
                        principalTable: "Noticias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FotografiasNoticias_ListaNoticiasId",
                table: "FotografiasNoticias",
                column: "ListaNoticiasId");

            migrationBuilder.CreateIndex(
                name: "IX_JornalistasNoticias_JornalistaFK",
                table: "JornalistasNoticias",
                column: "JornalistaFK");

            migrationBuilder.CreateIndex(
                name: "IX_JornalistasNoticias_NoticiaFK",
                table: "JornalistasNoticias",
                column: "NoticiaFK");
        }
    }
}
