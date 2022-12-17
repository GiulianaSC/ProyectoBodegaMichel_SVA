import ComponenteListaDistrito from './distritos/ComponenteListaDistrito';
import ComponenteListaCliente from './clientes/ComponenteListaCliente';
import ComponentePrincipal from './principal/ComponentePrincipal';
import ComponenteListaCategoria from './categorias/ComponenteListaCategoria';
import ComponenteRegistrarDistrito from './distritos/ComponenteRegistrarDistrito';
import ComponenteRegistrarCategoria from './categorias/ComponenteRegistrarCategoria';
import ComponenteListaProducto from './productos/ComponenteListaProducto';
import ComponenteListaProveedor from './proveedores/ComponenteListaProveedor';
import ComponenteRegistrarCliente from './clientes/ComponenteRegistrarCliente';
import ComponenteRegistrarProducto from './productos/ComponenteRegistrarProducto';
import ComponenteRegistrarProveedor from './proveedores/ComponenteRegistrarProveedor';
import ComponenteActualizarDistrito from './distritos/ComponenteActualizarDistrito';
import ComponenteActualizarCliente from './clientes/ComponenteActualizarCliente';
import ComponenteActualizarCategoria from './categorias/ComponenteActualizarCategoria';
import ComponenteActualizarProveedor from './proveedores/ComponenteActualizarProveedor';
import ComponenteActualizarProducto from './productos/ComponenteActualizarProducto';

const rutas=[
    {path:"/",componente:ComponentePrincipal },
    {path:"/clientes",componente:ComponenteListaCliente },
    {path:"/distritos",componente:ComponenteListaDistrito },
    {path:"/distritos/registrar",componente:ComponenteRegistrarDistrito },
    {path:"/distritos/actualizar/:id",componente:ComponenteActualizarDistrito },
    {path:"/categorias",componente:ComponenteListaCategoria },
    {path:"/productos",componente:ComponenteListaProducto },
    {path:"/proveedores",componente:ComponenteListaProveedor},
    {path:"/categorias/registrar",componente:ComponenteRegistrarCategoria },
    {path:"/categorias/actualizar/:id",componente:ComponenteActualizarCategoria },
    {path:"/clientes/registrar",componente:ComponenteRegistrarCliente },
    {path:"/clientes/actualizar/:id",componente:ComponenteActualizarCliente },
    {path:"/productos/registrar",componente:ComponenteRegistrarProducto },
    {path:"/proveedores/registrar",componente:ComponenteRegistrarProveedor },
    {path:"/proveedores/actualizar/:id",componente:ComponenteActualizarProveedor},
    {path:"/productos/actualizar/:id",componente:ComponenteActualizarProducto},

]

export default rutas;