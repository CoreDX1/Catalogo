using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Models;

public partial class AlmacenDbContext : DbContext
{
    public AlmacenDbContext() { }

    public AlmacenDbContext(DbContextOptions<AlmacenDbContext> options)
        : base(options) { }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Imagene> Imagenes { get; set; }

    public virtual DbSet<Inventario> Inventarios { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        =>
        optionsBuilder.UseSqlServer(
            "Server=172.29.25.99;Database=AlmacenDB;Trusted_Connection=false;User ID=sa;Password=index#123;Encrypt=False"
        );

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.CategoriaId).HasName("PK__Categori__F353C1C5ED0AC91D");

            entity.Property(e => e.CategoriaId).HasColumnName("CategoriaID");
            entity.Property(e => e.Nombre).HasMaxLength(255);
        });

        modelBuilder.Entity<Imagene>(entity =>
        {
            entity.HasKey(e => e.ImagenId).HasName("PK__Imagenes__0C7D20D776C3FABF");

            entity.Property(e => e.ImagenId).HasColumnName("ImagenID");
            entity.Property(e => e.Imagen).HasMaxLength(2083).IsUnicode(false);
            entity.Property(e => e.NameImagen).HasMaxLength(255).IsUnicode(false);
        });

        modelBuilder.Entity<Inventario>(entity =>
        {
            entity.HasKey(e => e.InventarioId).HasName("PK__Inventar__FB8A24B7A97902AD");

            entity.ToTable("Inventario");

            entity.Property(e => e.InventarioId).HasColumnName("InventarioID");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

            entity
                .HasOne(d => d.Producto)
                .WithMany(p => p.Inventarios)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inventari__Produ__5441852A");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.ProductoId).HasName("PK__Producto__A430AE83A45F40AE");

            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
            entity.Property(e => e.CategoriaId).HasColumnName("CategoriaID");
            entity.Property(e => e.ImagenId).HasColumnName("ImagenID");
            entity.Property(e => e.Nombre).HasMaxLength(255);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

            entity
                .HasOne(d => d.Categoria)
                .WithMany(p => p.Productos)
                .HasForeignKey(d => d.CategoriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Productos__Categ__4F7CD00D");

            entity
                .HasOne(d => d.Imagen)
                .WithMany(p => p.Productos)
                .HasForeignKey(d => d.ImagenId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Productos__Image__5070F446");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
