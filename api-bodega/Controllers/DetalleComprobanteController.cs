using api_bodega.Entitys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace api_bodega.Controllers
{
    [ApiController]
    [Route("api-bodega/detalleComprobante")]
    public class DetalleComprobanteController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public DetalleComprobanteController(ApplicationDbContext context)

        {
            this.context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<DetalleComprobante>>> findAll()
        {
            return await context.DetalleComprobante.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> add(DetalleComprobante dc)
        {
            //Verificando la existencia del producto y comprobante
            var productoexiste = await context.Producto.AnyAsync(x => x.idProducto == dc.idProducto);
            var comprobanteexiste = await context.Comprobante.AnyAsync(x => x.idComprobante == dc.idComprobante);

            if (!productoexiste)
            {
                return BadRequest($"No existe el producto con codigo: {dc.idProducto}");
            }
            if (!comprobanteexiste)
            {
                return BadRequest($"No existe el comprobante con codigo: {dc.idComprobante}");
            }
            context.Add(dc);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<DetalleComprobante>> findById(int id)
        {
            var detalleComprobante = await context.DetalleComprobante
                .FirstOrDefaultAsync(x => x.idDetalleComprobante == id);
            return detalleComprobante;
        }



    }
}
