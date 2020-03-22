using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BodegasRuizApp.Data.Migrations
{
    public partial class Models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CiudadId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Compra",
                columns: table => new
                {
                    CompraId = table.Column<Guid>(nullable: false),
                    OrdenCompra = table.Column<string>(nullable: true),
                    CantidadComprada = table.Column<int>(nullable: false),
                    FechaFavorito = table.Column<DateTime>(nullable: false),
                    UsuarioId = table.Column<Guid>(nullable: false),
                    UsuarioId1 = table.Column<string>(nullable: true),
                    ProductoId = table.Column<Guid>(nullable: false),
                    Producto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compra", x => x.CompraId);
                    table.ForeignKey(
                        name: "FK_Compra_AspNetUsers_UsuarioId1",
                        column: x => x.UsuarioId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Favorito",
                columns: table => new
                {
                    FavoritoId = table.Column<Guid>(nullable: false),
                    FechaFavorito = table.Column<DateTime>(nullable: false),
                    FechaDesfavorito = table.Column<DateTime>(nullable: false),
                    EsFavorito = table.Column<bool>(nullable: false),
                    UsuarioId = table.Column<Guid>(nullable: false),
                    UsuarioId1 = table.Column<string>(nullable: true),
                    ProductoId = table.Column<Guid>(nullable: false),
                    Producto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorito", x => x.FavoritoId);
                    table.ForeignKey(
                        name: "FK_Favorito_AspNetUsers_UsuarioId1",
                        column: x => x.UsuarioId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Precio",
                columns: table => new
                {
                    PrecioId = table.Column<Guid>(nullable: false),
                    PrecioFinal = table.Column<double>(nullable: false),
                    UsuarioId = table.Column<Guid>(nullable: false),
                    UsuarioId1 = table.Column<string>(nullable: true),
                    ProductoId = table.Column<Guid>(nullable: false),
                    Producto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Precio", x => x.PrecioId);
                    table.ForeignKey(
                        name: "FK_Precio_AspNetUsers_UsuarioId1",
                        column: x => x.UsuarioId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Provincia",
                columns: table => new
                {
                    ProvinciaId = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    MultiploProvincia = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincia", x => x.ProvinciaId);
                });

            migrationBuilder.CreateTable(
                name: "Ciudad",
                columns: table => new
                {
                    CiudadId = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    MultiploCiudad = table.Column<double>(nullable: false),
                    ProvinciaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudad", x => x.CiudadId);
                    table.ForeignKey(
                        name: "FK_Ciudad_Provincia_ProvinciaId",
                        column: x => x.ProvinciaId,
                        principalTable: "Provincia",
                        principalColumn: "ProvinciaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CiudadId",
                table: "AspNetUsers",
                column: "CiudadId");

            migrationBuilder.CreateIndex(
                name: "IX_Ciudad_ProvinciaId",
                table: "Ciudad",
                column: "ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_UsuarioId1",
                table: "Compra",
                column: "UsuarioId1");

            migrationBuilder.CreateIndex(
                name: "IX_Favorito_UsuarioId1",
                table: "Favorito",
                column: "UsuarioId1");

            migrationBuilder.CreateIndex(
                name: "IX_Precio_UsuarioId1",
                table: "Precio",
                column: "UsuarioId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Ciudad_CiudadId",
                table: "AspNetUsers",
                column: "CiudadId",
                principalTable: "Ciudad",
                principalColumn: "CiudadId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Ciudad_CiudadId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Ciudad");

            migrationBuilder.DropTable(
                name: "Compra");

            migrationBuilder.DropTable(
                name: "Favorito");

            migrationBuilder.DropTable(
                name: "Precio");

            migrationBuilder.DropTable(
                name: "Provincia");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CiudadId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CiudadId",
                table: "AspNetUsers");
        }
    }
}
