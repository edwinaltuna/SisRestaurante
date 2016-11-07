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
        public ActionResult Principal(int id)
        {
            try { 
            List<Mesa> lista = gestionarMesaServices.Instancia.ListarMesa(id);
            return View(lista);
            }
            catch (Exception e)
            {
                ViewBag.mensaje = e.Message;
                return View();
            }
        }

        public ActionResult ValidarMesa(int id)
        {
            try
            {
                Mesa mesa = gestionarMesaServices.Instancia.ValidarMesa(id);
                Session["mesa"] = mesa;
                if (mesa.estado == false) {
                    return RedirectToAction("ListarProducto", "GestionarPedido");
                }
                else
                {
                    return RedirectToAction("VerPedido", "GestionarPedido", new { mesa.id });
                }
            }
            catch (Exception e)
            {
                ViewBag.mensaje = e.Message;
                return View();
            }
        }


    }
}
