import axios from "axios";
import { Formik,Field, Form} from "formik";
import { useRef, useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import * as Yup from 'yup';
import { CategoriaRegistrarDTO } from "./categoria.model";
export default function ComponenteRegistrarCategoria() {
    const history= useNavigate();
    const url = "https://localhost:44317/api-bodega/categoria";
    // const [nombre, setNombre]=useState("");
    // const handlesubmit=(e:React.FormEvent<HTMLFormElement>)=>{
    //     e.preventDefault();
    //     console.log(nombre);
    // }

    // const handlesubmit = (e: React.FormEvent<HTMLFormElement>) => {
    //     e.preventDefault();
    //     if (txtNom.current) {
    //         console.log(txtNom.current.value);
    //     }
    //     if (txtCom.current) {
    //         console.log(txtCom.current.value);
    //     }
    // }
    // const txtNom = useRef<HTMLInputElement>(null);
    // const txtCom = useRef<HTMLInputElement>(null);
    async function RegistrarCategoria(categoria:CategoriaRegistrarDTO){
        try{
            await axios.post(url,categoria);
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
                                nomCategoria: '',
                                comCategoria: '',
                                estadoCategoria: true,
                            }}
                                onSubmit={async(valores) => {
                                    await new Promise((r)=>setTimeout(r,1000));
                                    //var est=false;
                                    //if(valores.estadoCategoria ==="true"){
                                      //  est=true;
                                    //}else{
                                        //est=false;
                                    //}
                                    await RegistrarCategoria(valores);
                                    console.log(valores);
                                }}
                                // validationSchema={
                                //     Yup.object({nombre: Yup.string().required("Este campo es requerido")})
                                // }
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
                                            <label className="form-label" htmlFor="nomCategoria">Nombre:</label>
                                            <Field className="form-control"  name="nomCategoria" placeholder="Ingrese el nombre de la categoria" maxLength="100" required />
                                        </div>
                                    </div>
                                    <hr style={{ color: "#5A5A5A" }} />
                                    <div className="row">
                                        <div className="col-12">
                                            <label className="form-label" htmlFor="comCategoria">Comentario:</label>
                                            <Field className="form-control"  name="comCategoria" placeholder="Ingrese un comentario si desea" />
                                        </div>
                                    </div>
                                    <hr style={{ color: "#5A5A5A" }} />
                                    <div className="row">
                                        <div className="col-6">
                                            <label className="form-label">Estado:</label>
                                            <div className="col-6 form-check">
                                                <Field type="checkbox" className="form-check-input" name="estadoCategoria" />
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