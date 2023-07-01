using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PROYECTODBP.Models;
using PROYECTODBP.Servicio;

namespace PROYECTODBP.Controllers
{
    public class ProductosController : Controller
    {
        private readonly IProducto _producto;
        public ProductosController(IProducto producto)
        {
            _producto = producto;
        }


        public IActionResult Hombres()
        {
            var objSession = HttpContext.Session
                                        .GetString("sUsuario");
            if (objSession != null)
            {
                //Deserializar el objeto
                var obj = JsonConvert.DeserializeObject<Cliente>(HttpContext.Session.GetString("sUsuario"));
                return View(_producto.GetAllProductsHombre());
            }
            else
            {
                return RedirectToAction("InicioSesion","Usuario");
            }
        }
        public IActionResult Mujeres()
        {
            var objSession = HttpContext.Session
                                        .GetString("sUsuario");
            if (objSession != null)
            {
                //Deserializar el objeto
                var obj = JsonConvert.DeserializeObject<Cliente>(HttpContext.Session.GetString("sUsuario"));
                return View(_producto.GetAllProductsMujer());
            }
            else
            {
                return RedirectToAction("InicioSesion", "Usuario");
            }

        }
        [Route("Productos/Detalles/{codigo}")]
        public IActionResult Detalles(int codigo)

        {
            var objSession = HttpContext.Session
                                        .GetString("sUsuario");
            if (objSession != null)
            {
                //Deserializar el objeto
                var obj = JsonConvert.DeserializeObject<Cliente>(HttpContext.Session.GetString("sUsuario"));
                return View(_producto.GetProducto(codigo));
            }
            else
            {
                return RedirectToAction("InicioSesion", "Usuario");
            }

        }

        public IActionResult crudpro()
        {
           
                //Deserializar el objeto
                return View(_producto.GetAllProducts());
            
            

        }
        [Route("Distrito/Eliminar/{id}")]
        public IActionResult EliminarPro(int id)
        {
                _producto.remove(id);
                return RedirectToAction("crudpro", "Productos");
            
            

        }
        public IActionResult GrabarPro(Tbproducto obj)
        {
            
                _producto.add(obj);
                return RedirectToAction("crudpro", "Productos");


        }
        public IActionResult ModificarPro(int id)
        {
                return View(_producto.edit(id));
            }
            
        public IActionResult ModificarProducto(Tbproducto obj)
        {
                _producto.editDetails(obj);
                return RedirectToAction("crudpro", "Productos");
            }
           
        
        public IActionResult NuevoPro()
        {

            return View();
        }
            
    }
}
