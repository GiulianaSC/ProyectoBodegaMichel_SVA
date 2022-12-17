import axios from "axios";
import { Formik,Field, Form} from "formik";
import { useEffect, useState } from "react";
import { Link, useNavigate, useParams } from "react-router-dom";
import { ClienteDTO} from "./cliente.model";
export default function ComponenteActualizarCliente() {
    const history= useNavigate();
    const { id }: any = useParams();
    const url = "https://localhost:44317/api-bodega/cliente/";

    const [clientes, setClientes] = useState<ClienteDTO>();
    const peticionesGet = async () => {
        await axios
            .get(url+id)
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


    async function ActualizarCliente(cliente:ClienteDTO){
        try{
            await axios.post(url+id,cliente);
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
                            <h1 style={{ textAlign: "center" }}>Actualizar Cliente</h1>
                        </div>
                        <div className='card-body' >
                            <Formik initialValues={{
                                idCliente: id,
                                nDocumento: '',
                                tipoDocumento: '',
                                nombreCliente: '',
                                apellidoCliente: '',
                                estadoCliente: true,
                                idDistrito: '',
                            }}
                                onSubmit={async(valores) => {
                                    await new Promise((r)=>setTimeout(r,1000));

                                    await ActualizarCliente({
                                        idCliente: valores.idCliente,
                                        nDocumento: valores.nDocumento,
                                        tipoDocumento: valores.tipoDocumento,
                                        nombreCliente: valores.nombreCliente,
                                        apellidoCliente: valores.apellidoCliente,
                                        estadoCliente: valores.estadoCliente,
                                        idDistrito: valores.idDistrito,
                                    }
                                    );
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
                                            <input type="text" className="form-control" placeholder="Autogenerado" value={clientes?.idCliente ||''} style={{
                                                backgroundColor: "rgba(236, 236, 236)",
                                            }} readOnly />
                                        </div>
                                        <div className="col-4">
                                            <label className="form-label" htmlFor="tipoDocumento">Tipo de documento:</label>
                                            <Field className="form-control"  name="tipoDocumento"  value={clientes?.tipoDocumento ||''} placeholder="Ingrese el tipo de documento" maxLength="20" required />
                                        </div>
                                        <div className="col-4">
                                            <label className="form-label" htmlFor="nDocumento">N Documento:</label>
                                            <Field className="form-control"  name="nDocumento" placeholder="Ingrese el numero de documento" value={clientes?.nDocumento ||''} maxLength="20" required />
                                        </div>
                                    </div>
                                    <hr style={{ color: "#5A5A5A" }} />
                                    <div className="row">
                                        <div className="col-6">
                                            <label className="form-label" htmlFor="nombreCliente">Nombre:</label>
                                            <Field className="form-control"  name="nombreCliente" placeholder="Ingrese el nombre" value={clientes?.nombreCliente ||''} />
                                        </div>
                                        <div className="col-6">
                                            <label className="form-label" htmlFor="apellidoCliente">Apellido:</label>
                                            <Field className="form-control"  name="apellidoCliente" placeholder="Ingrese el apellido" value={clientes?.apellidoCliente ||''}/>
                                        </div>
                                    </div>
                                    <hr style={{ color: "#5A5A5A" }} />
                                    <div className="row">
                                    <div className="col-6">
                                            <label className="form-label" htmlFor="idDistrito">Distrito:</label>
                                            <Field type="number" className="form-control"  name="idDistrito" placeholder="Ingrese el distrito" value={clientes?.idDistrito ||''} />
                                        </div>
                                        <div className="col-6">
                                            <label className="form-label">Estado:</label>
                                            <div className="col-6 form-check">
                                            {clientes?.estadoCliente ? (
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