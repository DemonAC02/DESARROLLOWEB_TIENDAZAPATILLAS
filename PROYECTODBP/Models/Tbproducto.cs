using System;
using System.Collections.Generic;

namespace PROYECTODBP.Models;

public partial class Tbproducto
{
    ZapatillasC conexion = new ZapatillasC();   
    public int IdProducto { get; set; }

    public string? Nombre { get; set; }

    public int? IdMarca { get; set; }

    public int? IdCategoria { get; set; }

    public decimal? Precio { get; set; }

    public int? Stock { get; set; }

    public string? RutaImagen { get; set; }

    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();

    public virtual Categorias? IdCategoriaNavigation { get; set; }

    public virtual Marca? IdMarcaNavigation { get; set; }
    public string getNombreMarca()
    {
        string marca = (from tbPro in conexion.Marcas
                           where tbPro.IdMarca == IdMarca
                           select tbPro.Descripcion).Single();
        return marca;
    }

}
