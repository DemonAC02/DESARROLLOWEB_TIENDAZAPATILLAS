using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PROYECTODBP.Models;
using PROYECTODBP.Servicio;

namespace PROYECTODBP.Controllers
{
    public class MarcasController : Controller
    {
        private readonly IMarcas _marcas;
        public MarcasController(IMarcas marcas)
        {
            _marcas = marcas;
        }
        [Route("/Marcas")]
        public IActionResult Index()
        {
            var objSession = HttpContext.Session
                                        .GetString("sUsuario");
            if (objSession != null)
            {
                //Deserializar el objeto
                var obj1 = JsonConvert.DeserializeObject<Cliente>(HttpContext.Session.GetString("sUsuario"));
                return View(_marcas.GetAllMarcas());
            }
            else
            {
                return RedirectToAction("InicioSesion", "Usuario");
            }
        }
        public IActionResult crudmar()
        {
            
                return View(_marcas.GetAllMarcas());
          
        }
        [Route("Marcas/Eliminar/{id}")]
        public IActionResult EliminarMar(int id)
        {
            
                _marcas.remove(id);
                return RedirectToAction("crudmar", "Marcas");
           
        }
        public IActionResult GrabarMarc(Marca obj)
        {
            
                _marcas.add(obj);
                return RedirectToAction("crudmar", "Marcas");
   

        }
        public IActionResult ModificarMar(int id)
        {
         
                //Deserializar el objeto
                return View(_marcas.edit(id));
            
           
        }
        public IActionResult ModificarMarca(Marca obj)
        {
            
                _marcas.editDetails(obj);
                return RedirectToAction("crudmar", "Marcas");
           

        }
        public IActionResult NuevoMar()
        {
            
                return View();
           
            
        }
    }
}
