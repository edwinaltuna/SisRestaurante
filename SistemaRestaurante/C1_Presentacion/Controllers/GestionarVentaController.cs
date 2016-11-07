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
        public ActionResult CambiarEstado(int id)
        {
            return PartialView("_CambiarEstado",id);
        }

    }
}
