using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Ej3_GA.Models
{
    public partial class T28_Ej3_GAContext : DbContext
    {
        public T28_Ej3_GAContext(DbContextOptions<T28_Ej3_GAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cajeros> Cajeros { get; set; }
        public virtual DbSet<MaquinasRegistradoras> MaquinasRegistradoras { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }
        public virtual DbSet<Venta> Venta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=192.168.0.38; Database=T28_Ej3_GA; User ID=sa; Password=viiksen_15");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cajeros>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("PK__Cajeros__06370DAD5FCE099C");

                entity.Property(e => e.NomApels)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MaquinasRegistradoras>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("PK__Maquinas__06370DAD1EF9EBAF");

                entity.ToTable("Maquinas_Registradoras");
            });

            modelBuilder.Entity<Productos>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("PK__Producto__06370DAD3A3DDB47");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserInfo__1788CCAC22120940");

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

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.HasKey(e => new { e.Cajero, e.Maquina, e.Producto })
                    .HasName("PK");

                entity.HasOne(d => d.CajeroNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.Cajero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Venta__Cajero__3C69FB99");

                entity.HasOne(d => d.MaquinaNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.Maquina)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Venta__Maquina__3D5E1FD2");

                entity.HasOne(d => d.ProductoNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.Producto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Venta__Producto__3E52440B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
