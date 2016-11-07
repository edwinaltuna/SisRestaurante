using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using C3_Dominio.Entidades;
using C2_Aplicacion;

namespace C1_Presentacion.Controllers
{
    public class GestionarVentaController : Controller
    {
        //
        // GET: /GestionarVenta/

        public ActionResult Listar()
        {
            List<Venta> listaVentas = gestionarVentaServices.Instancia.Listar();
            return View(listaVentas);
        }

        [HttpGet]
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CambiarEstado(int[] data)
        {
            bool cambio = gestionarVentaServices.Instancia.CambiarEstadoVenta(data[0], data[1]== 0 ? 1 : 0);
            List<int> parametros = new List<int>();
            parametros.Add(data[0]);
            parametros.Add(data[1] == 0 ? 1 : 0);
            return PartialView("_CambiarEstado",parametros);
        }

        [HttpPost]
        public ActionResult MostrarPedidosVenta(string[] data)
        {
            return PartialView("_DetalleVenta",data);
        }

    }
}
