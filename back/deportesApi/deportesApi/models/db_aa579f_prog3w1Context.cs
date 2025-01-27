﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace deportesApi.models
{
    public partial class db_aa579f_prog3w1Context : DbContext
    {
        public db_aa579f_prog3w1Context()
        {
        }

        public db_aa579f_prog3w1Context(DbContextOptions<db_aa579f_prog3w1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Deporte> Deportes { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Socio> Socios { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name= connectionstrings:dbParcial");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Deporte>(entity =>
            {
                entity.ToTable("deportes");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("roles");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Socio>(entity =>
            {
                entity.ToTable("socios");

                entity.HasIndex(e => e.IdDeporte, "IX_socios_IdDeporte");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Apellido).HasMaxLength(100);

                entity.Property(e => e.Nombre).HasMaxLength(100);

                entity.HasOne(d => d.IdDeporteNavigation)
                    .WithMany(p => p.Socios)
                    .HasForeignKey(d => d.IdDeporte);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuarios");

                entity.HasIndex(e => e.IdRol, "IX_usuarios_IdRol");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Apellido).HasMaxLength(100);

                entity.Property(e => e.Nombre).HasMaxLength(100);

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
