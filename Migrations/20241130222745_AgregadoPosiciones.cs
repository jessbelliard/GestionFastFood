using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionFastFood.Migrations
{
    /// <inheritdoc />
    public partial class AgregadoPosiciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumeroPosiciones",
                table: "Mesa");

            migrationBuilder.CreateTable(
                name: "Posicion",
                columns: table => new
                {
                    PosicionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posicion", x => x.PosicionId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posicion");

            migrationBuilder.AddColumn<int>(
                name: "NumeroPosiciones",
                table: "Mesa",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
