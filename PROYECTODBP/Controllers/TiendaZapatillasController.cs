
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PROYECTODBP.Models;
using PROYECTODBP.Servicio;

namespace DBPProyecto.Controllers
{
    public class TiendaZapatillasController : Controller
    {
        private readonly IProducto _producto;
        public TiendaZapatillasController(IProducto producto)
        {
            _producto = producto;
        }
        [Route("/")]
        public IActionResult Index()
        {
            var objSession = HttpContext.Session
                                        .GetString("sUsuario");
            if (objSession != null)
            {
                //Deserializar el objeto
                var obj1 = JsonConvert.DeserializeObject<Cliente>(HttpContext.Session.GetString("sUsuario"));
                return View();
            }
            else
            {
                return RedirectToAction("InicioSesion", "Usuario");
            }
        }
        [Route("/SobreNosotros")]
        public IActionResult SobreNosotros()
        {
            return View();
        }
        [Route("/PoliticaPrivacidad")]
        public IActionResult PoliticaPrivacidad()
        {
            return View();
        }
        [Route("/PoliticaDevoluciones")]
        public IActionResult PoliticaDevoluciones()
        {
            return View();
        }
        public IActionResult Mantenimiento()
        {

            //Deserializar el objeto

            return View();
        }

    }
}
