using Microsoft.EntityFrameworkCore;
using PROYECTODBP.Models;

namespace PROYECTODBP.Servicio
{
    public class VentaRepository:IVenta
    {
     
        ZapatillasC _context = new ZapatillasC();   
        public Venta ObtenerVentaPorId(int ventaId)
        {
            return _context.Venta.FirstOrDefault(v => v.IdVenta == ventaId);
        }

        public void GuardarVenta(Venta venta)
        {
            _context.Venta.Add(venta);
            _context.SaveChanges();
        }

        public void GuardarDetalleVenta(DetalleVenta detalleVenta)
        {
            _context.DetalleVentas.Add(detalleVenta);
            _context.SaveChanges();
        }

        public IEnumerable<Venta> BuscarVentasPorUsuario(int id)
        {
            var obj = (from vent in _context.Venta where vent.IdCliente == id select vent);
            return obj;
        }
    }
}
