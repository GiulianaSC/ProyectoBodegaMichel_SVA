using api_producto.entitys;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_producto
{
    public class ApplicationDbcontext : DbContext
    {
        public ApplicationDbcontext( DbContextOptions options) : base(options)
        {
        }

        //configurando la tabla de base de datos
        public DbSet<producto> producto { get; set; }
    }
}
