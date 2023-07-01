using PROYECTODBP.Models;

namespace PROYECTODBP.Servicio
{
    public interface IDetalle
    {
        IEnumerable<DetalleVenta> GetDetalleSeleccionado(int num1, int num2);
        IEnumerable<DetalleVenta> DetallasDeLaVenta(int id);

    }
}
