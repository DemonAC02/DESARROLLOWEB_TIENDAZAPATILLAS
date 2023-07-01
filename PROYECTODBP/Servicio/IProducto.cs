using PROYECTODBP.Models;
namespace PROYECTODBP.Servicio
{
    public interface IProducto
    {
        IEnumerable<Tbproducto> GetAllProducts();
        IEnumerable<Tbproducto> GetAllProductsHombre();
        IEnumerable<Tbproducto> GetAllProductsMujer();
        Tbproducto GetProducto(int id);
        void ActualizarStock(int idProducto, int cantidad);

        void add(Tbproducto obj);
        void remove(int id);
        Tbproducto edit(int id);
        void editDetails(Tbproducto obj);
    }
}
