using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Ej4_I.Models
{
    public partial class T28_Ej4_IContext : DbContext
    {
        public T28_Ej4_IContext(DbContextOptions<T28_Ej4_IContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Equipos> Equipos { get; set; }
        public virtual DbSet<Facultad> Facultad { get; set; }
        public virtual DbSet<Investigadores> Investigadores { get; set; }
        public virtual DbSet<Reserva> Reserva { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=192.168.0.38; Database=T28_Ej4_I; User ID=sa; Password=viiksen_15");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipos>(entity =>
            {
                entity.HasKey(e => e.NumSerie)
                    .HasName("PK__Equipos__63AD426314C98FCE");

                entity.Property(e => e.NumSerie)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.FacultadNavigation)
                    .WithMany(p => p.Equipos)
                    .HasForeignKey(d => d.Facultad)
                    .HasConstraintName("FK__Equipos__Faculta__3B75D760");
            });

            modelBuilder.Entity<Facultad>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("PK__Facultad__06370DADDE5253DF");

                entity.Property(e => e.Codigo).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Investigadores>(entity =>
            {
                entity.HasKey(e => e.Dni)
                    .HasName("PK__Investig__C035B8DCDE0EDE49");

                entity.Property(e => e.Dni)
                    .HasColumnName("DNI")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.NomApels)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.FacultadNavigation)
                    .WithMany(p => p.Investigadores)
                    .HasForeignKey(d => d.Facultad)
                    .HasConstraintName("FK__Investiga__Facul__38996AB5");
            });

            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.HasKey(e => new { e.Dni, e.NumSerie })
                    .HasName("PK");

                entity.Property(e => e.Dni)
                    .HasColumnName("DNI")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.NumSerie)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Comienzo).HasColumnType("datetime");

                entity.Property(e => e.Fin).HasColumnType("datetime");

                entity.HasOne(d => d.DniNavigation)
                    .WithMany(p => p.Reserva)
                    .HasForeignKey(d => d.Dni)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Reserva__DNI__3E52440B");

                entity.HasOne(d => d.NumSerieNavigation)
                    .WithMany(p => p.Reserva)
                    .HasForeignKey(d => d.NumSerie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Reserva__NumSeri__3F466844");
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserInfo__1788CCACC6E51C96");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
