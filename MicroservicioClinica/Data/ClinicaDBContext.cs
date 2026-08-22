using Microsoft.EntityFrameworkCore;
using MicroservicioClinica.Models;

namespace MicroservicioClinica.Data
{
    public class ClinicaDBContext : DbContext
    {
        public ClinicaDBContext(
            DbContextOptions<ClinicaDBContext> options)
            : base(options)
        {
        }

        public DbSet<Paciente> Pacientes { get; set; }

        public DbSet<Medico> Medicos { get; set; }

        public DbSet<Cita> Citas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Paciente>()
                .ToTable("Pacientes");

            modelBuilder.Entity<Medico>()
                .ToTable("Medicos");

            modelBuilder.Entity<Cita>()
                .ToTable("Citas");

            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Paciente)
                .WithMany(p => p.Citas)
                .HasForeignKey(c => c.PacienteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Medico)
                .WithMany(m => m.Citas)
                .HasForeignKey(c => c.MedicoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}