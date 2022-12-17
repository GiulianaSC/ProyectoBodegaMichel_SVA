import axios from "axios";
import { Formik,Field, Form} from "formik";
import { useRef, useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import * as Yup from 'yup';
import { ClienteRegistrarDTO } from "./cliente.model";
export default function ComponenteRegistrarCliente() {
    const history= useNavigate();
    const url = "https://localhost:44317/api-bodega/cliente";
    async function RegistrarCliente(cliente:ClienteRegistrarDTO){
        try{
            await axios.post(url,cliente);
            history("/clientes");
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
                            <h1 style={{ textAlign: "center" }}>Registrar Cliente</h1>
                        </div>
                        <div className='card-body' >
                            <Formik initialValues={{
                                nDocumento: '',
                                tipoDocumento: '',
                                nombreCliente: '',
                                apellidoCliente: '',
                                estadoCliente: true,
                                idDistrito: '',
                            }}
                                onSubmit={async(valores) => {
                                    await new Promise((r)=>setTimeout(r,1000));

                                    await RegistrarCliente(valores);
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
                                        <div className="col-4">
                                            <label className="form-label">Codigo:</label>
                                            <input type="text" className="form-control" placeholder="Autogenerado" style={{
                                                backgroundColor: "rgba(236, 236, 236)",
                                            }} readOnly />
                                        </div>
                                        <div className="col-4">
                                            <label className="form-label" htmlFor="tipoDocumento">Tipo de documento:</label>
                                            <Field className="form-control"  name="tipoDocumento" placeholder="Ingrese el tipo de documento" maxLength="20" required />
                                        </div>
                                        <div className="col-4">
                                            <label className="form-label" htmlFor="nDocumento">N Documento:</label>
                                            <Field className="form-control"  name="nDocumento" placeholder="Ingrese el numero de documento" maxLength="20" required />
                                        </div>
                                    </div>
                                    <hr style={{ color: "#5A5A5A" }} />
                                    <div className="row">
                                        <div className="col-6">
                                            <label className="form-label" htmlFor="nombreCliente">Nombre:</label>
                                            <Field className="form-control"  name="nombreCliente" placeholder="Ingrese el nombre" />
                                        </div>
                                        <div className="col-6">
                                            <label className="form-label" htmlFor="apellidoCliente">Apellido:</label>
                                            <Field className="form-control"  name="apellidoCliente" placeholder="Ingrese el apellido" />
                                        </div>
                                    </div>
                                    <hr style={{ color: "#5A5A5A" }} />
                                    <div className="row">
                                    <div className="col-6">
                                            <label className="form-label" htmlFor="idDistrito">Distrito:</label>
                                            <Field type="number" className="form-control"  name="idDistrito" placeholder="Ingrese el distrito" />
                                        </div>
                                        <div className="col-6">
                                            <label className="form-label">Estado:</label>
                                            <div className="col-6 form-check">
                                                <Field type="checkbox" className="form-check-input" name="estadoCliente" />
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
                                        <Link className="btn btn-secondary" to="/clientes">
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