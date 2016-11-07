using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using C3_Dominio.Entidades;
using C2_Aplicacion;

namespace C1_Presentacion.Controllers
{
    public class ReportesController : Controller
    {

        [HttpGet]
        public ActionResult ReportesdeVenta()
        {
            return View();
        }
        public ActionResult ReporteProducto()
        {
            return View();
        }

        public ActionResult Data()
        {
            IList<Producto> listaProductos = new List<Producto>();
            listaProductos = gestionarReporteServices.Instancia.reporteDeProductos();
            return Json(listaProductos, JsonRequestBehavior.AllowGet);
        }
    }
}
