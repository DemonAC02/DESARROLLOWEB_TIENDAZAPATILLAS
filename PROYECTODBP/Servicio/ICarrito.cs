using PROYECTODBP.Models;
namespace PROYECTODBP.Servicio
{
    public interface ICarrito
    {
        void add(TemporalCarrito temporalCarrito);
        IEnumerable<TemporalCarrito> getAllTempoSales();
        void remove(int id);
        void LimpiarCarrito();
    }
}
