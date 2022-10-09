using anular_venta.Entitys;
using Microsoft.EntityFrameworkCore;

namespace anular_venta
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Aventas> Aventas { get; set; }
    }
}
