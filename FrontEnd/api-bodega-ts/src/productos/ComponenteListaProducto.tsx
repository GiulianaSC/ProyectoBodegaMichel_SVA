import axios from "axios";
import { useEffect, useState } from "react";
import { ProductoDTO } from "./producto.model";
import { Link } from "react-router-dom";

export default function ComponenteListaProducto() {
    const urlproducto = "https://localhost:44317/api-bodega/producto";
    const [productos, setProductos] = useState<ProductoDTO[]>();
    const peticionesGet = async () => {
        await axios
            .get(urlproducto)
            .then((response) => {
                setProductos(response.data);
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
                            <h1 style={{ textAlign: "center" }}>Lista Producto</h1>
                        </div>
                        <div className='card-body' >
                        <hr />
                            <div style={{ textAlign: "right" }}>
                                <a href="productos/registrar" className="btn btn-primary">
                                    Registrar Producto
                                </a></div>
                            <hr />
                            <div className="table-responsive">
                                <table className="table table-hover table-bordered"  style={{ textAlign: "center" }}>
                                    <thead className="table-dark">
                                        <tr>
                                            <th scope="col">Código</th>
                                            <th scope="col">Descripcion</th>
                                            <th scope="col">Precio compra</th>                                          
                                            <th scope="col">Precio venta</th>
                                            <th scope="col">Stock</th>
                                            <th scope="col">Categoria</th>
                                            <th scope="col">Estado</th>
                                            <th scope="col">Editar</th>
                                            <th scope="col">Eliminar</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        {/* se muestra los datos de la tabla */}
                                        {productos?.map((producto) => (
                                            <tr key={producto.idProducto}>
                                                <th scope="row">{producto.idProducto}</th>
                                                <td>{producto.descripcionProducto}</td>
                                                <td>{producto.precioCompra}</td>                                             
                                                <td>{producto.precioVenta}</td>
                                                <td>{producto.stock}</td>
                                                <td>{producto.idCategoria}</td>
                                                {producto.estadoProducto?<td>Habilitado</td>:<td>Deshabilitado</td>}
                                                <td>
                                                <Link
                    to={`/productos/actualizar/${producto.idProducto}`}
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
