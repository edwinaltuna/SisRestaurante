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
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        [HttpGet]
        public ActionResult Login(string mensaje)
        {
            ViewBag.mensaje = mensaje;
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection frm)
        {
            try
            {
                string usuario = frm["txtusuario"].ToString();
                string pass = frm["txtpassword"].ToString();
                Trabajador trabajador = null;
                gestionarTrabajadorServices gestionartrabajadorservicios = new gestionarTrabajadorServices();

                trabajador = gestionartrabajadorservicios.IniciarSession(usuario, pass);
                Session["Trabajador"] = trabajador;
                return RedirectToAction("Principal", "Intranet");

            }
            catch (Exception e)
            {
                ViewBag.mensaje = e.Message;
                return View();
            }
        }
    }
}
