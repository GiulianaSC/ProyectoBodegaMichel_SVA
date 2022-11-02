using api_bodega.Entitys;
using Microsoft.EntityFrameworkCore;
namespace api_bodega
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<DetalleComprobante> DetalleComprobante { get; set; }
        public DbSet<Comprobante> Comprobante { get; set; }
    }
}
