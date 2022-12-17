import axios from "axios";
import { Formik,Field, Form} from "formik";
import { useEffect, useRef, useState } from "react";
import { Link, useNavigate, useParams } from "react-router-dom";
import * as Yup from 'yup';
import { CategoriaDTO, CategoriaRegistrarDTO } from "./categoria.model";
export default function ComponenteActualizarCategoria() {
    const history= useNavigate();
    const { id }: any = useParams();
    const url = "https://localhost:44317/api-bodega/categoria/";
 
    const [categorias, setCategorias] = useState<CategoriaDTO>();
    const peticionesGet = async () => {
        await axios
            .get(url+id)
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

    async function ActualizarCategoria(categoria:CategoriaDTO){
        try{
            await axios.post(url+id,categoria);
            history("/categorias");
        }catch(error){
            console.log(error);
        }
    }
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
                            <h1 style={{ textAlign: "center" }}>Registrar Categoria</h1>
                        </div>
                        <div className='card-body' >
                            <Formik initialValues={{
                                idCategoria: id,
                                nomCategoria: '',
                                comCategoria: '',
                                estadoCategoria: true && false,
                            }}
                                onSubmit={async(valores) => {
                                    await new Promise((r)=>setTimeout(r,1000));
                                    await ActualizarCategoria({
                                        idCategoria: valores.idCategoria,
                                nomCategoria: valores.nomCategoria,
                                comCategoria: valores.comCategoria,
                                estadoCategoria: valores.estadoCategoria,
                                    });
                                    console.log(valores);
                                }}
                            >
                                <Form className="form-control" style={{
                                    backdropFilter: "blur(2px)",
                                    backgroundColor: "rgba(251, 242, 240, .15)",
                                    color: "#000000"
                                }}>
                                    <hr style={{ color: "#5A5A5A" }} />
                                    <div className="row">
                                        <div className="col-6">
                                            <label className="form-label">Codigo:</label>
                                            <input type="text" className="form-control" placeholder="Autogenerado" value={categorias?.idCategoria ||''} style={{
                                                backgroundColor: "rgba(236, 236, 236)",
                                            }} readOnly />
                                        </div>
                                        <div className="col-6">
                                            <label className="form-label" htmlFor="nomCategoria">Nombre:</label>
                                            <Field className="form-control"  name="nomCategoria" placeholder="Ingrese el nombre de la categoria" value={categorias?.nomCategoria ||''} maxLength="100" required />
                                        </div>
                                    </div>
                                    <hr style={{ color: "#5A5A5A" }} />
                                    <div className="row">
                                        <div className="col-12">
                                            <label className="form-label" htmlFor="comCategoria">Comentario:</label>
                                            <Field className="form-control"  name="comCategoria" placeholder="Ingrese un comentario si desea" value={categorias?.comCategoria ||''} />
                                        </div>
                                    </div>
                                    <hr style={{ color: "#5A5A5A" }} />
                                    <div className="row">
                                        <div className="col-6">
                                            <label className="form-label">Estado:</label>
                                            <div className="col-6 form-check">
                                            {categorias?.estadoCategoria ? (
                  <div>
                  <Field
                    className="form-check-input"
                    name="estadoCategoria"
                    type="checkbox"
                    checked={true}
                  />
                  <label className="form-check-label">Habilitado</label>
                </div>
                ) : (
                    <div>
                    <Field
                      className="form-check-input"
                      name="estadoCategoria"
                      type="checkbox"
                    />
                    <label className="form-check-label">Deshabilitado</label>
                  </div>
                  
                )}
                                            </div>
                                        </div>
                                    </div>
                                    <hr style={{ color: "#5A5A5A" }} />
                                    <div style={{ textAlign: "right" }}>
                                    <button type="submit" className="btn btn-primary">
                                            Actualizar
                                        </button>
                                        ㅤ
                                        <Link className="btn btn-secondary" to="/categorias">
                                            Cancelar
                                        </Link>
                                    </div>
                                    <hr style={{ color: "#5A5A5A" }} />
                                </Form>

                            </Formik>


                        </div>
                    </div>
                </div>
            </div>
        </section>
    );
}