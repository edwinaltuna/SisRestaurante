using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using C2_Aplicacion;
using C3_Dominio.Entidades;

namespace C1_Presentacion.Controllers
{
    public class TipoProductoController : Controller
    {
        //
        // GET: /TipoTrabajador/
        gestionarTipoProductoServices obj = new gestionarTipoProductoServices();
        TipoProducto data = new TipoProducto();
        // GET: /Trabajador/
        public ActionResult Index()
        {
            List<TipoProducto> listTipoProducto = null;
            listTipoProducto = obj.ListarTipoProductos().ToList();
            return View(listTipoProducto);
        }

        [HttpGet]
        public ActionResult Registrar()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Registrar(FormCollection form)
        {
            data.id = Int32.Parse(form["id"].ToString());
            data.descripcion = form["descripcion"];
            data.estado = Boolean.Parse(form["estado"].ToString());
            obj.RegistrarTipoTrabajador(data);
            return RedirectToAction("Index", "TipoProducto");
        }


        public ActionResult Detalles(Int16 id)
        {
            TipoProducto t = gestionarTipoProductoServices.Instancia.ListarTipoProductoPorId(id);
            return View(t);
        }
    }
}
