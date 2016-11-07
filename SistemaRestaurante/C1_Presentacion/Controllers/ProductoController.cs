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
            data.precio = float.Parse(form["precio"].ToString());
            data.descripcion = form["descripcion"];
            data.fecha = DateTime.Parse(form["fecha"].ToString());
            data.imagen = form["imagen"];
            data.estado = Boolean.Parse(form["estado"].ToString());
            data.tipoProducto.id = Int32.Parse(form["idTipoProducto"].ToString());

            obj.RegistrarProducto(data);
            return RedirectToAction("Index", "TipoProducto");
        }

        public ActionResult Details(int id)
        {
            return View(obj.DetallesPlato(id));
        }

        public ActionResult Edit(int id)
        {
            return View(obj.DetallesPlato(id));
        }

        // POST: Estudiante/Edit/5
        [HttpPost]
        public ActionResult Edit(Producto collection)
        {
            try
            {
                // TODO: Add update logic here
                Producto objPlato = new Producto();
                obj.Update(collection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Estudiante/Delete/5
        public ActionResult Delete(int id)
        {
            return View(obj.DetallesPlato(id));
        }

        // POST: Estudiante/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                obj.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
//aa