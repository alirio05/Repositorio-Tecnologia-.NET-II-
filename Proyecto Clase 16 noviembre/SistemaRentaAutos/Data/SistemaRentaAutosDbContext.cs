using Microsoft.EntityFrameworkCore;
using SistemaRentaAutos.Models;

namespace SistemaRentaAutos.Data;

public class SistemaRentaAutosDbContext(DbContextOptions<SistemaRentaAutosDbContext> options) : DbContext(options)
{
    public DbSet<Cliente> Clientes => Set<Cliente>();
    public DbSet<Auto> Autos => Set<Auto>();
    public DbSet<Empleado> Empleados => Set<Empleado>();
    public DbSet<Renta> Rentas => Set<Renta>();
    public DbSet<Pago> Pagos => Set<Pago>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.ToTable("Clientes");
            entity.HasKey(x => x.ClienteID);
            entity.Property(x => x.ClienteID).ValueGeneratedNever();
            entity.Property(x => x.Nombre).HasColumnType("varchar(100)");
            entity.Property(x => x.Apellido).HasColumnType("varchar(100)");
            entity.Property(x => x.DUI).HasColumnType("varchar(15)");
            entity.Property(x => x.Telefono).HasColumnType("varchar(20)");
            entity.Property(x => x.Correo).HasColumnType("varchar(100)");
            entity.Property(x => x.Direccion).HasColumnType("varchar(200)");
            entity.Property(x => x.FechaRegistro).HasColumnType("date");
        });

        modelBuilder.Entity<Auto>(entity =>
        {
            entity.ToTable("Autos");
            entity.HasKey(x => x.AutoID);
            entity.Property(x => x.AutoID).ValueGeneratedNever();
            entity.Property(x => x.Marca).HasColumnType("varchar(50)");
            entity.Property(x => x.Modelo).HasColumnType("varchar(50)");
            entity.Property(x => x.Placa).HasColumnType("varchar(15)");
            entity.Property(x => x.Color).HasColumnType("varchar(30)");
            entity.Property(x => x.TipoCombustible).HasColumnType("varchar(30)");
            entity.Property(x => x.PrecioPorDia).HasColumnType("decimal(10,2)");
            entity.Property(x => x.Estado).HasColumnType("varchar(30)");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.ToTable("Empleados");
            entity.HasKey(x => x.EmpleadoID);
            entity.Property(x => x.EmpleadoID).ValueGeneratedNever();
            entity.Property(x => x.Nombre).HasColumnType("varchar(100)");
            entity.Property(x => x.Apellido).HasColumnType("varchar(100)");
            entity.Property(x => x.Cargo).HasColumnType("varchar(50)");
            entity.Property(x => x.Telefono).HasColumnType("varchar(20)");
            entity.Property(x => x.Correo).HasColumnType("varchar(100)");
            entity.Property(x => x.FechaContratacion).HasColumnType("date");
            entity.Property(x => x.Salario).HasColumnType("decimal(10,2)");
        });

        modelBuilder.Entity<Renta>(entity =>
        {
            entity.ToTable("Rentas");
            entity.HasKey(x => x.RentaID);
            entity.Property(x => x.RentaID).ValueGeneratedNever();
            entity.Property(x => x.FechaInicio).HasColumnType("date");
            entity.Property(x => x.FechaFin).HasColumnType("date");
            entity.Property(x => x.TotalRenta).HasColumnType("decimal(10,2)");
            entity.Property(x => x.Estado).HasColumnType("varchar(30)");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.ToTable("Pagos");
            entity.HasKey(x => x.PagoID);
            entity.Property(x => x.PagoID).ValueGeneratedNever();
            entity.Property(x => x.FechaPago).HasColumnType("date");
            entity.Property(x => x.MetodoPago).HasColumnType("varchar(50)");
            entity.Property(x => x.Monto).HasColumnType("decimal(10,2)");
            entity.Property(x => x.EstadoPago).HasColumnType("varchar(30)");
            entity.Property(x => x.Referencia).HasColumnType("varchar(50)");
        });
    }
}
