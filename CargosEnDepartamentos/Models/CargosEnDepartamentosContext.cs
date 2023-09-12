using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CargosEnDepartamentos.Models;

public partial class CargosEnDepartamentosContext : DbContext
{
    public CargosEnDepartamentosContext()
    {
    }

    public CargosEnDepartamentosContext(DbContextOptions<CargosEnDepartamentosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=localhost; database=CargosEnDepartamentos; integrated security=true; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.IdCargo).HasName("PK__Cargo__4054BE5125DA3A3C");

            entity.ToTable("Cargo");

            entity.Property(e => e.IdCargo).HasColumnName("Id_Cargo");
            entity.Property(e => e.IdDepartamento).HasColumnName("Id_Departamento");
            entity.Property(e => e.NombreCargo)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Nombre_Cargo");

            entity.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.Cargos)
                .HasForeignKey(d => d.IdDepartamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cargo__Id_Depart__398D8EEE");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.IdDepartamento).HasName("PK__Departam__D9F8A911E4024C33");

            entity.ToTable("Departamento");

            entity.Property(e => e.IdDepartamento).HasColumnName("Id_Departamento");
            entity.Property(e => e.NombreDepartamento)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.IdPersona).HasName("PK__Persona__C95634AFCB1B797D");

            entity.ToTable("Persona");

            entity.Property(e => e.IdPersona).HasColumnName("Id_Persona");
            entity.Property(e => e.ApellidoPersona)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Apellido_Persona");
            entity.Property(e => e.IdCargo).HasColumnName("Id_Cargo");
            entity.Property(e => e.NombrePersona)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Nombre_Persona");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Nombre_Usuario");

            entity.HasOne(d => d.IdCargoNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdCargo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Persona__Id_Carg__3C69FB99");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
