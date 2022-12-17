export interface ProductoDTO{
    idProducto: integer;
    descripcionProducto: string;
    precioCompra: decimal;
    precioVenta: decimal;
    stock: integer;
    estadoProducto: boolean;
    idCategoria: integer;
}
export interface ProductoRegistrarDTO{
    descripcionProducto: string;
    precioCompra: decimal;
    precioVenta: decimal;
    stock: integer;
    estadoProducto: boolean;
    idCategoria: integer;
}