using api_bodega.Entitys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace api_bodega.Controllers
{
    [ApiController]
    [Route("api-bodega/distrito")]
    public class DistritoController : ControllerBase
    {

        private readonly ApplicationDbContext context;
        public DistritoController(ApplicationDbContext context)
        {
            this.context = context;
        }
        //cuando queremos obtener informacion
        [HttpGet]
        public async Task<ActionResult<List<Distrito>>> findAll()
        {
            return await context.Distrito.ToListAsync();
        }
        //cuando queremos obtener solo los habilitados
        [HttpGet("custom")]
        public async Task<ActionResult<List<Distrito>>> findAllCustom()
        {
            return await context.Distrito.Where(x => x.estadoDistrito == true).ToListAsync();
        }


        //cuando queremos guardar informacion
        [HttpPost]
        public async Task<ActionResult> add(Distrito d)
        {
            context.Add(d);
            await context.SaveChangesAsync();
            return Ok();
        }
        //cuando queremos buscar informacion
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Distrito>> findById(int id)
        {
            var distrito = await context.Distrito
                .FirstOrDefaultAsync(x => x.idDistrito == id);
            return distrito;

        }
        //cuando queremos actualizar informacion
        [HttpPut("{id:int}")]
        public async Task<ActionResult> update(Distrito d, int id)
        {
            if (d.idDistrito != id)
            {
                return BadRequest("No se encuentro el codigo correspondiente");
            }

            context.Update(d);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> delete(int id)
        {

            var existe = await context.Distrito.AnyAsync(x => x.idDistrito == id);
            if (!existe)
            {
                return NotFound();
            }
            var distrito= await context.Distrito.FirstOrDefaultAsync(x => x.idDistrito == id);
            distrito.estadoDistrito = false;
            context.Update(distrito);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
