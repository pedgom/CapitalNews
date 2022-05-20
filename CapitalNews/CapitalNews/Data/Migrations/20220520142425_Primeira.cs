using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CapitalNews.Data.Migrations
{
    public partial class Primeira : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaNome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fotografias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fotografia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fotografias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jornalistas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fotojor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jornalistas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Leitores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fotolei = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leitores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Noticias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoriaFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Noticias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Noticias_Categorias_CategoriaFK",
                        column: x => x.CategoriaFK,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TextoComentario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataComentario = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Visibilidade = table.Column<bool>(type: "bit", nullable: false),
                    NoticiaFK = table.Column<int>(type: "int", nullable: false),
                    LeitorFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comentarios_Leitores_LeitorFK",
                        column: x => x.LeitorFK,
                        principalTable: "Leitores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comentarios_Noticias_NoticiaFK",
                        column: x => x.NoticiaFK,
                        principalTable: "Noticias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FotografiasNoticias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FotografiaFK = table.Column<int>(type: "int", nullable: false),
                    NoticiaFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FotografiasNoticias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FotografiasNoticias_Fotografias_FotografiaFK",
                        column: x => x.FotografiaFK,
                        principalTable: "Fotografias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FotografiasNoticias_Noticias_NoticiaFK",
                        column: x => x.NoticiaFK,
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
                    NoticiaFK = table.Column<int>(type: "int", nullable: false),
                    JornalistaFK = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_Comentarios_LeitorFK",
                table: "Comentarios",
                column: "LeitorFK");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_NoticiaFK",
                table: "Comentarios",
                column: "NoticiaFK");

            migrationBuilder.CreateIndex(
                name: "IX_FotografiasNoticias_FotografiaFK",
                table: "FotografiasNoticias",
                column: "FotografiaFK");

            migrationBuilder.CreateIndex(
                name: "IX_FotografiasNoticias_NoticiaFK",
                table: "FotografiasNoticias",
                column: "NoticiaFK");

            migrationBuilder.CreateIndex(
                name: "IX_JornalistasNoticias_JornalistaFK",
                table: "JornalistasNoticias",
                column: "JornalistaFK");

            migrationBuilder.CreateIndex(
                name: "IX_JornalistasNoticias_NoticiaFK",
                table: "JornalistasNoticias",
                column: "NoticiaFK");

            migrationBuilder.CreateIndex(
                name: "IX_Noticias_CategoriaFK",
                table: "Noticias",
                column: "CategoriaFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentarios");

            migrationBuilder.DropTable(
                name: "FotografiasNoticias");

            migrationBuilder.DropTable(
                name: "JornalistasNoticias");

            migrationBuilder.DropTable(
                name: "Leitores");

            migrationBuilder.DropTable(
                name: "Fotografias");

            migrationBuilder.DropTable(
                name: "Jornalistas");

            migrationBuilder.DropTable(
                name: "Noticias");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
