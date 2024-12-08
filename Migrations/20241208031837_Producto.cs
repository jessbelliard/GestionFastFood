using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionFastFood.Migrations
{
    /// <inheritdoc />
    public partial class Producto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PedidoId",
                table: "Producto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PosicionId",
                table: "Producto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Producto_PedidoId",
                table: "Producto",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_PosicionId",
                table: "Producto",
                column: "PosicionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Pedido_PedidoId",
                table: "Producto",
                column: "PedidoId",
                principalTable: "Pedido",
                principalColumn: "PedidoID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Posicion_PosicionId",
                table: "Producto",
                column: "PosicionId",
                principalTable: "Posicion",
                principalColumn: "PosicionId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Pedido_PedidoId",
                table: "Producto");

            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Posicion_PosicionId",
                table: "Producto");

            migrationBuilder.DropIndex(
                name: "IX_Producto_PedidoId",
                table: "Producto");

            migrationBuilder.DropIndex(
                name: "IX_Producto_PosicionId",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "PedidoId",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "PosicionId",
                table: "Producto");
        }
    }
}
