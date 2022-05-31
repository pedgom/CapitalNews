using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CapitalNews.Data.Migrations
{
    public partial class TabelasRelacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FotografiasNoticias_Fotografias_FotografiaFK",
                table: "FotografiasNoticias");

            migrationBuilder.DropForeignKey(
                name: "FK_FotografiasNoticias_Noticias_NoticiaFK",
                table: "FotografiasNoticias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FotografiasNoticias",
                table: "FotografiasNoticias");

            migrationBuilder.DropIndex(
                name: "IX_FotografiasNoticias_FotografiaFK",
                table: "FotografiasNoticias");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "FotografiasNoticias");

            migrationBuilder.RenameColumn(
                name: "NoticiaFK",
                table: "FotografiasNoticias",
                newName: "ListaNoticiasId");

            migrationBuilder.RenameColumn(
                name: "FotografiaFK",
                table: "FotografiasNoticias",
                newName: "ListaFotografiasId");

            migrationBuilder.RenameIndex(
                name: "IX_FotografiasNoticias_NoticiaFK",
                table: "FotografiasNoticias",
                newName: "IX_FotografiasNoticias_ListaNoticiasId");

            migrationBuilder.RenameColumn(
                name: "FotoNoticia",
                table: "Fotografias",
                newName: "Descritores");

            migrationBuilder.AddColumn<string>(
                name: "Funcao",
                table: "JornalistasNoticias",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FotografiasNoticias",
                table: "FotografiasNoticias",
                columns: new[] { "ListaFotografiasId", "ListaNoticiasId" });

            migrationBuilder.AddForeignKey(
                name: "FK_FotografiasNoticias_Fotografias_ListaFotografiasId",
                table: "FotografiasNoticias",
                column: "ListaFotografiasId",
                principalTable: "Fotografias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FotografiasNoticias_Noticias_ListaNoticiasId",
                table: "FotografiasNoticias",
                column: "ListaNoticiasId",
                principalTable: "Noticias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FotografiasNoticias_Fotografias_ListaFotografiasId",
                table: "FotografiasNoticias");

            migrationBuilder.DropForeignKey(
                name: "FK_FotografiasNoticias_Noticias_ListaNoticiasId",
                table: "FotografiasNoticias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FotografiasNoticias",
                table: "FotografiasNoticias");

            migrationBuilder.DropColumn(
                name: "Funcao",
                table: "JornalistasNoticias");

            migrationBuilder.RenameColumn(
                name: "ListaNoticiasId",
                table: "FotografiasNoticias",
                newName: "NoticiaFK");

            migrationBuilder.RenameColumn(
                name: "ListaFotografiasId",
                table: "FotografiasNoticias",
                newName: "FotografiaFK");

            migrationBuilder.RenameIndex(
                name: "IX_FotografiasNoticias_ListaNoticiasId",
                table: "FotografiasNoticias",
                newName: "IX_FotografiasNoticias_NoticiaFK");

            migrationBuilder.RenameColumn(
                name: "Descritores",
                table: "Fotografias",
                newName: "FotoNoticia");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "FotografiasNoticias",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FotografiasNoticias",
                table: "FotografiasNoticias",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_FotografiasNoticias_FotografiaFK",
                table: "FotografiasNoticias",
                column: "FotografiaFK");

            migrationBuilder.AddForeignKey(
                name: "FK_FotografiasNoticias_Fotografias_FotografiaFK",
                table: "FotografiasNoticias",
                column: "FotografiaFK",
                principalTable: "Fotografias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FotografiasNoticias_Noticias_NoticiaFK",
                table: "FotografiasNoticias",
                column: "NoticiaFK",
                principalTable: "Noticias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
