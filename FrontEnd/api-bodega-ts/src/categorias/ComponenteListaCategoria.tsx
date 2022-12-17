import axios from "axios";
import { useEffect, useState } from "react";
import { CategoriaDTO } from "./categoria.model";
import { Link } from "react-router-dom";

export default function ComponenteListaDistrito() {
    const urlcategoria = "https://localhost:44317/api-bodega/categoria";
    const [categorias, setCategorias] = useState<CategoriaDTO[]>();
    const peticionesGet = async () => {
        await axios
            .get(urlcategoria)
            .then((response) => {
                setCategorias(response.data);
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
                            <h1 style={{ textAlign: "center" }}>Lista Categoria</h1>
                        </div>
                        <div className='card-body' >
                            <hr />
                            <div style={{ textAlign: "right" }}>
                                <a href="categorias/registrar" className="btn btn-primary">
                                    Registrar Categoria
                                </a></div>
                            <hr />
                            <div className="table-responsive">
                                <table className="table table-hover table-bordered" style={{ textAlign: "center" }}>
                                    <thead className="table-dark">
                                        <tr>
                                            <th scope="col">Código</th>
                                            <th scope="col">Nombre</th>
                                            <th scope="col">Comentario</th>
                                            <th scope="col">Estado</th>
                                            <th scope="col">Editar</th>
                                            <th scope="col">Eliminar</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        {/* se muestra los datos de la tabla */}
                                        {categorias?.map((categoria) => (
                                            <tr key={categoria.idCategoria}>
                                                <th scope="row">{categoria.idCategoria}</th>
                                                <td>{categoria.nomCategoria}</td>
                                                <td>{categoria.comCategoria}</td>
                                                {categoria.estadoCategoria?<td>Habilitado</td>:<td>Deshabilitado</td>}
                                                <td>
                                                <Link
                    to={`/categorias/actualizar/${categoria.idCategoria}`}
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