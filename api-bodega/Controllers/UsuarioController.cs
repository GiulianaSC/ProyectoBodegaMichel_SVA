using api_bodega.Entitys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace api_bodega.Controllers
{
    [ApiController]
    [Route("api-bodega/usuario")]

    public class UsuarioController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public UsuarioController(ApplicationDbContext context)
        {
            this.context = context;
        }

        //cuando queremos tener informacion
        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> findAll()
        {
            return await context.Usuario.ToListAsync();

        }

        //cuando queremos obtener solo los habilitados
        [HttpGet("custom")]
        public async Task<ActionResult<List<Usuario>>> findAllCustom()
        {
            return await context.Usuario.Where(x => x.EstadoUsuario == true).ToListAsync();

        }

        //cuando queremos guardar informacion
        [HttpPost]
        public async Task<ActionResult> add(Usuario u)
        {
            context.Add(u);
            await context.SaveChangesAsync();
            return Ok();
        }

        //cuando queremos buscar informacion
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Usuario>> findById(int id)
        {
            var usuario = await context.Usuario.FirstOrDefaultAsync(x => x.idUsuario == id);
            return usuario;

        }

        //cuando queremos actualizar informacion
        [HttpPut("{id:int}")]
        public async Task<ActionResult> update(Usuario u, int id)
        {
            if (u.idUsuario != id)
            {
                return BadRequest("No se encontro el codigo correspondiente");
            }
            context.Update(u);
            await context.SaveChangesAsync();
            return Ok();
        }

        //cuando queremos eliminar informacion
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> delete(int id)
        {

            var existe = await context.Usuario.AnyAsync(x => x.idUsuario == id);
            if (!existe)
            {
                return NotFound();
            }
            var usuario = await context.Usuario.FirstOrDefaultAsync(x => x.idUsuario == id);
            usuario.EstadoUsuario = false;
            context.Update(usuario);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
