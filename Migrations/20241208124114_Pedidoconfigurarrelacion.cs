using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionFastFood.Migrations
{
    /// <inheritdoc />
    public partial class Pedidoconfigurarrelacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Posicion_PedidoId",
                table: "Posicion");

            migrationBuilder.AddColumn<int>(
                name: "PosicionId",
                table: "Pedido",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Posicion_PedidoId",
                table: "Posicion",
                column: "PedidoId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Posicion_PedidoId",
                table: "Posicion");

            migrationBuilder.DropColumn(
                name: "PosicionId",
                table: "Pedido");

            migrationBuilder.CreateIndex(
                name: "IX_Posicion_PedidoId",
                table: "Posicion",
                column: "PedidoId");
        }
    }
}
