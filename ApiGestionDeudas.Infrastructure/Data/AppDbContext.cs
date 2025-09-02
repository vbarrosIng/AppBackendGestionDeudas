using ApiGestionDeudas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGestionDeudas.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.ToTable("usuarios");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                      .HasColumnName("id");

                entity.Property(e => e.Email)
                      .HasColumnName("email");

                entity.Property(e => e.PassdHash)
                      .HasColumnName("pass_hash");

                entity.Property(e => e.FechaCreacion)
                      .HasColumnName("fecha_creacion")
                      .HasColumnType("timestamp with time zone")
                      .HasDefaultValueSql("NOW()");

            });

            modelBuilder.Entity<Deudas>(entity =>
            {
                entity.ToTable("deudas");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .IsRequired();

                entity.Property(e => e.UsuarioId)
                    .HasColumnName("usuario_id")
                    .IsRequired();

                entity.Property(e => e.Total)
                    .HasColumnName("total")
                    .HasColumnType("numeric(12,2)")
                    .IsRequired();

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasDefaultValue(1)
                    .IsRequired();

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("fecha_creacion")
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("NOW()")
                    .IsRequired();

                entity.Property(e => e.FechaPago)
                    .HasColumnName("fecha_pago")
                    .HasColumnType("timestamp with time zone")
                    .IsRequired(false);
            });
        }

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Deudas> Deudas { get; set; }
    }
}
