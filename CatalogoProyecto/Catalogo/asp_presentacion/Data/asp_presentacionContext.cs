using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using lib_entidades.Modelos;

namespace asp_presentacion.Data
{
    public class asp_presentacionContext : DbContext
    {
        public asp_presentacionContext (DbContextOptions<asp_presentacionContext> options)
            : base(options)
        {
        }

        public DbSet<lib_entidades.Modelos.Publicaciones> Publicaciones { get; set; } = default!;
    }
}
