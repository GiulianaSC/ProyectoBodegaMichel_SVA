using api_bodega.Entitys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace api_bodega.Controllers
{
    [ApiController]
    [Route("api-bodega/proveedor")]
    public class ProveedorController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public ProveedorController(ApplicationDbContext context)
        {
            this.context = context;
        }

        //cuando queremos obtener informacion
        [HttpGet]
        public async Task<ActionResult<List<Proveedor>>> findAll()
        {
            return await context.Proveedor.Include(x => x.categoria).ToListAsync();
        }

        //cuando queremos obtener solo los habilitados
        [HttpGet("custom")]
        public async Task<ActionResult<List<Proveedor>>> findAllCustom()
        {
            return await context.Proveedor.Where(x => x.estadoProveedor == true).ToListAsync();
        }


        //cuando queremos guardar informacion
        [HttpPost]
        public async Task<ActionResult> add(Proveedor p)
        {
            //Verificando la existencia del cliente y usuario
            var categoriaexiste = await context.Categoria.AnyAsync(x => x.idCategoria == p.idCategoria);

            if (!categoriaexiste)
            {
                return BadRequest($"No existe la categoria con codigo: {p.idCategoria}");
            }

            context.Add(p);
            await context.SaveChangesAsync();
            return Ok();
        }
        //cuando queremos buscar informacion
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Proveedor>> findById(int id)
        {
            var proveedor = await context.Proveedor
                .FirstOrDefaultAsync(x => x.idProveedor == id);
            return proveedor;

        }
        //cuando queremos actualizar informacion
        [HttpPut("{id:int}")]
        public async Task<ActionResult> update(Proveedor p, int id)
        {
            if (p.idProveedor != id)
            {
                return BadRequest("No se encuentro el codigo correspondiente");
            }

            context.Update(p);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> delete(int id)
        {
            var existe = await context.Proveedor.AnyAsync(x => x.idProveedor == id);
            if (!existe)
            {
                return NotFound();
            }
            var proveedor = await context.Proveedor.FirstOrDefaultAsync(x => x.idProveedor == id);
            proveedor.estadoProveedor = false;
            context.Update(proveedor);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
