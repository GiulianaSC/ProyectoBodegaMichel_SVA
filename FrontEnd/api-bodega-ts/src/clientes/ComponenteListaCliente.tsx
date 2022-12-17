import axios from "axios";
import { useEffect, useState } from "react";
import { ClienteDTO } from "./cliente.model";
import { Link } from "react-router-dom";

export default function ComponenteListaCliente() {
    const urlcategoria = "https://localhost:44317/api-bodega/cliente";
    const [clientes, setClientes] = useState<ClienteDTO[]>();
    const peticionesGet = async () => {
        await axios
            .get(urlcategoria)
            .then((response) => {
                setClientes(response.data);
            })
            .catch((error) => {
                console.log(error);
            });
    };
    useEffect(() => {
        peticionesGet();
    }, []);
    return (
        <section>
            <div id="intro" className="bg-image vh-100" style={{ backgroundImage: "url(/img/portada.png)" }}>
                    <br />
                    <br />
                    <br />
                    <br />
                <div className="container">
                    <div className='card' style={{
                        backdropFilter: "blur(2px)",
                        backgroundColor: "rgba(251, 242, 240, .15)",
                        color: "#000000"
                    }}>
                        <div className='card-header'>
                            <h1 style={{ textAlign: "center" }}>Lista Cliente</h1>
                        </div>
                        <div className='card-body' >
                        <hr />
                            <div style={{ textAlign: "right" }}>
                                <a href="clientes/registrar" className="btn btn-primary">
                                    Registrar Cliente
                                </a></div>
                            <hr />
                            <div className="table-responsive">
                                <table className="table table-hover table-bordered" style={{ textAlign: "center" }}>
                                    <thead className="table-dark">
                                        <tr>
                                            <th scope="col">Código</th>
                                            <th scope="col">Tipo</th>
                                            <th scope="col">Documento</th>                                          
                                            <th scope="col">Nombre</th>
                                            <th scope="col">Apellido</th>
                                            <th scope="col">Distrito</th>
                                            <th scope="col">Estado</th>
                                            <th scope="col">Editar</th>
                                            <th scope="col">Eliminar</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        {/* se muestra los datos de la tabla */}
                                        {clientes?.map((cliente) => (
                                            <tr key={cliente.idCliente}>
                                                <th scope="row">{cliente.idCliente}</th>
                                                <td>{cliente.tipoDocumento}</td>
                                                <td>{cliente.nDocumento}</td>                                             
                                                <td>{cliente.nombreCliente}</td>
                                                <td>{cliente.apellidoCliente}</td>
                                                <td>{cliente.idDistrito}</td>
                                                {cliente.estadoCliente?<td>Habilitado</td>:<td>Deshabilitado</td>}
                                                <td>
                                                <Link
                    to={`/clientes/actualizar/${cliente.idCliente}`}
                    className="btn btn-success"
                  >
                                                        Actualizar
                                                        </Link>
                                                </td>
                                                <td>
                                                    <a href="#" className="btn btn-danger">
                                                        Eliminar
                                                    </a>
                                                </td>
                                            </tr>
                                        ))}
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>

    );
}
