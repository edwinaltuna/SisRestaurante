using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using C2_Aplicacion;
using C3_Dominio.Entidades;

namespace C1_Presentacion.Controllers
{
    public class ProductoController : Controller
    {
        //
        // GET: /Producto/

        gestionarProductoServices obj = new gestionarProductoServices();
        Producto data = new Producto();
        // GET: /Trabajador/
        public ActionResult Index()
        {
            List<Producto> listProducto = null;
            listProducto = obj.ListarProductos().ToList();
            return View(listProducto);
        }

        public ActionResult Registrar()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Registrar(FormCollection form)
        {
            data.id = Int32.Parse(form["id"].ToString());
            data.precio = Double.Parse(form["precio"].ToString());
            data.descripcion = form["descripcion"];
            data.fecha = DateTime.Parse(form["fecha"].ToString());
            data.imagen = form["imagen"];
            data.estado = Boolean.Parse(form["estado"].ToString());
            data.tipoProducto.id = Int32.Parse(form["idTipoProducto"].ToString());

            obj.RegistrarProducto(data);
            return RedirectToAction("Index", "TipoProducto");
        }

    }
}
//aa