using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionFastFood.Migrations
{
    /// <inheritdoc />
    public partial class Pedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Posicion",
                table: "Pedido");

            migrationBuilder.AddColumn<string>(
                name: "Detalle",
                table: "Pedido",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Detalle",
                table: "Pedido");

            migrationBuilder.AddColumn<int>(
                name: "Posicion",
                table: "Pedido",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
