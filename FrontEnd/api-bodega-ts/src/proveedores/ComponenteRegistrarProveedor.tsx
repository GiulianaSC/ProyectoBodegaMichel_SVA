import axios from "axios";
import { Formik,Field, Form} from "formik";
import { useRef, useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import * as Yup from 'yup';
import { ProveedorRegistrarDTO } from "./proveedor.model";

export default function ComponenteRegistrarProveedor() {
    const history= useNavigate();
    const url = "https://localhost:44317/api-bodega/proveedor";
    async function RegistrarProveedor(proveedor:ProveedorRegistrarDTO){
        try{
            await axios.post(url,proveedor);
            history("/proveedores");
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
                            <h1 style={{ textAlign: "center" }}>Registrar Proveedor</h1>
                        </div>
                        <div className='card-body' >
                            <Formik initialValues={{
                                     ruc: '',
                                     nombre: '',
                                     telefono: '',
                                     email: '',
                                     direccion: '',
                                     estadoProveedor: true,
                                     idCategoria: '',
                            }}
                                onSubmit={async(valores) => {
                                    await new Promise((r)=>setTimeout(r,1000));
                                    await RegistrarProveedor(valores);
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
                                            <label className="form-label" htmlFor="ruc">RUC:</label>
                                            <Field className="form-control"  name="ruc" placeholder="Ingrese el RUC" maxLength="11" required />
                                        </div>
                                        <div className="col-4">
                                            <label className="form-label" htmlFor="nombre">Razon Social:</label>
                                            <Field className="form-control"  name="nombre" placeholder="Ingrese el nombre" maxLength="100" required />
                                        </div>
                                    </div>
                                    <hr style={{ color: "#5A5A5A" }} />
                                    <div className="row">
                                        <div className="col-4">
                                            <label className="form-label" htmlFor="telefono">Telefono:</label>
                                            <Field className="form-control"  name="telefono" placeholder="Ingrese el telefono" />
                                        </div>
                                        <div className="col-4">
                                            <label className="form-label" htmlFor="email">Email:</label>
                                            <Field className="form-control"  name="email" placeholder="Ingrese el email" />
                                        </div>
                                        <div className="col-4">
                                            <label className="form-label" htmlFor="direccion">Direccion:</label>
                                            <Field className="form-control"  name="direccion" placeholder="Ingrese la direccion" />
                                        </div>
                                    </div>
                                    <hr style={{ color: "#5A5A5A" }} />
                                    <div className="row">
                                    <div className="col-6">
                                            <label className="form-label" htmlFor="idCategoria">Categoria:</label>
                                            <Field type="number" className="form-control"  name="idCategoria" placeholder="Ingrese la categoria" />
                                        </div>
                                        <div className="col-6">
                                            <label className="form-label">Estado:</label>
                                            <div className="col-6 form-check">
                                                <Field type="checkbox" className="form-check-input" name="estadoProveedor" />
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
                                        <Link className="btn btn-secondary" to="/proveedores">
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