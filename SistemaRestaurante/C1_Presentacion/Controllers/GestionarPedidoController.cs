using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using C3_Dominio.Entidades;
using C2_Aplicacion;

namespace C1_Presentacion.Controllers
{
    public class GestionarPedidoController : Controller
    {
        public ActionResult ListarProducto()
        {
            try {
                List<Producto> listaproducto = gestionarPedidoServices.Instancia.ListarPedido();
                return View(listaproducto);
            }
            catch (Exception e)
            {
                ViewBag.mensaje = e.Message;
                return View();
            }
        }

        public ActionResult VerPedido()
        {
            return View();
        }

    }
}
