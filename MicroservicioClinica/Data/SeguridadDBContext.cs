using Microsoft.EntityFrameworkCore;
using MicroservicioClinica.Models;

namespace MicroservicioClinica.Data
{
    public class SeguridadDBContext : DbContext
    {
        public SeguridadDBContext(
            DbContextOptions<SeguridadDBContext> options)
            : base(options)
        {
        }

        public DbSet<Rol> Roles { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Permiso> Permisos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Rol>()
                .ToTable("Roles");

            modelBuilder.Entity<Usuario>()
                .ToTable("Usuarios");

            modelBuilder.Entity<Permiso>()
                .ToTable("Permisos");

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Rol)
                .WithMany(r => r.Usuarios)
                .HasForeignKey(u => u.RolId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}