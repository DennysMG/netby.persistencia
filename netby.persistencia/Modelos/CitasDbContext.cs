using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace netby.persistencia.Modelos;

public partial class CitasDbContext : DbContext
{
    public CitasDbContext()
    {
    }

    public CitasDbContext(DbContextOptions<CitasDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Citum> Cita { get; set; }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Citum>(entity =>
        {
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.FechaRegistro).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.SecuencialVehiculoNavigation).WithMany(p => p.Cita)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cita_Vehiculo");
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.FechaRegistro).HasDefaultValueSql("(getdate())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
