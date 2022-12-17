using Microsoft.EntityFrameworkCore.Migrations;

namespace api_bodega.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    idCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomCategoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    comCategoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    estadoCategoria = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.idCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Distrito",
                columns: table => new
                {
                    idDistrito = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomDistrito = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    comDistrito = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    estadoDistrito = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distrito", x => x.idDistrito);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    idUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEmpleado = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NombreUsuario = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContraseñaUsuario = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EstadoUsuario = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.idUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    idProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionProducto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PrecioCompra = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    PrecioVenta = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    EstadoProducto = table.Column<bool>(type: "bit", nullable: false),
                    idCategoria = table.Column<int>(type: "int", nullable: false),
                    categoriaidCategoria = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.idProducto);
                    table.ForeignKey(
                        name: "FK_Producto_Categoria_categoriaidCategoria",
                        column: x => x.categoriaidCategoria,
                        principalTable: "Categoria",
                        principalColumn: "idCategoria",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    idProveedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ruc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estadoProveedor = table.Column<bool>(type: "bit", nullable: false),
                    idCategoria = table.Column<int>(type: "int", nullable: false),
                    categoriaidCategoria = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.idProveedor);
                    table.ForeignKey(
                        name: "FK_Proveedor_Categoria_categoriaidCategoria",
                        column: x => x.categoriaidCategoria,
                        principalTable: "Categoria",
                        principalColumn: "idCategoria",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    idCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NDocumento = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    TipoDocumento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreCliente = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ApellidoCliente = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EstadoCliente = table.Column<bool>(type: "bit", nullable: false),
                    idDistrito = table.Column<int>(type: "int", nullable: false),
                    distritoidDistrito = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.idCliente);
                    table.ForeignKey(
                        name: "FK_Cliente_Distrito_distritoidDistrito",
                        column: x => x.distritoidDistrito,
                        principalTable: "Distrito",
                        principalColumn: "idDistrito",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comprobante",
                columns: table => new
                {
                    idComprobante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoComprobante = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    FechaComprobante = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Igv = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    EstadoComprobante = table.Column<bool>(type: "bit", nullable: false),
                    idCliente = table.Column<int>(type: "int", nullable: false),
                    clienteidCliente = table.Column<int>(type: "int", nullable: true),
                    idUsuario = table.Column<int>(type: "int", nullable: false),
                    usuarioidUsuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comprobante", x => x.idComprobante);
                    table.ForeignKey(
                        name: "FK_Comprobante_Cliente_clienteidCliente",
                        column: x => x.clienteidCliente,
                        principalTable: "Cliente",
                        principalColumn: "idCliente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comprobante_Usuario_usuarioidUsuario",
                        column: x => x.usuarioidUsuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetalleComprobante",
                columns: table => new
                {
                    idDetalleComprobante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CantProducto = table.Column<int>(type: "int", nullable: false),
                    PrecioVenta = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    ImporteProducto = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    idProducto = table.Column<int>(type: "int", nullable: false),
                    productoidProducto = table.Column<int>(type: "int", nullable: true),
                    idComprobante = table.Column<int>(type: "int", nullable: false),
                    comprobanteidComprobante = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleComprobante", x => x.idDetalleComprobante);
                    table.ForeignKey(
                        name: "FK_DetalleComprobante_Comprobante_comprobanteidComprobante",
                        column: x => x.comprobanteidComprobante,
                        principalTable: "Comprobante",
                        principalColumn: "idComprobante",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetalleComprobante_Producto_productoidProducto",
                        column: x => x.productoidProducto,
                        principalTable: "Producto",
                        principalColumn: "idProducto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_distritoidDistrito",
                table: "Cliente",
                column: "distritoidDistrito");

            migrationBuilder.CreateIndex(
                name: "IX_Comprobante_clienteidCliente",
                table: "Comprobante",
                column: "clienteidCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Comprobante_usuarioidUsuario",
                table: "Comprobante",
                column: "usuarioidUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleComprobante_comprobanteidComprobante",
                table: "DetalleComprobante",
                column: "comprobanteidComprobante");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleComprobante_productoidProducto",
                table: "DetalleComprobante",
                column: "productoidProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_categoriaidCategoria",
                table: "Producto",
                column: "categoriaidCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedor_categoriaidCategoria",
                table: "Proveedor",
                column: "categoriaidCategoria");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleComprobante");

            migrationBuilder.DropTable(
                name: "Proveedor");

            migrationBuilder.DropTable(
                name: "Comprobante");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Distrito");
        }
    }
}
