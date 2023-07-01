using System;
using System.Collections.Generic;

namespace PROYECTODBP.Models;

public partial class Venta
{
    public int IdVenta { get; set; }

    public int? IdCliente { get; set; }

    public string? Direccion { get; set; }

    public decimal? MontoTotal { get; set; }

    public string? Telefono { get; set; }

    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();

    public virtual Cliente? IdClienteNavigation { get; set; }
}
