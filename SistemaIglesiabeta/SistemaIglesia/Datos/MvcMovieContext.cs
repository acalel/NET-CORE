using Microsoft.EntityFrameworkCore;
using SistemaIglesia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaIglesia.Datos
{
    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext(DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }

        public DbSet<pruebaentity> Movie { get; set; }
    }
}
