using System;
using System.Collections.Generic;

namespace PROYECTODBP.Models;

public partial class Marca
{
    public int IdMarca { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Tbproducto> Tbproductos { get; set; } = new List<Tbproducto>();
}
