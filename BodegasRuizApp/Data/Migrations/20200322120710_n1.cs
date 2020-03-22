using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BodegasRuizApp.Data.Migrations
{
    public partial class n1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    ProductoId = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(nullable: false),
                    CantidadTotal = table.Column<int>(nullable: false),
                    PrecioStd = table.Column<double>(nullable: false),
                    DiasBarrica = table.Column<int>(nullable: false),
                    Añada = table.Column<string>(nullable: false),
                    GradoAlc = table.Column<double>(nullable: false),
                    Foto = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.ProductoId);
                });

            migrationBuilder.CreateTable(
                name: "Ubicacion",
                columns: table => new
                {
                    UbicacionId = table.Column<Guid>(nullable: false),
                    PosicionX = table.Column<string>(nullable: true),
                    PosicionY = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ubicacion", x => x.UbicacionId);
                });

            migrationBuilder.CreateTable(
                name: "ProductoUbicacion",
                columns: table => new
                {
                    ProductoUbicacionId = table.Column<Guid>(nullable: false),
                    ProductoId = table.Column<Guid>(nullable: false),
                    UbicacionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoUbicacion", x => x.ProductoUbicacionId);
                    table.ForeignKey(
                        name: "FK_ProductoUbicacion_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductoUbicacion_Ubicacion_UbicacionId",
                        column: x => x.UbicacionId,
                        principalTable: "Ubicacion",
                        principalColumn: "UbicacionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Precio_ProductoId",
                table: "Precio",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorito_ProductoId",
                table: "Favorito",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_ProductoId",
                table: "Compra",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoUbicacion_ProductoId",
                table: "ProductoUbicacion",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoUbicacion_UbicacionId",
                table: "ProductoUbicacion",
                column: "UbicacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Compra_Producto_ProductoId",
                table: "Compra",
                column: "ProductoId",
                principalTable: "Producto",
                principalColumn: "ProductoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Favorito_Producto_ProductoId",
                table: "Favorito",
                column: "ProductoId",
                principalTable: "Producto",
                principalColumn: "ProductoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Precio_Producto_ProductoId",
                table: "Precio",
                column: "ProductoId",
                principalTable: "Producto",
                principalColumn: "ProductoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compra_Producto_ProductoId",
                table: "Compra");

            migrationBuilder.DropForeignKey(
                name: "FK_Favorito_Producto_ProductoId",
                table: "Favorito");

            migrationBuilder.DropForeignKey(
                name: "FK_Precio_Producto_ProductoId",
                table: "Precio");

            migrationBuilder.DropTable(
                name: "ProductoUbicacion");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Ubicacion");

            migrationBuilder.DropIndex(
                name: "IX_Precio_ProductoId",
                table: "Precio");

            migrationBuilder.DropIndex(
                name: "IX_Favorito_ProductoId",
                table: "Favorito");

            migrationBuilder.DropIndex(
                name: "IX_Compra_ProductoId",
                table: "Compra");
        }
    }
}
