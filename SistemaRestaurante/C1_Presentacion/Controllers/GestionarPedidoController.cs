using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace C1_Presentacion.Controllers
{
    public class GestionarPedidoController : Controller
    {
        //
        // GET: /GestionarPedido/

        public ActionResult ListarProducto()
        {
            return View();
        }

        public ActionResult VerPedido()
        {
            return View();
        }

    }
}
