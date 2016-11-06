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
    public class IntranetController : Controller
    {
        //
        // GET: /Intranet/
        [HttpGet]
        public ActionResult Principal(Int32 id)
        {
            List<Mesa> lista = gestionarMesaServices.Instancia.ListarMesa(id);
            return View(lista);
        }

    }
}
