import axios from "axios";
import { useEffect, useState } from "react";
import { ProveedorDTO } from "./proveedor.model";
import { Link } from "react-router-dom";

export default function ComponenteListaProveedor() {
    const urlproveedor = "https://localhost:44317/api-bodega/proveedor";
    const [proveedores, setProveedores] = useState<ProveedorDTO[]>();
    const peticionesGet = async () => {
        await axios
            .get(urlproveedor )
            .then((response) => {
                setProveedores(response.data);
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
                            <h1 style={{ textAlign: "center" }}>Lista Proveedor</h1>
                        </div>
                        <div className='card-body' >
                        <hr />
                            <div style={{ textAlign: "right" }}>
                                <a href="proveedores/registrar" className="btn btn-primary">
                                    Registrar Proveedor
                                </a></div>
                            <hr />
                            <div className="table-responsive">
                                <table className="table table-hover table-bordered"  style={{ textAlign: "center" }}>
                                    <thead className="table-dark">
                                        <tr>
                                            <th scope="col">Código</th>
                                            <th scope="col">RUC</th>
                                            <th scope="col">Razon Social</th>
                                            <th scope="col">Telefono</th>                                          
                                            <th scope="col">Email</th>
                                            <th scope="col">Direccion</th>
                                            <th scope="col">Categoria</th>
                                            <th scope="col">Estado</th>
                                            <th scope="col">Editar</th>
                                            <th scope="col">Eliminar</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        {/* se muestra los datos de la tabla */}
                                        {proveedores?.map((proveedor) => (
                                            <tr key={proveedor.idProveedor}>
                                                <th scope="row">{proveedor.idProveedor}</th>
                                                <td>{proveedor.ruc}</td>
                                                <td>{proveedor.nombre}</td>
                                                <td>{proveedor.telefono}</td>                                              
                                                <td>{proveedor.email}</td>
                                                <td>{proveedor.direccion}</td>
                                                <td>{proveedor.idCategoria}</td>
                                                {proveedor.estadoProveedor?<td>Habilitado</td>:<td>Deshabilitado</td>}
                                                <td>
                                                <Link
                    to={`/proveedores/actualizar/${proveedor.idProveedor}`}
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
