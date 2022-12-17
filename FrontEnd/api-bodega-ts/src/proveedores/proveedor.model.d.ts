export interface ProveedorDTO{
    idProveedor: integer;
    ruc: string;
    nombre: string;
    telefono: string;
    email: string;
    direccion: string;
    estadoProveedor: boolean;
    idCategoria: integer;
}
export interface ProveedorRegistrarDTO{
    ruc: string;
    nombre: string;
    telefono: string;
    email: string;
    direccion: string;
    estadoProveedor: boolean;
    idCategoria: integer;
}