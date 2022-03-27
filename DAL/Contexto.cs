using Microsoft.EntityFrameworkCore;
using ExamenBlazor.Entidades;

namespace ExamenBlazor.DAL
{
    public class Contexto : DbContext
    {

        public DbSet<Producto> Producto { get; set; }
        public DbSet<ProductoEmpacado> ProductoEmpacado { get; set; }

        public Contexto(DbContextOptions<Contexto> options) : base(options) { }
    }
}

