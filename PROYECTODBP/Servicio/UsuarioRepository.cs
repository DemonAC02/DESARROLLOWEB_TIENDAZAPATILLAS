using PROYECTODBP.Models;

namespace PROYECTODBP.Servicio
{
    public class UsuarioRepository:IUsuario
    {
        private ZapatillasC conexion = new ZapatillasC();

        public void add(Cliente obj)
        {
            conexion.Clientes.Add(obj);
            conexion.SaveChanges();
        }

        public Cliente edit(int id)
        {
            var objEncontrado = (from tdis in conexion.Clientes
                                 where tdis.IdCliente == id
                                 select tdis).Single();
            return objEncontrado;
        }

        public void editDetails(Cliente obj)
        {
            var objAModificar = (from tdis in conexion.Clientes
                                 where tdis.IdCliente == obj.IdCliente
                                 select tdis).FirstOrDefault();
            if (objAModificar != null)
            {
                objAModificar.Nombre = obj.Nombre;
                objAModificar.Apellidos = obj.Apellidos;
                objAModificar.Correo = obj.Correo;
                objAModificar.Clave = obj.Clave;

            }
            conexion.SaveChanges();
        }

        public IEnumerable<Cliente> GetAllUser()
        {
            return conexion.Clientes;
        }

        public void remove(int id)
        {
            var objEncontrado = (from tdis in conexion.Clientes
                                 where tdis.IdCliente == id
                                 select tdis).Single();
            conexion.Clientes.Remove(objEncontrado);
            conexion.SaveChanges();
        }

        public bool ValidateUser(Cliente usuario)
        {
            var obj = (from tusu in conexion.Clientes
                       where tusu.Correo == usuario.Correo
                       && tusu.Clave == usuario.Clave
                       select tusu).FirstOrDefault();
            if (obj == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
