using api_bodega.Entitys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace api_bodega.Controllers
{
    [ApiController]
    [Route("api-bodega/categoria")]
    public class CategoriaController : ControllerBase
    {

        private readonly ApplicationDbContext context;
        public CategoriaController(ApplicationDbContext context)
        {
            this.context = context;
        }
        //cuando queremos obtener informacion
        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> findAll()
        {
            return await context.Categoria.ToListAsync();
        }
        //cuando queremos obtener solo los habilitados
        [HttpGet("custom")]
        public async Task<ActionResult<List<Categoria>>> findAllCustom()
        {
            return await context.Categoria.Where(x => x.estadoCategoria == true).ToListAsync();
        }


        //cuando queremos guardar informacion
        [HttpPost]
        public async Task<ActionResult> add(Categoria c)
        {
            context.Add(c);
            await context.SaveChangesAsync();
            return Ok();
        }
        //cuando queremos buscar informacion
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Categoria>> findById(int id)
        {
            var categoria = await context.Categoria
                .FirstOrDefaultAsync(x => x.idCategoria == id);
            return categoria;

        }
        //cuando queremos actualizar informacion
        [HttpPut("{id:int}")]
        public async Task<ActionResult> update(Categoria c, int id)
        {
            if (c.idCategoria != id)
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

            var existe = await context.Categoria.AnyAsync(x => x.idCategoria == id);
            if (!existe)
            {
                return NotFound();
            }
            var categoria= await context.Categoria.FirstOrDefaultAsync(x => x.idCategoria == id);
            categoria.estadoCategoria = false;
            context.Update(categoria);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
