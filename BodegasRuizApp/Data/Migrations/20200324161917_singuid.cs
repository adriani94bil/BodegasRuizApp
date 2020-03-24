using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BodegasRuizApp.Data.Migrations
{
    public partial class singuid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compra_AspNetUsers_UsuarioId1",
                table: "Compra");

            migrationBuilder.DropForeignKey(
                name: "FK_Favorito_AspNetUsers_UsuarioId1",
                table: "Favorito");

            migrationBuilder.DropForeignKey(
                name: "FK_Precio_AspNetUsers_UsuarioId1",
                table: "Precio");

            migrationBuilder.DropIndex(
                name: "IX_Precio_UsuarioId1",
                table: "Precio");

            migrationBuilder.DropIndex(
                name: "IX_Favorito_UsuarioId1",
                table: "Favorito");

            migrationBuilder.DropIndex(
                name: "IX_Compra_UsuarioId1",
                table: "Compra");

            migrationBuilder.DropColumn(
                name: "UsuarioId1",
                table: "Precio");

            migrationBuilder.DropColumn(
                name: "UsuarioId1",
                table: "Favorito");

            migrationBuilder.DropColumn(
                name: "UsuarioId1",
                table: "Compra");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "Precio",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "Favorito",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "Compra",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Precio_UsuarioId",
                table: "Precio",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorito_UsuarioId",
                table: "Favorito",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_UsuarioId",
                table: "Compra",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Compra_AspNetUsers_UsuarioId",
                table: "Compra",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Favorito_AspNetUsers_UsuarioId",
                table: "Favorito",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Precio_AspNetUsers_UsuarioId",
                table: "Precio",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compra_AspNetUsers_UsuarioId",
                table: "Compra");

            migrationBuilder.DropForeignKey(
                name: "FK_Favorito_AspNetUsers_UsuarioId",
                table: "Favorito");

            migrationBuilder.DropForeignKey(
                name: "FK_Precio_AspNetUsers_UsuarioId",
                table: "Precio");

            migrationBuilder.DropIndex(
                name: "IX_Precio_UsuarioId",
                table: "Precio");

            migrationBuilder.DropIndex(
                name: "IX_Favorito_UsuarioId",
                table: "Favorito");

            migrationBuilder.DropIndex(
                name: "IX_Compra_UsuarioId",
                table: "Compra");

            migrationBuilder.AlterColumn<Guid>(
                name: "UsuarioId",
                table: "Precio",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId1",
                table: "Precio",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UsuarioId",
                table: "Favorito",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId1",
                table: "Favorito",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UsuarioId",
                table: "Compra",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId1",
                table: "Compra",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Precio_UsuarioId1",
                table: "Precio",
                column: "UsuarioId1");

            migrationBuilder.CreateIndex(
                name: "IX_Favorito_UsuarioId1",
                table: "Favorito",
                column: "UsuarioId1");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_UsuarioId1",
                table: "Compra",
                column: "UsuarioId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Compra_AspNetUsers_UsuarioId1",
                table: "Compra",
                column: "UsuarioId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Favorito_AspNetUsers_UsuarioId1",
                table: "Favorito",
                column: "UsuarioId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Precio_AspNetUsers_UsuarioId1",
                table: "Precio",
                column: "UsuarioId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
