import axios from "axios";
import { Field, Form, Formik } from "formik";
import { Link, useNavigate } from "react-router-dom";
import { DistritoRegistrarDTO } from "./distrito.model";

export default function ComponenteRegistrarDistrito() {
    const history= useNavigate();
    const url = "https://localhost:44317/api-bodega/distrito";
    async function RegistrarDistrito(distrito:DistritoRegistrarDTO){
        try{
            await axios.post(url,distrito);
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
                            <h1 style={{ textAlign: "center" }}>Registrar Distrito</h1>
                        </div>
                        <div className='card-body' >
                        <Formik initialValues={{
                                nomDistrito: '',
                                comDistrito: '',
                                estadoDistrito: true,
                            }}
                                onSubmit={async(valores) => {
                                    await new Promise((r)=>setTimeout(r,1000));
                                    await RegistrarDistrito(valores);
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
                                            <input type="text" className="form-control" placeholder="Autogenerado" style={{
                                                backgroundColor: "rgba(236, 236, 236)",
                                            }} readOnly />
                                        </div>
                                        <div className="col-6">
                                            <label className="form-label" htmlFor="nomDistrito">Nombre:</label>
                                            <Field className="form-control"  name="nomDistrito" placeholder="Ingrese el nombre del distrito" maxLength="100" required />
                                        </div>
                                    </div>
                                    <hr style={{ color: "#5A5A5A" }} />
                                    <div className="row">
                                        <div className="col-12">
                                            <label className="form-label" htmlFor="comDistrito">Comentario:</label>
                                            <Field className="form-control"  name="comDistrito" placeholder="Ingrese un comentario si desea" />
                                        </div>
                                    </div>
                                    <hr style={{ color: "#5A5A5A" }} />
                                    <div className="row">
                                        <div className="col-6">
                                            <label className="form-label">Estado:</label>
                                            <div className="col-6 form-check">
                                                <Field type="checkbox" className="form-check-input" name="estadoDistrito" />
                                                <label className="form-check-label">Habilitado</label>
                                            </div>
                                        </div>
                                    </div>
                                    <hr style={{ color: "#5A5A5A" }} />
                                    <div style={{ textAlign: "right" }}>
                                    <button type="submit" className="btn btn-primary">
                                            Registrar
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