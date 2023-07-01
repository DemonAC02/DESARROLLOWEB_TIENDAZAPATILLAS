using PROYECTODBP.Models;

namespace PROYECTODBP.Servicio
{
    public interface IMarcas
    {
        IEnumerable<Marca> GetAllMarcas();

        void add(Marca obj);
        void remove(int id);
        Marca edit(int id);
        void editDetails(Marca obj);
    }
}
