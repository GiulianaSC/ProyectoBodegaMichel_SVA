using api_bodega.Entitys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace api_bodega.Controllers
{
    [ApiController]
    [Route("api-bodega/cliente")]
    public class ClienteController : ControllerBase
    {

        private readonly ApplicationDbContext context;
        public ClienteController(ApplicationDbContext context)
        {
            this.context = context;
        }
        //cuando queremos obtener informacion
        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> findAll()
        {
            return await context.Cliente.ToListAsync();
        }
        //cuando queremos obtener solo los habilitados
        [HttpGet("custom")]
        public async Task<ActionResult<List<Cliente>>> findAllCustom()
        {
            return await context.Cliente.Where(x => x.EstadoCliente == true).ToListAsync();
        }


        //cuando queremos guardar informacion
        [HttpPost]
        public async Task<ActionResult> add(Cliente c)
        {
            context.Add(c);
            await context.SaveChangesAsync();
            return Ok();
        }
        //cuando queremos buscar informacion
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Cliente>> findById(int id)
        {
            var cliente = await context.Cliente
                .FirstOrDefaultAsync(x => x.idCliente == id);
            return cliente;

        }
        //cuando queremos actualizar informacion
        [HttpPut("{id:int}")]
        public async Task<ActionResult> update(Cliente c, int id)
        {
            if (c.idCliente != id)
            {
                return BadRequest("No se encuentro el codigo correspondiente");
            }

            context.Update(c);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> delete(int id)
        {

            var existe = await context.Cliente.AnyAsync(x => x.idCliente == id);
            if (!existe)
            {
                return NotFound();
            }
            var cliente= await context.Cliente.FirstOrDefaultAsync(x => x.idCliente == id);
            cliente.EstadoCliente = false;
            context.Update(cliente);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
