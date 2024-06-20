﻿namespace Catalogo.Models;

public partial class Producto
{
    public int ProductoId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public decimal Precio { get; set; }

    public int CategoriaId { get; set; }

    public int ImagenId { get; set; }

    public int Stars { get; set; }

    public virtual Categoria Categoria { get; set; } = null!;

    public virtual Imagene Imagen { get; set; } = null!;

    public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();
}
