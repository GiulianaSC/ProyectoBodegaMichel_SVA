import axios from "axios";
import { Formik,Field, Form} from "formik";
import { useRef, useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import * as Yup from 'yup';
import { ProductoRegistrarDTO } from "./producto.model";
export default function ComponenteRegistrarProducto() {
    const history= useNavigate();
    const url = "https://localhost:44317/api-bodega/producto";
    async function RegistrarProducto(producto:ProductoRegistrarDTO){
        try{
            await axios.post(url,producto);
            history("/productos");
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
                            <h1 style={{ textAlign: "center" }}>Registrar Producto</h1>
                        </div>
                        <div className='card-body' >
                            <Formik initialValues={{
                                 descripcionProducto: '',
                                 precioCompra: '',
                                 precioVenta: '',
                                 stock: '',
                                 estadoProducto: true,
                                 idCategoria: '',
                            }}
                                onSubmit={async(valores) => {
                                    await new Promise((r)=>setTimeout(r,1000));
                                    await RegistrarProducto(valores);
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
                                        <div className="col-8">
                                            <label className="form-label" htmlFor="descripcionProducto">Descripcion:</label>
                                            <Field className="form-control"  name="descripcionProducto" placeholder="Ingrese la descripcion del producto" maxLength="20" required />
                                        </div>
                                    </div>
                                    <hr style={{ color: "#5A5A5A" }} />
                                    <div className="row">
                                        <div className="col-4">
                                            <label className="form-label" htmlFor="precioCompra">Precio Compra:</label>
                                            <Field className="form-control"  name="precioCompra" placeholder="Ingrese el precio de compra" />
                                        </div>
                                        <div className="col-4">
                                            <label className="form-label" htmlFor="precioVenta">Precio Venta:</label>
                                            <Field className="form-control"  name="precioVenta" placeholder="Ingrese el precio de venta" />
                                        </div>
                                        <div className="col-4">
                                            <label className="form-label" htmlFor="stock">Stock:</label>
                                            <Field type="number" className="form-control"  name="stock" />
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
                                                <Field type="checkbox" className="form-check-input" name="estadoProducto" />
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
                                        <Link className="btn btn-secondary" to="/productos">
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