using Microsoft.AspNetCore.Mvc;
using PROYECTODBP.Servicio;

namespace PROYECTODBP.Controllers
{
    public class DetalleVentaController : Controller
    {
        private readonly IDetalle _detalle;
        public DetalleVentaController(IDetalle detalle)
        {
            _detalle = detalle;
        }
        public IActionResult DetalleVenta()
        {
            return View();
        }
        public IActionResult VerDetalles(int can1, int can2)
        {
            return View(_detalle.GetDetalleSeleccionado(can1,can2));
        }
        public IActionResult VistaDetalles(int id)
        {
            return View(_detalle.DetallasDeLaVenta(id));
        }

    }
}
