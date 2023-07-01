using PROYECTODBP.Models;

namespace PROYECTODBP.Servicio
{
    public class CarritoRepository:ICarrito
    {
        private List<TemporalCarrito> lst = new List<TemporalCarrito>();
        public void add(TemporalCarrito temporalCarrito)
        {
            lst.Add(temporalCarrito);
        }

        public IEnumerable<TemporalCarrito> getAllTempoSales()
        {
            return lst;
        }

        public void LimpiarCarrito()
        {
            lst.Clear();
        }

        public void remove(int id)
        {
            var objEncontrado = (from tdis in lst
                                 where tdis.codigo == id
                                 select tdis).Single();
            lst.Remove(objEncontrado);
        }
    }
}
