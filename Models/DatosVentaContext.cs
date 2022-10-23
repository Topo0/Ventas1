using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiWebClub.Models
{
    public partial class DatosVentaContext : DbContext
    {
        public DatosVentaContext()
        {
        }

        public DatosVentaContext(DbContextOptions<DatosVentaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Concepto> Concepto { get; set; }
        public virtual DbSet<Direccion> Direccion { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Venta> Venta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=JP;Database=DatosVenta;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente);

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdDireccion).HasColumnName("idDireccion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDireccionNavigation)
                    .WithMany(p => p.Cliente)
                    .HasForeignKey(d => d.IdDireccion)
                    .HasConstraintName("FK_Cliente_Direccion");
            });

            modelBuilder.Entity<Concepto>(entity =>
            {
                entity.HasKey(e => e.IdConcepto);

                entity.Property(e => e.IdConcepto).HasColumnName("idConcepto");

                entity.Property(e => e.IdProducto).HasColumnName("idProducto");

                entity.Property(e => e.IdVenta).HasColumnName("idVenta");

                entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(16, 0)");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.Concepto)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Concepto_Producto");

                entity.HasOne(d => d.IdVentaNavigation)
                    .WithMany(p => p.Concepto)
                    .HasForeignKey(d => d.IdVenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Concepto_Venta");
            });

            modelBuilder.Entity<Direccion>(entity =>
            {
                entity.HasKey(e => e.IdDireccion);

                entity.Property(e => e.IdDireccion).HasColumnName("idDireccion");

                entity.Property(e => e.Calle)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Colonia)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroTelefonico)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Referencias)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto);

                entity.Property(e => e.IdProducto).HasColumnName("idProducto");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Imagen)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnType("decimal(16, 0)");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.Contraseña)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoElectronico)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.HasKey(e => e.IdVenta);

                entity.Property(e => e.IdVenta).HasColumnName("idVenta");

                entity.Property(e => e.Fehca).HasColumnType("datetime");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.Total).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK_Venta_Cliente");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
