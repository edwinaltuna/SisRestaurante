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

    }
}
