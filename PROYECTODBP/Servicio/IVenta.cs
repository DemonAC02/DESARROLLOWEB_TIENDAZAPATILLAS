using PROYECTODBP.Models;

namespace PROYECTODBP.Servicio
{
    public interface IVenta
    {
        Venta ObtenerVentaPorId(int ventaId);
        void GuardarVenta(Venta venta);
        void GuardarDetalleVenta(DetalleVenta detalleVenta);
        IEnumerable<Venta> BuscarVentasPorUsuario(int id);
    }
}
