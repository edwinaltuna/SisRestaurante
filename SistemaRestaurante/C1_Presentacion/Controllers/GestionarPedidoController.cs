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

        public void CrearCarritoSession()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("idProducto", Type.GetType("System.Int32"));
            dt.Columns.Add("descripcion", Type.GetType("System.String"));
            dt.Columns.Add("cantidad", Type.GetType("System.Int32"));
            dt.Columns.Add("precio", Type.GetType("System.Decimal"));    
            Session["detalleVenta"] = dt;
        }

        public void CrearVentaCabecera()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("idMesa", Type.GetType("System.Int32"));
            dt.Columns.Add("idTrabajador", Type.GetType("System.Int32"));
            dt.Columns.Add("Total", Type.GetType("System.Decimal"));        
            Session["Venta"] = dt;
        }

        public ActionResult VerPedido()
        {
            if (Session["detalleventa"] == null) { CrearCarritoSession();}
            DataTable dt = (DataTable)Session["detalleVenta"];
            decimal total = 0;
            foreach (DataRow f in dt.Rows) { 
                
            }
            return View();
        }

        public ActionResult AgregarPedido(FormCollection frm)
        {
            return View();
        //    try
        //    {
        //        if (Convert.ToInt32(frm["txtCant"]) < 0)
        //        {
        //            ViewBag.mensajito = "Lo sentimos la cantidad debe ser mayor a cero";
        //            List<Producto> listaproducto = gestionarPedidoServices.Instancia.ListarPedido();
        //            return View("ListarProducto", listaproducto);
        //        }
        //        else {
        //            if (Session["detalleventa"] == null) { CrearCarritoSession(); }
        //            DataTable dt = (DataTable)Session["Venta"];
        //            Boolean Existe = false;
        //            foreach (DataRow f in dt.Rows)
        //            {
        //                Int32 cantidad = Convert.ToInt32(frm["txtCant"]);
        //                if (Convert.ToInt32(frm["txtidProducto"]) == Convert.ToInt32(f["idProducto"]))
        //                {
        //                    Existe = true;
        //                    f["cantidad"] = cantidad + Convert.ToInt32(f["cantidad"]);
        //                    dt.AcceptChanges();
        //                    break;
        //                }
        //            }
        //            Session["detalleventa"] = dt;
        //            if (!Existe)
        //            {
        //                DataRow r = dt.NewRow();
        //                r[""] = Convert.ToInt32(frm[""]);
        //                r[""] = Convert.ToInt32(frm[""]);
        //                r[""] = Convert.ToInt32(frm[""]);
        //                r[""] = Convert.ToInt32(frm[""]);
        //                r[""] = Convert.ToInt32(frm[""]);
        //                dt.Rows.Add(r);
        //                return RedirectToAction("VerPedido");
        //            }
        //            else { return RedirectToAction("VerPedido"); }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        }

    }
}
