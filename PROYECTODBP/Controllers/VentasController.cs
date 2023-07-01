using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PROYECTODBP.Models;
using PROYECTODBP.Servicio;

namespace PROYECTODBP.Controllers
{
    public class VentasController : Controller
    {
        private readonly ICarrito _temporalCarrito;
        private readonly IVenta _venta;
        private readonly IProducto _producto;

        public VentasController(ICarrito temporalCarrito, IVenta venta, IProducto producto)
        {
            _temporalCarrito = temporalCarrito;
            _venta = venta;
            _producto = producto;
        }


        public IActionResult ResumenVenta()
        {
            var objSession = HttpContext.Session.GetString("sUsuario");

            if (objSession != null)
            {
                var obj = JsonConvert.DeserializeObject<Cliente>(HttpContext.Session.GetString("sUsuario"));
                ViewBag.idCli = obj.getIdCliente();
                var carritos = _temporalCarrito.getAllTempoSales();
                double total = 0;

                foreach (var item in carritos)
                {
                    double precioTotalProducto = item.precio * item.cantidad;
                    total += precioTotalProducto;
                }

                var resumenViewModel = new ResumenVenta
                {
                    Carrito = carritos,
                    Total = total
                };



                return View(resumenViewModel);
            }
            else
            {
                return RedirectToAction("InicioSesion", "Usuario");
            }
        }

        [HttpPost]
        public IActionResult Confirmar(string txtdireccion, string txttelefono, string txtidcliente, string txttotal)
        {
            var objSession = HttpContext.Session
                                        .GetString("sUsuario");
            if (objSession != null)
            {
                //Deserializar el objeto
                var obj = JsonConvert.DeserializeObject<Cliente>(HttpContext.Session.GetString("sUsuario"));
                Venta vens = new Venta();

                vens.IdCliente = int.Parse(txtidcliente);
                vens.MontoTotal = (decimal?)double.Parse(txttotal);
                vens.Direccion = txtdireccion;
                vens.Telefono = txttelefono;
                _venta.GuardarVenta(vens);
                foreach (var item in _temporalCarrito.getAllTempoSales())
                {
                    var detalleVenta = new DetalleVenta
                    {
                        IdVenta = vens.IdVenta,
                        IdProducto = item.codigo,
                        Cantidad = item.cantidad,
                        Total = (decimal?)(item.precio * item.cantidad)
                    };
                    _producto.ActualizarStock(item.codigo, item.cantidad);
                    _venta.GuardarDetalleVenta(detalleVenta);
                }
                _temporalCarrito.LimpiarCarrito();
                return RedirectToAction("Index", "TiendaZapatillas");
            }
            else
            {
                return RedirectToAction("InicioSesion", "Usuario");
            }
        }
        public IActionResult ComprasUsu()
        {
            var objSession = HttpContext.Session.GetString("sUsuario");

            if (objSession != null)
            {
                var obj = JsonConvert.DeserializeObject<Cliente>(HttpContext.Session.GetString("sUsuario"));
                int IdPro = obj.getIdCliente();
                return View(_venta.BuscarVentasPorUsuario(IdPro));


            }
            else
            {
                return RedirectToAction("InicioSesion", "Usuario");
            }
        }
    }
}
