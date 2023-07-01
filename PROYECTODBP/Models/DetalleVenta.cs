using PROYECTODBP.Servicio;
using System;
using System.Collections.Generic;

namespace PROYECTODBP.Models;

public partial class DetalleVenta
{
    ZapatillasC conexion = new ZapatillasC();
    public int IdVentaDetalle { get; set; }

    public int? IdVenta { get; set; }

    public int? IdProducto { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Total { get; set; }

    public virtual Tbproducto? IdProductoNavigation { get; set; }

    public virtual Venta? IdVentaNavigation { get; set; }
    public string getNombreProd()
    {
        string marca = (from tbPro in conexion.Tbproductos
                        where tbPro.IdProducto == IdProducto
                        select tbPro.Nombre).Single();
        return marca;
    }
}
