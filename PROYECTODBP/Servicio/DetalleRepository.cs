using PROYECTODBP.Models;

namespace PROYECTODBP.Servicio
{
    public class DetalleRepository : IDetalle
    {
        ZapatillasC conexion = new ZapatillasC();

        public IEnumerable<DetalleVenta> DetallasDeLaVenta(int id)
        {
            var lst =(from tdet in conexion.DetalleVentas where tdet.IdVenta == id select tdet).ToList(); 
            return lst;
        }

        public IEnumerable<DetalleVenta> GetDetalleSeleccionado(int num1, int num2)
        {
            var obj = from det in conexion.DetalleVentas where det.Cantidad > num1 && det.Cantidad < num2 select det;
            return obj;
        }
        
    }
}
