using PROYECTODBP.Models;

namespace PROYECTODBP.Servicio
{
    public interface IUsuario
    {
        IEnumerable<Cliente> GetAllUser();

        void add(Cliente obj);
        void remove(int id);
        Cliente edit(int id);
        void editDetails(Cliente obj);
        bool ValidateUser(Cliente usuario);
    }
}
