using api_bodega.Entitys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace api_bodega.Controllers
{
    [ApiController]
    [Route("api-bodega/comprobante")]
    public class ComprobanteController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public ComprobanteController(ApplicationDbContext context)

        {
            this.context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<Comprobante>>> findAll()
        {
            return await context.Comprobante.Include(x=>x.cliente).Include(x => x.usuario).ToListAsync();
        }
        //cuando queremos obtener solo los habilitados
        [HttpGet("custom")]
        public async Task<ActionResult<List<Comprobante>>> findAllCustom()
        {
            return await context.Comprobante.Where(x => x.EstadoComprobante == true).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> add(Comprobante co)
        {
            //Verificando la existencia del cliente y usuario
            var clienteexiste = await context.Cliente.AnyAsync(x=> x.idCliente==co.idCliente);
            var usuarioexiste = await context.Usuario.AnyAsync(x => x.idUsuario == co.idUsuario);

            if (!clienteexiste )
            {
                return BadRequest($"No existe el cliente con codigo: {co.idCliente}");
            }
            if (!usuarioexiste)
            {
                return BadRequest($"No existe el usuario con codigo: {co.idUsuario}");
            }
            context.Add(co);
            await context.SaveChangesAsync();
            return Ok();
        }
        //cuando queremos buscar por ID
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Comprobante>> findById(int id)
        {
            var detalleComprobante = await context.Comprobante
                .FirstOrDefaultAsync(x => x.idComprobante == id);
            return detalleComprobante;
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> delete(int id)
        {

            var existe = await context.Comprobante.AnyAsync(x => x.idComprobante == id);
            if (!existe)
            {
                return NotFound();
            }
            var comprobante = await context.Comprobante.FirstOrDefaultAsync(x => x.idComprobante == id);
            comprobante.EstadoComprobante = false;
            context.Update(comprobante);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
