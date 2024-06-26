﻿using System.Text.Json.Serialization;

namespace Catalogo.Models.Entities;

public partial class Imagene
{
    public int ImagenId { get; set; }

    public string Imagen { get; set; } = null!;

    public string NameImagen { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
