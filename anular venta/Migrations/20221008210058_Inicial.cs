using Microsoft.EntityFrameworkCore.Migrations;

namespace anular_venta.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aventas",
                columns: table => new
                {
                    NumeroDeComprobante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoDeComprobante = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Desde = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hasta = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aventas", x => x.NumeroDeComprobante);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aventas");
        }
    }
}
