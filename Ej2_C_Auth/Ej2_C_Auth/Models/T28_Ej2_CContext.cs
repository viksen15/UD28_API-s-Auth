using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Ej2_C_Auth.Models
{
    public partial class T28_Ej2_CContext : DbContext
    {

        public T28_Ej2_CContext(DbContextOptions<T28_Ej2_CContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AsignadoA> AsignadoA { get; set; }
        public virtual DbSet<Cientificos> Cientificos { get; set; }
        public virtual DbSet<Proyecto> Proyecto { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=192.168.0.38; Database=T28_Ej2_C; User ID=sa; Password=viiksen_15");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AsignadoA>(entity =>
            {
                entity.HasKey(e => new { e.Cientifico, e.Proyecto })
                    .HasName("PK");

                entity.ToTable("Asignado_A");

                entity.Property(e => e.Cientifico)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Proyecto)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.CientificoNavigation)
                    .WithMany(p => p.AsignadoA)
                    .HasForeignKey(d => d.Cientifico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Asignado___Cient__3A81B327");

                entity.HasOne(d => d.ProyectoNavigation)
                    .WithMany(p => p.AsignadoA)
                    .HasForeignKey(d => d.Proyecto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Asignado___Proye__3B75D760");
            });

            modelBuilder.Entity<Cientificos>(entity =>
            {
                entity.HasKey(e => e.Dni)
                    .HasName("PK__Cientifi__C035B8DCF5DC0B87");

                entity.Property(e => e.Dni)
                    .HasColumnName("DNI")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.NomApels)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Proyecto>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserInfo__1788CCACD354124E");

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
