using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionFastFood.Migrations
{
    /// <inheritdoc />
    public partial class Posicion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MesaId",
                table: "Posicion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PedidoId",
                table: "Posicion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Posicion_MesaId",
                table: "Posicion",
                column: "MesaId");

            migrationBuilder.CreateIndex(
                name: "IX_Posicion_PedidoId",
                table: "Posicion",
                column: "PedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posicion_Mesa_MesaId",
                table: "Posicion",
                column: "MesaId",
                principalTable: "Mesa",
                principalColumn: "MesaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posicion_Pedido_PedidoId",
                table: "Posicion",
                column: "PedidoId",
                principalTable: "Pedido",
                principalColumn: "PedidoID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posicion_Mesa_MesaId",
                table: "Posicion");

            migrationBuilder.DropForeignKey(
                name: "FK_Posicion_Pedido_PedidoId",
                table: "Posicion");

            migrationBuilder.DropIndex(
                name: "IX_Posicion_MesaId",
                table: "Posicion");

            migrationBuilder.DropIndex(
                name: "IX_Posicion_PedidoId",
                table: "Posicion");

            migrationBuilder.DropColumn(
                name: "MesaId",
                table: "Posicion");

            migrationBuilder.DropColumn(
                name: "PedidoId",
                table: "Posicion");
        }
    }
}
