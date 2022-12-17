export interface ClienteDTO{
    idCliente: integer;
    nDocumento: string;
    tipoDocumento: string;
    nombreCliente: string;
    apellidoCliente: string;
    estadoCliente: boolean;
    idDistrito: integer;
}
export interface ClienteRegistrarDTO{
    nDocumento: string;
    tipoDocumento: string;
    nombreCliente: string;
    apellidoCliente: string;
    estadoCliente: boolean;
    idDistrito: integer;
}