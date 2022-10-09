using anular_venta.Entitys;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace anular_venta.Controllers
{
    [ApiController]
    [Route ("anular_venta/ventas")]
    public class AutorController: ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Aventas>> findAll()
        {
            return new List<Aventas>()
            {
                new Aventas(){NumeroDeComprobante=23123452,TipoDeComprobante="Factura",Desde="14/03/2022",Hasta="15/03/2022"},
                new Aventas(){NumeroDeComprobante=534345324,TipoDeComprobante="Boleta",Desde="20/06/2022",Hasta="25/06/2022",}
            };
        }

    }
}
