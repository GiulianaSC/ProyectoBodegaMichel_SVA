
export default function ComponenteMenu() {
    return (
    <nav className="navbar navbar-expand-lg navbar-light fixed-top mask-custom shadow-0" 
    style={{
      backdropFilter: "blur(5px)",
      backgroundColor: "rgba(255, 255, 255, .15)",
      color: "#fff"}}>
    <div className="container">
      <a className="navbar-brand" href="#!"><span style={{color: "#A08A87"}}>Bodega</span><span style={{color: "#675B5B"}}>Michel</span></a>
      <button className="navbar-toggler" type="button" data-mdb-toggle="collapse"
        data-mdb-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false"
        aria-label="Toggle navigation">
        <i className="fas fa-bars"></i>
      </button>
      <div className="collapse navbar-collapse" id="navbarSupportedContent">
        <ul className="navbar-nav me-auto">
        <li className="nav-item">
            <a className="nav-link" href="/">Inicio</a>
          </li>
          <li className="nav-item">
            <a className="nav-link" href="/clientes">Cliente</a>
          </li>
          <li className="nav-item">
            <a className="nav-link" href="/proveedores">Proveedor</a>
          </li>
          <li className="nav-item">
            <a className="nav-link" href="/productos">Producto</a>
          </li>
          <li className="nav-item">
            <a className="nav-link" href="/distritos">Distrito</a>
          </li>
          <li className="nav-item">
            <a className="nav-link" href="/categorias">Categoria</a>
          </li>
          <li className="nav-item">
            <a className="nav-link" href="/">Venta</a>
          </li>
          <li className="nav-item">
            <a className="nav-link" href="/">Usuarios</a>
          </li>
        </ul>
      </div>
    </div>
  </nav>
    );
}