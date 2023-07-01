using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PROYECTODBP.Models;
using PROYECTODBP.Servicio;

namespace PROYECTODBP.Controllers
{
    public class UsuarioController : Controller
    {
            private readonly IUsuario _usuario;
            public UsuarioController(IUsuario usuario)
            {
                _usuario = usuario;
            }
            public IActionResult crudusu()
        { 
                //Deserializar el objeto
                return View(_usuario.GetAllUser());
            }
            
            
            public IActionResult EliminarUsu(int id)
            {
            
                _usuario.remove(id);
                return RedirectToAction("crudusu", "Usuario");
            }
            
            public IActionResult GrabarUsu(Cliente obj)
        { 
            
                _usuario.add(obj);
                return RedirectToAction("InicioSesion", "Usuario");
            
        }
            public IActionResult ModificarUsu(int id)
            {
           
                //Deserializar el objeto
                return View(_usuario.edit(id));
            }
           
        
            public IActionResult ModificarUsuario(Cliente obj)
            {
           
                //Deserializar el objeto
                _usuario.editDetails(obj);
                return RedirectToAction("crudusu", "Usuario");
            }
        
            public IActionResult NuevoUsu()
            {
                return View();
            }
        public IActionResult ValidarUsuario(Cliente obj)
        {
            if (obj.Correo == "admin" && obj.Clave=="admin")
            {
                return RedirectToAction("mantenimiento", "TiendaZapatillas");
            }
            if (_usuario.ValidateUser(obj))
            {
                HttpContext.Session.SetString("sUsuario", JsonConvert.SerializeObject(obj));
                HttpContext.Session.SetString("sUsuarioId", obj.IdCliente.ToString());

                return RedirectToAction("Index", "TiendaZapatillas");
            }
            else
            {
                return View("InicioSesion");
            }
        }

        public IActionResult CerrarSesion()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("InicioSesion", "Usuario");
        }
        public IActionResult InicioSesion()
        {
            return View();
        }

    }
}
