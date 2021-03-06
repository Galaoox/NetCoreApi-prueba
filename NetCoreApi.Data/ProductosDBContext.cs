using Microsoft.EntityFrameworkCore;
using NetCoreApi.Data.Models;

#nullable disable

namespace NetCoreApi.Data
{
    public partial class ProductosDBContext : DbContext
    {
        public ProductosDBContext()
        {
        }

        public ProductosDBContext(DbContextOptions<ProductosDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Venta> Ventas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("cliente");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("apellido");

                entity.Property(e => e.Cedula).HasColumnName("cedula");

                entity.Property(e => e.Disabled).HasColumnName("disabled");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("producto");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Disabled).HasColumnName("disabled");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nombre");

                entity.Property(e => e.ValorUnitario)
                    .HasColumnType("decimal(16, 2)")
                    .HasColumnName("valor_unitario");
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.ToTable("venta");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Disabled).HasColumnName("disabled");

                entity.Property(e => e.IdProducto).HasColumnName("id_producto");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.ValorTotal)
                    .HasColumnType("decimal(16, 2)")
                    .HasColumnName("valor_total");

                entity.Property(e => e.ValorUnitario)
                    .HasColumnType("decimal(16, 2)")
                    .HasColumnName("valor_unitario");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_venta_producto");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_venta_cliente");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
