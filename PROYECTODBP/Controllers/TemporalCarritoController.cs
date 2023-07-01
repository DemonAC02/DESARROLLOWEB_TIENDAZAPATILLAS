using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PROYECTODBP.Models;
using PROYECTODBP.Servicio;

namespace PROYECTODBP.Controllers
{
    public class TemporalCarritoController : Controller
    {
        private readonly ICarrito _temporalCarrito;
        public TemporalCarritoController(ICarrito temporalCarrito)
        {
            _temporalCarrito = temporalCarrito;
        }
        public IActionResult Index(string txtcodigo, string txtnombre, string txtprecio, string txtcantidad)
        {
            var objSession = HttpContext.Session.GetString("sUsuario");
            if (objSession != null)
            {
                var objv = JsonConvert.DeserializeObject<Cliente>(HttpContext.Session.GetString("sUsuario"));

                int codigo = int.Parse(txtcodigo);
                int cantidad = int.Parse(txtcantidad);

                // Verificar si el producto ya existe en el carrito temporal
                var existingProduct = _temporalCarrito.getAllTempoSales().FirstOrDefault(p => p.codigo == codigo);

                if (existingProduct != null)
                {
                    // El producto ya existe, sumar las cantidades
                    existingProduct.cantidad += cantidad;
                }
                else
                {
                    // El producto no existe, agregarlo al carrito
                    TemporalCarrito obj = new TemporalCarrito();
                    obj.codigo = codigo;
                    obj.descripcion = txtnombre;
                    obj.precio = double.Parse(txtprecio);
                    obj.cantidad = cantidad;
                    _temporalCarrito.add(obj);
                }

                return RedirectToAction("Index", "TiendaZapatillas");
            }
            else
            {
                return RedirectToAction("Inicio", "Usuario");
            }
        }

        public IActionResult VerCarrito()
        {
            var objSession = HttpContext.Session
                                        .GetString("sUsuario");
            if (objSession != null)
            {
                //Deserializar el objeto
                var obj1 = JsonConvert.DeserializeObject<Cliente>(HttpContext.Session.GetString("sUsuario"));
                return View(_temporalCarrito.getAllTempoSales());
            }
            else
            {
                return RedirectToAction("InicioSesion", "Usuario");
            }

        }
        public IActionResult EliminarProd(int id)
        {
            var objSession = HttpContext.Session
                                        .GetString("sUsuario");
            if (objSession != null)
            {
                //Deserializar el objeto
                var obj1 = JsonConvert.DeserializeObject<Cliente>(HttpContext.Session.GetString("sUsuario"));
                _temporalCarrito.remove(id);
                return RedirectToAction("VerCarrito", "TemporalCarrito");
            }
            else
            {
                return RedirectToAction("InicioSesion", "Usuario");
            }
        }
    }
}
