using api_producto.entitys;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_producto.Controllers
{
    //indicamos que es un controlador
    [ApiController]
    //definimos la ruta de acceso al controlador
    [Route("api-producto/producto")]
    
    public class ProductoController:ControllerBase
    {
        //cuando queremos tener informacion
        [HttpGet]
        public ActionResult<List<producto>> findAll()
        {
            return new List<producto>()
            {
                new producto(){codigoProd=1,nombre="Aaron david Ramos Crespo",estado=true},
                new producto(){precioventa=2,nombre="s/ 5 ",estado=true},
                new producto(){nombreProd="Queso",estado=true},
                new producto(){categoria="Lacteos",estado=true},
                new producto(){stock=2,nombre="10",estado=true}
            };
        }
    }
}
