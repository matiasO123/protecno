using Microsoft.EntityFrameworkCore;
using Protecno.Models;
namespace Protecno.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Rols { get; set; }
        public DbSet<Persona> personas { get; set; }
        public DbSet<Cliente> clientes { get; set; }
        public DbSet<Empleado> empleados { get; set; }
        public DbSet<Proveedor> proveedors { get; set; }
        public DbSet<Producto> productos { get; set; }
        public DbSet<Reparacion> reparacions { get; set; }
        public DbSet<Evento> eventos { get; set; }
        public DbSet<Pago> pago { get; set; }
        public DbSet<Factura> factura { get; set; }
        public DbSet<Repuesto> repuestos { get; set; }
        public DbSet<ReparacionRepuesto> reparacionRepuestos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=miBaseDeDatos.db");
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }
    }
}

