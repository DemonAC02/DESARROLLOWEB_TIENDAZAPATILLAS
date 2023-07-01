namespace PROYECTODBP.Models
{
    public class ResumenVenta
    {
        public IEnumerable<PROYECTODBP.Models.TemporalCarrito> Carrito { get; set; }
        public double Total { get; set; }
    }
}
