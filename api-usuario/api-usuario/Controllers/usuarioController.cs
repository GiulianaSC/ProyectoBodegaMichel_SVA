using api_usuario.entitys;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_usuario.Controllers
{
    //indicamos que es un controlador
    [ApiController]
    //definimos la ruta de acceso al controlador
    [Route("api-usuario/usuario")]
    
    public class usuarioController:ControllerBase
    {
        //cuando queremos tener informacion
        [HttpGet]
        public ActionResult<List<usuario>> findAll()
        {
            return new List<usuario>()
            {
                new usuario(){codigo=1,nombre="Guisepy Poma",estado=true},
                new usuario(){codigo=2,nombre="Roxana Alvarado",estado=true}
            };
        }
    }
}
