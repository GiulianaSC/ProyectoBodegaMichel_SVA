using api_usuario.entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_usuario
{
    public class ApplicationDbcontext : DbContext
    {
        public ApplicationDbcontext( DbContextOptions options) : base(options)
        {
        }

        //configurando la tabla de base de datos
        public DbSet<usuario> usuario { get; set; }
    }
}
