import axios from "axios";
import { Field, Form, Formik } from "formik";
import { Link, useNavigate, useParams } from "react-router-dom";
import { DistritoDTO, DistritoRegistrarDTO } from "./distrito.model";
import { useEffect, useState } from "react";

export default function ComponenteActualizarDistrito() {
    const history= useNavigate();
    const { id }: any = useParams();
    const url = "https://localhost:44317/api-bodega/distrito/";

    const [distritos, setDistritos] = useState<DistritoDTO>();
    const peticionesGet = async () => {
        await axios
            .get(url+id)
            .then((response) => {
                setDistritos(response.data);
            })
            .catch((error) => {
                console.log(error);
            });
    };
    useEffect(() => {
        peticionesGet();
    }, []);

    async function ActualizarDistrito(distrito:DistritoDTO){
        try{
            await axios.put(url+id,distrito);
            history("/distritos");
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
                            <h1 style={{ textAlign: "center" }}>Actualizar Distrito</h1>
                        </div>
                        <div className='card-body' >
                        <Formik initialValues={{
                            idDistrito: id,
                                nomDistrito: '',
                                comDistrito: '',
                                estadoDistrito: true,
                            }}
                                onSubmit={async(valores) => {
                                    await ActualizarDistrito({
                                        
                                        idDistrito: valores.idDistrito,
                                        nomDistrito: valores.nomDistrito,
                                        comDistrito: valores.comDistrito,
                                        estadoDistrito: valores.estadoDistrito,
                                      });
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
                                            <input type="text" className="form-control" placeholder="Autogenerado" value={distritos?.idDistrito ||''} style={{
                                                backgroundColor: "rgba(236, 236, 236)",
                                            }} readOnly />
                                        </div>
                                        <div className="col-6">
                                            <label className="form-label" htmlFor="nomDistrito">Nombre:</label>
                                            <Field className="form-control"  name="nomDistrito" value={distritos?.nomDistrito ||''} 
      placeholder="Ingrese el nombre del distrito" maxLength="100" required />
                                        </div>
                                    </div>
                                    <hr style={{ color: "#5A5A5A" }} />
                                    <div className="row">
                                        <div className="col-12">
                                            <label className="form-label" htmlFor="comDistrito">Comentario:</label>
                                            <Field className="form-control"  name="comDistrito" value={distritos?.comDistrito||''}  placeholder="Ingrese un comentario si desea" />
                                        </div>
                                    </div>
                                    <hr style={{ color: "#5A5A5A" }} />
                                    <div className="row">
                                        <div className="col-6">
                                            <label className="form-label">Estado:</label>
                                            <div className="col-6 form-check">
                {distritos?.estadoDistrito ? (
                  <div>
                    <Field
                      className="form-check-input"
                      name="estado"
                      type="checkbox"
                      checked={true}
                    />
                    <label className="form-check-label">Habilitado</label>
                  </div>
                ) : (
                  <div>
                    <Field
                      className="form-check-input"
                      name="estado"
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
                                        <Link className="btn btn-secondary" to="/distritos">
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