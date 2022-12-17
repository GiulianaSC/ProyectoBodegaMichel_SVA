using api_bodega.Entitys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace api_bodega.Controllers
{
    [ApiController]
    [Route("api-bodega/producto")]

    public class ProductoController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public ProductoController(ApplicationDbContext context)
        {
            this.context = context;
        }

        //cuando queremos obtener informacion
        [HttpGet]
        public async Task<ActionResult<List<Producto>>> findAll()
        {
            return await context.Producto.Include(x => x.categoria).ToListAsync();
        }

        //cuando queremos obtener solo los habilitados
        [HttpGet("custom")]
        public async Task<ActionResult<List<Producto>>> findAllCustom()
        {
            return await context.Producto.Where(x => x.EstadoProducto == true).ToListAsync();
        }


        //cuando queremos guardar informacion
        [HttpPost]
        public async Task<ActionResult> add(Producto p)
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
        public async Task<ActionResult<Producto>> findById(int id)
        {
            var producto = await context.Producto
                .FirstOrDefaultAsync(x => x.idProducto == id);
            return producto;

        }
        //cuando queremos actualizar informacion
        [HttpPut("{id:int}")]
        public async Task<ActionResult> update(Producto p, int id)
        {
            if (p.idProducto != id)
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

            var existe = await context.Producto.AnyAsync(x => x.idProducto == id);
            if (!existe)
            {
                return NotFound();
            }
            var producto = await context.Producto.FirstOrDefaultAsync(x => x.idProducto == id);
           producto.EstadoProducto= false;
            context.Update(producto);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
