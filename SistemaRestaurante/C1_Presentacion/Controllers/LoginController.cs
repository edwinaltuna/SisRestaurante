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
        public ActionResult Login(String mensaje)
        {
            ViewBag.mensaje = mensaje;
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection frm)
        {
            try
            {
                String usuario = frm["txtusuario"].ToString();
                String pass = frm["txtpassword"].ToString();
                Trabajador trabajador = null;
                gestionarTrabajadorServices gestionartrabajadorservicios = new gestionarTrabajadorServices();
                if (usuario != "")
                {
                    if (pass!= "")
                    {
                        trabajador = gestionartrabajadorservicios.IniciarSession(usuario, pass);
                        if (trabajador != null)
                        {
                            Session["trabajador"] = trabajador;
                            return RedirectToAction("Principal", "Intranet");
                        }
                        else { return RedirectToAction("Login", new { mensaje = "Usuario o contraseña no validos" }); }
                    }
                    else { return RedirectToAction("Login", new { mensaje = "Debe Ingresar una Contraseña" }); }
                }
                else { return RedirectToAction("Login", new { mensaje = "Debe Ingresar un Usuario" }); }
            }
            catch (Exception e) { throw e; }
        }
    }
}
