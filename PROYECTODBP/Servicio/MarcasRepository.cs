using PROYECTODBP.Models;

namespace PROYECTODBP.Servicio
{
    public class MarcasRepository:IMarcas
    {
        private ZapatillasC conexion = new ZapatillasC();
        public IEnumerable<Marca> GetAllMarcas()
        {
            return conexion.Marcas;
        }
        public void add(Marca obj)
        {
            conexion.Marcas.Add(obj);
            conexion.SaveChanges();
        }
        public Marca edit(int id)
        {
            var objEncontrado = (from tdis in conexion.Marcas
                                 where tdis.IdMarca == id
                                 select tdis).Single();
            return objEncontrado;
        }
        public void editDetails(Marca obj)
        {
            var objAModificar = (from tdis in conexion.Marcas
                                 where tdis.IdMarca == obj.IdMarca
                                 select tdis).FirstOrDefault();
            if (objAModificar != null)
            {
                objAModificar.Descripcion = obj.Descripcion;

            }
            conexion.SaveChanges();
        }
        public void remove(int id)
        {
            var objEncontrado = (from tdis in conexion.Marcas
                                 where tdis.IdMarca == id
                                 select tdis).Single();
            conexion.Marcas.Remove(objEncontrado);
            conexion.SaveChanges();
        }
    }
}
